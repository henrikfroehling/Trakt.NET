namespace TraktApiSharp.Objects.Get.Users.Statistics.Implementations
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>A collection of Trakt user statistics for ratings.</summary>
    public class TraktUserRatingsStatistics : ITraktUserRatingsStatistics
    {
        /// <summary>Gets or sets the total number of items an user has rated.</summary>
        [JsonProperty(PropertyName = "total")]
        public int? Total { get; set; }

        /// <summary>
        /// Gets or sets the rating distribution of an user's ratings.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "distribution")]
        public IDictionary<string, int> Distribution { get; set; }
    }
}
