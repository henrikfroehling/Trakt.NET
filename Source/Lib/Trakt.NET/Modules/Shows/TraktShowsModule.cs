namespace TraktNet.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Get.Shows;
    using Parameters;
    using Requests.Handler;
    using Requests.Shows;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to shows.
    /// <para>
    /// This module contains all methods of the <a href ="http://trakt.docs.apiary.io/#reference/shows">"Trakt API Doc - Shows"</a> section.
    /// </para>
    /// </summary>
    public partial class TraktShowsModule : ATraktModule
    {
        internal TraktShowsModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Gets trending shows.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/shows/trending/get-trending-shows">"Trakt API Doc - Shows: Trending"</a> for more information.
        /// </para>
        /// <para>
        /// Use the <see cref="ITraktShowFilterBuilder" /> to create an instance of the optional <see cref="ITraktShowFilter" />.
        /// See also <seealso cref="TraktFilter.NewShowFilter()" />.
        /// </para>
        /// </summary>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="ITraktShowFilter" />.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktTrendingShow}"/> instance containing the queried trending shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktTrendingShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktTrendingShow>> GetTrendingShowsAsync(TraktExtendedInfo extendedInfo = null,
                                                                                  ITraktShowFilter filter = null,
                                                                                  TraktPagedParameters pagedParameters = null,
                                                                                  CancellationToken cancellationToken = default)
        {
            var request = new ShowsTrendingRequest
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets popular shows.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/shows/popular/get-popular-shows">"Trakt API Doc - Shows: Popular"</a> for more information.
        /// </para>
        /// <para>
        /// Use the <see cref="ITraktShowFilterBuilder" /> to create an instance of the optional <see cref="ITraktShowFilter" />.
        /// See also <seealso cref="TraktFilter.NewShowFilter()" />.
        /// </para>
        /// </summary>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="ITraktShowFilter" />.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktShow}"/> instance containing the queried popular shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktShow>> GetPopularShowsAsync(TraktExtendedInfo extendedInfo = null,
                                                                         ITraktShowFilter filter = null,
                                                                         TraktPagedParameters pagedParameters = null,
                                                                         CancellationToken cancellationToken = default)
        {
            var request = new ShowsPopularRequest
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets the most favorited shows.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/shows/favorited/get-the-most-favorited-shows">"Trakt API Doc - Shows: Favorited"</a> for more information.
        /// </para>
        /// <para>
        /// Use the <see cref="ITraktShowFilterBuilder" /> to create an instance of the optional <see cref="ITraktShowFilter" />.
        /// See also <seealso cref="TraktFilter.NewShowFilter()" />.
        /// </para>
        /// </summary>
        /// <param name="period">The time period, for which the most favorited shows should be queried. See also <seealso cref="TraktTimePeriod" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="ITraktShowFilter" />.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktMostFavoritedShow}"/> instance containing the queried most favorited shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktMostFavoritedShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktMostFavoritedShow>> GetMostFavoritedShowsAsync(TraktTimePeriod period = null,
                                                                                            TraktExtendedInfo extendedInfo = null,
                                                                                            ITraktShowFilter filter = null,
                                                                                            TraktPagedParameters pagedParameters = null,
                                                                                            CancellationToken cancellationToken = default)
        {
            var request = new ShowsMostFavoritedRequest
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
        /// Gets the most played shows.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/shows/played/get-the-most-played-shows">"Trakt API Doc - Shows: Played"</a> for more information.
        /// </para>
        /// <para>
        /// Use the <see cref="ITraktShowFilterBuilder" /> to create an instance of the optional <see cref="ITraktShowFilter" />.
        /// See also <seealso cref="TraktFilter.NewShowFilter()" />.
        /// </para>
        /// </summary>
        /// <param name="period">The time period, for which the most played shows should be queried. See also <seealso cref="TraktTimePeriod" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="ITraktShowFilter" />.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktMostPlayedShow}"/> instance containing the queried most played shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktMostPWCShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktMostPWCShow>> GetMostPlayedShowsAsync(TraktTimePeriod period = null,
                                                                                   TraktExtendedInfo extendedInfo = null,
                                                                                   ITraktShowFilter filter = null,
                                                                                   TraktPagedParameters pagedParameters = null,
                                                                                   CancellationToken cancellationToken = default)
        {
            var request = new ShowsMostPlayedRequest
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
        /// Gets the most watched shows.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/shows/watched/get-the-most-watched-shows">"Trakt API Doc - Shows: Watched"</a> for more information.
        /// </para>
        /// <para>
        /// Use the <see cref="ITraktShowFilterBuilder" /> to create an instance of the optional <see cref="ITraktShowFilter" />.
        /// See also <seealso cref="TraktFilter.NewShowFilter()" />.
        /// </para>
        /// </summary>
        /// <param name="period">The time period, for which the most watched shows should be queried. See also <seealso cref="TraktTimePeriod" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="ITraktShowFilter" />.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktMostPWCShow}"/> instance containing the queried most watched shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktMostPWCShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktMostPWCShow>> GetMostWatchedShowsAsync(TraktTimePeriod period = null,
                                                                                    TraktExtendedInfo extendedInfo = null,
                                                                                    ITraktShowFilter filter = null,
                                                                                    TraktPagedParameters pagedParameters = null,
                                                                                    CancellationToken cancellationToken = default)
        {
            var request = new ShowsMostWatchedRequest
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
        /// Gets the most collected shows.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/shows/collected/get-the-most-collected-shows">"Trakt API Doc - Shows: Collected"</a> for more information.
        /// </para>
        /// <para>
        /// Use the <see cref="ITraktShowFilterBuilder" /> to create an instance of the optional <see cref="ITraktShowFilter" />.
        /// See also <seealso cref="TraktFilter.NewShowFilter()" />.
        /// </para>
        /// </summary>
        /// <param name="period">The time period, for which the most collected shows should be queried. See also <seealso cref="TraktTimePeriod" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="ITraktShowFilter" />.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktMostPWCShow}"/> instance containing the queried most collected shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktMostPWCShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktMostPWCShow>> GetMostCollectedShowsAsync(TraktTimePeriod period = null,
                                                                                      TraktExtendedInfo extendedInfo = null,
                                                                                      ITraktShowFilter filter = null,
                                                                                      TraktPagedParameters pagedParameters = null,
                                                                                      CancellationToken cancellationToken = default)
        {
            var request = new ShowsMostCollectedRequest
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
        /// Gets the most anticipated shows.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/shows/anticipated/get-the-most-anticipated-shows">"Trakt API Doc - Shows: Anticipated"</a> for more information.
        /// </para>
        /// <para>
        /// Use the <see cref="ITraktShowFilterBuilder" /> to create an instance of the optional <see cref="ITraktShowFilter" />.
        /// See also <seealso cref="TraktFilter.NewShowFilter()" />.
        /// </para>
        /// </summary>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="ITraktShowFilter" />.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktMostAnticipatedShow}"/> instance containing the queried most anticipated shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktMostAnticipatedShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktMostAnticipatedShow>> GetMostAnticipatedShowsAsync(TraktExtendedInfo extendedInfo = null,
                                                                                                ITraktShowFilter filter = null,
                                                                                                TraktPagedParameters pagedParameters = null,
                                                                                                CancellationToken cancellationToken = default)
        {
            var request = new ShowsMostAnticipatedRequest
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets updated shows since the given <paramref name="startDate" />.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/shows/anticipated/get-recently-updated-shows">"Trakt API Doc - Shows: Updates"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The start date, after which updated shows should be queried. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktRecentlyUpdatedShow}"/> instance containing the queried updated shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktRecentlyUpdatedShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktRecentlyUpdatedShow>> GetRecentlyUpdatedShowsAsync(DateTime? startDate = null,
                                                                                                TraktExtendedInfo extendedInfo = null,
                                                                                                TraktPagedParameters pagedParameters = null,
                                                                                                CancellationToken cancellationToken = default)
        {
            var request = new ShowsRecentlyUpdatedRequest
            {
                StartDate = startDate,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets recently updated show ids since the given <paramref name="startDate" />.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/shows/updated-ids/get-recently-updated-show-trakt-ids">"Trakt API Doc - Shows: Updated Ids"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The start date, after which updated show ids should be queried. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ListItem}"/> instance containing the queried updated show ids and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<int>> GetRecentlyUpdatedShowIdsAsync(DateTime? startDate = null, TraktPagedParameters pagedParameters = null,
                                                                            CancellationToken cancellationToken = default)
        {
            var request = new ShowsRecentlyUpdatedIdsRequest
            {
                StartDate = startDate,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        private Task<TraktResponse<ITraktShow>> GetShowInStreamAsync(string showIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                     CancellationToken cancellationToken = default)
            => GetShowImplementationAsync(true, showIdOrSlug, extendedInfo, cancellationToken);

        private Task<TraktResponse<ITraktShow>> GetShowImplementationAsync(bool asyncStream, string showIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                           CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            var request = new ShowSummaryRequest
            {
                Id = showIdOrSlug,
                ExtendedInfo = extendedInfo
            };

            if (asyncStream)
                return requestHandler.ExecuteSingleItemStreamRequestAsync(request, cancellationToken);

            return requestHandler.ExecuteSingleItemRequestAsync(request, cancellationToken);
        }
    }
}
