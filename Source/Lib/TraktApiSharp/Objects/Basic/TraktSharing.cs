namespace TraktApiSharp.Objects.Basic
{
    using Newtonsoft.Json;

    /// <summary>Represents Trakt connection options.</summary>
    public class TraktSharing
    {
        /// <summary>Gets or sets, whether Facebook connection is enabled.</summary>
        [JsonProperty(PropertyName = "facebook")]
        public bool? Facebook { get; set; }

        /// <summary>Gets or sets, whether Twitter connection is enabled.</summary>
        [JsonProperty(PropertyName = "twitter")]
        public bool? Twitter { get; set; }

        /// <summary>Gets or sets, whether Google connection is enabled.</summary>
        [JsonProperty(PropertyName = "google")]
        public bool? Google { get; set; }

        /// <summary>Gets or sets, whether Tumblr connection is enabled.</summary>
        [JsonProperty(PropertyName = "tumblr")]
        public bool? Tumblr { get; set; }

        /// <summary>Gets or sets, whether Medium connection is enabled.</summary>
        [JsonProperty(PropertyName = "medium")]
        public bool? Medium { get; set; }

        /// <summary>Gets or sets, whether Slack connection is enabled.</summary>
        [JsonProperty(PropertyName = "slack")]
        public bool? Slack { get; set; }
    }
}
