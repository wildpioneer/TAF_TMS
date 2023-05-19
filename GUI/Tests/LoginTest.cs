using GUI.Utilites.Configuration;

namespace GUI.Tests;

public class LoginTest : BaseTest
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();

    [Test]
    public void SuccessLoginTest()
    {
        NavigationSteps.NavigateToLoginPage();
        NavigationSteps.SuccessfulLogin(Configurator.Admin);
        
        Assert.IsTrue(NavigationSteps.DashboardPage.IsPageOpened());
    }
}