namespace TraktNet.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Basic;
    using Objects.Get.Lists;
    using Objects.Get.Movies;
    using Objects.Get.Users;
    using Parameters;
    using Requests.Handler;
    using Requests.Movies;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Extensions;

    /// <summary>
    /// Provides access to data retrieving methods specific to movies.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/movies">"Trakt API Doc - Movies"</a> section.
    /// </para>
    /// </summary>
    public class TraktMoviesModule : ATraktModule
    {
        internal TraktMoviesModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Gets a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/summary/get-a-movie">"Trakt API Doc - Movies: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleMoviesAsync(TraktMultipleObjectsQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movie should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktMovie" /> instance with the queried movie's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktMovie>> GetMovieAsync(string movieIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                              CancellationToken cancellationToken = default)
            => GetMovieImplementationAsync(false, movieIdOrSlug, extendedInfo, cancellationToken);

        /// <summary>
        /// Gets multiple different <see cref="ITraktMovie" />s at once with the given Trakt-Ids or -Slugs.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/summary/get-a-movie">"Trakt API Doc - Movies: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMovieAsync(string, TraktExtendedInfo, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="moviesQueryParams">A list of movie ids and optional extended infos. See also <seealso cref="TraktMultipleObjectsQueryParams" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktMovie" /> instances with the data of each queried movie.</returns>
        /// <exception cref="TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        [Obsolete("GetMultipleMoviesAsync is deprecated, please use GetMoviesStreamAsync instead.")]
        public async Task<IEnumerable<TraktResponse<ITraktMovie>>> GetMultipleMoviesAsync(TraktMultipleObjectsQueryParams moviesQueryParams,
                                                                                          CancellationToken cancellationToken = default)
        {
            if (moviesQueryParams == null || moviesQueryParams.Count == 0)
                return new List<TraktResponse<ITraktMovie>>();

            var tasks = new List<Task<TraktResponse<ITraktMovie>>>();

            foreach (TraktObjectsQueryParams queryParam in moviesQueryParams)
            {
                Task<TraktResponse<ITraktMovie>> task = GetMovieAsync(queryParam.Id, queryParam.ExtendedInfo, cancellationToken);
                tasks.Add(task);
            }

            TraktResponse<ITraktMovie>[] movies = await Task.WhenAll(tasks).ConfigureAwait(false);
            return movies.ToList();
        }

        /// <summary>
        /// Gets multiple different <see cref="ITraktMovie" />s at once with the given Trakt-Ids or -Slugs.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/summary/get-a-movie">"Trakt API Doc - Movies: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMovieAsync(string, TraktExtendedInfo, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="moviesQueryParams">A list of movie ids and optional extended infos. See also <seealso cref="TraktMultipleObjectsQueryParams" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <a href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1?view=net-7.0">async stream</a> of <see cref="ITraktMovie" /> instances with the data of each queried movie.</returns>
        /// <exception cref="TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public async IAsyncEnumerable<TraktResponse<ITraktMovie>> GetMoviesStreamAsync(TraktMultipleObjectsQueryParams moviesQueryParams,
                                                                                          [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (moviesQueryParams == null || moviesQueryParams.Count == 0)
                yield break;

            var tasks = new List<Task<TraktResponse<ITraktMovie>>>();

            foreach (TraktObjectsQueryParams queryParam in moviesQueryParams)
            {
                Task<TraktResponse<ITraktMovie>> task = GetMovieInStreamAsync(queryParam.Id, queryParam.ExtendedInfo, cancellationToken);
                tasks.Add(task);
            }

            await foreach (TraktResponse<ITraktMovie> result in tasks.StreamFinishedTaskResultsAsync())
            {
                yield return result;
            }
        }

        /// <summary>
        /// Gets all title aliases for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/aliases/get-all-movie-aliases">"Trakt API Doc - Movies: Aliases"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktMovieAlias" /> instances, each containing a title and country code.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktMovieAlias>> GetMovieAliasesAsync(string movieIdOrSlug,
                                                                              CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new MovieAliasesRequest
            {
                Id = movieIdOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all releases for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/releases/get-all-movie-releases">"Trakt API Doc - Movies: Releases"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="countryCode">An optional two letter country code to query a specific release.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktMovieRelease" /> instances, each containing a country code, certification, release date and a note.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktMovieRelease>> GetMovieReleasesAsync(string movieIdOrSlug, string countryCode = null,
                                                                                 CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new MovieReleasesRequest
            {
                Id = movieIdOrSlug,
                CountryCode = countryCode
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all translations for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/translations/get-all-movie-translations">"Trakt API Doc - Movies: Translations"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="languageCode">An optional two letter language code to query a specific translation language.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktMovieTranslation" /> instances, each containing a title, tagline, overview and language code.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktMovieTranslation>> GetMovieTranslationsAsync(string movieIdOrSlug, string languageCode = null,
                                                                                         CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new MovieTranslationsRequest
            {
                Id = movieIdOrSlug,
                LanguageCode = languageCode
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets top level comments for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/translations/get-all-movie-comments">"Trakt API Doc - Movies: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktComment}"/> instance containing the queried movie comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktComment>> GetMovieCommentsAsync(string movieIdOrSlug,
                                                                             TraktCommentSortOrder commentSortOrder = null,
                                                                             TraktPagedParameters pagedParameters = null,
                                                                             CancellationToken cancellationToken = default)
        {
            var request = new MovieCommentsRequest
            {
                Id = movieIdOrSlug,
                SortOrder = commentSortOrder,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets all <see cref="ITraktList" />s containing a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/lists/get-lists-containing-this-movie">"Trakt API Doc - Movies: Lists"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="listType">The type of lists, that should be queried. Defaults to personal lists.</param>
        /// <param name="listSortOrder">The list sort order. See also <seealso cref="TraktListSortOrder" />. Defaults to sorted by popularity.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktList}"/> instance containing the queried movie lists and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktList" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktList>> GetMovieListsAsync(string movieIdOrSlug, TraktListType listType = null,
                                                                       TraktListSortOrder listSortOrder = null,
                                                                       TraktPagedParameters pagedParameters = null,
                                                                       CancellationToken cancellationToken = default)
        {
            var request = new MovieListsRequest
            {
                Id = movieIdOrSlug,
                Type = listType,
                SortOrder = listSortOrder,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets all people for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/people/get-all-people-for-a-movie">"Trakt API Doc - Movies: People"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktCastAndCrew" /> instance, containing the cast and crew for a movie with the given movieIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktCastAndCrew>> GetMoviePeopleAsync(string movieIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                          CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new MoviePeopleRequest
            {
                Id = movieIdOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the ratings for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/ratings/get-movie-ratings">"Trakt API Doc - Movies: Ratings"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktRating" /> instance, containing the ratings for a movie with the given movieIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktRating>> GetMovieRatingsAsync(string movieIdOrSlug, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new MovieRatingsRequest
            {
                Id = movieIdOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets related movies for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/related/get-related-movies">"Trakt API Doc - Movies: Related"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktMovie}"/> instance containing the queried related movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktMovie>> GetMovieRelatedMoviesAsync(string movieIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                                TraktPagedParameters pagedParameters = null,
                                                                                CancellationToken cancellationToken = default)
        {
            var request = new MovieRelatedMoviesRequest
            {
                Id = movieIdOrSlug,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets the statistics for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/stats/get-movie-stats">"Trakt API Doc - Movies: Stats"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktStatistics" /> instance, containing the statistics for a movie with the given movieIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktStatistics>> GetMovieStatisticsAsync(string movieIdOrSlug, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new MovieStatisticsRequest
            {
                Id = movieIdOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all watching users of a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/watching/get-users-watching-right-now">"Trakt API Doc - Movies: Watching"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the users should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktUser" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktUser>> GetMovieWatchingUsersAsync(string movieIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                              CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new MovieWatchingUsersRequest
            {
                Id = movieIdOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all studios of a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/movies/studios/get-movie-studios">"Trakt API Doc - Movies: Studios"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktStudio" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktStudio>> GetMovieStudiosAsync(string movieIdOrSlug, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new MovieStudiosRequest
            {
                Id = movieIdOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets trending movies.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/trending/get-trending-movies">"Trakt API Doc - Movies: Trending"</a> for more information.
        /// </para>
        /// <para>
        /// Use the <see cref="ITraktMovieFilterBuilder" /> to create an instance of the optional <see cref="ITraktMovieFilter" />.
        /// See also <seealso cref="TraktFilter.NewMovieFilter()" />.
        /// </para>
        /// </summary>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="ITraktMovieFilter" />.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktTrendingMovie}"/> instance containing the queried trending movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktTrendingMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktTrendingMovie>> GetTrendingMoviesAsync(TraktExtendedInfo extendedInfo = null,
                                                                                    ITraktMovieFilter filter = null,
                                                                                    TraktPagedParameters pagedParameters = null,
                                                                                    CancellationToken cancellationToken = default)
        {
            var request = new MoviesTrendingRequest
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets popular movies.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/popular/get-popular-movies">"Trakt API Doc - Movies: Popular"</a> for more information.
        /// </para>
        /// <para>
        /// Use the <see cref="ITraktMovieFilterBuilder" /> to create an instance of the optional <see cref="ITraktMovieFilter" />.
        /// See also <seealso cref="TraktFilter.NewMovieFilter()" />.
        /// </para>
        /// </summary>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="ITraktMovieFilter" />.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktMovie}"/> instance containing the queried popular movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktMovie>> GetPopularMoviesAsync(TraktExtendedInfo extendedInfo = null,
                                                                           ITraktMovieFilter filter = null,
                                                                           TraktPagedParameters pagedParameters = null,
                                                                           CancellationToken cancellationToken = default)
        {
            var request = new MoviesPopularRequest
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets the most played movies.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/played/get-the-most-played-movies">"Trakt API Doc - Movies: Played"</a> for more information.
        /// </para>
        /// <para>
        /// Use the <see cref="ITraktMovieFilterBuilder" /> to create an instance of the optional <see cref="ITraktMovieFilter" />.
        /// See also <seealso cref="TraktFilter.NewMovieFilter()" />.
        /// </para>
        /// </summary>
        /// <param name="period">The time period, for which the most played movies should be queried. See also <seealso cref="TraktTimePeriod" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="ITraktMovieFilter" />.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktMostPlayedMovie}"/> instance containing the queried most played movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktMostPWCMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktMostPWCMovie>> GetMostPlayedMoviesAsync(TraktTimePeriod period = null,
                                                                                     TraktExtendedInfo extendedInfo = null,
                                                                                     ITraktMovieFilter filter = null,
                                                                                     TraktPagedParameters pagedParameters = null,
                                                                                     CancellationToken cancellationToken = default)
        {
            var request = new MoviesMostPlayedRequest
            {
                Period = period,
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets the most watched movies.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/watched/get-the-most-watched-movies">"Trakt API Doc - Movies: Watched"</a> for more information.
        /// </para>
        /// <para>
        /// Use the <see cref="ITraktMovieFilterBuilder" /> to create an instance of the optional <see cref="ITraktMovieFilter" />.
        /// See also <seealso cref="TraktFilter.NewMovieFilter()" />.
        /// </para>
        /// </summary>
        /// <param name="period">The time period, for which the most watched movies should be queried. See also <seealso cref="TraktTimePeriod" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="ITraktMovieFilter" />.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktMostPWCMovie}"/> instance containing the queried most watched movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktMostPWCMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktMostPWCMovie>> GetMostWatchedMoviesAsync(TraktTimePeriod period = null,
                                                                                      TraktExtendedInfo extendedInfo = null,
                                                                                      ITraktMovieFilter filter = null,
                                                                                      TraktPagedParameters pagedParameters = null,
                                                                                      CancellationToken cancellationToken = default)
        {
            var request = new MoviesMostWatchedRequest
            {
                Period = period,
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets the most collected movies.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/watched/get-the-most-collected-movies">"Trakt API Doc - Movies: Collected"</a> for more information.
        /// </para>
        /// <para>
        /// Use the <see cref="ITraktMovieFilterBuilder" /> to create an instance of the optional <see cref="ITraktMovieFilter" />.
        /// See also <seealso cref="TraktFilter.NewMovieFilter()" />.
        /// </para>
        /// </summary>
        /// <param name="period">The time period, for which the most collected movies should be queried. See also <seealso cref="TraktTimePeriod" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="ITraktMovieFilter" />.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktMostPWCMovie}"/> instance containing the queried most collected movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktMostPWCMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktMostPWCMovie>> GetMostCollectedMoviesAsync(TraktTimePeriod period = null,
                                                                                        TraktExtendedInfo extendedInfo = null,
                                                                                        ITraktMovieFilter filter = null,
                                                                                        TraktPagedParameters pagedParameters = null,
                                                                                        CancellationToken cancellationToken = default)
        {
            var request = new MoviesMostCollectedRequest
            {
                Period = period,
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets the most anticipated movies.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/anticipated/get-the-most-anticipated-movies">"Trakt API Doc - Movies: Anticipated"</a> for more information.
        /// </para>
        /// <para>
        /// Use the <see cref="ITraktMovieFilterBuilder" /> to create an instance of the optional <see cref="ITraktMovieFilter" />.
        /// See also <seealso cref="TraktFilter.NewMovieFilter()" />.
        /// </para>
        /// </summary>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="ITraktMovieFilter" />.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktMostAnticipatedMovie}"/> instance containing the queried most anticipated movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktMostAnticipatedMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktMostAnticipatedMovie>> GetMostAnticipatedMoviesAsync(TraktExtendedInfo extendedInfo = null,
                                                                                                  ITraktMovieFilter filter = null,
                                                                                                  TraktPagedParameters pagedParameters = null,
                                                                                                  CancellationToken cancellationToken = default)
        {
            var request = new MoviesMostAnticipatedRequest
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets the most recommended movies.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/movies/recommended/get-the-most-recommended-movies">"Trakt API Doc - Movies: Recommended"</a> for more information.
        /// </para>
        /// <para>
        /// Use the <see cref="ITraktMovieFilterBuilder" /> to create an instance of the optional <see cref="ITraktMovieFilter" />.
        /// See also <seealso cref="TraktFilter.NewMovieFilter()" />.
        /// </para>
        /// </summary>
        /// <param name="period">The time period, for which the most recommended movies should be queried. See also <seealso cref="TraktTimePeriod" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="ITraktMovieFilter" />.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktMostRecommendedMovie}"/> instance containing the queried most recommended movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktMostRecommendedMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktMostRecommendedMovie>> GetMostRecommendedMoviesAsync(TraktTimePeriod period = null,
                                                                                                  TraktExtendedInfo extendedInfo = null,
                                                                                                  ITraktMovieFilter filter = null,
                                                                                                  TraktPagedParameters pagedParameters = null,
                                                                                                  CancellationToken cancellationToken = default)
        {
            var request = new MoviesMostRecommendedRequest
            {
                Period = period,
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktBoxOfficeMovie" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktListResponse<ITraktBoxOfficeMovie>> GetBoxOfficeMoviesAsync(TraktExtendedInfo extendedInfo = null,
                                                                                     CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new MoviesBoxOfficeRequest
            {
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
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
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktRecentlyUpdatedMovie}"/> instance containing the queried updated movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktRecentlyUpdatedMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktRecentlyUpdatedMovie>> GetRecentlyUpdatedMoviesAsync(DateTime? startDate = null,
                                                                                                  TraktExtendedInfo extendedInfo = null,
                                                                                                  TraktPagedParameters pagedParameters = null,
                                                                                                  CancellationToken cancellationToken = default)
        {
            var request = new MoviesRecentlyUpdatedRequest
            {
                StartDate = startDate,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets recently updated movie ids since the given <paramref name="startDate" />.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/movies/updated-ids/get-recently-updated-movie-trakt-ids">"Trakt API Doc - Movies: Updated Ids"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The start date, after which updated movie ids should be queried. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ListItem}"/> instance containing the queried updated movie ids and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<int>> GetRecentlyUpdatedMovieIdsAsync(DateTime? startDate = null, TraktPagedParameters pagedParameters = null,
                                                                             CancellationToken cancellationToken = default)
        {
            var request = new MoviesRecentlyUpdatedIdsRequest
            {
                StartDate = startDate,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        private Task<TraktResponse<ITraktMovie>> GetMovieInStreamAsync(string movieIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                       CancellationToken cancellationToken = default)
            => GetMovieImplementationAsync(true, movieIdOrSlug, extendedInfo, cancellationToken);

        private Task<TraktResponse<ITraktMovie>> GetMovieImplementationAsync(bool asyncStream, string movieIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                             CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            var request = new MovieSummaryRequest
            {
                Id = movieIdOrSlug,
                ExtendedInfo = extendedInfo
            };

            if (asyncStream)
                return requestHandler.ExecuteSingleItemStreamRequestAsync(request, cancellationToken);

            return requestHandler.ExecuteSingleItemRequestAsync(request, cancellationToken);
        }
    }
}
