namespace TraktNet.Objects.Get.Seasons
{
    /// <summary>Represents the progress of a Trakt season.</summary>
    public interface ITraktSeasonProgress
    {
        /// <summary>Gets or sets the number of the collected or watched season.</summary>
        int? Number { get; set; }

        /// <summary>Gets or sets the number of episodes in the season, which already aired.</summary>
        int? Aired { get; set; }

        /// <summary>Gets or sets the number of episodes in the season already collected or watched.</summary>
        int? Completed { get; set; }
    }
}
