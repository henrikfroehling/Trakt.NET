namespace TraktApiSharp.Objects.Get.Shows
{
    using Seasons;
    using System;
    using System.Collections.Generic;

    /// <summary>Represents the collection progress of a Trakt show.</summary>
    public class TraktShowCollectionProgress : TraktShowProgress, ITraktShowCollectionProgress
    {
        /// <summary>Gets or sets the UTC datetime, when the last collection occured.</summary>
        public DateTime? LastCollectedAt { get; set; }

        /// <summary>
        /// Gets or sets the collected seasons. See also <seealso cref="ITraktSeasonCollectionProgress" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktSeasonCollectionProgress> Seasons { get; set; }
    }
}
