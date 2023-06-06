using GUI.Core;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.Steps;

[Binding]
public class SimpleSteps
{
    [Given(@"открыт браузер")]
    public void OpenBrowser()
    {
        
    }

    [When(@"страца логина открыта")]
    [Given(@"страца логина открыта")]
    public void OpenLoginPage()
    {
        
    }

    [Then(@"поле username отображается")]
    public void IsUsernameDisplayed()
    {
        
    }

    
    [Then(@"поле password отображается")]
    public void IsPasswordDisplayed()
    {
        
    }

    [Then(@"ошибка не оботражается")]
    public void IsErrorDisplayed()
    {
        
    }
}