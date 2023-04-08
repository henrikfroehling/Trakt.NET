namespace TraktNet.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Basic;
    using Objects.Get.Episodes;
    using Objects.Get.Lists;
    using Objects.Get.Shows;
    using Objects.Get.Users;
    using Objects.Post.Shows;
    using Parameters;
    using Requests.Handler;
    using Requests.Shows;
    using Requests.Shows.OAuth;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Extensions;

    /// <summary>
    /// Provides access to data retrieving methods specific to shows.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/shows">"Trakt API Doc - Shows"</a> section.
    /// </para>
    /// </summary>
    public class TraktShowsModule : ATraktModule
    {
        internal TraktShowsModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Gets a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/summary/get-a-single-show">"Trakt API Doc - Shows: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleShowsAsync(TraktMultipleObjectsQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the show should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktShow" /> instance with the queried show's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktShow>> GetShowAsync(string showIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                            CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new ShowSummaryRequest
            {
                Id = showIdOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets multiple different <see cref="ITraktShow" />s at once with the given Trakt-Ids or -Slugs.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/summary/get-a-single-show">"Trakt API Doc - Shows: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetShowAsync(string, TraktExtendedInfo, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="showsQueryParams">A list of show ids and optional extended infos. See also <seealso cref="TraktMultipleObjectsQueryParams" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktShow" /> instances with the data of each queried show.</returns>
        /// <exception cref="TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        [Obsolete("GetMultipleShowsAsync is deprecated, please use GetShowsStreamAsync instead.")]
        public async Task<IEnumerable<TraktResponse<ITraktShow>>> GetMultipleShowsAsync(TraktMultipleObjectsQueryParams showsQueryParams,
                                                                                        CancellationToken cancellationToken = default)
        {
            if (showsQueryParams == null || showsQueryParams.Count == 0)
                return new List<TraktResponse<ITraktShow>>();

            var tasks = new List<Task<TraktResponse<ITraktShow>>>();

            foreach (TraktObjectsQueryParams queryParam in showsQueryParams)
            {
                Task<TraktResponse<ITraktShow>> task = GetShowAsync(queryParam.Id, queryParam.ExtendedInfo, cancellationToken);
                tasks.Add(task);
            }

            TraktResponse<ITraktShow>[] shows = await Task.WhenAll(tasks).ConfigureAwait(false);
            return shows.ToList();
        }

        /// <summary>
        /// Gets multiple different <see cref="ITraktShow" />s at once with the given Trakt-Ids or -Slugs.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/summary/get-a-single-show">"Trakt API Doc - Shows: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetShowAsync(string, TraktExtendedInfo, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="showsQueryParams">A list of show ids and optional extended infos. See also <seealso cref="TraktMultipleObjectsQueryParams" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <a href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1?view=net-7.0">async stream</a> of <see cref="ITraktShow" /> instances with the data of each queried show.</returns>
        /// <exception cref="TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public async IAsyncEnumerable<TraktResponse<ITraktShow>> GetShowsStreamAsync(TraktMultipleObjectsQueryParams showsQueryParams,
                                                                                        [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (showsQueryParams == null || showsQueryParams.Count == 0)
                yield break;

            var tasks = new List<Task<TraktResponse<ITraktShow>>>();

            foreach (TraktObjectsQueryParams queryParam in showsQueryParams)
            {
                Task<TraktResponse<ITraktShow>> task = GetShowAsync(queryParam.Id, queryParam.ExtendedInfo, cancellationToken);
                tasks.Add(task);
            }

            await foreach(TraktResponse<ITraktShow> result in tasks.StreamFinishedTaskResultsAsync())
            {
                yield return result;
            }
        }

        /// <summary>
        /// Gets all title aliases for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/aliases/get-all-show-aliases">"Trakt API Doc - Shows: Aliases"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktShowAlias" /> instances, each containing a title and country code.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktShowAlias>> GetShowAliasesAsync(string showIdOrSlug, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new ShowAliasesRequest
            {
                Id = showIdOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all translations for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/translations/get-all-show-translations">"Trakt API Doc - Shows: Translations"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="languageCode">An optional two letter language code to query a specific translation language.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktShowTranslation" /> instances, each containing a title, overview and language code.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktShowTranslation>> GetShowTranslationsAsync(string showIdOrSlug, string languageCode = null,
                                                                                       CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new ShowTranslationsRequest
            {
                Id = showIdOrSlug,
                LanguageCode = languageCode
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets top level comments for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/translations/get-all-show-comments">"Trakt API Doc - Shows: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktComment}"/> instance containing the queried show comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktComment>> GetShowCommentsAsync(string showIdOrSlug,
                                                                            TraktCommentSortOrder commentSortOrder = null,
                                                                            TraktPagedParameters pagedParameters = null,
                                                                            CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new ShowCommentsRequest
            {
                Id = showIdOrSlug,
                SortOrder = commentSortOrder,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all <see cref="ITraktList" />s containing a <see cref="ITraktShow" /> with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/lists/get-lists-containing-this-show">"Trakt API Doc - Shows: Lists"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="listType">The type of lists, that should be queried. Defaults to personal lists. See also <seealso cref="TraktListType" />. </param>
        /// <param name="listSortOrder">The list sort order. See also <seealso cref="TraktListSortOrder" />. Defaults to sorted by popularity.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktList}"/> instance containing the queried show lists and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktList" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktList>> GetShowListsAsync(string showIdOrSlug, TraktListType listType = null,
                                                                      TraktListSortOrder listSortOrder = null,
                                                                      TraktPagedParameters pagedParameters = null,
                                                                      CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new ShowListsRequest
            {
                Id = showIdOrSlug,
                Type = listType,
                SortOrder = listSortOrder,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all people for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/people/get-all-people-for-a-show">"Trakt API Doc - Shows: People"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktShowCastAndCrew" /> instance, containing the cast and crew for a show with the given showIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktShowCastAndCrew>> GetShowPeopleAsync(string showIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                             CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new ShowPeopleRequest
            {
                Id = showIdOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the ratings for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/ratings/get-show-ratings">"Trakt API Doc - Shows: Ratings"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktRating" /> instance, containing the ratings for a show with the given showIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktRating>> GetShowRatingsAsync(string showIdOrSlug, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new ShowRatingsRequest
            {
                Id = showIdOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets related shows for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/related/get-related-shows">"Trakt API Doc - Shows: Related"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
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
        /// An <see cref="TraktPagedResponse{ITraktShow}"/> instance containing the queried related shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktShow>> GetShowRelatedShowsAsync(string showIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                             TraktPagedParameters pagedParameters = null,
                                                                             CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new ShowRelatedShowsRequest
            {
                Id = showIdOrSlug,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the statistics for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/stats/get-show-stats">"Trakt API Doc - Shows: Stats"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktStatistics" /> instance, containing the statistics for a show with the given showIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktStatistics>> GetShowStatisticsAsync(string showIdOrSlug, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new ShowStatisticsRequest
            {
                Id = showIdOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all watching users of a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/watching/get-users-watching-right-now">"Trakt API Doc - Shows: Watching"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
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
        public Task<TraktListResponse<ITraktUser>> GetShowWatchingUsersAsync(string showIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                             CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new ShowWatchingUsersRequest
            {
                Id = showIdOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the collection progress for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/collection-progress/get-show-collection-progress">"Trakt API Doc - Shows: Collection Progress"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="includingHiddenSeasons">Determines, if the returned collection progress should contain hidden seasons.</param>
        /// <param name="includingSpecialSeasons">Determines, if the returned collection progress should contain special seasons.</param>
        /// <param name="countSpecialSeasons">Determins, if special seasons should be counted in the statistics of the returned collection progress.</param>
        /// <param name="lastActivity">Determines the last activity type of the collection progress.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktShowCollectionProgress" /> instance, containing the collection progress for a show with the given showIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktShowCollectionProgress>> GetShowCollectionProgressAsync(string showIdOrSlug, bool? includingHiddenSeasons = null,
                                                                                                bool? includingSpecialSeasons = null,
                                                                                                bool? countSpecialSeasons = null,
                                                                                                TraktLastActivity lastActivity = null,
                                                                                                CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new ShowCollectionProgressRequest
            {
                Id = showIdOrSlug,
                Hidden = includingHiddenSeasons,
                Specials = includingSpecialSeasons,
                CountSpecials = countSpecialSeasons,
                LastActivity = lastActivity
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the watched progress for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/watched-progress/get-show-watched-progress">"Trakt API Doc - Shows: Watched Progress"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="includingHiddenSeasons">Determines, if the returned watched progress should contain hidden seasons.</param>
        /// <param name="includingSpecialSeasons">Determines, if the returned watched progress should contain special seasons.</param>
        /// <param name="countSpecialSeasons">Determins, if special seasons should be counted in the statistics of the returned watched progress.</param>
        /// <param name="lastActivity">Determines the last activity type of the watched progress.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktShowWatchedProgress" /> instance, containing the watched progress for a show with the given showIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktShowWatchedProgress>> GetShowWatchedProgressAsync(string showIdOrSlug, bool? includingHiddenSeasons = null,
                                                                                          bool? includingSpecialSeasons = null,
                                                                                          bool? countSpecialSeasons = null,
                                                                                          TraktLastActivity lastActivity = null,
                                                                                          CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new ShowWatchedProgressRequest
            {
                Id = showIdOrSlug,
                Hidden = includingHiddenSeasons,
                Specials = includingSpecialSeasons,
                CountSpecials = countSpecialSeasons,
                LastActivity = lastActivity
            },
            cancellationToken);
        }

        /// <summary>
        /// Resets the watched progress for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/shows/watched-progress/reset-show-progress">"Trakt API Doc - Shows: Reset Watched Progress"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="resetAt">An optional reset_at UTC date to have it calculate progress from that specific date onwards.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktShowResetWatchedProgressPost" /> instance, containing an optional reset_at UTC date to have it
        /// calculate progress from that specific date onwards.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktShowResetWatchedProgressPost>> ResetShowWatchedProgressAsync(string showIdOrSlug, DateTime? resetAt = null,
                                                                                                     CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new ShowResetWatchedProgressRequest
            {
                Id = showIdOrSlug,
                RequestBody = new TraktShowResetWatchedProgressPost
                {
                    ResetAt = resetAt
                }
            },
            cancellationToken);
        }

        /// <summary>
        /// Undo the reset and have watched progress use all watched history for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization required.</para>
        /// <para>VIP only.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/shows/reset-watched-progress/undo-reset-show-progress">"Trakt API Doc - Shows: Reset Watched Progress"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktNoContentResponse> UndoResetShowWatchedProgressAsync(string showIdOrSlug, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new ShowUndoResetWatchedProgressRequest
            {
                Id = showIdOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the next scheduled to air <see cref="ITraktEpisode" /> for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/next-episode/get-next-episode">"Trakt API Doc - Shows: Next Episode"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the episode should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktEpisode" /> instance with the queried episode's data or null, if there is no scheduled to air episode.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktEpisode>> GetShowNextEpisodeAsync(string showIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                          CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new ShowNextEpisodeRequest
            {
                Id = showIdOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the most recently aired <see cref="ITraktEpisode" /> for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/next-episode/get-last-episode">"Trakt API Doc - Shows: Last Episode"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the episode should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktEpisode" /> instance with the queried episode's data or null, if there is no most recently aired episode.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktEpisode>> GetShowLastEpisodeAsync(string showIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                          CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new ShowLastEpisodeRequest
            {
                Id = showIdOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets trending shows.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/trending/get-trending-shows">"Trakt API Doc - Shows: Trending"</a> for more information.
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
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new ShowsTrendingRequest
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets popular shows.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/popular/get-popular-shows">"Trakt API Doc - Shows: Popular"</a> for more information.
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
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new ShowsPopularRequest
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the most played shows.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/played/get-the-most-played-shows">"Trakt API Doc - Shows: Played"</a> for more information.
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
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new ShowsMostPlayedRequest
            {
                Period = period,
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the most watched shows.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/watched/get-the-most-watched-shows">"Trakt API Doc - Shows: Watched"</a> for more information.
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
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new ShowsMostWatchedRequest
            {
                Period = period,
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the most collected shows.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/collected/get-the-most-collected-shows">"Trakt API Doc - Shows: Collected"</a> for more information.
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
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new ShowsMostCollectedRequest
            {
                Period = period,
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the most anticipated shows.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/anticipated/get-the-most-anticipated-shows">"Trakt API Doc - Shows: Anticipated"</a> for more information.
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
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new ShowsMostAnticipatedRequest
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets updated shows since the given <paramref name="startDate" />.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/anticipated/get-recently-updated-shows">"Trakt API Doc - Shows: Updates"</a> for more information.
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
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new ShowsRecentlyUpdatedRequest
            {
                StartDate = startDate,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
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
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new ShowsRecentlyUpdatedIdsRequest
            {
                StartDate = startDate,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }
    }
}
