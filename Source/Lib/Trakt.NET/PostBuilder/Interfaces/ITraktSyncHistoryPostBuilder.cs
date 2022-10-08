namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post;
    using TraktNet.Objects.Post.Syncs.History;

    public interface ITraktSyncHistoryPostBuilder
    {
        /// <summary>Adds the given <paramref name="movie"/> to the builder.</summary>
        /// <param name="movie">The <see cref="ITraktMovie"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithMovie(ITraktMovie movie);

        /// <summary>Adds the given <paramref name="movieIds"/> to the builder.</summary>
        /// <param name="movieIds">The <see cref="ITraktMovieIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithMovie(ITraktMovieIds movieIds);

        /// <summary>Adds the given <paramref name="movie"/> to the builder.</summary>
        /// <param name="movie">The <see cref="ITraktMovie"/> which will be added.</param>
        /// <param name="watchedAt">The UTC datetime when the <paramref name="movie"/> was watched.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithMovieWatchedAt(ITraktMovie movie, DateTime watchedAt);

        /// <summary>Adds the given <paramref name="movieWatchedAt"/> to the builder.</summary>
        /// <param name="movieWatchedAt">The <see cref="WatchedMovie"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieWatchedAt"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithMovieWatchedAt(WatchedMovie movieWatchedAt);

        /// <summary>Adds the given <paramref name="movieIds"/> to the builder.</summary>
        /// <param name="movieIds">The <see cref="ITraktMovieIds"/> which will be added.</param>
        /// <param name="watchedAt">The UTC datetime when the <paramref name="movieIds"/> was watched.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithMovieWatchedAt(ITraktMovieIds movieIds, DateTime watchedAt);

        /// <summary>Adds the given <paramref name="movieIdsWatchedAt"/> to the builder.</summary>
        /// <param name="movieIdsWatchedAt">The <see cref="WatchedMovieIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIdsWatchedAt"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithMovieWatchedAt(WatchedMovieIds movieIdsWatchedAt);

        /// <summary>Adds the given <paramref name="movies"/> collection to the builder.</summary>
        /// <param name="movies">A collection of <see cref="ITraktMovie"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movies"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithMovies(IEnumerable<ITraktMovie> movies);

        /// <summary>Adds the given <paramref name="movieIds"/> collection to the builder.</summary>
        /// <param name="movieIds">A collection of <see cref="ITraktMovieIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds);

        /// <summary>Adds the given <paramref name="moviesWatchedAt"/> collection to the builder.</summary>
        /// <param name="moviesWatchedAt">A collection of <see cref="WatchedMovie"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="moviesWatchedAt"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithMoviesWatchedAt(IEnumerable<WatchedMovie> moviesWatchedAt);

        /// <summary>Adds the given <paramref name="movieIdsWatchedAt"/> collection to the builder.</summary>
        /// <param name="movieIdsWatchedAt">A collection of <see cref="WatchedMovieIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIdsWatchedAt"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithMoviesWatchedAt(IEnumerable<WatchedMovieIds> movieIdsWatchedAt);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithShow(ITraktShow show);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithShow(ITraktShowIds showIds);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="watchedAt">The UTC datetime when the <paramref name="show"/> was watched.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        ITraktSyncHistoryPostBuilder WithShowWatchedAt(ITraktShow show, DateTime watchedAt);

        /// <summary>Adds the given <paramref name="showWatchedAt"/> to the builder.</summary>
        /// <param name="showWatchedAt">The <see cref="WatchedShow"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showWatchedAt"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithShowWatchedAt(WatchedShow showWatchedAt);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="watchedAt">The UTC datetime when the <paramref name="showIds"/> was watched.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithShowWatchedAt(ITraktShowIds showIds, DateTime watchedAt);

        /// <summary>Adds the given <paramref name="showIdsWatchedAt"/> to the builder.</summary>
        /// <param name="showIdsWatchedAt">The <see cref="WatchedShowIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWatchedAt"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithShowWatchedAt(WatchedShowIds showIdsWatchedAt);

        /// <summary>Adds the given <paramref name="shows"/> collection to the builder.</summary>
        /// <param name="shows">A collection of <see cref="ITraktShow"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="shows"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithShows(IEnumerable<ITraktShow> shows);

        /// <summary>Adds the given <paramref name="showIds"/> collection to the builder.</summary>
        /// <param name="showIds">A collection of <see cref="ITraktShowIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithShows(IEnumerable<ITraktShowIds> showIds);

        /// <summary>Adds the given <paramref name="showsWatchedAt"/> collection to the builder.</summary>
        /// <param name="showsWatchedAt">A collection of <see cref="WatchedShow"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showsWatchedAt"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithShowsWatchedAt(IEnumerable<WatchedShow> showsWatchedAt);

        /// <summary>Adds the given <paramref name="showIdsWatchedAt"/> collection to the builder.</summary>
        /// <param name="showIdsWatchedAt">A collection of <see cref="WatchedShowIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWatchedAt"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithShowsWatchedAt(IEnumerable<WatchedShowIds> showIdsWatchedAt);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="seasons">The <see cref="PostHistorySeasons"/> for the <paramref name="show"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithShowAndSeasons(ITraktShow show, PostHistorySeasons seasons);

        /// <summary>Adds the given <paramref name="showAndSeasons"/> to the builder.</summary>
        /// <param name="showAndSeasons">The <see cref="WatchedShowAndSeasons"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showAndSeasons"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithShowAndSeasons(WatchedShowAndSeasons showAndSeasons);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="seasons">The <see cref="PostHistorySeasons"/> for the <paramref name="showIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithShowAndSeasons(ITraktShowIds showIds, PostHistorySeasons seasons);

        /// <summary>Adds the given <paramref name="showIdsAndSeasons"/> to the builder.</summary>
        /// <param name="showIdsAndSeasons">The <see cref="WatchedShowIdsAndSeasons"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsAndSeasons"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithShowAndSeasons(WatchedShowIdsAndSeasons showIdsAndSeasons);

        /// <summary>Adds the given <paramref name="showsAndSeasons"/> collection to the builder.</summary>
        /// <param name="showsAndSeasons">A collection of <see cref="WatchedShowAndSeasons"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showsAndSeasons"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithShowsAndSeasons(IEnumerable<WatchedShowAndSeasons> showsAndSeasons);

        /// <summary>Adds the given <paramref name="showIdsAndSeasons"/> collection to the builder.</summary>
        /// <param name="showIdsAndSeasons">A collection of <see cref="WatchedShowIdsAndSeasons"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsAndSeasons"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithShowsAndSeasons(IEnumerable<WatchedShowIdsAndSeasons> showIdsAndSeasons);

        /// <summary>Adds the given <paramref name="season"/> to the builder.</summary>
        /// <param name="season">The <see cref="ITraktSeason"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithSeason(ITraktSeason season);

        /// <summary>Adds the given <paramref name="seasonIds"/> to the builder.</summary>
        /// <param name="seasonIds">The <see cref="ITraktSeasonIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithSeason(ITraktSeasonIds seasonIds);

        /// <summary>Adds the given <paramref name="season"/> to the builder.</summary>
        /// <param name="season">The <see cref="ITraktSeason"/> which will be added.</param>
        /// <param name="watchedAt">The UTC datetime when the <paramref name="season"/> was watched.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithSeasonWatchedAt(ITraktSeason season, DateTime watchedAt);

        /// <summary>Adds the given <paramref name="seasonWatchedAt"/> to the builder.</summary>
        /// <param name="seasonWatchedAt">The <see cref="WatchedSeason"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonWatchedAt"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithSeasonWatchedAt(WatchedSeason seasonWatchedAt);

        /// <summary>Adds the given <paramref name="seasonIds"/> to the builder.</summary>
        /// <param name="seasonIds">The <see cref="ITraktSeasonIds"/> which will be added.</param>
        /// <param name="watchedAt">The UTC datetime when the <paramref name="seasonIds"/> was watched.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithSeasonWatchedAt(ITraktSeasonIds seasonIds, DateTime watchedAt);

        /// <summary>Adds the given <paramref name="seasonIdsWatchedAt"/> to the builder.</summary>
        /// <param name="seasonIdsWatchedAt">The <see cref="WatchedSeasonIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIdsWatchedAt"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithSeasonWatchedAt(WatchedSeasonIds seasonIdsWatchedAt);

        /// <summary>Adds the given <paramref name="seasons"/> collection to the builder.</summary>
        /// <param name="seasons">A collection of <see cref="ITraktSeason"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons);

        /// <summary>Adds the given <paramref name="seasonIds"/> collection to the builder.</summary>
        /// <param name="seasonIds">A collection of <see cref="ITraktSeasonIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithSeasons(IEnumerable<ITraktSeasonIds> seasonIds);

        /// <summary>Adds the given <paramref name="seasonsWatchedAt"/> collection to the builder.</summary>
        /// <param name="seasonsWatchedAt">A collection of <see cref="WatchedSeason"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonsWatchedAt"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithSeasonsWatchedAt(IEnumerable<WatchedSeason> seasonsWatchedAt);

        /// <summary>Adds the given <paramref name="seasonIdsWatchedAt"/> collection to the builder.</summary>
        /// <param name="seasonIdsWatchedAt">A collection of <see cref="WatchedSeasonIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIdsWatchedAt"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithSeasonsWatchedAt(IEnumerable<WatchedSeasonIds> seasonIdsWatchedAt);

        /// <summary>Adds the given <paramref name="episode"/> to the builder.</summary>
        /// <param name="episode">The <see cref="ITraktEpisode"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithEpisode(ITraktEpisode episode);

        /// <summary>Adds the given <paramref name="episodeIds"/> to the builder.</summary>
        /// <param name="episodeIds">The <see cref="ITraktEpisodeIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIds"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithEpisode(ITraktEpisodeIds episodeIds);

        /// <summary>Adds the given <paramref name="episode"/> to the builder.</summary>
        /// <param name="episode">The <see cref="ITraktEpisode"/> which will be added.</param>
        /// <param name="watchedAt">The UTC datetime when the <paramref name="episode"/> was watched.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithEpisodeWatchedAt(ITraktEpisode episode, DateTime watchedAt);

        /// <summary>Adds the given <paramref name="episodeWatchedAt"/> to the builder.</summary>
        /// <param name="episodeWatchedAt">The <see cref="WatchedEpisode"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeWatchedAt"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithEpisodeWatchedAt(WatchedEpisode episodeWatchedAt);

        /// <summary>Adds the given <paramref name="episodeIds"/> to the builder.</summary>
        /// <param name="episodeIds">The <see cref="ITraktEpisodeIds"/> which will be added.</param>
        /// <param name="watchedAt">The UTC datetime when the <paramref name="episodeIds"/> was watched.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIds"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithEpisodeWatchedAt(ITraktEpisodeIds episodeIds, DateTime watchedAt);

        /// <summary>Adds the given <paramref name="episodeIdsWatchedAt"/> to the builder.</summary>
        /// <param name="episodeIdsWatchedAt">The <see cref="WatchedEpisodeIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIdsWatchedAt"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithEpisodeWatchedAt(WatchedEpisodeIds episodeIdsWatchedAt);

        /// <summary>Adds the given <paramref name="episodes"/> collection to the builder.</summary>
        /// <param name="episodes">A collection of <see cref="ITraktEpisode"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodes"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes);

        /// <summary>Adds the given <paramref name="episodeIds"/> collection to the builder.</summary>
        /// <param name="episodeIds">A collection of <see cref="ITraktEpisodeIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIds"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithEpisodes(IEnumerable<ITraktEpisodeIds> episodeIds);

        /// <summary>Adds the given <paramref name="episodesWatchedAt"/> collection to the builder.</summary>
        /// <param name="episodesWatchedAt">A collection of <see cref="WatchedEpisode"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodesWatchedAt"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithEpisodesWatchedAt(IEnumerable<WatchedEpisode> episodesWatchedAt);

        /// <summary>Adds the given <paramref name="episodeIdsWatchedAt"/> collection to the builder.</summary>
        /// <param name="episodeIdsWatchedAt">A collection of <see cref="WatchedEpisodeIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIdsWatchedAt"/> is null.</exception>
        ITraktSyncHistoryPostBuilder WithEpisodesWatchedAt(IEnumerable<WatchedEpisodeIds> episodeIdsWatchedAt);

        /// <summary>Creates a new <see cref="ITraktSyncHistoryPost" /> instance with the added movies, shows, seasons and episodes.</summary>
        /// <returns>A new <see cref="ITraktSyncHistoryPost" /> instance with the added movies, shows, seasons and episodes.</returns>
        ITraktSyncHistoryPost Build();
    }
}
