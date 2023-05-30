using GUI.Clients;
using GUI.Services;

namespace GUI.Tests.API;

public class BaseApiTest
{
    protected ApiClient _apiClient;
    protected ProjectService _projectService;

    [OneTimeSetUp]
    public void InitApiClient()
    {
        _apiClient = new ApiClient();
        _projectService = new ProjectService(_apiClient);
    }
}