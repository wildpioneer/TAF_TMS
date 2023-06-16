using GUI.Core;
using GUI.Pages;
using GUI.Steps;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.Steps;

[Binding]
public class SecondSteps
{
    private Browser? _browser;
    private NavigationSteps? _navigationSteps;
    private DashboardPage? _dashboardPage;
    
    private readonly ScenarioContext _scenarioContext;

    public SecondSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"browser is opened")]
    public void BrowserIsOpened()
    {
        _browser = new Browser();        
    }

    [Given(@"the login page is opened")]
    public void TheLoginPageIsOpened()
    {
        _navigationSteps = new NavigationSteps(_browser?.Driver);
        _navigationSteps.NavigateToLoginPage();
    }

    [When(@"user ""(.*)"" with password ""(.*)"" logged in")]
    [Given(@"user ""(.*)"" with password ""(.*)"" logged in")]
    public void UserWithPasswordLoggedIn(string username, string password)
    {
        _dashboardPage = _navigationSteps?.SuccessfulLogin(username, password);
    }
    
    [Then(@"title is ""(.*)""")]
    public void TitleIs(string expectedValue)
    {
        Assert.That(_browser.Driver.Title, Is.EqualTo(expectedValue));
    }
        
    [Then(@"project id is (.*)")]
    public void ThenProjectIdIs(int expectedValue)
    {
        Assert.Contains(expectedValue.ToString(), _dashboardPage.GetProjectIDsFromTable());
    }

    [After()]
    public void TearDown()
    {
        _browser?.Driver.Quit();
    }
}