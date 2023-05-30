using GUI.Clients;
using GUI.Models;
using RestSharp;

namespace GUI.Services;

public class ProjectService : BaseService
{
    public ProjectService(ApiClient apiClient) : base(apiClient)
    {
    }

    public Task<Project> GetProject(string projectId)
    {
        var request = new RestRequest("index.php?/api/v2/get_project/{project_id}")
            .AddUrlSegment("project_id", projectId);
        
        return _apiClient.ExecuteAsync<Project>(request);
    }
}