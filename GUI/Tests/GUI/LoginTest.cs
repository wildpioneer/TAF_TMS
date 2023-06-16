using Allure.Commons;
using GUI.Utilites.Configuration;

namespace GUI.Tests.GUI;

public class LoginTest : BaseTest
{
    [Test(Description = "Успешный логин")]
    [Description("Более детализированное описание теста")]
    [SmokeTest]
    public void SuccessLoginTest()
    {
        NavigationSteps.NavigateToLoginPage();
        NavigationSteps.SuccessfulLogin(Configurator.Admin);
        
        Assert.IsTrue(NavigationSteps.DashboardPage.IsPageOpened());
    }
}