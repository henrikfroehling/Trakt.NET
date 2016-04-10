namespace TraktApiSharp.Objects.Users
{
    using Newtonsoft.Json;

    public class TraktSharingText
    {
        [JsonProperty(PropertyName = "watching")]
        public string Watching { get; set; }

        [JsonProperty(PropertyName = "watched")]
        public string Watched { get; set; }
    }
}
