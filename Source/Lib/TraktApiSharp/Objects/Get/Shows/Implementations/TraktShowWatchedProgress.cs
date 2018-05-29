namespace TraktApiSharp.Objects.Get.Shows
{
    using Seasons;
    using System;
    using System.Collections.Generic;

    /// <summary>Represents the watched progress of a Trakt show.</summary>
    public class TraktShowWatchedProgress : TraktShowProgress, ITraktShowWatchedProgress
    {
        /// <summary>Gets or sets the UTC datetime, when the last watch occured.</summary>
        public DateTime? LastWatchedAt { get; set; }

        /// <summary>
        /// Gets or sets the watched seasons. See also <seealso cref="ITraktSeasonWatchedProgress" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktSeasonWatchedProgress> Seasons { get; set; }
    }
}
