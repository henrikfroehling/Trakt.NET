namespace TraktApiSharp.Objects.Basic
{
    using Newtonsoft.Json;

    /// <summary>Represents Trakt statistics.</summary>
    public class TraktStatistics
    {
        /// <summary>Gets or sets the number of watchers.</summary>
        [JsonProperty(PropertyName = "watchers")]
        public int? Watchers { get; set; }

        /// <summary>Gets or sets the number of playes.</summary>
        [JsonProperty(PropertyName = "plays")]
        public int? Plays { get; set; }

        /// <summary>Gets or sets the number of collectors.</summary>
        [JsonProperty(PropertyName = "collectors")]
        public int? Collectors { get; set; }

        /// <summary>Gets or sets the number of collected episodes.</summary>
        [JsonProperty(PropertyName = "collected_episodes")]
        public int? CollectedEpisodes { get; set; }

        /// <summary>Gets or sets the number of comments.</summary>
        [JsonProperty(PropertyName = "comments")]
        public int? Comments { get; set; }

        /// <summary>Gets or sets the number of lists.</summary>
        [JsonProperty(PropertyName = "lists")]
        public int? Lists { get; set; }

        /// <summary>Gets or sets the number of votes.</summary>
        [JsonProperty(PropertyName = "votes")]
        public int? Votes { get; set; }
    }
}
