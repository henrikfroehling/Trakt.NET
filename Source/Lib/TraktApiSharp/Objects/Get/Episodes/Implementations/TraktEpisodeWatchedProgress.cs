namespace TraktApiSharp.Objects.Get.Episodes.Implementations
{
    using System;

    /// <summary>Represents the watched progress of a Trakt episode.</summary>
    public class TraktEpisodeWatchedProgress : TraktEpisodeProgress, ITraktEpisodeWatchedProgress
    {
        /// <summary>Gets or sets the UTC datetime, when the last watch occured.</summary>
        public DateTime? LastWatchedAt { get; set; }
    }
}
