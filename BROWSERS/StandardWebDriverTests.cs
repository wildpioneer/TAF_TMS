using OpenQA.Selenium.Chrome;

namespace BROWSERS;

public class StandardWebDriverTests : BaseTest
{
    [OneTimeSetUp]
    public void SetUp()
    {
        Driver = new ChromeDriver();
    }

    [Test]
    public void InitTest()
    {
        Driver?.Navigate().GoToUrl("http://onliner.by");
        Assert.That(Driver?.Title, Is.EqualTo("Onlíner"));
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        Driver?.Quit();
    }
}