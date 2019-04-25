namespace TraktNet.Objects.Get.Users.Statistics
{
    /// <summary>A collection of Trakt user statistics for seasons.</summary>
    public interface ITraktUserSeasonsStatistics
    {
        /// <summary>Gets or sets the number of how many seasons an user has rated.</summary>
        int? Ratings { get; set; }

        /// <summary>Gets or sets the number of how many seasons an user has commented.</summary>
        int? Comments { get; set; }
    }
}
