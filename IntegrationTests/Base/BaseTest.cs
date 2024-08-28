namespace IntegrationTests.Base;

public class BaseTest
{
    [SetUp]
    public void BeforeEachTest()
    {
        AssureLocalMachine();
    }

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
    }

    [OneTimeTearDown]
    public void OneTimeTeardown()
    {
    }

    private void AssureLocalMachine()
    {
        bool isDebugMode = System.Diagnostics.Debugger.IsAttached;

        IEnumerable<object> categories = TestContext.CurrentContext.Test.Properties["Category"];
        bool isLocalOnlyTest = categories.Any(cat => cat.ToString() == "LocalOnlyTest");

        if (isLocalOnlyTest && !isDebugMode)
        {
            Assert.Ignore("Skipping local-only test on non-local machine.");
        }
    }
}
