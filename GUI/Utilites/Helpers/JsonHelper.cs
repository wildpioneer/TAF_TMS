using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace GUI.Utilites.Helpers;

public class JsonHelper
{
    public static JObject FromJson(string json)
    {
        return JsonConvert.DeserializeObject<JObject>(json);
    }
    
    public T DeserializeContent<T>(RestResponse response)
    {
        var content = response.Content;
        return JsonConvert.DeserializeObject<T>(content);
    }
}