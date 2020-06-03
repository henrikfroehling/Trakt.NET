namespace TraktNet.Objects.Get.Users.Statistics
{
    /// <summary>A collection of Trakt user statistics for shows.</summary>
    public interface ITraktUserShowsStatistics
    {
        /// <summary>Gets or sets the number of how many shows an user has watched.</summary>
        int? Watched { get; set; }

        /// <summary>Gets or sets the number of how many shows an user has collected.</summary>
        int? Collected { get; set; }

        /// <summary>Gets or sets the number of how many shows an user has rated.</summary>
        int? Ratings { get; set; }

        /// <summary>Gets or sets the number of how many shows an user has commented.</summary>
        int? Comments { get; set; }
    }
}
