using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace BROWSERS;

[Binding]
public class SpecFlowWebDriverTest : BaseTest
{
    private readonly IObjectContainer _objectContainer;

    public SpecFlowWebDriverTest(IObjectContainer objectContainer)
    {
        _objectContainer = objectContainer;
    }
    
    
    [BeforeScenario]
    public void SetUp()
    {
        Driver = new ChromeDriver();
        _objectContainer.RegisterInstanceAs<IWebDriver>(Driver);
    }

    [Given(@"Chrome is started")]
    public void GivenChromeIsStarted()
    {
        _objectContainer.Resolve<IWebDriver>().Navigate().GoToUrl("http://onliner.by");
        Assert.That(_objectContainer.Resolve<IWebDriver>()?.Title, Is.EqualTo("Onlíner"));
    }

    [AfterScenario()]
    public void TearDown()
    {
        _objectContainer.Resolve<IWebDriver>()?.Quit();
    }
}   