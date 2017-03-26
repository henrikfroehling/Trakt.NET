namespace TraktApiSharp.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Basic;
    using Objects.Get.Episodes;
    using Objects.Get.Seasons;
    using Objects.Get.Shows;
    using Objects.Get.Users;
    using Objects.Get.Users.Lists;
    using Requests.Handler;
    using Requests.Parameters;
    using Requests.Seasons;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Objects.Get.Episodes.Implementations;
    using TraktApiSharp.Objects.Get.Seasons.Implementations;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using TraktApiSharp.Objects.Get.Users.Lists.Implementations;

    /// <summary>
    /// Provides access to data retrieving methods specific to seasons.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/seasons">"Trakt API Doc - Seasons"</a> section.
    /// </para>
    /// </summary>
    public class TraktSeasonsModule : TraktBaseModule
    {
        internal TraktSeasonsModule(TraktClient client) : base(client) { }

        /// <summary>
        /// Gets the <see cref="TraktSeason" />s in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/seasons/summary/get-all-seasons-for-a-show">"Trakt API Doc - Seasons: Summary"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the seasons should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="translationLanguageCode">
        /// An optional two letter language code to query a specific translation for the returned episodes.
        /// <para>Set this to "all" to get all available translations.</para>
        /// </param>
        /// <returns>A list of <see cref="TraktSeason" /> instances with the data of each queried season.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given translationLanguageCode is shorter or longer than two characters, if it is not set to "all".
        /// </exception>
        public async Task<TraktListResponse<TraktSeason>> GetAllSeasonsAsync(string showIdOrSlug,
                                                                             TraktExtendedInfo extendedInfo = null,
                                                                             string translationLanguageCode = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecuteListRequestAsync(new TraktSeasonsAllRequest
            {
                Id = showIdOrSlug,
                ExtendedInfo = extendedInfo,
                TranslationLanguageCode = translationLanguageCode
            });
        }

        /// <summary>
        /// Gets all <see cref="TraktEpisode" />s in a single season in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/seasons/season/get-single-season-for-a-show">"Trakt API Doc - Seasons: Season"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleSeasonsAsync(TraktMultipleSeasonsQueryParams)" />.</para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, which should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the season's episodes should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="translationLanguageCode">
        /// An optional two letter language code to query a specific translation for the returned episodes.
        /// <para>Set this to "all" to get all available translations.</para>
        /// </param>
        /// <returns>A list of <see cref="TraktEpisode" /> instances with the data of each episode in the queried season.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given season number is below zero.
        /// Thrown, if the given translationLanguageCode is shorter or longer than two characters, if it is not set to "all".
        /// </exception>
        public async Task<TraktListResponse<TraktEpisode>> GetSeasonAsync(string showIdOrSlug, uint seasonNumber,
                                                                          TraktExtendedInfo extendedInfo = null,
                                                                          string translationLanguageCode = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecuteListRequestAsync(new TraktSeasonSingleRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                ExtendedInfo = extendedInfo,
                TranslationLanguageCode = translationLanguageCode
            });
        }

        /// <summary>
        /// Gets multiple different seasons at once in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/seasons/season/get-single-season-for-a-show">"Trakt API Doc - Seasons: Season"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetSeasonAsync(string, uint, TraktExtendedInfo, string)" />.</para>
        /// </summary>
        /// <param name="seasonsQueryParams">A list of show ids, season numbers and optional extended infos. See also <seealso cref="TraktMultipleSeasonsQueryParams" />.</param>
        /// <returns>A list of lists, each containing <see cref="TraktEpisode" /> instances with the data of each episode in the queried seasons.</returns>
        /// <exception cref="TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if one of the given show ids is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if one of the given season numbers is below zero.</exception>
        public async Task<IEnumerable<TraktListResponse<TraktEpisode>>> GetMultipleSeasonsAsync(TraktMultipleSeasonsQueryParams seasonsQueryParams)
        {
            if (seasonsQueryParams == null || seasonsQueryParams.Count <= 0)
                return new List<TraktListResponse<TraktEpisode>>();

            var tasks = new List<Task<TraktListResponse<TraktEpisode>>>();

            foreach (var queryParam in seasonsQueryParams)
            {
                Task<TraktListResponse<TraktEpisode>> task = GetSeasonAsync(queryParam.ShowId, queryParam.Season,
                                                                            queryParam.ExtendedInfo,
                                                                            queryParam.TranslationLanguageCode);

                tasks.Add(task);
            }

            var seasons = await Task.WhenAll(tasks);
            return seasons.ToList();
        }

        /// <summary>
        /// Gets top level comments for a <see cref="TraktSeason" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/seasons/comments/get-all-season-comments">"Trakt API Doc - Seasons: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, for which the comments should be queried.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="page">The page of the comments list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of comments for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{TraktComment}"/> instance containing the queried season comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="TraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given season number is below zero.</exception>
        public async Task<TraktPagedResponse<TraktComment>> GetSeasonCommentsAsync(string showIdOrSlug, uint seasonNumber,
                                                                                   TraktCommentSortOrder commentSortOrder = null,
                                                                                   int? page = null, int? limitPerPage = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecutePagedRequestAsync(new TraktSeasonCommentsRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                SortOrder = commentSortOrder,
                Page = page,
                Limit = limitPerPage
            });
        }

        /// <summary>
        /// Gets all <see cref="TraktList" />s containing the given <see cref="TraktSeason" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/seasons/lists/get-lists-containing-this-season">"Trakt API Doc - Seasons: Lists"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, for which the lists should be queried.</param>
        /// <param name="listType">The type of lists, that should be queried. Defaults to personal lists.</param>
        /// <param name="listSortOrder">The list sort order. See also <seealso cref="TraktListSortOrder" />. Defaults to sorted by popularity.</param>
        /// <param name="page">The page of the <see cref="TraktList" /> list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of <see cref="TraktList" />s for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{TraktList}"/> instance containing the queried season lists and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="TraktList" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given season number is below zero.</exception>
        public async Task<TraktPagedResponse<TraktList>> GetSeasonListsAsync(string showIdOrSlug, uint seasonNumber,
                                                                             TraktListType listType = null, TraktListSortOrder listSortOrder = null,
                                                                             int? page = null, int? limitPerPage = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecutePagedRequestAsync(new TraktSeasonListsRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                Type = listType,
                SortOrder = listSortOrder,
                Page = page,
                Limit = limitPerPage
            });
        }

        /// <summary>
        /// Gets the ratings for a <see cref="TraktSeason" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/seasons/ratings/get-season-ratings">"Trakt API Doc - Seasons: Ratings"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, for which the ratings should be queried.</param>
        /// <returns>An <see cref="TraktRating" /> instance, containing the ratings for a season with the given showIdOrSlug and the given season number.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given season number is below zero.</exception>
        public async Task<TraktResponse<TraktRating>> GetSeasonRatingsAsync(string showIdOrSlug, uint seasonNumber)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecuteSingleItemRequestAsync(new TraktSeasonRatingsRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber
            });
        }

        /// <summary>
        /// Gets the statistics for a <see cref="TraktSeason" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/seasons/stats/get-season-stats">"Trakt API Doc - Seasons: Stats"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, for which the statistics should be queried.</param>
        /// <returns>An <see cref="TraktStatistics" /> instance, containing the statistics for a season with the given showIdOrSlug and the given season number.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given season number is below zero.</exception>
        public async Task<TraktResponse<TraktStatistics>> GetSeasonStatisticsAsync(string showIdOrSlug, uint seasonNumber)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecuteSingleItemRequestAsync(new TraktSeasonStatisticsRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber
            });
        }

        /// <summary>
        /// Gets all watching users of a <see cref="TraktSeason" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/seasons/watching/get-users-watching-right-now">"Trakt API Doc - Seasons: Watching"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, for which the watching users should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the users should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>A list of <see cref="TraktUser" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given season number is below zero.</exception>
        public async Task<TraktListResponse<TraktUser>> GetSeasonWatchingUsersAsync(string showIdOrSlug, uint seasonNumber,
                                                                                    TraktExtendedInfo extendedInfo = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecuteListRequestAsync(new TraktSeasonWatchingUsersRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                ExtendedInfo = extendedInfo
            });
        }
    }
}
