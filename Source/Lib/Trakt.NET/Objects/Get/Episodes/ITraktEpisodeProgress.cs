namespace TraktNet.Objects.Get.Episodes
{
    /// <summary>Represents the progress of a Trakt episode.</summary>
    public interface ITraktEpisodeProgress
    {
        /// <summary>Gets or sets the number of the collected or watched episode.</summary>
        int? Number { get; set; }

        /// <summary>Gets or sets, whether the episode was collected or watched.</summary>
        bool? Completed { get; set; }
    }
}
