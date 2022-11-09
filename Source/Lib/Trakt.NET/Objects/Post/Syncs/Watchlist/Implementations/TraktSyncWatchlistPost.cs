﻿namespace TraktNet.Objects.Post.Syncs.Watchlist
{
    using Exceptions;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A Trakt watchlist post, containing all movies, shows, seasons and / or episodes,
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
        /// An optional list of <see cref="ITraktSyncWatchlistPostSeason" />s.
        /// <para>Each <see cref="ITraktSyncWatchlistPostSeason" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncWatchlistPostSeason> Seasons { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncWatchlistPostEpisode" />s.
        /// <para>Each <see cref="ITraktSyncWatchlistPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IEnumerable<ITraktSyncWatchlistPostEpisode> Episodes { get; set; }

        public Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktSyncWatchlistPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktSyncWatchlistPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public void Validate()
        {
            bool bHasNoMovies = Movies == null || !Movies.Any();
            bool bHasNoShows = Shows == null || !Shows.Any();
            bool bHasNoSeasons = Seasons == null || !Seasons.Any();
            bool bHasNoEpisodes = Episodes == null || !Episodes.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoSeasons && bHasNoEpisodes)
                throw new TraktPostValidationException("no watchlist items set");
        }
    }
}
