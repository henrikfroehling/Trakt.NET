namespace TraktNet.Objects.Get.Watched
{
    using Shows;
    using System;
    using System.Collections.Generic;

    /// <summary>Contains information about a watched Trakt show.</summary>
    public interface ITraktWatchedShow : ITraktShow
    {
        /// <summary>Gets or sets the number of plays for the watched show.</summary>
        int? Plays { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the show was last watched.</summary>
        DateTime? LastWatchedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the show was resetted.</summary>
        DateTime? ResetAt { get; set; }

        /// <summary>Gets or sets the Trakt show. See also <seealso cref="ITraktShow" />.<para>Nullable</para></summary>
        ITraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets a list of watched seasons in the watched show.
        /// See also <seealso cref="ITraktWatchedShowSeason" />.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktWatchedShowSeason> WatchedSeasons { get; set; }
    }
}
