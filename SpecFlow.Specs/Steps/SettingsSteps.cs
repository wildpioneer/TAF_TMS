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
        Driver.Navigate().GoToUrl(GUI.Utilites.Configuration.Configurator.AppSettings.URL + 
                                  "index.php?/admin/site_settings");
        Assert.That(Driver.Title, Is.EqualTo("Site Settings - TestRail"));
    }

}