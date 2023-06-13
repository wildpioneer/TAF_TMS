using GUI.Core;
using GUI.Steps;
using TechTalk.SpecFlow;

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
        Console.WriteLine("Start Browser");
        var navigationStep = new NavigationSteps(_browser.Driver);
        navigationStep.NavigateToLoginPage();
    }

    [AfterScenario("GUI")]
    public void AfterScenario()
    {
        _browser.Driver.Quit();
    }
}