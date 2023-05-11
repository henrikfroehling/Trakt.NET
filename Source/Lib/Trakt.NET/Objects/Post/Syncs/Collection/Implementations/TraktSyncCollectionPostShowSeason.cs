namespace TraktNet.Objects.Post.Syncs.Collection
{
    using Objects.Basic;
    using System;
    using System.Collections.Generic;

    /// <summary>A Trakt collection post season, containing the required season number and optional episodes.</summary>
    public class TraktSyncCollectionPostShowSeason : TraktMetadata, ITraktSyncCollectionPostShowSeason
    {
        /// <summary>Gets or sets the required season number of the Trakt season.</summary>
        public int Number { get; set; }


        /// <summary>Gets or sets the collected at UTC datetime of the Trakt episode.</summary>
        public DateTime? CollectedAt { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncCollectionPostShowEpisode" />s.
        /// <para>
        /// If no episodes are set, the whole Trakt season will be added to the collection.
        /// Otherwise, only the specified episodes will be added to the collection.
        /// </para>
        /// </summary>
        public IList<ITraktSyncCollectionPostShowEpisode> Episodes { get; set; }
    }
}
