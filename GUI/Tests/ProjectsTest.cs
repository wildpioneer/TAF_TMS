using GUI.Utilites.Configuration;
using GUI.Utilites.Helpers;

namespace GUI.Tests;

public class ProjectsTest : BaseTest
{
    [Test]
    [Regression]
    public void CreateProjectTest()
    {
        var testProject = TestDataHelper.GetTestProject("GeneralProject.json");
        
        NavigationSteps.NavigateToLoginPage();
        NavigationSteps.SuccessfulLogin(Configurator.Admin);
        ProjectSteps.NavigateToAddProjectPage();
    }
}