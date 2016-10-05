namespace TraktApiSharp.Utils
{
    using Newtonsoft.Json;

    internal static class Json
    {
        internal static readonly JsonSerializerSettings DEFAULT_JSON_SETTINGS
            = new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore
            };

        internal static string Serialize(object value)
            => JsonConvert.SerializeObject(value, DEFAULT_JSON_SETTINGS);

        internal static TResult Deserialize<TResult>(string value)
            => JsonConvert.DeserializeObject<TResult>(value, DEFAULT_JSON_SETTINGS);
    }
}
