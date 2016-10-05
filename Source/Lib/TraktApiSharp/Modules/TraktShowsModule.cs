namespace TraktApiSharp.Modules
{
    using Attributes;
    using Enums;
    using Extensions;
    using Objects.Basic;
    using Objects.Get.Shows;
    using Objects.Get.Shows.Common;
    using Objects.Get.Users;
    using Requests;
    using Requests.Params;
    using Requests.WithOAuth.Shows;
    using Requests.WithoutOAuth.Shows;
    using Requests.WithoutOAuth.Shows.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to shows.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/shows">"Trakt API Doc - Shows"</a> section.
    /// </para>
    /// </summary>
    public class TraktShowsModule : TraktBaseModule
    {
        internal TraktShowsModule(TraktClient client) : base(client) { }

        /// <summary>
        /// Gets a <see cref="TraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/summary/get-a-single-show">"Trakt API Doc - Shows: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleShowsAsync(TraktMultipleObjectsQueryParams)" />.</para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the show should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>An <see cref="TraktShow" /> instance with the queried show's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktShow> GetShowAsync([NotNull] string showIdOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            Validate(showIdOrSlug);

            return await QueryAsync(new TraktShowSummaryRequest(Client)
            {
                Id = showIdOrSlug,
                ExtendedInfo = extendedInfo
            });
        }

        /// <summary>
        /// Gets multiple different <see cref="TraktShow" />s at once with the given Trakt-Ids or -Slugs.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/summary/get-a-single-show">"Trakt API Doc - Shows: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetShowAsync(string, TraktExtendedInfo)" />.</para>
        /// </summary>
        /// <param name="showsQueryParams">A list of show ids and optional extended infos. See also <seealso cref="TraktMultipleObjectsQueryParams" />.</param>
        /// <returns>A list of <see cref="TraktShow" /> instances with the data of each queried show.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if one of the given show ids is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktShow>> GetMultipleShowsAsync(TraktMultipleObjectsQueryParams showsQueryParams)
        {
            if (showsQueryParams == null || showsQueryParams.Count <= 0)
                return new List<TraktShow>();

            var tasks = new List<Task<TraktShow>>();

            foreach (var queryParam in showsQueryParams)
            {
                Task<TraktShow> task = GetShowAsync(queryParam.Id, queryParam.ExtendedInfo);
                tasks.Add(task);
            }

            var shows = await Task.WhenAll(tasks);
            return shows.ToList();
        }

        /// <summary>
        /// Gets all title aliases for a <see cref="TraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/aliases/get-all-show-aliases">"Trakt API Doc - Shows: Aliases"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <returns>A list of <see cref="TraktShowAlias" /> instances, each containing a title and country code.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktShowAlias>> GetShowAliasesAsync([NotNull] string showIdOrSlug)
        {
            Validate(showIdOrSlug);

            return await QueryAsync(new TraktShowAliasesRequest(Client) { Id = showIdOrSlug });
        }

        /// <summary>
        /// Gets all translations for a <see cref="TraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/translations/get-all-show-translations">"Trakt API Doc - Shows: Translations"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <returns>A list of <see cref="TraktShowTranslation" /> instances, each containing a title, overview and language code.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktShowTranslation>> GetShowTranslationsAsync([NotNull] string showIdOrSlug)
        {
            Validate(showIdOrSlug);

            return await QueryAsync(new TraktShowTranslationsRequest(Client) { Id = showIdOrSlug });
        }

        /// <summary>
        /// Gets a single translation for a <see cref="TraktShow" /> with the given Trakt-Id or -Slug and the given language code.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/translations/get-all-show-translations">"Trakt API Doc - Shows: Translations"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="languageCode">The 2 letter language code, for which a translation should be queried.</param>
        /// <returns>
        /// An <see cref="TraktShowTranslation" /> instance, containing a translated title, overview and language code
        /// for the show with the given showIdOrSlug.
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given showIdOrSlug is null, empty or contains spaces.
        /// Thronw, if the given language code is null, empty, contains spaces or doesn't have the length 2.
        /// </exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktShowTranslation> GetShowSingleTranslationAsync([NotNull] string showIdOrSlug, [NotNull] string languageCode)
        {
            Validate(showIdOrSlug, languageCode);

            return await QueryAsync(new TraktShowSingleTranslationRequest(Client)
            {
                Id = showIdOrSlug,
                LanguageCode = languageCode
            });
        }

        /// <summary>
        /// Gets top level comments for a <see cref="TraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/translations/get-all-show-comments">"Trakt API Doc - Shows: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="page">The page of the comments list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of comments for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktComment}"/> instance containing the queried show comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktComment>> GetShowCommentsAsync([NotNull] string showIdOrSlug,
                                                                                        TraktCommentSortOrder commentSortOrder = null,
                                                                                        int? page = null, int? limitPerPage = null)
        {
            Validate(showIdOrSlug);

            return await QueryAsync(new TraktShowCommentsRequest(Client)
            {
                Id = showIdOrSlug,
                Sorting = commentSortOrder,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });
        }

        /// <summary>
        /// Gets all people for a <see cref="TraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/people/get-all-people-for-a-show">"Trakt API Doc - Shows: People"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>An <see cref="TraktCastAndCrew" /> instance, containing the cast and crew for a show with the given showIdOrSlug.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktCastAndCrew> GetShowPeopleAsync([NotNull] string showIdOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            Validate(showIdOrSlug);

            return await QueryAsync(new TraktShowPeopleRequest(Client)
            {
                Id = showIdOrSlug,
                ExtendedInfo = extendedInfo
            });
        }

        /// <summary>
        /// Gets the ratings for a <see cref="TraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/ratings/get-show-ratings">"Trakt API Doc - Shows: Ratings"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <returns>An <see cref="TraktRating" /> instance, containing the ratings for a show with the given showIdOrSlug.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktRating> GetShowRatingsAsync([NotNull] string showIdOrSlug)
        {
            Validate(showIdOrSlug);

            return await QueryAsync(new TraktShowRatingsRequest(Client) { Id = showIdOrSlug });
        }

        /// <summary>
        /// Gets related shows for a <see cref="TraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/related/get-related-shows">"Trakt API Doc - Shows: Related"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="page">The page of the related shows list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of related shows for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktShow}"/> instance containing the queried related shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktShow>> GetShowRelatedShowsAsync([NotNull] string showIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                                         int? page = null, int? limitPerPage = null)
        {
            Validate(showIdOrSlug);

            return await QueryAsync(new TraktShowRelatedShowsRequest(Client)
            {
                Id = showIdOrSlug,
                ExtendedInfo = extendedInfo,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });
        }

        /// <summary>
        /// Gets the statistics for a <see cref="TraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/stats/get-show-stats">"Trakt API Doc - Shows: Stats"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <returns>An <see cref="TraktStatistics" /> instance, containing the statistics for a show with the given showIdOrSlug.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktStatistics> GetShowStatisticsAsync([NotNull] string showIdOrSlug)
        {
            Validate(showIdOrSlug);

            return await QueryAsync(new TraktShowStatisticsRequest(Client) { Id = showIdOrSlug });
        }

        /// <summary>
        /// Gets all watching users of a <see cref="TraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/watching/get-users-watching-right-now">"Trakt API Doc - Shows: Watching"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the users should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>A list of <see cref="TraktUser" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktUser>> GetShowWatchingUsersAsync([NotNull] string showIdOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            Validate(showIdOrSlug);

            return await QueryAsync(new TraktShowWatchingUsersRequest(Client) { Id = showIdOrSlug, ExtendedInfo = extendedInfo });
        }

        /// <summary>
        /// Gets the collection progress for a <see cref="TraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/collection-progress/get-show-collection-progress">"Trakt API Doc - Shows: Collection Progress"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="includingHiddenSeasons">Determines, if the returned collection progress should contain hidden seasons.</param>
        /// <param name="includingSpecialSeasons">Determines, if the returned collection progress should contain special seasons.</param>
        /// <param name="countSpecialSeasons">Determins, if special seasons should be counted in the statistics of the returned collection progress.</param>
        /// <returns>An <see cref="TraktShowCollectionProgress" /> instance, containing the collection progress for a show with the given showIdOrSlug.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktShowCollectionProgress> GetShowCollectionProgressAsync([NotNull] string showIdOrSlug, bool? includingHiddenSeasons = null,
                                                                                      bool? includingSpecialSeasons = null,
                                                                                      bool? countSpecialSeasons = null)
        {
            Validate(showIdOrSlug);

            return await QueryAsync(new TraktShowCollectionProgressRequest(Client)
            {
                Id = showIdOrSlug,
                Hidden = includingHiddenSeasons,
                Specials = includingSpecialSeasons,
                CountSpecials = countSpecialSeasons
            });
        }

        /// <summary>
        /// Gets the watched progress for a <see cref="TraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/watched-progress/get-show-watched-progress">"Trakt API Doc - Shows: Watched Progress"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="includingHiddenSeasons">Determines, if the returned watched progress should contain hidden seasons.</param>
        /// <param name="includingSpecialSeasons">Determines, if the returned watched progress should contain special seasons.</param>
        /// <param name="countSpecialSeasons">Determins, if special seasons should be counted in the statistics of the returned watched progress.</param>
        /// <returns>An <see cref="TraktShowWatchedProgress" /> instance, containing the watched progress for a show with the given showIdOrSlug.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktShowWatchedProgress> GetShowWatchedProgressAsync([NotNull] string showIdOrSlug, bool? includingHiddenSeasons = null,
                                                                                bool? includingSpecialSeasons = null,
                                                                                bool? countSpecialSeasons = null)
        {
            Validate(showIdOrSlug);

            return await QueryAsync(new TraktShowWatchedProgressRequest(Client)
            {
                Id = showIdOrSlug,
                Hidden = includingHiddenSeasons,
                Specials = includingSpecialSeasons,
                CountSpecials = countSpecialSeasons
            });
        }

        /// <summary>
        /// Gets trending shows.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/trending/get-trending-shows">"Trakt API Doc - Shows: Trending"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktShowFilter" />.</param>
        /// <param name="page">The page of the trending shows list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum item count of trending shows for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktTrendingShow}"/> instance containing the queried trending shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktTrendingShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktTrendingShow>> GetTrendingShowsAsync(TraktExtendedInfo extendedInfo = null,
                                                                                  TraktShowFilter filter = null,
                                                                                  int? page = null, int? limitPerPage = null)
            => await QueryAsync(new TraktShowsTrendingRequest(Client)
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });

        /// <summary>
        /// Gets popular shows.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/popular/get-popular-shows">"Trakt API Doc - Shows: Popular"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktShowFilter" />.</param>
        /// <param name="page">The page of the popular shows list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum item count of popular shows for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktShow}"/> instance containing the queried popular shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktShow>> GetPopularShowsAsync(TraktExtendedInfo extendedInfo = null,
                                                                         TraktShowFilter filter = null,
                                                                         int? page = null, int? limitPerPage = null)
            => await QueryAsync(new TraktShowsPopularRequest(Client)
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });

        /// <summary>
        /// Gets the most played shows.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/played/get-the-most-played-shows">"Trakt API Doc - Shows: Played"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="period">The time period, for which the most played shows should be queried. See also <seealso cref="TraktTimePeriod" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktShowFilter" />.</param>
        /// <param name="page">The page of the most played shows list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum item count of most played shows for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktMostPlayedShow}"/> instance containing the queried most played shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktMostPlayedShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktMostPlayedShow>> GetMostPlayedShowsAsync(TraktTimePeriod period = null,
                                                                                      TraktExtendedInfo extendedInfo = null,
                                                                                      TraktShowFilter filter = null,
                                                                                      int? page = null, int? limitPerPage = null)
            => await QueryAsync(new TraktShowsMostPlayedRequest(Client)
            {
                Period = period,
                ExtendedInfo = extendedInfo,
                Filter = filter,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });

        /// <summary>
        /// Gets the most watched shows.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/watched/get-the-most-watched-shows">"Trakt API Doc - Shows: Watched"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="period">The time period, for which the most watched shows should be queried. See also <seealso cref="TraktTimePeriod" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktShowFilter" />.</param>
        /// <param name="page">The page of the most watched shows list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum item count of most watched shows for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktMostWatchedShow}"/> instance containing the queried most watched shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktMostWatchedShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktMostWatchedShow>> GetMostWatchedShowsAsync(TraktTimePeriod period = null,
                                                                                        TraktExtendedInfo extendedInfo = null,
                                                                                        TraktShowFilter filter = null,
                                                                                        int? page = null, int? limitPerPage = null)
            => await QueryAsync(new TraktShowsMostWatchedRequest(Client)
            {
                Period = period,
                ExtendedInfo = extendedInfo,
                Filter = filter,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });

        /// <summary>
        /// Gets the most collected shows.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/collected/get-the-most-collected-shows">"Trakt API Doc - Shows: Collected"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="period">The time period, for which the most collected shows should be queried. See also <seealso cref="TraktTimePeriod" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktShowFilter" />.</param>
        /// <param name="page">The page of the most collected shows list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum item count of most collected shows for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktMostCollectedShow}"/> instance containing the queried most collected shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktMostCollectedShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktMostCollectedShow>> GetMostCollectedShowsAsync(TraktTimePeriod period = null,
                                                                                            TraktExtendedInfo extendedInfo = null,
                                                                                            TraktShowFilter filter = null,
                                                                                            int? page = null, int? limitPerPage = null)
            => await QueryAsync(new TraktShowsMostCollectedRequest(Client)
            {
                Period = period,
                ExtendedInfo = extendedInfo,
                Filter = filter,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });

        /// <summary>
        /// Gets the most anticipated shows.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/anticipated/get-the-most-anticipated-shows">"Trakt API Doc - Shows: Anticipated"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktShowFilter" />.</param>
        /// <param name="page">The page of the most anticipated shows list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum item count of most anticipated shows for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktMostAnticipatedShow}"/> instance containing the queried most anticipated shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktMostAnticipatedShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktMostAnticipatedShow>> GetMostAnticipatedShowsAsync(TraktExtendedInfo extendedInfo = null,
                                                                                                TraktShowFilter filter = null,
                                                                                                int? page = null, int? limitPerPage = null)
            => await QueryAsync(new TraktShowsMostAnticipatedRequest(Client)
            {
                ExtendedInfo = extendedInfo,
                Filter = filter,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });

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
        /// <param name="page">The page of the updated shows list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum item count of updated shows for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktRecentlyUpdatedShow}"/> instance containing the queried updated shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktRecentlyUpdatedShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktRecentlyUpdatedShow>> GetRecentlyUpdatedShowsAsync(DateTime? startDate = null,
                                                                                                TraktExtendedInfo extendedInfo = null,
                                                                                                int? page = null, int? limitPerPage = null)
            => await QueryAsync(new TraktShowsRecentlyUpdatedRequest(Client)
            {
                StartDate = startDate,
                ExtendedInfo = extendedInfo,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });

        private void Validate(string showIdOrSlug)
        {
            if (string.IsNullOrEmpty(showIdOrSlug) || showIdOrSlug.ContainsSpace())
                throw new ArgumentException("show id or slug not valid", nameof(showIdOrSlug));
        }

        private void Validate(string showIdOrSlug, string languageCode)
        {
            Validate(showIdOrSlug);

            if (string.IsNullOrEmpty(languageCode) || languageCode.Length != 2)
                throw new ArgumentException("show language code not valid", nameof(languageCode));
        }
    }
}
