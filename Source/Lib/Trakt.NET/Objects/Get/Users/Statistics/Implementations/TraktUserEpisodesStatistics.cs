namespace TraktNet.Objects.Get.Users.Statistics
{
    /// <summary>A collection of Trakt user statistics for episodes.</summary>
    public class TraktUserEpisodesStatistics : ITraktUserEpisodesStatistics
    {
        /// <summary>Gets or sets the number of how many times an user has played episodes.</summary>
        public int? Plays { get; set; }

        /// <summary>Gets or sets the number of how many episodes an user has watched.</summary>
        public int? Watched { get; set; }

        /// <summary>Gets or sets the number of minutes that an user has watched episodes.</summary>
        public int? Minutes { get; set; }

        /// <summary>Gets or sets the number of how many episodes an user has collected.</summary>
        public int? Collected { get; set; }

        /// <summary>Gets or sets the number of how many episodes an user has rated.</summary>
        public int? Ratings { get; set; }

        /// <summary>Gets or sets the number of how many episodes an user has commented.</summary>
        public int? Comments { get; set; }
    }
}
