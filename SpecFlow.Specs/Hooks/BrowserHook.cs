using GUI.Core;
using GUI.Steps;
using NUnit.Framework;
using TechTalk.SpecFlow;
[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace SpecFlow.Specs.Hooks;

[Binding]
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