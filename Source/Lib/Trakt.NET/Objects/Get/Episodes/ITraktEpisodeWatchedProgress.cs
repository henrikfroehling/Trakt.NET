namespace TraktNet.Objects.Get.Episodes
{
    using System;

    /// <summary>Represents the watched progress of a Trakt episode.</summary>
    public interface ITraktEpisodeWatchedProgress : ITraktEpisodeProgress
    {
        /// <summary>Gets or sets the UTC datetime, when the last watch occured.</summary>
        DateTime? LastWatchedAt { get; set; }
    }
}
