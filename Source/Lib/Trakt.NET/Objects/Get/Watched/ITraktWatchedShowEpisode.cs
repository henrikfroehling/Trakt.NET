namespace TraktNet.Objects.Get.Watched
{
    using System;

    /// <summary>Contains information about a watched Trakt episode.</summary>
    public interface ITraktWatchedShowEpisode
    {
        /// <summary>Gets or sets the number of the watched episode.</summary>
        int? Number { get; set; }

        /// <summary>Gets or sets the number of plays for the watched episode.</summary>
        int? Plays { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the episode was last watched.</summary>
        DateTime? LastWatchedAt { get; set; }
    }
}
