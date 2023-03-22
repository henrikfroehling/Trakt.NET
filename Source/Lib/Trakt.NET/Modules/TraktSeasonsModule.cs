namespace TraktNet.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Basic;
    using Objects.Get.Episodes;
    using Objects.Get.Lists;
    using Objects.Get.Seasons;
    using Objects.Get.Shows;
    using Objects.Get.Users;
    using Requests.Handler;
    using Requests.Seasons;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Extensions;
    using TraktNet.Parameters;

    /// <summary>
    /// Provides access to data retrieving methods specific to seasons.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/seasons">"Trakt API Doc - Seasons"</a> section.
    /// </para>
    /// </summary>
    public class TraktSeasonsModule : ATraktModule
    {
        internal TraktSeasonsModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Gets the <see cref="ITraktSeason" />s in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/seasons/summary/get-all-seasons-for-a-show">"Trakt API Doc - Seasons: Summary"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the seasons should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="translationLanguageCode">
        /// An optional two letter language code to query a specific translation for the returned episodes.
        /// <para>Set this to "all" to get all available translations.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktSeason" /> instances with the data of each queried season.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktSeason>> GetAllSeasonsAsync(string showIdOrSlug,
                                                                        TraktExtendedInfo extendedInfo = null,
                                                                        string translationLanguageCode = null,
                                                                        CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new SeasonsAllRequest
            {
                Id = showIdOrSlug,
                ExtendedInfo = extendedInfo,
                TranslationLanguageCode = translationLanguageCode
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all <see cref="ITraktEpisode" />s in a single season in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/seasons/season/get-single-season-for-a-show">"Trakt API Doc - Seasons: Season"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleSeasonsAsync(TraktMultipleSeasonsQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, which should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the season's episodes should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="translationLanguageCode">
        /// An optional two letter language code to query a specific translation for the returned episodes.
        /// <para>Set this to "all" to get all available translations.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktEpisode" /> instances with the data of each episode in the queried season.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktEpisode>> GetSeasonAsync(string showIdOrSlug, uint seasonNumber,
                                                                     TraktExtendedInfo extendedInfo = null,
                                                                     string translationLanguageCode = null,
                                                                     CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new SeasonSingleRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                ExtendedInfo = extendedInfo,
                TranslationLanguageCode = translationLanguageCode
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets multiple different seasons at once in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/seasons/season/get-single-season-for-a-show">"Trakt API Doc - Seasons: Season"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetSeasonAsync(string, uint, TraktExtendedInfo, string, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="seasonsQueryParams">A list of show ids, season numbers and optional extended infos. See also <seealso cref="TraktMultipleSeasonsQueryParams" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of lists, each containing <see cref="ITraktEpisode" /> instances with the data of each episode in the queried seasons.</returns>
        /// <exception cref="TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        [Obsolete("GetMultipleSeasonsAsync is deprecated, please use GetSeasonsStreamAsync instead.")]
        public async Task<IEnumerable<TraktListResponse<ITraktEpisode>>> GetMultipleSeasonsAsync(TraktMultipleSeasonsQueryParams seasonsQueryParams,
                                                                                                 CancellationToken cancellationToken = default)
        {
            if (seasonsQueryParams == null || seasonsQueryParams.Count == 0)
                return new List<TraktListResponse<ITraktEpisode>>();

            var tasks = new List<Task<TraktListResponse<ITraktEpisode>>>();

            foreach (TraktSeasonsQueryParams queryParam in seasonsQueryParams)
            {
                Task<TraktListResponse<ITraktEpisode>> task = GetSeasonAsync(queryParam.ShowId, queryParam.Season, queryParam.ExtendedInfo,
                                                                             queryParam.TranslationLanguageCode, cancellationToken);

                tasks.Add(task);
            }

            TraktListResponse<ITraktEpisode>[] seasons = await Task.WhenAll(tasks).ConfigureAwait(false);
            return seasons.ToList();
        }

        /// <summary>
        /// Gets multiple different seasons at once in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/seasons/season/get-single-season-for-a-show">"Trakt API Doc - Seasons: Season"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetSeasonAsync(string, uint, TraktExtendedInfo, string, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="seasonsQueryParams">A list of show ids, season numbers and optional extended infos. See also <seealso cref="TraktMultipleSeasonsQueryParams" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <a href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1?view=net-7.0">async stream</a> of lists, each containing <see cref="ITraktEpisode" /> instances with the data of each episode in the queried seasons.</returns>
        /// <exception cref="TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public async IAsyncEnumerable<TraktListResponse<ITraktEpisode>> GetSeasonsStreamAsync(TraktMultipleSeasonsQueryParams seasonsQueryParams,
                                                                                                 [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (seasonsQueryParams == null || seasonsQueryParams.Count == 0)
                yield break;

            var tasks = new List<Task<TraktListResponse<ITraktEpisode>>>();

            foreach (TraktSeasonsQueryParams queryParam in seasonsQueryParams)
            {
                Task<TraktListResponse<ITraktEpisode>> task = GetSeasonAsync(queryParam.ShowId, queryParam.Season, queryParam.ExtendedInfo,
                                                                             queryParam.TranslationLanguageCode, cancellationToken);

                tasks.Add(task);
            }

            await foreach (TraktListResponse<ITraktEpisode> result in tasks.StreamFinishedTaskResultsAsync().ConfigureAwait(false))
            {
                yield return result;
            }
        }

        /// <summary>
        /// Gets top level comments for a <see cref="ITraktSeason" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/seasons/comments/get-all-season-comments">"Trakt API Doc - Seasons: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, for which the comments should be queried.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktComment}"/> instance containing the queried season comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktComment>> GetSeasonCommentsAsync(string showIdOrSlug, uint seasonNumber,
                                                                              TraktCommentSortOrder commentSortOrder = null,
                                                                              TraktPagedParameters pagedParameters = null,
                                                                              CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new SeasonCommentsRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                SortOrder = commentSortOrder,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all <see cref="ITraktList" />s containing the given <see cref="ITraktSeason" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/seasons/lists/get-lists-containing-this-season">"Trakt API Doc - Seasons: Lists"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, for which the lists should be queried.</param>
        /// <param name="listType">The type of lists, that should be queried. Defaults to personal lists.</param>
        /// <param name="listSortOrder">The list sort order. See also <seealso cref="TraktListSortOrder" />. Defaults to sorted by popularity.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktList}"/> instance containing the queried season lists and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktList" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktList>> GetSeasonListsAsync(string showIdOrSlug, uint seasonNumber,
                                                                        TraktListType listType = null, TraktListSortOrder listSortOrder = null,
                                                                        TraktPagedParameters pagedParameters = null,
                                                                        CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new SeasonListsRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                Type = listType,
                SortOrder = listSortOrder,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all people for a <see cref="ITraktSeason" /> in a show with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/seasons/people/get-all-people-for-a-season">"Trakt API Doc - Seasons: People"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, for which the people should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktShowCastAndCrew" /> instance, containing the cast and crew for a season with the given showIdOrSlug and the given season number.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktShowCastAndCrew>> GetSeasonPeopleAsync(string showIdOrSlug, uint seasonNumber, TraktExtendedInfo extendedInfo = null,
                                                                               CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new SeasonPeopleRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the ratings for a <see cref="ITraktSeason" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/seasons/ratings/get-season-ratings">"Trakt API Doc - Seasons: Ratings"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, for which the ratings should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktRating" /> instance, containing the ratings for a season with the given showIdOrSlug and the given season number.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktRating>> GetSeasonRatingsAsync(string showIdOrSlug, uint seasonNumber,
                                                                       CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new SeasonRatingsRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the statistics for a <see cref="ITraktSeason" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/seasons/stats/get-season-stats">"Trakt API Doc - Seasons: Stats"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, for which the statistics should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktStatistics" /> instance, containing the statistics for a season with the given showIdOrSlug and the given season number.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktStatistics>> GetSeasonStatisticsAsync(string showIdOrSlug, uint seasonNumber,
                                                                              CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new SeasonStatisticsRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the translations for a <see cref="ITraktSeason" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/seasons/translations/get-all-season-translations">"Trakt API Doc - Seasons: Translations"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, for which the translations should be queried.</param>
        /// <param name="languageCode">An optional two letter language code to query a specific translation language.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktSeasonTranslation" /> instances, each containing a title, overview and language code.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktSeasonTranslation>> GetSeasonTranslationsAsync(string showIdOrSlug, uint seasonNumber, string languageCode = null,
                                                                                           CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new SeasonTranslationsRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                LanguageCode = languageCode
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all watching users of a <see cref="ITraktSeason" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/seasons/watching/get-users-watching-right-now">"Trakt API Doc - Seasons: Watching"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, for which the watching users should be queried.</param>
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
        public Task<TraktListResponse<ITraktUser>> GetSeasonWatchingUsersAsync(string showIdOrSlug, uint seasonNumber,
                                                                               TraktExtendedInfo extendedInfo = null,
                                                                               CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new SeasonWatchingUsersRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }
    }
}
