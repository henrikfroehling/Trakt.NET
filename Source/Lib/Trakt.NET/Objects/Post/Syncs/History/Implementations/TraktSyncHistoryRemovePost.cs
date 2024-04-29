﻿namespace TraktNet.Objects.Post.Syncs.History
{
    using Exceptions;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A Trakt history remove post, containing all movies, shows, seasons, episodes and / or history ids,
    /// which should be removed from the user's history.
    /// </summary>
    public class TraktSyncHistoryRemovePost : ITraktSyncHistoryRemovePost
    {
        /// <summary>
        /// An optional list of <see cref="ITraktSyncHistoryRemovePostMovie" />s.
        /// <para>Each <see cref="ITraktSyncHistoryRemovePostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IList<ITraktSyncHistoryRemovePostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncHistoryRemovePostShow" />s.
        /// <para>Each <see cref="ITraktSyncHistoryRemovePostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IList<ITraktSyncHistoryRemovePostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncHistoryRemovePostSeason" />s.
        /// <para>Each <see cref="ITraktSyncHistoryRemovePostSeason" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IList<ITraktSyncHistoryRemovePostSeason> Seasons { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncHistoryRemovePostEpisode" />s.
        /// <para>Each <see cref="ITraktSyncHistoryRemovePostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IList<ITraktSyncHistoryRemovePostEpisode> Episodes { get; set; }

        /// <summary>An optional list of history ids, which should be removed.</summary>
        public IList<ulong> HistoryIds { get; set; }

        public virtual Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktSyncHistoryRemovePost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktSyncHistoryRemovePost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public virtual void Validate()
        {
            bool bHasNoMovies = Movies == null || !Movies.Any();
            bool bHasNoShows = Shows == null || !Shows.Any();
            bool bHasNoSeasons = Seasons == null || !Seasons.Any();
            bool bHasNoEpisodes = Episodes == null || !Episodes.Any();
            bool bHasNoHistoryIds = HistoryIds == null || !HistoryIds.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoSeasons && bHasNoEpisodes && bHasNoHistoryIds)
                throw new TraktPostValidationException("no history items set");
        }
    }
}
