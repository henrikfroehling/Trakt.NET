namespace TraktApiSharp.Objects.Get.Users.Statistics.Implementations
{
    /// <summary>A collection of Trakt user statistics for shows.</summary>
    public class TraktUserShowsStatistics : ITraktUserShowsStatistics
    {
        /// <summary>Gets or sets the number of how many shows an user has watched.</summary>
        public int? Watched { get; set; }

        /// <summary>Gets or sets the number of how many shows an user has collected.</summary>
        public int? Collected { get; set; }

        /// <summary>Gets or sets the number of how many shows an user has rated.</summary>
        public int? Ratings { get; set; }

        /// <summary>Gets or sets the number of how many shows an user has commented.</summary>
        public int? Comments { get; set; }
    }
}
