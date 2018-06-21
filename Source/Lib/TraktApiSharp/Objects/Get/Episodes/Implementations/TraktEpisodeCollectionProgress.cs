namespace TraktNet.Objects.Get.Episodes
{
    using System;

    /// <summary>Represents the collection progress of a Trakt episode.</summary>
    public class TraktEpisodeCollectionProgress : TraktEpisodeProgress, ITraktEpisodeCollectionProgress
    {
        /// <summary>Gets or sets the UTC datetime, when the episode was collected.</summary>
        public DateTime? CollectedAt { get; set; }
    }
}
