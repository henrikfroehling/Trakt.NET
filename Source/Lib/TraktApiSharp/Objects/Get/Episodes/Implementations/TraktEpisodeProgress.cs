namespace TraktApiSharp.Objects.Get.Episodes
{
    /// <summary>Represents the progress of a Trakt episode.</summary>
    public abstract class TraktEpisodeProgress : ITraktEpisodeProgress
    {
        /// <summary>Gets or sets the number of the collected or watched episode.</summary>
        public int? Number { get; set; }

        /// <summary>Gets or sets, whether the episode was collected or watched.</summary>
        public bool? Completed { get; set; }
    }
}
