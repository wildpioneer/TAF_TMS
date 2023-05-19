using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace GUI.Utilites.Helpers;

public class JsonHelper
{
    public static object? FromJson(string json)
    {
        return JsonConvert.DeserializeObject(json);
    }
}