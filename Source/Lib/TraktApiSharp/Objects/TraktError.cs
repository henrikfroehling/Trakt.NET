namespace TraktApiSharp.Objects
{
    using Newtonsoft.Json;

    public class TraktError
    {
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "error_description")]
        public string Description { get; set; }
    }
}
