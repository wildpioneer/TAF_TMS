using Allure.Commons;
using GUI.Core;
using GUI.Steps;
using NUnit.Allure.Core;
using OpenQA.Selenium;

namespace GUI.Tests;

[AllureNUnit]
[Parallelizable(ParallelScope.All)]
public class BaseTest
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    
    protected IWebDriver Driver;
    private AllureLifecycle _allure;

    protected NavigationSteps NavigationSteps;
    protected ProjectSteps ProjectSteps;
    
    [SetUp]
    public void Setup()
    {
        logger.Info("Starting IWebDriver...");
        Driver = new Browser().Driver;
        
        // Инициализация AllureLifecycle
        _allure = AllureLifecycle.Instance;
        
        // Инициализация Steps
        NavigationSteps = new NavigationSteps(Driver);
        ProjectSteps = new ProjectSteps(Driver);
    }

    [TearDown]
    public void TearDown()
    {
        logger.Info("Closing IWebDriver...");
        
        // Проверка, был ли тест сброшен
        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            // Создание скриншота
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            byte[] screenshotBytes = screenshot.AsByteArray;

            // Прикрепление скриншота к отчету Allure
            _allure.AddAttachment("Screenshot", "image/png", screenshotBytes);
        }
        
        Driver.Quit();
        Driver.Dispose();
    }
}