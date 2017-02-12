namespace TraktApiSharp.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Basic;
    using Objects.Get.Movies;
    using Objects.Get.Movies.Common;
    using Objects.Get.Users;
    using Objects.Get.Users.Lists;
    using Requests.Handler;
    using Requests.Movies;
    using Requests.Parameters;
    using Responses;
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
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        public async Task<TraktResponse<TraktMovie>> GetMovieAsync(string movieIdOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecuteSingleItemRequestAsync(new TraktMovieSummaryRequest
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
        /// <exception cref="TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if one of the given movie ids is null, empty or contains spaces.</exception>
        public async Task<IEnumerable<TraktResponse<TraktMovie>>> GetMultipleMoviesAsync(TraktMultipleObjectsQueryParams moviesQueryParams)
        {
            if (moviesQueryParams == null || moviesQueryParams.Count <= 0)
                return new List<TraktResponse<TraktMovie>>();

            var tasks = new List<Task<TraktResponse<TraktMovie>>>();

            foreach (var queryParam in moviesQueryParams)
            {
                Task<TraktResponse<TraktMovie>> task = GetMovieAsync(queryParam.Id, queryParam.ExtendedInfo);
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
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        public async Task<TraktListResponse<TraktMovieAlias>> GetMovieAliasesAsync(string movieIdOrSlug)
        {
            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteListRequestAsync(new TraktMovieAliasesRequest { Id = movieIdOrSlug });
        }

        /// <summary>
        /// Gets all releases for a <see cref="TraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/releases/get-all-movie-releases">"Trakt API Doc - Movies: Releases"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="TraktMovieIds" />.</param>
        /// <param name="countryCode">An optional two letter country code to query a specific release.</param>
        /// <returns>A list of <see cref="TraktMovieRelease" /> instances, each containing a country code, certification, release date and a note.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given countryCode is shorter or longer than two characters.</exception>
        public async Task<TraktListResponse<TraktMovieRelease>> GetMovieReleasesAsync(string movieIdOrSlug, string countryCode = null)
        {
            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteListRequestAsync(new TraktMovieReleasesRequest { Id = movieIdOrSlug, CountryCode = countryCode });
        }

        /// <summary>
        /// Gets all translations for a <see cref="TraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/translations/get-all-movie-translations">"Trakt API Doc - Movies: Translations"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="TraktMovieIds" />.</param>
        /// <param name="languageCode">An optional two letter language code to query a specific translation language.</param>
        /// <returns>A list of <see cref="TraktMovieTranslation" /> instances, each containing a title, tagline, overview and language code.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given languageCode is shorter or longer than two characters.</exception>
        public async Task<TraktListResponse<TraktMovieTranslation>> GetMovieTranslationsAsync(string movieIdOrSlug, string languageCode = null)
        {
            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteListRequestAsync(new TraktMovieTranslationsRequest { Id = movieIdOrSlug, LanguageCode = languageCode });
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
        /// An <see cref="TraktPagedResponse{TraktComment}"/> instance containing the queried movie comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="TraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        public async Task<TraktPagedResponse<TraktComment>> GetMovieCommentsAsync(string movieIdOrSlug,
                                                                                  TraktCommentSortOrder commentSortOrder = null,
                                                                                  int? page = null, int? limitPerPage = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecutePagedRequestAsync(new TraktMovieCommentsRequest
            {
                Id = movieIdOrSlug,
                SortOrder = commentSortOrder,
                Page = page,
                Limit = limitPerPage
            });
        }

        /// <summary>
        /// Gets all <see cref="TraktList" />s containing a <see cref="TraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/lists/get-lists-containing-this-movie">"Trakt API Doc - Movies: Lists"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="TraktMovieIds" />.</param>
        /// <param name="listType">The type of lists, that should be queried. Defaults to personal lists.</param>
        /// <param name="listSortOrder">The list sort order. See also <seealso cref="TraktListSortOrder" />. Defaults to sorted by popularity.</param>
        /// <param name="page">The page of the <see cref="TraktList" /> list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of <see cref="TraktList" />s for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{TraktList}"/> instance containing the queried movie lists and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="TraktList" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        public async Task<TraktPagedResponse<TraktList>> GetMovieListsAsync(string movieIdOrSlug, TraktListType listType = null,
                                                                            TraktListSortOrder listSortOrder = null,
                                                                            int? page = null, int? limitPerPage = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecutePagedRequestAsync(new TraktMovieListsRequest
            {
                Id = movieIdOrSlug,
                Type = listType,
                SortOrder = listSortOrder,
                Page = page,
                Limit = limitPerPage
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
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        public async Task<TraktResponse<TraktCastAndCrew>> GetMoviePeopleAsync(string movieIdOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteSingleItemRequestAsync(new TraktMoviePeopleRequest { Id = movieIdOrSlug, ExtendedInfo = extendedInfo });
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
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        public async Task<TraktResponse<TraktRating>> GetMovieRatingsAsync(string movieIdOrSlug)
        {
            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteSingleItemRequestAsync(new TraktMovieRatingsRequest { Id = movieIdOrSlug });
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
        /// An <see cref="TraktPagedResponse{TraktMovie}"/> instance containing the queried related movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="Objects.Get.Shows.TraktShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        public async Task<TraktPagedResponse<TraktMovie>> GetMovieRelatedMoviesAsync(string movieIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                                     int? page = null, int? limitPerPage = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecutePagedRequestAsync(new TraktMovieRelatedMoviesRequest
            {
                Id = movieIdOrSlug,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limitPerPage
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
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        public async Task<TraktResponse<TraktStatistics>> GetMovieStatisticsAsync(string movieIdOrSlug)
        {
            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteSingleItemRequestAsync(new TraktMovieStatisticsRequest { Id = movieIdOrSlug });
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
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        public async Task<TraktListResponse<TraktUser>> GetMovieWatchingUsersAsync(string movieIdOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteListRequestAsync(new TraktMovieWatchingUsersRequest { Id = movieIdOrSlug, ExtendedInfo = extendedInfo });
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
        /// An <see cref="TraktPagedResponse{TraktTrendingMovie}"/> instance containing the queried trending movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="TraktTrendingMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktPagedResponse<TraktTrendingMovie>> GetTrendingMoviesAsync(TraktExtendedInfo extendedInfo = null,
                                                                                         TraktMovieFilter filter = null,
                                                                                         int? page = null, int? limitPerPage = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecutePagedRequestAsync(new TraktMoviesTrendingRequest
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = page,
                Limit = limitPerPage
            });
        }

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
        /// An <see cref="TraktPagedResponse{TraktMovie}"/> instance containing the queried popular movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="TraktMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktPagedResponse<TraktMovie>> GetPopularMoviesAsync(TraktExtendedInfo extendedInfo = null,
                                                                                TraktMovieFilter filter = null,
                                                                                int? page = null, int? limitPerPage = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecutePagedRequestAsync(new TraktMoviesPopularRequest
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = page,
                Limit = limitPerPage
            });
        }

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
        /// An <see cref="TraktPagedResponse{TraktMostPlayedMovie}"/> instance containing the queried most played movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="TraktMostPWCMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktPagedResponse<TraktMostPWCMovie>> GetMostPlayedMoviesAsync(TraktTimePeriod period = null,
                                                                                             TraktExtendedInfo extendedInfo = null,
                                                                                             TraktMovieFilter filter = null,
                                                                                             int? page = null, int? limitPerPage = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecutePagedRequestAsync(new TraktMoviesMostPlayedRequest
            {
                Period = period,
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = page,
                Limit = limitPerPage
            });
        }

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
        /// An <see cref="TraktPagedResponse{TraktMostWatchedMovie}"/> instance containing the queried most watched movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="TraktMostWatchedMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktPagedResponse<TraktMostPWCMovie>> GetMostWatchedMoviesAsync(TraktTimePeriod period = null,
                                                                                               TraktExtendedInfo extendedInfo = null,
                                                                                               TraktMovieFilter filter = null,
                                                                                               int? page = null, int? limitPerPage = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecutePagedRequestAsync(new TraktMoviesMostWatchedRequest
            {
                Period = period,
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = page,
                Limit = limitPerPage
            });
        }

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
        /// An <see cref="TraktPagedResponse{TraktMostCollectedMovie}"/> instance containing the queried most collected movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="TraktMostCollectedMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktPagedResponse<TraktMostPWCMovie>> GetMostCollectedMoviesAsync(TraktTimePeriod period = null,
                                                                                                   TraktExtendedInfo extendedInfo = null,
                                                                                                   TraktMovieFilter filter = null,
                                                                                                   int? page = null, int? limitPerPage = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecutePagedRequestAsync(new TraktMoviesMostCollectedRequest
            {
                Period = period,
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = page,
                Limit = limitPerPage
            });
        }

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
        /// An <see cref="TraktPagedResponse{TraktMostAnticipatedMovie}"/> instance containing the queried most anticipated movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="TraktMostAnticipatedMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktPagedResponse<TraktMostAnticipatedMovie>> GetMostAnticipatedMoviesAsync(TraktExtendedInfo extendedInfo = null,
                                                                                                       TraktMovieFilter filter = null,
                                                                                                       int? page = null, int? limitPerPage = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecutePagedRequestAsync(new TraktMoviesMostAnticipatedRequest
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = page,
                Limit = limitPerPage
            });
        }

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
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktListResponse<TraktBoxOfficeMovie>> GetBoxOfficeMoviesAsync(TraktExtendedInfo extendedInfo = null)
        {
            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteListRequestAsync(new TraktMoviesBoxOfficeRequest { ExtendedInfo = extendedInfo });
        }

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
        /// An <see cref="TraktPagedResponse{TraktRecentlyUpdatedMovie}"/> instance containing the queried updated movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="TraktRecentlyUpdatedMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktPagedResponse<TraktRecentlyUpdatedMovie>> GetRecentlyUpdatedMoviesAsync(DateTime? startDate = null,
                                                                                                       TraktExtendedInfo extendedInfo = null,
                                                                                                       int? page = null, int? limitPerPage = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecutePagedRequestAsync(new TraktMoviesRecentlyUpdatedRequest
            {
                StartDate = startDate,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limitPerPage
            });
        }
    }
}
