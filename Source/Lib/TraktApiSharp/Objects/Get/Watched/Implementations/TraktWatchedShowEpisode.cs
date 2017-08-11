namespace TraktApiSharp.Objects.Get.Watched.Implementations
{
    using System;

    /// <summary>Contains information about a watched Trakt episode.</summary>
    public class TraktWatchedShowEpisode : ITraktWatchedShowEpisode
    {
        /// <summary>Gets or sets the number of the watched episode.</summary>
        public int? Number { get; set; }

        /// <summary>Gets or sets the number of plays for the watched episode.</summary>
        public int? Plays { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the episode was last watched.</summary>
        public DateTime? LastWatchedAt { get; set; }
    }
}
