using GUI.Utilites.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace GUI.Clients;

public class ApiClient
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    
    private readonly RestClient _restClient;

    public ApiClient()
    {
        var options = new RestClientOptions(Configurator.AppSettings.URL)
        {
            Authenticator = new HttpBasicAuthenticator(Configurator.Admin.Username, Configurator.Admin.Password),
            ThrowOnAnyError = true,
            MaxTimeout = 10000
        }; 
        _restClient = new RestClient(options);
    }

    public T Execute<T>(RestRequest request) where T : new()
    {
        logger.Info("Request: " + request.Resource);
        var response = _restClient.Execute<T>(request);
        
        logger.Info("Response Status: " + response.ResponseStatus);
        logger.Info("Response Body: " + response.Content);
        
        return response.Data;
    }

    public RestResponse Execute(RestRequest request)
    {
        logger.Info("Request: " + request.Resource);
        var response = _restClient.Execute(request);
        
        logger.Info("Response Status: " + response.StatusCode);
        logger.Info("Response Body: " + response.Content);
        
        return response;
    }

    public async Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
    {
        logger.Info("Request: " + request.Resource);
        var response = await _restClient.ExecuteAsync<T>(request);
        
        logger.Info("Response Status: " + response.StatusCode);
        logger.Info("Response Body: " + response.Content);
        
        return response.Data;
    }

    public async Task<RestResponse> ExecuteAsync(RestRequest request)
    {
        logger.Info("Request: " + request.Resource);
        var response = await _restClient.ExecuteAsync(request);
        
        logger.Info("Response Status: " + response.ResponseStatus);
        logger.Info("Response Body: " + response.Content);
        
        return response;
    }
    
    private static string FormatRequestBody(string body)
    {
        return JToken.Parse(body).ToString(Formatting.Indented);
    }
}