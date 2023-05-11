namespace TraktNet.Objects.Get.Shows
{
    using Seasons;
    using System;
    using System.Collections.Generic;

    /// <summary>Represents the collection progress of a Trakt show.</summary>
    public interface ITraktShowCollectionProgress : ITraktShowProgress
    {
        /// <summary>Gets or sets the UTC datetime, when the last collection occured.</summary>
        DateTime? LastCollectedAt { get; set; }

        /// <summary>
        /// Gets or sets the collected seasons. See also <seealso cref="ITraktSeasonCollectionProgress" />.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktSeasonCollectionProgress> Seasons { get; set; }
    }
}
