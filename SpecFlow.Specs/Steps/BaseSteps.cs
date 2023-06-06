using GUI.Core;
using GUI.Steps;
using OpenQA.Selenium;

namespace SpecFlow.Specs.Steps;

public class BaseSteps
{
    protected IWebDriver Driver;
    protected NavigationSteps _navigationSteps;

    public BaseSteps(Browser browser)
    {
        Driver = browser.Driver;
        _navigationSteps = new NavigationSteps(Driver);
    }
}