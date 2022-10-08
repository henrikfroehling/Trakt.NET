namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post;
    using TraktNet.Objects.Post.Syncs.Ratings;

    public interface ITraktSyncRatingsPostBuilder
    {
        /// <summary>Adds the given <paramref name="movie"/> to the builder.</summary>
        /// <param name="movie">The <see cref="ITraktMovie"/> which will be added.</param>
        /// <param name="rating">The <see cref="TraktPostRating"/> for the given <paramref name="movie"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithMovie(ITraktMovie movie, TraktPostRating rating);

        /// <summary>Adds the given <paramref name="movieWithRating"/> to the builder.</summary>
        /// <param name="movieWithRating">The <see cref="RatingsMovie"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieWithRating"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithMovie(RatingsMovie movieWithRating);

        /// <summary>Adds the given <paramref name="movieIds"/> to the builder.</summary>
        /// <param name="movieIds">The <see cref="ITraktMovieIds"/> which will be added.</param>
        /// <param name="rating">The <see cref="TraktPostRating"/> for the given <paramref name="movieIds"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithMovie(ITraktMovieIds movieIds, TraktPostRating rating);

        /// <summary>Adds the given <paramref name="movieIdsWithRating"/> to the builder.</summary>
        /// <param name="movieIdsWithRating">The <see cref="RatingsMovieIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIdsWithRating"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithMovie(RatingsMovieIds movieIdsWithRating);

        /// <summary>Adds the given <paramref name="movie"/> to the builder.</summary>
        /// <param name="movie">The <see cref="ITraktMovie"/> which will be added.</param>
        /// <param name="rating">The <see cref="TraktPostRating"/> for the given <paramref name="movie"/>.</param>
        /// <param name="ratedAt">The UTC datetime when the <paramref name="movie"/> was rated.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithMovieRatedAt(ITraktMovie movie, TraktPostRating rating, DateTime ratedAt);

        /// <summary>Adds the given <paramref name="movieWithRatingRatedAt"/> to the builder.</summary>
        /// <param name="movieWithRatingRatedAt">The <see cref="RatingsMovieRatedAt"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieWithRatingRatedAt"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithMovieRatedAt(RatingsMovieRatedAt movieWithRatingRatedAt);

        /// <summary>Adds the given <paramref name="movieIds"/> to the builder.</summary>
        /// <param name="movieIds">The <see cref="ITraktMovieIds"/> which will be added.</param>
        /// <param name="rating">The <see cref="TraktPostRating"/> for the given <paramref name="movieIds"/>.</param>
        /// <param name="ratedAt">The UTC datetime when the <paramref name="movieIds"/> was rated.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithMovieRatedAt(ITraktMovieIds movieIds, TraktPostRating rating, DateTime ratedAt);

        /// <summary>Adds the given <paramref name="movieIdsWithRatingsRatedAt"/> to the builder.</summary>
        /// <param name="movieIdsWithRatingsRatedAt">The <see cref="RatingsMovieIdsRatedAt"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIdsWithRatingsRatedAt"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithMovieRatedAt(RatingsMovieIdsRatedAt movieIdsWithRatingsRatedAt);

        /// <summary>Adds the given <paramref name="moviesWithRating"/> collection to the builder.</summary>
        /// <param name="moviesWithRating">A collection of <see cref="RatingsMovie"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="moviesWithRating"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithMovies(IEnumerable<RatingsMovie> moviesWithRating);

        /// <summary>Adds the given <paramref name="movieIdsWithRating"/> collection to the builder.</summary>
        /// <param name="movieIdsWithRating">A collection of <see cref="RatingsMovieIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIdsWithRating"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithMovies(IEnumerable<RatingsMovieIds> movieIdsWithRating);

        /// <summary>Adds the given <paramref name="moviesWithRatingRatedAt"/> collection to the builder.</summary>
        /// <param name="moviesWithRatingRatedAt">A collection of <see cref="RatingsMovieRatedAt"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="moviesWithRatingRatedAt"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithMoviesRatedAt(IEnumerable<RatingsMovieRatedAt> moviesWithRatingRatedAt);

        /// <summary>Adds the given <paramref name="movieIdsWithRatingRatedAt"/> collection to the builder.</summary>
        /// <param name="movieIdsWithRatingRatedAt">A collection of <see cref="RatingsMovieIdsRatedAt"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIdsWithRatingRatedAt"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithMoviesRatedAt(IEnumerable<RatingsMovieIdsRatedAt> movieIdsWithRatingRatedAt);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="rating">The <see cref="TraktPostRating"/> for the given <paramref name="show"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithShow(ITraktShow show, TraktPostRating rating);

        /// <summary>Adds the given <paramref name="showWitRating"/> to the builder.</summary>
        /// <param name="showWitRating">The <see cref="RatingsShow"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showWitRating"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithShow(RatingsShow showWitRating);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="rating">The <see cref="TraktPostRating"/> for the given <paramref name="showIds"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithShow(ITraktShowIds showIds, TraktPostRating rating);

        /// <summary>Adds the given <paramref name="showIdsWithRating"/> to the builder.</summary>
        /// <param name="showIdsWithRating">The <see cref="RatingsShowIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithRating"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithShow(RatingsShowIds showIdsWithRating);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="rating">The <see cref="TraktPostRating"/> for the given <paramref name="show"/>.</param>
        /// <param name="ratedAt">The UTC datetime when the <paramref name="show"/> was rated.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithShowRatedAt(ITraktShow show, TraktPostRating rating, DateTime ratedAt);

        /// <summary>Adds the given <paramref name="showWithRatingRatedAt"/> to the builder.</summary>
        /// <param name="showWithRatingRatedAt">The <see cref="RatingsShowRatedAt"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showWithRatingRatedAt"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithShowRatedAt(RatingsShowRatedAt showWithRatingRatedAt);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="rating">The <see cref="TraktPostRating"/> for the given <paramref name="showIds"/>.</param>
        /// <param name="ratedAt">The UTC datetime when the <paramref name="showIds"/> was rated.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithShowRatedAt(ITraktShowIds showIds, TraktPostRating rating, DateTime ratedAt);

        /// <summary>Adds the given <paramref name="showIdsWithRatingRatedAt"/> to the builder.</summary>
        /// <param name="showIdsWithRatingRatedAt">The <see cref="RatingsShowIdsRatedAt"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithRatingRatedAt"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithShowRatedAt(RatingsShowIdsRatedAt showIdsWithRatingRatedAt);

        /// <summary>Adds the given <paramref name="showsWithRating"/> collection to the builder.</summary>
        /// <param name="showsWithRating">A collection of <see cref="RatingsShow"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showsWithRating"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithShows(IEnumerable<RatingsShow> showsWithRating);

        /// <summary>Adds the given <paramref name="showIdsWithRating"/> collection to the builder.</summary>
        /// <param name="showIdsWithRating">A collection of <see cref="RatingsShowIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithRating"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithShows(IEnumerable<RatingsShowIds> showIdsWithRating);

        /// <summary>Adds the given <paramref name="showsWithRatingRatedAt"/> collection to the builder.</summary>
        /// <param name="showsWithRatingRatedAt">A collection of <see cref="RatingsShowRatedAt"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showsWithRatingRatedAt"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithShowsRatedAt(IEnumerable<RatingsShowRatedAt> showsWithRatingRatedAt);

        /// <summary>Adds the given <paramref name="showIdsWithRatingRatedAt"/> collection to the builder.</summary>
        /// <param name="showIdsWithRatingRatedAt">A collection of <see cref="RatingsShowIdsRatedAt"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithRatingRatedAt"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithShowsRatedAt(IEnumerable<RatingsShowIdsRatedAt> showIdsWithRatingRatedAt);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="seasons">The <see cref="PostRatingsSeasons"/> for the <paramref name="show"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithShowAndSeasons(ITraktShow show, PostRatingsSeasons seasons);

        /// <summary>Adds the given <paramref name="showAndSeasons"/> to the builder.</summary>
        /// <param name="showAndSeasons">The <see cref="RatingsShowAndSeasons"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showAndSeasons"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithShowAndSeasons(RatingsShowAndSeasons showAndSeasons);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="seasons">The <see cref="PostRatingsSeasons"/> for the <paramref name="showIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithShowAndSeasons(ITraktShowIds showIds, PostRatingsSeasons seasons);

        /// <summary>Adds the given <paramref name="showIdsAndSeasons"/> to the builder.</summary>
        /// <param name="showIdsAndSeasons">The <see cref="RatingsShowIdsAndSeasons"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsAndSeasons"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithShowAndSeasons(RatingsShowIdsAndSeasons showIdsAndSeasons);

        /// <summary>Adds the given <paramref name="showsAndSeasons"/> collection to the builder.</summary>
        /// <param name="showsAndSeasons">A collection of <see cref="RatingsShowAndSeasons"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showsAndSeasons"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithShowsAndSeasons(IEnumerable<RatingsShowAndSeasons> showsAndSeasons);

        /// <summary>Adds the given <paramref name="showIdsAndSeasons"/> collection to the builder.</summary>
        /// <param name="showIdsAndSeasons">A collection of <see cref="RatingsShowIdsAndSeasons"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsAndSeasons"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithShowsAndSeasons(IEnumerable<RatingsShowIdsAndSeasons> showIdsAndSeasons);

        /// <summary>Adds the given <paramref name="season"/> to the builder.</summary>
        /// <param name="season">The <see cref="ITraktSeason"/> which will be added.</param>
        /// <param name="rating">The <see cref="TraktPostRating"/> for the given <paramref name="season"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithSeason(ITraktSeason season, TraktPostRating rating);

        /// <summary>Adds the given <paramref name="seasonWithRating"/> to the builder.</summary>
        /// <param name="seasonWithRating">The <see cref="RatingsSeason"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonWithRating"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithSeason(RatingsSeason seasonWithRating);

        /// <summary>Adds the given <paramref name="seasonIds"/> to the builder.</summary>
        /// <param name="seasonIds">The <see cref="ITraktSeasonIds"/> which will be added.</param>
        /// <param name="rating">The <see cref="TraktPostRating"/> for the given <paramref name="seasonIds"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithSeason(ITraktSeasonIds seasonIds, TraktPostRating rating);

        /// <summary>Adds the given <paramref name="seasonIdsWithRating"/> to the builder.</summary>
        /// <param name="seasonIdsWithRating">The <see cref="RatingsSeasonIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIdsWithRating"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithSeason(RatingsSeasonIds seasonIdsWithRating);

        /// <summary>Adds the given <paramref name="season"/> to the builder.</summary>
        /// <param name="season">The <see cref="ITraktSeason"/> which will be added.</param>
        /// <param name="rating">The <see cref="TraktPostRating"/> for the given <paramref name="season"/>.</param>
        /// <param name="ratedAt">The UTC datetime when the <paramref name="season"/> was rated.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithSeasonRatedAt(ITraktSeason season, TraktPostRating rating, DateTime ratedAt);

        /// <summary>Adds the given <paramref name="seasonWithRatingRatedAt"/> to the builder.</summary>
        /// <param name="seasonWithRatingRatedAt">The <see cref="RatingsSeasonRatedAt"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonWithRatingRatedAt"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithSeasonRatedAt(RatingsSeasonRatedAt seasonWithRatingRatedAt);

        /// <summary>Adds the given <paramref name="seasonIds"/> to the builder.</summary>
        /// <param name="seasonIds">The <see cref="ITraktSeasonIds"/> which will be added.</param>
        /// <param name="rating">The <see cref="TraktPostRating"/> for the given <paramref name="seasonIds"/>.</param>
        /// <param name="ratedAt">The UTC datetime when the <paramref name="seasonIds"/> was rated.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithSeasonRatedAt(ITraktSeasonIds seasonIds, TraktPostRating rating, DateTime ratedAt);

        /// <summary>Adds the given <paramref name="seasonIdsWithRatingRatedAt"/> to the builder.</summary>
        /// <param name="seasonIdsWithRatingRatedAt">The <see cref="RatingsSeasonIdsRatedAt"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIdsWithRatingRatedAt"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithSeasonRatedAt(RatingsSeasonIdsRatedAt seasonIdsWithRatingRatedAt);

        /// <summary>Adds the given <paramref name="seasonsWithRating"/> collection to the builder.</summary>
        /// <param name="seasonsWithRating">A collection of <see cref="RatingsSeason"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonsWithRating"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithSeasons(IEnumerable<RatingsSeason> seasonsWithRating);

        /// <summary>Adds the given <paramref name="seasonIdsWithRating"/> collection to the builder.</summary>
        /// <param name="seasonIdsWithRating">A collection of <see cref="RatingsSeasonIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIdsWithRating"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithSeasons(IEnumerable<RatingsSeasonIds> seasonIdsWithRating);

        /// <summary>Adds the given <paramref name="seasonsWithRatingRatedAt"/> collection to the builder.</summary>
        /// <param name="seasonsWithRatingRatedAt">A collection of <see cref="RatingsSeasonRatedAt"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonsWithRatingRatedAt"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithSeasonsRatedAt(IEnumerable<RatingsSeasonRatedAt> seasonsWithRatingRatedAt);

        /// <summary>Adds the given <paramref name="seasonIdsWithRatingRatedAt"/> collection to the builder.</summary>
        /// <param name="seasonIdsWithRatingRatedAt">A collection of <see cref="RatingsSeasonIdsRatedAt"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIdsWithRatingRatedAt"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithSeasonsRatedAt(IEnumerable<RatingsSeasonIdsRatedAt> seasonIdsWithRatingRatedAt);

        /// <summary>Adds the given <paramref name="episode"/> to the builder.</summary>
        /// <param name="episode">The <see cref="ITraktEpisode"/> which will be added.</param>
        /// <param name="rating">The <see cref="TraktPostRating"/> for the given <paramref name="episode"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithEpisode(ITraktEpisode episode, TraktPostRating rating);

        /// <summary>Adds the given <paramref name="episodeWithRating"/> to the builder.</summary>
        /// <param name="episodeWithRating">The <see cref="RatingsEpisode"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeWithRating"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithEpisode(RatingsEpisode episodeWithRating);

        /// <summary>Adds the given <paramref name="episodeIds"/> to the builder.</summary>
        /// <param name="episodeIds">The <see cref="ITraktEpisodeIds"/> which will be added.</param>
        /// <param name="rating">The <see cref="TraktPostRating"/> for the given <paramref name="episodeIds"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIds"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithEpisode(ITraktEpisodeIds episodeIds, TraktPostRating rating);

        /// <summary>Adds the given <paramref name="episodeIdsWithRating"/> to the builder.</summary>
        /// <param name="episodeIdsWithRating">The <see cref="RatingsEpisodeIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIdsWithRating"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithEpisode(RatingsEpisodeIds episodeIdsWithRating);

        /// <summary>Adds the given <paramref name="episode"/> to the builder.</summary>
        /// <param name="episode">The <see cref="ITraktEpisode"/> which will be added.</param>
        /// <param name="rating">The <see cref="TraktPostRating"/> for the given <paramref name="episode"/>.</param>
        /// <param name="ratedAt">The UTC datetime when the <paramref name="episode"/> was rated.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithEpisodeRatedAt(ITraktEpisode episode, TraktPostRating rating, DateTime ratedAt);

        /// <summary>Adds the given <paramref name="episodeWithRatingRatedAt"/> to the builder.</summary>
        /// <param name="episodeWithRatingRatedAt">The <see cref="RatingsEpisodeRatedAt"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeWithRatingRatedAt"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithEpisodeRatedAt(RatingsEpisodeRatedAt episodeWithRatingRatedAt);

        /// <summary>Adds the given <paramref name="episodeIds"/> to the builder.</summary>
        /// <param name="episodeIds">The <see cref="ITraktEpisodeIds"/> which will be added.</param>
        /// <param name="rating">The <see cref="TraktPostRating"/> for the given <paramref name="episodeIds"/>.</param>
        /// <param name="ratedAt">The UTC datetime when the <paramref name="episodeIds"/> was rated.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIds"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithEpisodeRatedAt(ITraktEpisodeIds episodeIds, TraktPostRating rating, DateTime ratedAt);

        /// <summary>Adds the given <paramref name="episodeIdsWithRatingRatedAt"/> to the builder.</summary>
        /// <param name="episodeIdsWithRatingRatedAt">The <see cref="RatingsEpisodeIdsRatedAt"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIdsWithRatingRatedAt"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithEpisodeRatedAt(RatingsEpisodeIdsRatedAt episodeIdsWithRatingRatedAt);

        /// <summary>Adds the given <paramref name="episodesWithRating"/> to the builder.</summary>
        /// <param name="episodesWithRating">The <see cref="RatingsEpisode"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodesWithRating"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithEpisodes(IEnumerable<RatingsEpisode> episodesWithRating);

        /// <summary>Adds the given <paramref name="episodeIdsWithRating"/> to the builder.</summary>
        /// <param name="episodeIdsWithRating">The <see cref="RatingsEpisodeIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIdsWithRating"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithEpisodes(IEnumerable<RatingsEpisodeIds> episodeIdsWithRating);

        /// <summary>Adds the given <paramref name="episodesWithRatingRatedAt"/> to the builder.</summary>
        /// <param name="episodesWithRatingRatedAt">The <see cref="RatingsEpisodeRatedAt"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodesWithRatingRatedAt"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithEpisodesRatedAt(IEnumerable<RatingsEpisodeRatedAt> episodesWithRatingRatedAt);

        /// <summary>Adds the given <paramref name="episodeIdsWithRatingRatedAt"/> to the builder.</summary>
        /// <param name="episodeIdsWithRatingRatedAt">The <see cref="RatingsEpisodeIdsRatedAt"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncRatingsPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIdsWithRatingRatedAt"/> is null.</exception>
        ITraktSyncRatingsPostBuilder WithEpisodesRatedAt(IEnumerable<RatingsEpisodeIdsRatedAt> episodeIdsWithRatingRatedAt);

        /// <summary>Creates a new <see cref="ITraktSyncRatingsPost" /> instance with the added movies, shows, seasons and episodes.</summary>
        /// <returns>A new <see cref="ITraktSyncRatingsPost" /> instance with the added movies, shows, seasons and episodes.</returns>
        ITraktSyncRatingsPost Build();
    }
}
