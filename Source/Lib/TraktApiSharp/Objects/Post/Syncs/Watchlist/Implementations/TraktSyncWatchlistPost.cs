namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using Objects.Json;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A Trakt watchlist post, containing all movies, shows and / or episodes,
    /// which should be added to the user's watchlist.
    /// </summary>
    public class TraktSyncWatchlistPost : ITraktSyncWatchlistPost
    {
        /// <summary>
        /// An optional list of <see cref="ITraktSyncWatchlistPostMovie" />s.
        /// <para>Each <see cref="ITraktSyncWatchlistPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncWatchlistPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncWatchlistPostShow" />s.
        /// <para>Each <see cref="ITraktSyncWatchlistPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncWatchlistPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncWatchlistPostEpisode" />s.
        /// <para>Each <see cref="ITraktSyncWatchlistPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncWatchlistPostEpisode> Episodes { get; set; }

        /// <summary>Returns a new <see cref="TraktSyncWatchlistPostBuilder" /> instance.</summary>
        /// <returns>A new <see cref="TraktSyncWatchlistPostBuilder" /> instance.</returns>
        public static TraktSyncWatchlistPostBuilder Builder() => new TraktSyncWatchlistPostBuilder();

        public HttpContent ToHttpContent()
        {
            throw new System.NotImplementedException();
        }

        public Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktSyncWatchlistPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktSyncWatchlistPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public void Validate()
        {
            // TODO
        }
    }
}
