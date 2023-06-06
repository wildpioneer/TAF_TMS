using GUI.Core;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.Steps;

[Binding]
public class SettingsSteps : BaseSteps
{
    public SettingsSteps(Browser browser) : base(browser)
    {
    }

    [Then(@"settings page is opened")]
    public void IsSettingsPageOpened()
    {
        Driver.Navigate().GoToUrl("https://aqac01onl01.testrail.io/index.php?/admin/site_settings");
        Assert.AreEqual("Site Settings - TestRail", Driver.Title);
    }

}