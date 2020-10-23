namespace TraktNet.Objects.Post.Syncs.Ratings
{
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A Trakt ratings post, containing all movies, shows and / or episodes,
    /// which should be added to the user's ratings.
    /// </summary>
    public class TraktSyncRatingsPost : ITraktSyncRatingsPost
    {
        /// <summary>
        /// An optional list of <see cref="ITraktSyncRatingsPostMovie" />s.
        /// <para>Each <see cref="ITraktSyncRatingsPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncRatingsPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncRatingsPostShow" />s.
        /// <para>Each <see cref="ITraktSyncRatingsPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncRatingsPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncRatingsPostEpisode" />s.
        /// <para>Each <see cref="ITraktSyncRatingsPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncRatingsPostEpisode> Episodes { get; set; }

        public Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktSyncRatingsPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktSyncRatingsPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public void Validate()
        {
            // TODO
        }
    }
}
