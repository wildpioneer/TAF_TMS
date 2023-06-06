using GUI.Steps;
using SpecFlow.Actions.Selenium;
using TechTalk.SpecFlow;
using Browser = GUI.Core.Browser;

namespace SpecFlow.Specs.Hooks;

public class BrowserHook
{
    private readonly Browser _browser;

    public BrowserHook(Browser browser)
    {
        _browser = browser;
    }

    ///<summary>
    ///  Start Browser 
    /// </summary>
    [BeforeScenario("GUI")]
    public void BeforeScenario()
    {
        var navigationStep = new NavigationSteps(_browser.Driver);
        navigationStep.NavigateToLoginPage();
    }

    [AfterScenario("GUI")]
    public void AfterScenario()
    {
        _browser.Driver.Quit();
    }
}