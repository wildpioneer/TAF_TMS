using GUI.Pages;
using OpenQA.Selenium;

namespace GUI.Steps;

public class BaseStep
{
    protected IWebDriver Driver { get; set; }

    public LoginPage LoginPage => new LoginPage(Driver);
    public DashboardPage DashboardPage => new DashboardPage(Driver);

    public BaseStep(IWebDriver driver)
    {
        Driver = driver;
    }
}