namespace TraktApiSharp.Objects.Get.Users.Statistics
{
    using System.Collections.Generic;

    /// <summary>A collection of Trakt user statistics for ratings.</summary>
    public class TraktUserRatingsStatistics : ITraktUserRatingsStatistics
    {
        /// <summary>Gets or sets the total number of items an user has rated.</summary>
        public int? Total { get; set; }

        /// <summary>
        /// Gets or sets the rating distribution of an user's ratings.
        /// <para>Nullable</para>
        /// </summary>
        public IDictionary<string, int> Distribution { get; set; }
    }
}
