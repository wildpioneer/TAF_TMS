using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GUI.Utilites.Helpers;

public class JsonHelper
{
    public static JObject FromJson(string json)
    {
        return JsonConvert.DeserializeObject<JObject>(json);
    }
}