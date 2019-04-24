namespace TraktNet.Objects.Get.Collections
{
    using Shows;
    using System;
    using System.Collections.Generic;

    /// <summary>Contains information about a collected Trakt show.</summary>
    public interface ITraktCollectionShow : ITraktShow
    {
        /// <summary>Gets or sets the UTC datetime, when the last episode was collected in the show.</summary>
        DateTime? LastCollectedAt { get; set; }

        /// <summary>
        /// Gets or sets the collected Trakt show. See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets a list of collected seasons in the collected show.
        /// See also <seealso cref="ITraktCollectionShowSeason" />.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktCollectionShowSeason> CollectionSeasons { get; set; }
    }
}
