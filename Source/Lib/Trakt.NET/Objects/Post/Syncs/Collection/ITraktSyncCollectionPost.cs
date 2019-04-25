namespace TraktNet.Objects.Post.Syncs.Collection
{
    using Requests.Interfaces;
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt collection post, containing all movies, shows and / or episodes,
    /// which should be added to the user's collection.
    /// </summary>
    public interface ITraktSyncCollectionPost : IRequestBody
    {
        /// <summary>
        /// An optional list of <see cref="ITraktSyncCollectionPostMovie" />s.
        /// <para>Each <see cref="ITraktSyncCollectionPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IEnumerable<ITraktSyncCollectionPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncCollectionPostShow" />s.
        /// <para>Each <see cref="ITraktSyncCollectionPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IEnumerable<ITraktSyncCollectionPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncCollectionPostEpisode" />s.
        /// <para>Each <see cref="ITraktSyncCollectionPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IEnumerable<ITraktSyncCollectionPostEpisode> Episodes { get; set; }
    }
}
