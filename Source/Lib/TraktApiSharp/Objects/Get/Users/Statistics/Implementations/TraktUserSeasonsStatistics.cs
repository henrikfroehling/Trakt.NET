namespace TraktApiSharp.Objects.Get.Users.Statistics.Implementations
{
    /// <summary>A collection of Trakt user statistics for seasons.</summary>
    public class TraktUserSeasonsStatistics : ITraktUserSeasonsStatistics
    {
        /// <summary>Gets or sets the number of how many seasons an user has rated.</summary>
        public int? Ratings { get; set; }

        /// <summary>Gets or sets the number of how many seasons an user has commented.</summary>
        public int? Comments { get; set; }
    }
}
