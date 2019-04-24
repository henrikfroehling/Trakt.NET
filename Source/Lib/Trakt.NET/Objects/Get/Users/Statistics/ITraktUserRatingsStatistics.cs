namespace TraktNet.Objects.Get.Users.Statistics
{
    using System.Collections.Generic;

    /// <summary>A collection of Trakt user statistics for ratings.</summary>
    public interface ITraktUserRatingsStatistics
    {
        /// <summary>Gets or sets the total number of items an user has rated.</summary>
        int? Total { get; set; }

        /// <summary>
        /// Gets or sets the rating distribution of an user's ratings.
        /// <para>Nullable</para>
        /// </summary>
        IDictionary<string, int> Distribution { get; set; }
    }
}
