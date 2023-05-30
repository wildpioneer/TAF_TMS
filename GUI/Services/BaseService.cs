using GUI.Clients;

namespace GUI.Services;

public class BaseService
{
    protected ApiClient _apiClient;

    public BaseService(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }
}