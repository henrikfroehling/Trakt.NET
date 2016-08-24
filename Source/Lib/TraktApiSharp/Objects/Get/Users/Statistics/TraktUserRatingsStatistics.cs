namespace TraktApiSharp.Objects.Get.Users.Statistics
{
    using Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>A collection of Trakt user statistics for ratings.</summary>
    public class TraktUserRatingsStatistics
    {
        /// <summary>Gets or sets the total number of items an user has rated.</summary>
        [JsonProperty(PropertyName = "total")]
        public int? Total { get; set; }

        /// <summary>
        /// Gets or sets the rating distribution of an user's ratings.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "distribution")]
        [Nullable]
        public Dictionary<string, int> Distribution { get; set; }
    }
}
