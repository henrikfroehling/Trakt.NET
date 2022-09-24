namespace TraktNet.Objects.Post.Syncs.History
{
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A Trakt history post, containing all movies, shows and / or episodes,
    /// which should be added to the user's history.
    /// </summary>
    public class TraktSyncHistoryPost : ITraktSyncHistoryPost
    {
        /// <summary>
        /// An optional list of <see cref="ITraktSyncHistoryPostMovie" />s.
        /// <para>Each <see cref="ITraktSyncHistoryPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncHistoryPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncHistoryPostShow" />s.
        /// <para>Each <see cref="ITraktSyncHistoryPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncHistoryPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncHistoryPostEpisode" />s.
        /// <para>Each <see cref="ITraktSyncHistoryPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncHistoryPostEpisode> Episodes { get; set; }

        public virtual Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktSyncHistoryPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktSyncHistoryPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public virtual void Validate()
        {
            bool bHasNoMovies = Movies == null || !Movies.Any();
            bool bHasNoShows = Shows == null || !Shows.Any();
            bool bHasNoEpisodes = Episodes == null || !Episodes.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoEpisodes)
                throw new ArgumentException("no watched history items set");
        }
    }
}
