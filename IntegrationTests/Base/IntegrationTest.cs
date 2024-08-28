using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.Base;

/// <summary>
/// Initializes a new instance of the <see cref="IntegrationTest{TEntryPoint, TContext}"/> class.
/// </summary>
/// <remarks>
/// You can pass a DbContext if needed, or use <see cref="DbContext"/> as null if no context is required, as demonstrated in the <see cref="EndpointTests"/> class.
/// </remarks>
[TestFixture]
[Category("Integration Test")]
[Parallelizable(ParallelScope.Self)]
public abstract class IntegrationTest<TEntryPoint, TContext> : BaseTest
    where TEntryPoint : class
    where TContext : DbContext?
{
    private WebHostFactory<TEntryPoint, TContext> _webHostFactory = new WebHostFactory<TEntryPoint, TContext>();
    public HttpClient Client { get; private set; } = null!;
    public TContext DbContext => _webHostFactory.Context;

    [SetUp]
    public void BeforeEachTest()
    {
        base.BeforeEachTest();
        Client = _webHostFactory.CreateClient();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _webHostFactory.Dispose();
    }

    [TearDown]
    public void Teardown()
    {
        Client.Dispose(); // Dispose HttpClient
    }

    /// <summary>
    /// Resolves a service of type <typeparamref name="T"/> from the web host's service provider.
    /// </summary>
    /// <typeparam name="T">The type of service to resolve.</typeparam>
    /// <returns>The resolved service of type <typeparamref name="T"/>.</returns>
    public T? ResolveService<T>() where T : notnull
    {
        return _webHostFactory.ResolveService<T>();
    }
}