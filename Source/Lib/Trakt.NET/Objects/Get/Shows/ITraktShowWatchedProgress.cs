namespace TraktNet.Objects.Get.Shows
{
    using Seasons;
    using System;
    using System.Collections.Generic;

    /// <summary>Represents the watched progress of a Trakt show.</summary>
    public interface ITraktShowWatchedProgress : ITraktShowProgress
    {
        /// <summary>Gets or sets the UTC datetime, when the last watch occured.</summary>
        DateTime? LastWatchedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the watched progress has been reset.</summary>
        DateTime? ResetAt { get; set; }

        /// <summary>
        /// Gets or sets the watched seasons. See also <seealso cref="ITraktSeasonWatchedProgress" />.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktSeasonWatchedProgress> Seasons { get; set; }
    }
}
