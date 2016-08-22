namespace TraktApiSharp.Objects.Get.Users.Statistics
{
    using Newtonsoft.Json;

    /// <summary>A collection of Trakt user statistics for episodes.</summary>
    public class TraktUserEpisodesStatistics
    {
        /// <summary>Gets or sets the number of how many times an user has played episodes.</summary>
        [JsonProperty(PropertyName = "plays")]
        public int? Plays { get; set; }

        /// <summary>Gets or sets the number of how many episodes an user has watched.</summary>
        [JsonProperty(PropertyName = "watched")]
        public int? Watched { get; set; }

        /// <summary>Gets or sets the number of minutes that an user has watched episodes.</summary>
        [JsonProperty(PropertyName = "minutes")]
        public int? Minutes { get; set; }

        /// <summary>Gets or sets the number of how many episodes an user has collected.</summary>
        [JsonProperty(PropertyName = "collected")]
        public int? Collected { get; set; }

        /// <summary>Gets or sets the number of how many episodes an user has rated.</summary>
        [JsonProperty(PropertyName = "ratings")]
        public int? Ratings { get; set; }

        /// <summary>Gets or sets the number of how many episodes an user has commented.</summary>
        [JsonProperty(PropertyName = "comments")]
        public int? Comments { get; set; }
    }
}
