namespace TraktApiSharp.Utils
{
    using Newtonsoft.Json;
    using System.Threading.Tasks;

    internal static class Json
    {
        internal static readonly JsonSerializerSettings DEFAULT_JSON_SETTINGS
            = new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore
            };

        internal static string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value, DEFAULT_JSON_SETTINGS);
        }

        internal static TResult Deserialize<TResult>(string value)
        {
            return JsonConvert.DeserializeObject<TResult>(value, DEFAULT_JSON_SETTINGS);
        }

        internal static async Task<string> SerializeAsync(object value)
        {
            return await Task.Run(() => JsonConvert.SerializeObject(value, DEFAULT_JSON_SETTINGS));
        }

        internal static async Task<TResult> DeserializeAsync<TResult>(string value)
        {
            return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(value, DEFAULT_JSON_SETTINGS));
        }
    }
}
