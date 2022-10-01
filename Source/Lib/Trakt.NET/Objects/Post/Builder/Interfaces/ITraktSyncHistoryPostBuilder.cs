namespace TraktNet.Objects.Post
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.History;

    public interface ITraktSyncHistoryPostBuilder
    {
        ITraktSyncHistoryPostBuilder WithMovie(ITraktMovie movie);
        ITraktSyncHistoryPostBuilder WithMovie(ITraktMovieIds movieIds);
        ITraktSyncHistoryPostBuilder WithMovieWatchedAt(ITraktMovie movie, DateTime watchedAt);
        ITraktSyncHistoryPostBuilder WithMovieWatchedAt(WatchedMovie movieWatchedAt);
        ITraktSyncHistoryPostBuilder WithMovieWatchedAt(ITraktMovieIds movieIds, DateTime watchedAt);
        ITraktSyncHistoryPostBuilder WithMovieWatchedAt(WatchedMovieIds movieIdsWatchedAt);

        ITraktSyncHistoryPostBuilder WithMovies(IEnumerable<ITraktMovie> movies);
        ITraktSyncHistoryPostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds);
        ITraktSyncHistoryPostBuilder WithMoviesWatchedAt(IEnumerable<WatchedMovie> moviesWatchedAt);
        ITraktSyncHistoryPostBuilder WithMoviesWatchedAt(IEnumerable<WatchedMovieIds> movieIdsWatchedAt);

        ITraktSyncHistoryPostBuilder WithShow(ITraktShow show);
        ITraktSyncHistoryPostBuilder WithShow(ITraktShowIds showIds);
        ITraktSyncHistoryPostBuilder WithShowWatchedAt(ITraktShow show, DateTime watchedAt);
        ITraktSyncHistoryPostBuilder WithShowWatchedAt(WatchedShow showWatchedAt);
        ITraktSyncHistoryPostBuilder WithShowWatchedAt(ITraktShowIds showIds, DateTime watchedAt);
        ITraktSyncHistoryPostBuilder WithShowWatchedAt(WatchedShowIds showIdsWatchedAt);

        ITraktSyncHistoryPostBuilder WithShows(IEnumerable<ITraktShow> shows);
        ITraktSyncHistoryPostBuilder WithShows(IEnumerable<ITraktShowIds> showIds);
        ITraktSyncHistoryPostBuilder WithShowsWatchedAt(IEnumerable<WatchedShow> showsWatchedAt);
        ITraktSyncHistoryPostBuilder WithShowsWatchedAt(IEnumerable<WatchedShowIds> showIdsWatchedAt);

        ITraktSyncHistoryPostBuilder WithShowAndSeasons(ITraktShow show, PostHistorySeasons seasons);
        ITraktSyncHistoryPostBuilder WithShowAndSeasons(WatchedShowAndSeasons showAndSeasons);
        ITraktSyncHistoryPostBuilder WithShowAndSeasons(ITraktShowIds showIds, PostHistorySeasons seasons);
        ITraktSyncHistoryPostBuilder WithShowAndSeasons(WatchedShowIdsAndSeasons showIdsAndSeasons);

        ITraktSyncHistoryPostBuilder WithShowsAndSeasons(IEnumerable<WatchedShowAndSeasons> showsAndSeasons);
        ITraktSyncHistoryPostBuilder WithShowsAndSeasons(IEnumerable<WatchedShowIdsAndSeasons> showIdsAndSeasons);

        ITraktSyncHistoryPostBuilder WithSeason(ITraktSeason season);
        ITraktSyncHistoryPostBuilder WithSeason(ITraktSeasonIds seasonIds);
        ITraktSyncHistoryPostBuilder WithSeasonWatchedAt(ITraktSeason season, DateTime watchedAt);
        ITraktSyncHistoryPostBuilder WithSeasonWatchedAt(WatchedSeason seasonWatchedAt);
        ITraktSyncHistoryPostBuilder WithSeasonWatchedAt(ITraktSeasonIds seasonIds, DateTime watchedAt);
        ITraktSyncHistoryPostBuilder WithSeasonWatchedAt(WatchedSeasonIds seasonIdsWatchedAt);

        ITraktSyncHistoryPostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons);
        ITraktSyncHistoryPostBuilder WithSeasons(IEnumerable<ITraktSeasonIds> seasonIds);
        ITraktSyncHistoryPostBuilder WithSeasonsWatchedAt(IEnumerable<WatchedSeason> seasonsWatchedAt);
        ITraktSyncHistoryPostBuilder WithSeasonsWatchedAt(IEnumerable<WatchedSeasonIds> seasonIdsWatchedAt);

        ITraktSyncHistoryPostBuilder WithEpisode(ITraktEpisode episode);
        ITraktSyncHistoryPostBuilder WithEpisode(ITraktEpisodeIds episodeIds);
        ITraktSyncHistoryPostBuilder WithEpisodeWatchedAt(ITraktEpisode episode, DateTime watchedAt);
        ITraktSyncHistoryPostBuilder WithEpisodeWatchedAt(WatchedEpisode episodeWatchedAt);
        ITraktSyncHistoryPostBuilder WithEpisodeWatchedAt(ITraktEpisodeIds episodeIds, DateTime watchedAt);
        ITraktSyncHistoryPostBuilder WithEpisodeWatchedAt(WatchedEpisodeIds episodeIdsWatchedAt);

        ITraktSyncHistoryPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes);
        ITraktSyncHistoryPostBuilder WithEpisodes(IEnumerable<ITraktEpisodeIds> episodeIds);
        ITraktSyncHistoryPostBuilder WithEpisodesWatchedAt(IEnumerable<WatchedEpisode> episodesWatchedAt);
        ITraktSyncHistoryPostBuilder WithEpisodesWatchedAt(IEnumerable<WatchedEpisodeIds> episodeIdsWatchedAt);

        ITraktSyncHistoryPost Build();
    }
}
