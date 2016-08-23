namespace TraktApiSharp.Objects.Get.Users.Statistics
{
    using Newtonsoft.Json;

    /// <summary>A collection of Trakt user statistics for shows.</summary>
    public class TraktUserShowsStatistics
    {
        /// <summary>Gets or sets the number of how many shows an user has watched.</summary>
        [JsonProperty(PropertyName = "watched")]
        public int? Watched { get; set; }

        /// <summary>Gets or sets the number of how many shows an user has collected.</summary>
        [JsonProperty(PropertyName = "collected")]
        public int? Collected { get; set; }

        /// <summary>Gets or sets the number of how many shows an user has rated.</summary>
        [JsonProperty(PropertyName = "ratings")]
        public int? Ratings { get; set; }

        /// <summary>Gets or sets the number of how many shows an user has commented.</summary>
        [JsonProperty(PropertyName = "comments")]
        public int? Comments { get; set; }
    }
}
