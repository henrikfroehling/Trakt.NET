namespace TraktNet.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Get.Movies;
    using Parameters;
    using Requests.Handler;
    using Requests.Movies;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to movies.
    /// <para>
    /// This module contains all methods of the <a href ="http://trakt.docs.apiary.io/#reference/movies">"Trakt API Doc - Movies"</a> section.
    /// </para>
    /// </summary>
    public partial class TraktMoviesModule : ATraktModule
    {
        internal TraktMoviesModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Gets trending movies.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/movies/trending/get-trending-movies">"Trakt API Doc - Movies: Trending"</a> for more information.
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
        /// See <a href="http://trakt.docs.apiary.io/#reference/movies/popular/get-popular-movies">"Trakt API Doc - Movies: Popular"</a> for more information.
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
        /// Gets the most favorited movies.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/movies/favorited/get-the-most-favorited-movies">"Trakt API Doc - Movies: Favorited"</a> for more information.
        /// </para>
        /// <para>
        /// Use the <see cref="ITraktMovieFilterBuilder" /> to create an instance of the optional <see cref="ITraktMovieFilter" />.
        /// See also <seealso cref="TraktFilter.NewMovieFilter()" />.
        /// </para>
        /// </summary>
        /// <param name="period">The time period, for which the most favorited movies should be queried. See also <seealso cref="TraktTimePeriod" />.</param>
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
        /// An <see cref="TraktPagedResponse{ITraktMostFavoritedMovie}"/> instance containing the queried most favorited movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktMostFavoritedMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktMostFavoritedMovie>> GetMostFavoritedMoviesAsync(TraktTimePeriod period = null,
                                                                                              TraktExtendedInfo extendedInfo = null,
                                                                                              ITraktMovieFilter filter = null,
                                                                                              TraktPagedParameters pagedParameters = null,
                                                                                              CancellationToken cancellationToken = default)
        {
            var request = new MoviesMostFavoritedRequest
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
        /// Gets the most played movies.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/movies/played/get-the-most-played-movies">"Trakt API Doc - Movies: Played"</a> for more information.
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
        /// See <a href="http://trakt.docs.apiary.io/#reference/movies/watched/get-the-most-watched-movies">"Trakt API Doc - Movies: Watched"</a> for more information.
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
        /// See <a href="http://trakt.docs.apiary.io/#reference/movies/watched/get-the-most-collected-movies">"Trakt API Doc - Movies: Collected"</a> for more information.
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
        /// See <a href="http://trakt.docs.apiary.io/#reference/movies/anticipated/get-the-most-anticipated-movies">"Trakt API Doc - Movies: Anticipated"</a> for more information.
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
        /// Gets the top 10 box office movies.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/movies/box-office/get-the-weekend-box-office">"Trakt API Doc - Movies: Box Office"</a> for more information.
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
        /// See <a href="http://trakt.docs.apiary.io/#reference/movies/updates/get-recently-updated-movies">"Trakt API Doc - Movies: Updates"</a> for more information.
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
