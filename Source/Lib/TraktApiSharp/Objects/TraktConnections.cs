namespace TraktApiSharp.Objects
{
    using Newtonsoft.Json;

    public class TraktConnections
    {
        [JsonProperty(PropertyName = "facebook")]
        public bool? Facebook { get; set; }

        [JsonProperty(PropertyName = "twitter")]
        public bool? Twitter { get; set; }

        [JsonProperty(PropertyName = "google")]
        public bool? Google { get; set; }

        [JsonProperty(PropertyName = "tumblr")]
        public bool? Tumblr { get; set; }

        [JsonProperty(PropertyName = "medium")]
        public bool? Medium { get; set; }

        [JsonProperty(PropertyName = "slack")]
        public bool? Slack { get; set; }
    }
}
