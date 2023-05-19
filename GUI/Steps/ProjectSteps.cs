using GUI.Models;
using GUI.Pages;
using OpenQA.Selenium;

namespace GUI.Steps;

public class ProjectSteps : BaseStep
{
    public ProjectSteps(IWebDriver driver) : base(driver)
    {
    }

    public void NavigateToAddProjectPage()
    {
        new AddProjectPage(Driver, true);
    }
    
    public void CreateProject(Project project)
    {
        
    }
}