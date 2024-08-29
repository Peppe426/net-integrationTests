using Base;

namespace IntegrationTests.Base;

public class BaseTest
{
    [SetUp]
    public void BeforeEachTest()
    {
        LocalMachine.IsTrue();
    }

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
    }

    [OneTimeTearDown]
    public void OneTimeTeardown()
    {
    }   
}
