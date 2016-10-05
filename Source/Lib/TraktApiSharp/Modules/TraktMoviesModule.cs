namespace TraktApiSharp.Modules
{
    using Attributes;
    using Enums;
    using Extensions;
    using Objects.Basic;
    using Objects.Get.Movies;
    using Objects.Get.Movies.Common;
    using Objects.Get.Users;
    using Requests;
    using Requests.Params;
    using Requests.WithoutOAuth.Movies;
    using Requests.WithoutOAuth.Movies.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to movies.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/movies">"Trakt API Doc - Movies"</a> section.
    /// </para>
    /// </summary>
    public class TraktMoviesModule : TraktBaseModule
    {
        internal TraktMoviesModule(TraktClient client) : base(client) { }

        /// <summary>
        /// Gets a <see cref="TraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/summary/get-a-movie">"Trakt API Doc - Movies: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleMoviesAsync(TraktMultipleObjectsQueryParams)" />.</para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="TraktMovieIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movie should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>An <see cref="TraktMovie" /> instance with the queried movie's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktMovie> GetMovieAsync([NotNull] string movieIdOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            Validate(movieIdOrSlug);

            return await QueryAsync(new TraktMovieSummaryRequest(Client)
            {
                Id = movieIdOrSlug,
                ExtendedInfo = extendedInfo
            });
        }

        /// <summary>
        /// Gets multiple different <see cref="TraktMovie" />s at once with the given Trakt-Ids or -Slugs.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/summary/get-a-movie">"Trakt API Doc - Movies: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMovieAsync(string, TraktExtendedInfo)" />.</para>
        /// </summary>
        /// <param name="moviesQueryParams">A list of movie ids and optional extended infos. See also <seealso cref="TraktMultipleObjectsQueryParams" />.</param>
        /// <returns>A list of <see cref="TraktMovie" /> instances with the data of each queried movie.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if one of the given movie ids is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktMovie>> GetMultipleMoviesAsync(TraktMultipleObjectsQueryParams moviesQueryParams)
        {
            if (moviesQueryParams == null || moviesQueryParams.Count <= 0)
                return new List<TraktMovie>();

            var tasks = new List<Task<TraktMovie>>();

            foreach (var queryParam in moviesQueryParams)
            {
                Task<TraktMovie> task = GetMovieAsync(queryParam.Id, queryParam.ExtendedInfo);
                tasks.Add(task);
            }

            var movies = await Task.WhenAll(tasks);
            return movies.ToList();
        }

        /// <summary>
        /// Gets all title aliases for a <see cref="TraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/aliases/get-all-movie-aliases">"Trakt API Doc - Movies: Aliases"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="TraktMovieIds" />.</param>
        /// <returns>A list of <see cref="TraktMovieAlias" /> instances, each containing a title and country code.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktMovieAlias>> GetMovieAliasesAsync([NotNull] string movieIdOrSlug)
        {
            Validate(movieIdOrSlug);

            return await QueryAsync(new TraktMovieAliasesRequest(Client) { Id = movieIdOrSlug });
        }

        /// <summary>
        /// Gets all releases for a <see cref="TraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/releases/get-all-movie-releases">"Trakt API Doc - Movies: Releases"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="TraktMovieIds" />.</param>
        /// <returns>A list of <see cref="TraktMovieRelease" /> instances, each containing a country code, certification, release date and a note.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktMovieRelease>> GetMovieReleasesAsync([NotNull] string movieIdOrSlug)
        {
            Validate(movieIdOrSlug);

            return await QueryAsync(new TraktMovieReleasesRequest(Client) { Id = movieIdOrSlug });
        }

        /// <summary>
        /// Gets a single release for a <see cref="TraktMovie" /> with the given Trakt-Id or -Slug and the given country code.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/releases/get-all-movie-releases">"Trakt API Doc - Movies: Releases"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="TraktMovieIds" />.</param>
        /// <param name="countryCode">The 2 letter country code, for which a translation should be queried.</param>
        /// <returns>
        /// An <see cref="TraktMovieTranslation" /> instance, containing a country code, certification, release date and a note
        /// for the movie with the given movieIdOrSlug.
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movieIdOrSlug is null, empty or contains spaces.
        /// Thronw, if the given country code is null, empty, contains spaces or doesn't have the length 2.
        /// </exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktMovieRelease> GetMovieSingleReleaseAsync([NotNull] string movieIdOrSlug, [NotNull] string countryCode)
        {
            Validate(movieIdOrSlug, countryCode);

            return await QueryAsync(new TraktMovieSingleReleaseRequest(Client)
            {
                Id = movieIdOrSlug,
                LanguageCode = countryCode
            });
        }

        /// <summary>
        /// Gets all translations for a <see cref="TraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/translations/get-all-movie-translations">"Trakt API Doc - Movies: Translations"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="TraktMovieIds" />.</param>
        /// <returns>A list of <see cref="TraktMovieTranslation" /> instances, each containing a title, tagline, overview and language code.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktMovieTranslation>> GetMovieTranslationsAsync([NotNull] string movieIdOrSlug)
        {
            Validate(movieIdOrSlug);

            return await QueryAsync(new TraktMovieTranslationsRequest(Client) { Id = movieIdOrSlug });
        }

        /// <summary>
        /// Gets a single translation for a <see cref="TraktMovie" /> with the given Trakt-Id or -Slug and the given language code.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/translations/get-all-movie-translations">"Trakt API Doc - Movies: Translations"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="TraktMovieIds" />.</param>
        /// <param name="languageCode">The 2 letter language code, for which a translation should be queried.</param>
        /// <returns>
        /// An <see cref="TraktMovieTranslation" /> instance, containing a translated title, tagline, overview and language code
        /// for the movie with the given movieIdOrSlug.
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movieIdOrSlug is null, empty or contains spaces.
        /// Thronw, if the given language code is null, empty, contains spaces or doesn't have the length 2.
        /// </exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktMovieTranslation> GetMovieSingleTranslationAsync([NotNull] string movieIdOrSlug, [NotNull] string languageCode)
        {
            Validate(movieIdOrSlug, languageCode);

            return await QueryAsync(new TraktMovieSingleTranslationRequest(Client)
            {
                Id = movieIdOrSlug,
                LanguageCode = languageCode
            });
        }

        /// <summary>
        /// Gets top level comments for a <see cref="TraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/translations/get-all-movie-comments">"Trakt API Doc - Movies: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="TraktMovieIds" />.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="page">The page of the comments list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of comments for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktComment}"/> instance containing the queried movie comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktComment>> GetMovieCommentsAsync([NotNull] string movieIdOrSlug,
                                                                                         TraktCommentSortOrder commentSortOrder = null,
                                                                                         int? page = null, int? limitPerPage = null)
        {
            Validate(movieIdOrSlug);

            return await QueryAsync(new TraktMovieCommentsRequest(Client)
            {
                Id = movieIdOrSlug,
                Sorting = commentSortOrder,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });
        }

        /// <summary>
        /// Gets all people for a <see cref="TraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/people/get-all-people-for-a-movie">"Trakt API Doc - Movies: People"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="TraktMovieIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>An <see cref="TraktCastAndCrew" /> instance, containing the cast and crew for a movie with the given movieIdOrSlug.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktCastAndCrew> GetMoviePeopleAsync([NotNull] string movieIdOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            Validate(movieIdOrSlug);

            return await QueryAsync(new TraktMoviePeopleRequest(Client) { Id = movieIdOrSlug, ExtendedInfo = extendedInfo });
        }

        /// <summary>
        /// Gets the ratings for a <see cref="TraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/ratings/get-movie-ratings">"Trakt API Doc - Movies: Ratings"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="TraktMovieIds" />.</param>
        /// <returns>An <see cref="TraktRating" /> instance, containing the ratings for a movie with the given movieIdOrSlug.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktRating> GetMovieRatingsAsync([NotNull] string movieIdOrSlug)
        {
            Validate(movieIdOrSlug);

            return await QueryAsync(new TraktMovieRatingsRequest(Client) { Id = movieIdOrSlug });
        }

        /// <summary>
        /// Gets related movies for a <see cref="TraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/related/get-related-movies">"Trakt API Doc - Movies: Related"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="TraktMovieIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="page">The page of the related movies list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of related movies for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktMovie}"/> instance containing the queried related movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="Objects.Get.Shows.TraktShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktMovie>> GetMovieRelatedMoviesAsync([NotNull] string movieIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                                            int? page = null, int? limitPerPage = null)
        {
            Validate(movieIdOrSlug);

            return await QueryAsync(new TraktMovieRelatedMoviesRequest(Client)
            {
                Id = movieIdOrSlug,
                ExtendedInfo = extendedInfo,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });
        }

        /// <summary>
        /// Gets the statistics for a <see cref="TraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/stats/get-movie-stats">"Trakt API Doc - Movies: Stats"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="TraktMovieIds" />.</param>
        /// <returns>An <see cref="TraktStatistics" /> instance, containing the statistics for a movie with the given movieIdOrSlug.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktStatistics> GetMovieStatisticsAsync([NotNull] string movieIdOrSlug)
        {
            Validate(movieIdOrSlug);

            return await QueryAsync(new TraktMovieStatisticsRequest(Client) { Id = movieIdOrSlug });
        }

        /// <summary>
        /// Gets all watching users of a <see cref="TraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/watching/get-users-watching-right-now">"Trakt API Doc - Movies: Watching"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="TraktMovieIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the users should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>A list of <see cref="TraktUser" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktUser>> GetMovieWatchingUsersAsync([NotNull] string movieIdOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            Validate(movieIdOrSlug);

            return await QueryAsync(new TraktMovieWatchingUsersRequest(Client) { Id = movieIdOrSlug, ExtendedInfo = extendedInfo });
        }

        /// <summary>
        /// Gets trending movies.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/trending/get-trending-movies">"Trakt API Doc - Movies: Trending"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktMovieFilter" />.</param>
        /// <param name="page">The page of the trending movies list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum item count of trending movies for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktTrendingMovie}"/> instance containing the queried trending movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktTrendingMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktTrendingMovie>> GetTrendingMoviesAsync(TraktExtendedInfo extendedInfo = null,
                                                                                    TraktMovieFilter filter = null,
                                                                                    int? page = null, int? limitPerPage = null)
            => await QueryAsync(new TraktMoviesTrendingRequest(Client)
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });

        /// <summary>
        /// Gets popular movies.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/popular/get-popular-movies">"Trakt API Doc - Movies: Popular"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktMovieFilter" />.</param>
        /// <param name="page">The page of the popular movies list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum item count of popular movies for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktMovie}"/> instance containing the queried popular movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktMovie>> GetPopularMoviesAsync(TraktExtendedInfo extendedInfo = null,
                                                                           TraktMovieFilter filter = null,
                                                                           int? page = null, int? limitPerPage = null)
            => await QueryAsync(new TraktMoviesPopularRequest(Client)
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });

        /// <summary>
        /// Gets the most played movies.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/played/get-the-most-played-movies">"Trakt API Doc - Movies: Played"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="period">The time period, for which the most played movies should be queried. See also <seealso cref="TraktTimePeriod" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktMovieFilter" />.</param>
        /// <param name="page">The page of the most played movies list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum item count of most played movies for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktMostPlayedMovie}"/> instance containing the queried most played movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktMostPlayedMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktMostPlayedMovie>> GetMostPlayedMoviesAsync(TraktTimePeriod period = null,
                                                                                        TraktExtendedInfo extendedInfo = null,
                                                                                        TraktMovieFilter filter = null,
                                                                                        int? page = null, int? limitPerPage = null)
            => await QueryAsync(new TraktMoviesMostPlayedRequest(Client)
            {
                Period = period,
                ExtendedInfo = extendedInfo,
                Filter = filter,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });

        /// <summary>
        /// Gets the most watched movies.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/watched/get-the-most-watched-movies">"Trakt API Doc - Movies: Watched"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="period">The time period, for which the most watched movies should be queried. See also <seealso cref="TraktTimePeriod" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktMovieFilter" />.</param>
        /// <param name="page">The page of the most watched movies list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum item count of most watched movies for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktMostWatchedMovie}"/> instance containing the queried most watched movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktMostWatchedMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktMostWatchedMovie>> GetMostWatchedMoviesAsync(TraktTimePeriod period = null,
                                                                                          TraktExtendedInfo extendedInfo = null,
                                                                                          TraktMovieFilter filter = null,
                                                                                          int? page = null, int? limitPerPage = null)
            => await QueryAsync(new TraktMoviesMostWatchedRequest(Client)
            {
                Period = period,
                ExtendedInfo = extendedInfo,
                Filter = filter,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });

        /// <summary>
        /// Gets the most collected movies.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/watched/get-the-most-collected-movies">"Trakt API Doc - Movies: Collected"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="period">The time period, for which the most collected movies should be queried. See also <seealso cref="TraktTimePeriod" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktMovieFilter" />.</param>
        /// <param name="page">The page of the most collected movies list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum item count of most collected movies for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktMostCollectedMovie}"/> instance containing the queried most collected movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktMostCollectedMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktMostCollectedMovie>> GetMostCollectedMoviesAsync(TraktTimePeriod period = null,
                                                                                              TraktExtendedInfo extendedInfo = null,
                                                                                              TraktMovieFilter filter = null,
                                                                                              int? page = null, int? limitPerPage = null)
            => await QueryAsync(new TraktMoviesMostCollectedRequest(Client)
            {
                Period = period,
                ExtendedInfo = extendedInfo,
                Filter = filter,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });

        /// <summary>
        /// Gets the most anticipated movies.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/anticipated/get-the-most-anticipated-movies">"Trakt API Doc - Movies: Anticipated"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktMovieFilter" />.</param>
        /// <param name="page">The page of the most anticipated movies list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum item count of most anticipated movies for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktMostAnticipatedMovie}"/> instance containing the queried most anticipated movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktMostAnticipatedMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktMostAnticipatedMovie>> GetMostAnticipatedMoviesAsync(TraktExtendedInfo extendedInfo = null,
                                                                                                  TraktMovieFilter filter = null,
                                                                                                  int? page = null, int? limitPerPage = null)
            => await QueryAsync(new TraktMoviesMostAnticipatedRequest(Client)
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });

        /// <summary>
        /// Gets the top 10 box office movies.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/box-office/get-the-weekend-box-office">"Trakt API Doc - Movies: Box Office"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>A list of <see cref="TraktBoxOfficeMovie" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktBoxOfficeMovie>> GetBoxOfficeMoviesAsync(TraktExtendedInfo extendedInfo = null)
            => await QueryAsync(new TraktMoviesBoxOfficeRequest(Client) { ExtendedInfo = extendedInfo });

        /// <summary>
        /// Gets updated movies since the given <paramref name="startDate" />.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/updates/get-recently-updated-movies">"Trakt API Doc - Movies: Updates"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The start date, after which updated movies should be queried. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="page">The page of the updated movies list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum item count of updated movies for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktRecentlyUpdatedMovie}"/> instance containing the queried updated movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktRecentlyUpdatedMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktRecentlyUpdatedMovie>> GetRecentlyUpdatedMoviesAsync(DateTime? startDate = null,
                                                                                                  TraktExtendedInfo extendedInfo = null,
                                                                                                  int? page = null, int? limitPerPage = null)
            => await QueryAsync(new TraktMoviesRecentlyUpdatedRequest(Client)
            {
                StartDate = startDate,
                ExtendedInfo = extendedInfo,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });

        private void Validate(string movieIdOrSlug)
        {
            if (string.IsNullOrEmpty(movieIdOrSlug) || movieIdOrSlug.ContainsSpace())
                throw new ArgumentException("movie id or slug not valid", nameof(movieIdOrSlug));
        }

        private void Validate(string movieIdOrSlug, string languageCode)
        {
            Validate(movieIdOrSlug);

            if (string.IsNullOrEmpty(languageCode) || languageCode.Length != 2)
                throw new ArgumentException("movie language code not valid", nameof(languageCode));
        }
    }
}
