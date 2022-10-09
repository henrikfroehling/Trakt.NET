namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Watchlist;

    public interface ITraktSyncWatchlistPostBuilder
    {
        ITraktSyncWatchlistPostBuilder WithMovie(ITraktMovie movie);
        ITraktSyncWatchlistPostBuilder WithMovie(ITraktMovieIds movieIds);
        ITraktSyncWatchlistPostBuilder WithMovieWithNotes(ITraktMovie movie, string notes);
        ITraktSyncWatchlistPostBuilder WithMovieWithNotes(MovieWithNotes movieWithNotes);
        ITraktSyncWatchlistPostBuilder WithMovieWithNotes(ITraktMovieIds movieIds, string notes);
        ITraktSyncWatchlistPostBuilder WithMovieWithNotes(MovieIdsWithNotes movieIdsWithNotes);

        ITraktSyncWatchlistPostBuilder WithMovies(IEnumerable<ITraktMovie> movies);
        ITraktSyncWatchlistPostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds);
        ITraktSyncWatchlistPostBuilder WithMoviesWithNotes(IEnumerable<MovieWithNotes> moviesWithNotes);
        ITraktSyncWatchlistPostBuilder WithMoviesWithNotes(IEnumerable<MovieIdsWithNotes> movieIdsWithNotes);

        ITraktSyncWatchlistPostBuilder WithShow(ITraktShow show);
        ITraktSyncWatchlistPostBuilder WithShow(ITraktShowIds showIds);
        ITraktSyncWatchlistPostBuilder WithShowWithNotes(ITraktShow show, string notes);
        ITraktSyncWatchlistPostBuilder WithShowWithNotes(ShowWithNotes showWithNotes);
        ITraktSyncWatchlistPostBuilder WithShowWithNotes(ITraktShowIds showIds, string notes);
        ITraktSyncWatchlistPostBuilder WithShowWithNotes(ShowIdsWithNotes showIdsWithNotes);

        ITraktSyncWatchlistPostBuilder WithShows(IEnumerable<ITraktShow> shows);
        ITraktSyncWatchlistPostBuilder WithShows(IEnumerable<ITraktShowIds> showIds);
        ITraktSyncWatchlistPostBuilder WithShowsWithNotes(IEnumerable<ShowWithNotes> showsWithNotes);
        ITraktSyncWatchlistPostBuilder WithShowsWithNotes(IEnumerable<ShowIdsWithNotes> showIdsWithNotes);

        ITraktSyncWatchlistPostBuilder WithShowAndSeasons(ITraktShow show, PostSeasons seasons);
        ITraktSyncWatchlistPostBuilder WithShowAndSeasons(ShowAndSeasons showAndSeasons);
        ITraktSyncWatchlistPostBuilder WithShowAndSeasons(ITraktShowIds showIds, PostSeasons seasons);
        ITraktSyncWatchlistPostBuilder WithShowAndSeasons(ShowIdsAndSeasons showIdsAndSeasons);
        ITraktSyncWatchlistPostBuilder WithShowWithNotesAndSeasons(ShowWithNotesAndSeasons showWithNotesAndSeasons);
        ITraktSyncWatchlistPostBuilder WithShowWithNotesAndSeasons(ShowIdsWithNotesAndSeasons showIdsWithNotesAndSeasons);

        ITraktSyncWatchlistPostBuilder WithShowsAndSeasons(IEnumerable<ShowAndSeasons> showsAndSeasons);
        ITraktSyncWatchlistPostBuilder WithShowsAndSeasons(IEnumerable<ShowIdsAndSeasons> showIdsAndSeasons);
        ITraktSyncWatchlistPostBuilder WithShowsWithNotesAndSeasons(IEnumerable<ShowWithNotesAndSeasons> showsWithNotesAndSeasons);
        ITraktSyncWatchlistPostBuilder WithShowsWithNotesAndSeasons(IEnumerable<ShowIdsWithNotesAndSeasons> showIdsWithNotesAndSeasons);

        ITraktSyncWatchlistPostBuilder WithSeason(ITraktSeason season);
        ITraktSyncWatchlistPostBuilder WithSeason(ITraktSeasonIds seasonIds);
        ITraktSyncWatchlistPostBuilder WithSeasonWithNotes(ITraktSeason season, string notes);
        ITraktSyncWatchlistPostBuilder WithSeasonWithNotes(SeasonWithNotes seasonWithNotes);
        ITraktSyncWatchlistPostBuilder WithSeasonWithNotes(ITraktSeasonIds seasonIds, string notes);
        ITraktSyncWatchlistPostBuilder WithSeasonWithNotes(SeasonIdsWithNotes seasonIdsWithNotes);

        ITraktSyncWatchlistPostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons);
        ITraktSyncWatchlistPostBuilder WithSeasons(IEnumerable<ITraktSeasonIds> seasonIds);
        ITraktSyncWatchlistPostBuilder WithSeasonsWithNotes(IEnumerable<SeasonWithNotes> seasonsWithNotes);
        ITraktSyncWatchlistPostBuilder WithSeasonsWithNotes(IEnumerable<SeasonIdsWithNotes> seasonIdsWithNotes);

        ITraktSyncWatchlistPostBuilder WithEpisode(ITraktEpisode episode);
        ITraktSyncWatchlistPostBuilder WithEpisode(ITraktEpisodeIds episodeIds);
        ITraktSyncWatchlistPostBuilder WithEpisodeWithNotes(ITraktEpisode episode, string notes);
        ITraktSyncWatchlistPostBuilder WithEpisodeWithNotes(EpisodeWithNotes episodeWithNotes);
        ITraktSyncWatchlistPostBuilder WithEpisodeWithNotes(ITraktEpisodeIds episodeIds, string notes);
        ITraktSyncWatchlistPostBuilder WithEpisodeWithNotes(EpisodeIdsWithNotes episodeIdsWithNotes);

        ITraktSyncWatchlistPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes);
        ITraktSyncWatchlistPostBuilder WithEpisodes(IEnumerable<ITraktEpisodeIds> episodeIds);
        ITraktSyncWatchlistPostBuilder WithEpisodesWithNotes(IEnumerable<EpisodeWithNotes> episodesWithNotes);
        ITraktSyncWatchlistPostBuilder WithEpisodesWithNotes(IEnumerable<EpisodeIdsWithNotes> episodeIdsWithNotes);

        ITraktSyncWatchlistPost Build();
    }
}
