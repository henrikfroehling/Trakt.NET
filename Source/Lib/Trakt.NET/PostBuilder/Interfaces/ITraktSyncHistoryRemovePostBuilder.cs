namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.History;

    public interface ITraktSyncHistoryRemovePostBuilder
    {
        /// <summary>Adds the given <paramref name="movie"/> to the builder.</summary>
        /// <param name="movie">The <see cref="ITraktMovie"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithMovie(ITraktMovie movie);

        /// <summary>Adds the given <paramref name="movieIds"/> to the builder.</summary>
        /// <param name="movieIds">The <see cref="ITraktMovieIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithMovie(ITraktMovieIds movieIds);

        /// <summary>Adds the given <paramref name="movies"/> collection to the builder.</summary>
        /// <param name="movies">A collection of <see cref="ITraktMovie"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movies"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithMovies(IEnumerable<ITraktMovie> movies);

        /// <summary>Adds the given <paramref name="movieIds"/> collection to the builder.</summary>
        /// <param name="movieIds">A collection of <see cref="ITraktMovieIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithShow(ITraktShow show);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithShow(ITraktShowIds showIds);

        /// <summary>Adds the given <paramref name="shows"/> collection to the builder.</summary>
        /// <param name="shows">A collection of <see cref="ITraktShow"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="shows"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithShows(IEnumerable<ITraktShow> shows);

        /// <summary>Adds the given <paramref name="showIds"/> collection to the builder.</summary>
        /// <param name="showIds">A collection of <see cref="ITraktShowIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithShows(IEnumerable<ITraktShowIds> showIds);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="seasons">The <see cref="PostSeasons"/> for the <paramref name="show"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithShowAndSeasons(ITraktShow show, PostSeasons seasons);

        /// <summary>Adds the given <paramref name="showAndSeasons"/> to the builder.</summary>
        /// <param name="showAndSeasons">The <see cref="ShowAndSeasons"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showAndSeasons"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithShowAndSeasons(ShowAndSeasons showAndSeasons);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="seasons">The <see cref="PostSeasons"/> for the <paramref name="showIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithShowAndSeasons(ITraktShowIds showIds, PostSeasons seasons);

        /// <summary>Adds the given <paramref name="showIdsAndSeasons"/> to the builder.</summary>
        /// <param name="showIdsAndSeasons">The <see cref="ShowIdsAndSeasons"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsAndSeasons"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithShowAndSeasons(ShowIdsAndSeasons showIdsAndSeasons);

        /// <summary>Adds the given <paramref name="showsAndSeasons"/> collection to the builder.</summary>
        /// <param name="showsAndSeasons">A collection of <see cref="ShowAndSeasons"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showsAndSeasons"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithShowsAndSeasons(IEnumerable<ShowAndSeasons> showsAndSeasons);

        /// <summary>Adds the given <paramref name="showIdsAndSeasons"/> collection to the builder.</summary>
        /// <param name="showIdsAndSeasons">A collection of <see cref="ShowIdsAndSeasons"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsAndSeasons"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithShowsAndSeasons(IEnumerable<ShowIdsAndSeasons> showIdsAndSeasons);

        /// <summary>Adds the given <paramref name="season"/> to the builder.</summary>
        /// <param name="season">The <see cref="ITraktSeason"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithSeason(ITraktSeason season);

        /// <summary>Adds the given <paramref name="seasonIds"/> to the builder.</summary>
        /// <param name="seasonIds">The <see cref="ITraktSeasonIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithSeason(ITraktSeasonIds seasonIds);

        /// <summary>Adds the given <paramref name="seasons"/> collection to the builder.</summary>
        /// <param name="seasons">A collection of <see cref="ITraktSeason"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons);

        /// <summary>Adds the given <paramref name="seasonIds"/> collection to the builder.</summary>
        /// <param name="seasonIds">A collection of <see cref="ITraktSeasonIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithSeasons(IEnumerable<ITraktSeasonIds> seasonIds);

        /// <summary>Adds the given <paramref name="episode"/> to the builder.</summary>
        /// <param name="episode">The <see cref="ITraktEpisode"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithEpisode(ITraktEpisode episode);

        /// <summary>Adds the given <paramref name="episodeIds"/> to the builder.</summary>
        /// <param name="episodeIds">The <see cref="ITraktEpisodeIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIds"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithEpisode(ITraktEpisodeIds episodeIds);

        /// <summary>Adds the given <paramref name="episodes"/> collection to the builder.</summary>
        /// <param name="episodes">A collection of <see cref="ITraktEpisode"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodes"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes);

        /// <summary>Adds the given <paramref name="episodeIds"/> collection to the builder.</summary>
        /// <param name="episodeIds">A collection of <see cref="ITraktEpisodeIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIds"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithEpisodes(IEnumerable<ITraktEpisodeIds> episodeIds);

        /// <summary>Adds the given <paramref name="historyId"/> to the builder.</summary>
        /// <param name="historyId">The history id which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        ITraktSyncHistoryRemovePostBuilder WithHistoryId(ulong historyId);

        /// <summary>Adds the given <paramref name="historyIds"/> collection to the builder.</summary>
        /// <param name="historyIds">A collection of history ids which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="historyIds"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithHistoryIds(IEnumerable<ulong> historyIds);

        /// <summary>Adds the given <paramref name="historyId"/> and <paramref name="historyIds"/> collection to the builder.</summary>
        /// <param name="historyId">The history id which will be added.</param>
        /// <param name="historyIds">A collection of history ids which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        ITraktSyncHistoryRemovePostBuilder WithHistoryIds(ulong historyId, params ulong[] historyIds);

        /// <summary>Creates a new <see cref="ITraktSyncHistoryRemovePost" /> instance with the added movies, shows, seasons, episodes and history ids.</summary>
        /// <returns>A new <see cref="ITraktSyncHistoryRemovePost" /> instance with the added movies, shows, seasons, episodes and history ids.</returns>
        ITraktSyncHistoryRemovePost Build();
    }
}
