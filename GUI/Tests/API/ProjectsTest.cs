using GUI.Models;
using GUI.Services;
using RestSharp;

namespace GUI.Tests.API;

public class ProjectsTest : BaseApiTest
{
    [Test]
    public void GetProjectTest()
    {
        var request = new RestRequest("index.php?/api/v2/get_project/{project_id}")
            .AddUrlSegment("project_id", "1");
        var project = _apiClient.Execute(request);
        Console.Out.WriteLine(project.Content.Normalize());
    }

    [Test]
    public void GetProjectTest2()
    {
        var request = new RestRequest("index.php?/api/v2/get_project/{project_id}")
            .AddUrlSegment("project_id", "1");
        var project = _apiClient.ExecuteAsync<Project>(request);
        Console.Out.WriteLine(project.Result.Name);
    }

    [Test]
    public void GetProjectTest_1()
    {
        var project = _projectService.GetProject("1");
        Console.Out.WriteLine(project.Result.Name);
    }

}