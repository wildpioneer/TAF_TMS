using GUI.Core;
using GUI.Steps;
using OpenQA.Selenium;

namespace GUI;

public class BaseTest
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    protected IWebDriver Driver { get; set; }

    protected NavigationSteps NavigationSteps;
    
    [SetUp]
    public void Setup()
    {
        logger.Info("Starting IWebDriver...");
        Driver = new Browser().Driver;
        
        NavigationSteps = new NavigationSteps(Driver);
    }

    [TearDown]
    public void TearDown()
    {
        logger.Info("Closing IWebDriver...");
        Driver.Quit();
        Driver.Dispose();
    }
}