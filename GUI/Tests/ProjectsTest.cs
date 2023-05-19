using GUI.Models;
using GUI.Steps;
using GUI.Utilites.Configuration;
using GUI.Utilites.Helpers;

namespace GUI.Tests;

public class ProjectsTest : BaseTest
{
    [Test]
    public void CreateProjectTest()
    {
        Project testProject = TestDataHelper.GetTestProject("GeneralProject.json");
        NavigationSteps.NavigateToLoginPage();
        NavigationSteps.SuccessfulLogin(Configurator.Admin);
        ProjectSteps.NavigateToAddProjectPage();
    }
}