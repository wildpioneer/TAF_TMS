namespace GUI;

public class Tests
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();

    [SetUp]
    public void Setup()
    {
        logger.Trace("Test");
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}