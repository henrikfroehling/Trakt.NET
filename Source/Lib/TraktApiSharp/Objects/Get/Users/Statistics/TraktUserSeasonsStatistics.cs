namespace TraktApiSharp.Objects.Get.Users.Statistics
{
    using Newtonsoft.Json;

    /// <summary>A collection of Trakt user statistics for seasons.</summary>
    public class TraktUserSeasonsStatistics
    {
        /// <summary>Gets or sets the number of how many seasons an user has rated.</summary>
        [JsonProperty(PropertyName = "ratings")]
        public int? Ratings { get; set; }

        /// <summary>Gets or sets the number of how many seasons an user has commented.</summary>
        [JsonProperty(PropertyName = "comments")]
        public int? Comments { get; set; }
    }
}
