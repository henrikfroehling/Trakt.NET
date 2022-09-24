namespace TraktNet.Objects.Post.Syncs.History
{
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A Trakt history remove post, containing all movies, shows, episodes and / or history ids,
    /// which should be removed from the user's history.
    /// </summary>
    public class TraktSyncHistoryRemovePost : TraktSyncHistoryPost, ITraktSyncHistoryRemovePost
    {
        /// <summary>An optional list of history ids, which should be removed.</summary>
        public IEnumerable<ulong> HistoryIds { get; set; }

        public override Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktSyncHistoryRemovePost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktSyncHistoryRemovePost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public override void Validate()
        {
            bool bHasNoMovies = Movies == null || !Movies.Any();
            bool bHasNoShows = Shows == null || !Shows.Any();
            bool bHasNoEpisodes = Episodes == null || !Episodes.Any();
            bool bHasNoHistoryIds = HistoryIds == null || !HistoryIds.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoEpisodes && bHasNoHistoryIds)
                throw new ArgumentException("no watched history items set");
        }
    }
}
