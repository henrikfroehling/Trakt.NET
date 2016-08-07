namespace TraktApiSharp.Modules
{
    using Attributes;
    using Enums;
    using Extensions;
    using Objects.Basic;
    using Objects.Get.Shows.Episodes;
    using Objects.Get.Shows.Seasons;
    using Objects.Get.Users;
    using Requests;
    using Requests.Params;
    using Requests.WithoutOAuth.Shows.Seasons;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="Objects.Get.Shows.TraktShowIds" />.</param>
        /// <param name="extendedOption">
        /// The extended option, which determines how much data about the seasons should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <returns>A list of <see cref="TraktSeason" /> instances with the data of each queried season.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktSeason>> GetAllSeasonsAsync([NotNull] string showIdOrSlug, TraktExtendedOption extendedOption = null)
        {
            Validate(showIdOrSlug);

            return await QueryAsync(new TraktSeasonsAllRequest(Client)
            {
                Id = showIdOrSlug,
                ExtendedOption = extendedOption
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
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="Objects.Get.Shows.TraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, which should be queried.</param>
        /// <param name="extendedOption">
        /// The extended option, which determines how much data about the season's episodes should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <returns>A list of <see cref="TraktEpisode" /> instances with the data of each episode in the queried season.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given season number is below zero.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktEpisode>> GetSeasonAsync([NotNull] string showIdOrSlug, int seasonNumber,
                                                                    TraktExtendedOption extendedOption = null)
        {
            Validate(showIdOrSlug, seasonNumber);

            return await QueryAsync(new TraktSeasonSingleRequest(Client)
            {
                Id = showIdOrSlug,
                Season = seasonNumber,
                ExtendedOption = extendedOption
            });
        }

        /// <summary>
        /// Gets multiple different seasons at once in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/seasons/season/get-single-season-for-a-show">"Trakt API Doc - Seasons: Season"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetSeasonAsync(string, int, TraktExtendedOption)" />.</para>
        /// </summary>
        /// <param name="seasonsQueryParams">A list of show ids, season numbers and optional extended options. See also <seealso cref="TraktMultipleSeasonsQueryParams" />.</param>
        /// <returns>A list of lists, each containing <see cref="TraktEpisode" /> instances with the data of each episode in the queried seasons.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if one of the given show ids is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if one of the given season numbers is below zero.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<IEnumerable<TraktEpisode>>> GetMultipleSeasonsAsync(TraktMultipleSeasonsQueryParams seasonsQueryParams)
        {
            if (seasonsQueryParams == null || seasonsQueryParams.Count <= 0)
                return new List<List<TraktEpisode>>();

            var tasks = new List<Task<IEnumerable<TraktEpisode>>>();

            foreach (var queryParam in seasonsQueryParams)
            {
                Task<IEnumerable<TraktEpisode>> task = GetSeasonAsync(queryParam.ShowId, queryParam.Season,
                                                                      queryParam.ExtendedOption);

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
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="Objects.Get.Shows.TraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, for which the comments should be queried.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="page">The page of the comments list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of comments for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktComment}"/> instance containing the queried season comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given season number is below zero.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktComment>> GetSeasonCommentsAsync([NotNull] string showIdOrSlug, int seasonNumber,
                                                                                          TraktCommentSortOrder commentSortOrder = null,
                                                                                          int? page = null, int? limitPerPage = null)
        {
            Validate(showIdOrSlug, seasonNumber);

            return await QueryAsync(new TraktSeasonCommentsRequest(Client)
            {
                Id = showIdOrSlug,
                Season = seasonNumber,
                Sorting = commentSortOrder,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });
        }

        /// <summary>
        /// Gets the ratings for a <see cref="TraktSeason" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/seasons/ratings/get-season-ratings">"Trakt API Doc - Seasons: Ratings"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="Objects.Get.Shows.TraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, for which the ratings should be queried.</param>
        /// <returns>An <see cref="TraktRating" /> instance, containing the ratings for a season with the given showIdOrSlug and the given season number.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given season number is below zero.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktRating> GetSeasonRatingsAsync([NotNull] string showIdOrSlug, int seasonNumber)
        {
            Validate(showIdOrSlug, seasonNumber);

            return await QueryAsync(new TraktSeasonRatingsRequest(Client)
            {
                Id = showIdOrSlug,
                Season = seasonNumber
            });
        }

        /// <summary>
        /// Gets the statistics for a <see cref="TraktSeason" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/seasons/stats/get-season-stats">"Trakt API Doc - Seasons: Stats"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="Objects.Get.Shows.TraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, for which the statistics should be queried.</param>
        /// <returns>An <see cref="TraktStatistics" /> instance, containing the statistics for a season with the given showIdOrSlug and the given season number.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given season number is below zero.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktStatistics> GetSeasonStatisticsAsync([NotNull] string showIdOrSlug, int seasonNumber)
        {
            Validate(showIdOrSlug, seasonNumber);

            return await QueryAsync(new TraktSeasonStatisticsRequest(Client)
            {
                Id = showIdOrSlug,
                Season = seasonNumber
            });
        }

        /// <summary>
        /// Gets all watching users of a <see cref="TraktSeason" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/seasons/watching/get-users-watching-right-now">"Trakt API Doc - Seasons: Watching"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="Objects.Get.Shows.TraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, for which the watching users should be queried.</param>
        /// <param name="extendedOption">
        /// The extended option, which determines how much data about the users should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <returns>A list of <see cref="TraktUser" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given season number is below zero.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktUser>> GetSeasonWatchingUsersAsync([NotNull] string showIdOrSlug, int seasonNumber,
                                                                              TraktExtendedOption extendedOption = null)
        {
            Validate(showIdOrSlug, seasonNumber);

            return await QueryAsync(new TraktSeasonWatchingUsersRequest(Client)
            {
                Id = showIdOrSlug,
                Season = seasonNumber,
                ExtendedOption = extendedOption
            });
        }

        private void Validate(string showIdOrSlug, int seasonNumber = 0)
        {
            if (string.IsNullOrEmpty(showIdOrSlug) || showIdOrSlug.ContainsSpace())
                throw new ArgumentException("show id or slug not valid", nameof(showIdOrSlug));

            if (seasonNumber < 0)
                throw new ArgumentOutOfRangeException(nameof(seasonNumber), "season number not valid");
        }
    }
}
