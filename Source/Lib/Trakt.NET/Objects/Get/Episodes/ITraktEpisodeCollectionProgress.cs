namespace TraktNet.Objects.Get.Episodes
{
    using System;

    /// <summary>Represents the collection progress of a Trakt episode.</summary>
    public interface ITraktEpisodeCollectionProgress : ITraktEpisodeProgress
    {
        /// <summary>Gets or sets the UTC datetime, when the episode was collected.</summary>
        DateTime? CollectedAt { get; set; }
    }
}
