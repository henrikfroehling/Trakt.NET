namespace TraktNet.Objects.Post
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Ratings;

    public interface ITraktSyncRatingsPostBuilder
    {
        ITraktSyncRatingsPostBuilder WithMovie(ITraktMovie movie, TraktPostRating rating);
        ITraktSyncRatingsPostBuilder WithMovie(RatingsMovie movieWithRating);
        ITraktSyncRatingsPostBuilder WithMovie(ITraktMovieIds movieIds, TraktPostRating rating);
        ITraktSyncRatingsPostBuilder WithMovie(RatingsMovieIds movieIdsWithRating);
        ITraktSyncRatingsPostBuilder WithMovieRatedAt(ITraktMovie movie, TraktPostRating rating, DateTime ratedAt);
        ITraktSyncRatingsPostBuilder WithMovieRatedAt(RatingsMovieRatedAt movieWithRatingRatedAt);
        ITraktSyncRatingsPostBuilder WithMovieRatedAt(ITraktMovieIds movieIds, TraktPostRating rating, DateTime ratedAt);
        ITraktSyncRatingsPostBuilder WithMovieRatedAt(RatingsMovieIdsRatedAt movieIdsWithRatingsRatedAt);

        ITraktSyncRatingsPostBuilder WithMovies(IEnumerable<RatingsMovie> moviesWithRating);
        ITraktSyncRatingsPostBuilder WithMovies(IEnumerable<RatingsMovieIds> movieIdsWithRating);
        ITraktSyncRatingsPostBuilder WithMoviesRatedAt(IEnumerable<RatingsMovieRatedAt> moviesWithRatingRatedAt);
        ITraktSyncRatingsPostBuilder WithMoviesRatedAt(IEnumerable<RatingsMovieIdsRatedAt> movieIdsWithRatingRatedAt);

        ITraktSyncRatingsPostBuilder WithShow(ITraktShow show, TraktPostRating rating);
        ITraktSyncRatingsPostBuilder WithShow(RatingsShow showWitRating);
        ITraktSyncRatingsPostBuilder WithShow(ITraktShowIds showIds, TraktPostRating rating);
        ITraktSyncRatingsPostBuilder WithShow(RatingsShowIds showIdsWithRating);
        ITraktSyncRatingsPostBuilder WithShowRatedAt(ITraktShow show, TraktPostRating rating, DateTime ratedAt);
        ITraktSyncRatingsPostBuilder WithShowRatedAt(RatingsShowRatedAt showWithRatingRatedAt);
        ITraktSyncRatingsPostBuilder WithShowRatedAt(ITraktShowIds showIds, TraktPostRating rating, DateTime ratedAt);
        ITraktSyncRatingsPostBuilder WithShowRatedAt(RatingsShowIdsRatedAt showIdsWithRatingRatedAt);

        ITraktSyncRatingsPostBuilder WithShows(IEnumerable<RatingsShow> showsWithRating);
        ITraktSyncRatingsPostBuilder WithShows(IEnumerable<RatingsShowIds> showIdsWithRating);
        ITraktSyncRatingsPostBuilder WithShowsRatedAt(IEnumerable<RatingsShowRatedAt> showsWithRatingRatedAt);
        ITraktSyncRatingsPostBuilder WithShowsRatedAt(IEnumerable<RatingsShowIdsRatedAt> showIdsWithRatingRatedAt);

        ITraktSyncRatingsPostBuilder WithShowAndSeasons(ITraktShow show, PostRatingsSeasons seasons);
        ITraktSyncRatingsPostBuilder WithShowAndSeasons(RatingsShowAndSeasons showAndSeasons);
        ITraktSyncRatingsPostBuilder WithShowAndSeasons(ITraktShowIds showIds, PostRatingsSeasons seasons);
        ITraktSyncRatingsPostBuilder WithShowAndSeasons(RatingsShowIdsAndSeasons showIdsAndSeasons);

        ITraktSyncRatingsPostBuilder WithShowsAndSeasons(IEnumerable<RatingsShowAndSeasons> showsAndSeasons);
        ITraktSyncRatingsPostBuilder WithShowsAndSeasons(IEnumerable<RatingsShowIdsAndSeasons> showIdsAndSeasons);

        ITraktSyncRatingsPostBuilder WithSeason(ITraktSeason season, TraktPostRating rating);
        ITraktSyncRatingsPostBuilder WithSeason(RatingsSeason seasonWithRating);
        ITraktSyncRatingsPostBuilder WithSeason(ITraktSeasonIds seasonIds, TraktPostRating rating);
        ITraktSyncRatingsPostBuilder WithSeason(RatingsSeasonIds seasonIdsWithRating);
        ITraktSyncRatingsPostBuilder WithSeasonRatedAt(ITraktSeason season, TraktPostRating rating, DateTime ratedAt);
        ITraktSyncRatingsPostBuilder WithSeasonRatedAt(RatingsSeasonRatedAt seasonWithRatingRatedAt);
        ITraktSyncRatingsPostBuilder WithSeasonRatedAt(ITraktSeasonIds seasonIds, TraktPostRating rating, DateTime ratedAt);
        ITraktSyncRatingsPostBuilder WithSeasonRatedAt(RatingsSeasonIdsRatedAt seasonIdsWithRatingRatedAt);

        ITraktSyncRatingsPostBuilder WithSeasons(IEnumerable<RatingsSeason> seasonsWithRating);
        ITraktSyncRatingsPostBuilder WithSeasons(IEnumerable<RatingsSeasonIds> seasonIdsWithRating);
        ITraktSyncRatingsPostBuilder WithSeasonsRatedAt(IEnumerable<RatingsSeasonRatedAt> seasonsWithRatingRatedAt);
        ITraktSyncRatingsPostBuilder WithSeasonsRatedAt(IEnumerable<RatingsSeasonIdsRatedAt> seasonIdsWithRatingRatedAt);

        ITraktSyncRatingsPostBuilder WithEpisode(ITraktEpisode episode, TraktPostRating rating);
        ITraktSyncRatingsPostBuilder WithEpisode(RatingsEpisode episodeWithRating);
        ITraktSyncRatingsPostBuilder WithEpisode(ITraktEpisodeIds episodeIds, TraktPostRating rating);
        ITraktSyncRatingsPostBuilder WithEpisode(RatingsEpisodeIds episodeIdsWithRating);
        ITraktSyncRatingsPostBuilder WithEpisodeRatedAt(ITraktEpisode episode, TraktPostRating rating, DateTime ratedAt);
        ITraktSyncRatingsPostBuilder WithEpisodeRatedAt(RatingsEpisodeRatedAt episodeWithRatingRatedAt);
        ITraktSyncRatingsPostBuilder WithEpisodeRatedAt(ITraktEpisodeIds episodeIds, TraktPostRating rating, DateTime ratedAt);
        ITraktSyncRatingsPostBuilder WithEpisodeRatedAt(RatingsEpisodeIdsRatedAt episodeIdsWithRatingRatedAt);

        ITraktSyncRatingsPostBuilder WithEpisodes(IEnumerable<RatingsEpisode> episodesWithRating);
        ITraktSyncRatingsPostBuilder WithEpisodes(IEnumerable<RatingsEpisodeIds> episodeIdsWithRating);
        ITraktSyncRatingsPostBuilder WithEpisodesRatedAt(IEnumerable<RatingsEpisodeRatedAt> episodesWithRatingRatedAt);
        ITraktSyncRatingsPostBuilder WithEpisodesRatedAt(IEnumerable<RatingsEpisodeIdsRatedAt> episodeIdsWithRatingRatedAt);

        ITraktSyncRatingsPost Build();
    }
}
