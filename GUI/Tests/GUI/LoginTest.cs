using Allure.Commons;
using GUI.Utilites.Configuration;
using NUnit.Allure.Attributes;

namespace GUI.Tests.GUI;

public class LoginTest : BaseTest
{
    [Test(Description = "Успешный логин")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("User")]
    [AllureSuite("PassedSuite")]
    [AllureSubSuite("GUI")]
    [AllureIssue("TMS-12")]
    [AllureTms("TMS-13")]
    [AllureTag("Smoke")]
    [AllureLink("https://onliner.by")]
    [Description("Более детализированное описание теста")]
    [SmokeTest]
    public void SuccessLoginTest()
    {
        NavigationSteps.NavigateToLoginPage();
        NavigationSteps.SuccessfulLogin(Configurator.Admin);
        
        Assert.IsTrue(NavigationSteps.DashboardPage.IsPageOpened());
    }
}