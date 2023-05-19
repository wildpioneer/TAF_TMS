namespace GUI.Tests;

public class Tests : BaseTest
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();


    [Test]
    public void Test1()
    {
        logger.Info("UnitTest is passed...");
        Assert.Pass();
    }
}