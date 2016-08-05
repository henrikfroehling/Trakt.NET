namespace TraktApiSharp.Objects.Basic
{
    using Newtonsoft.Json;

    /// <summary>Represents Trakt sharing options.</summary>
    public class TraktSharing
    {
        /// <summary>Gets or sets, whether Facebook sharing is enabled.</summary>
        [JsonProperty(PropertyName = "facebook")]
        public bool? Facebook { get; set; }

        /// <summary>Gets or sets, whether Twitter sharing is enabled.</summary>
        [JsonProperty(PropertyName = "twitter")]
        public bool? Twitter { get; set; }

        /// <summary>Gets or sets, whether Google sharing is enabled.</summary>
        [JsonProperty(PropertyName = "google")]
        public bool? Google { get; set; }

        /// <summary>Gets or sets, whether Tumblr sharing is enabled.</summary>
        [JsonProperty(PropertyName = "tumblr")]
        public bool? Tumblr { get; set; }

        /// <summary>Gets or sets, whether Medium sharing is enabled.</summary>
        [JsonProperty(PropertyName = "medium")]
        public bool? Medium { get; set; }

        /// <summary>Gets or sets, whether Slack sharing is enabled.</summary>
        [JsonProperty(PropertyName = "slack")]
        public bool? Slack { get; set; }
    }
}
