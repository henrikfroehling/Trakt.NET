namespace TraktNet.Objects.Get.Users.Statistics
{
    /// <summary>A collection of Trakt user statistics for movies.</summary>
    public interface ITraktUserMoviesStatistics
    {
        /// <summary>Gets or sets the number of how many times an user has played movies.</summary>
        int? Plays { get; set; }

        /// <summary>Gets or sets the number of how many movies an user has watched.</summary>
        int? Watched { get; set; }

        /// <summary>Gets or sets the number of minutes that an user has watched movies.</summary>
        int? Minutes { get; set; }

        /// <summary>Gets or sets the number of how many movies an user has collected.</summary>
        int? Collected { get; set; }

        /// <summary>Gets or sets the number of how many movies an user has rated.</summary>
        int? Ratings { get; set; }

        /// <summary>Gets or sets the number of how many movies an user has commented.</summary>
        int? Comments { get; set; }
    }
}
