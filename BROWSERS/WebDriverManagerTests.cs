using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace BROWSERS;

public class WebDriverManagerTests : BaseTest
{
    [OneTimeSetUp]
    public void SetUp()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
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