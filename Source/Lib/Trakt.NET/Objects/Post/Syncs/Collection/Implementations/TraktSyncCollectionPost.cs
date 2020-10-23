namespace TraktNet.Objects.Post.Syncs.Collection
{
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A Trakt collection post, containing all movies, shows and / or episodes,
    /// which should be added to the user's collection.
    /// </summary>
    public class TraktSyncCollectionPost : ITraktSyncCollectionPost
    {
        /// <summary>
        /// An optional list of <see cref="ITraktSyncCollectionPostMovie" />s.
        /// <para>Each <see cref="ITraktSyncCollectionPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncCollectionPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncCollectionPostShow" />s.
        /// <para>Each <see cref="ITraktSyncCollectionPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncCollectionPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncCollectionPostEpisode" />s.
        /// <para>Each <see cref="ITraktSyncCollectionPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncCollectionPostEpisode> Episodes { get; set; }

        public Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktSyncCollectionPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktSyncCollectionPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public void Validate()
        {
            // TODO
        }
    }
}
