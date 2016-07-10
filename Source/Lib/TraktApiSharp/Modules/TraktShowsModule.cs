namespace TraktApiSharp.Modules
{
    using Enums;
    using Extensions;
    using Objects.Basic;
    using Objects.Get.Shows;
    using Objects.Get.Shows.Common;
    using Objects.Get.Users;
    using Requests;
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
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/summary/get-a-single-show">"Trakt API Doc - Shows: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetShowsAsync(string[], TraktExtendedOption)" />.</para>
        /// </summary>
        /// <param name="id">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="extended">
        /// The extended option, which determines how much data about the show should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <returns>A <see cref="TraktShow" /> instance with the queried show's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given id is null, empty or contains spaces.</exception>
        public async Task<TraktShow> GetShowAsync(string id, TraktExtendedOption extended = null)
        {
            Validate(id);

            return await QueryAsync(new TraktShowSummaryRequest(Client)
            {
                Id = id,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        /// <summary>
        /// Gets multiple <see cref="TraktShow" />s at once with the given Trakt-Ids or -Slugs.
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/summary/get-a-single-show">"Trakt API Doc - Shows: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetShowAsync(string, TraktExtendedOption)" />.</para>
        /// </summary>
        /// <param name="ids">An array of <see cref="TraktIdAndExtendedOption" />.</param>
        /// <param name="extended">
        /// The extended option, which determines how much data about the show should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <returns>A list of <see cref="TraktShow" /> instances with the data of each queried show.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if one of the given ids is null, empty or contains spaces.</exception>
        // TODO rename -> multiple
        public async Task<TraktListResult<TraktShow>> GetShowsAsync(TraktIdAndExtendedOption[] ids)
        {
            if (ids == null || ids.Length <= 0)
                return null;

            var tasks = new List<Task<TraktShow>>();

            for (int i = 0; i < ids.Length; i++)
            {
                var showRequest = ids[i];

                if (showRequest != null)
                {
                    Task<TraktShow> task = GetShowAsync(showRequest.Id, showRequest.ExtendedOption);
                    tasks.Add(task);
                }
            }

            var shows = await Task.WhenAll(tasks);
            return new TraktListResult<TraktShow> { Items = shows.ToList() };
        }

        /// <summary>
        /// Gets all title aliases for a <see cref="TraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/aliases/get-all-show-aliases">"Trakt API Doc - Shows: Aliases"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="id">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <returns>A list of <see cref="TraktShowAlias" /> instances, each containing a title and country code.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given id is null, empty or contains spaces.</exception>
        public async Task<TraktListResult<TraktShowAlias>> GetShowAliasesAsync(string id)
        {
            Validate(id);

            return await QueryAsync(new TraktShowAliasesRequest(Client) { Id = id });
        }

        /// <summary>
        /// Gets all translations for a <see cref="TraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/translations/get-all-show-translations">"Trakt API Doc - Shows: Translations"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="id">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <returns>A list of <see cref="TraktShowTranslation" /> instances, each containing a title, overview and country code.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given id is null, empty or contains spaces.</exception>
        public async Task<TraktListResult<TraktShowTranslation>> GetShowTranslationsAsync(string id)
        {
            Validate(id);

            return await QueryAsync(new TraktShowTranslationsRequest(Client) { Id = id });
        }

        /// <summary>
        /// Gets a single translation for a <see cref="TraktShow" /> with the given Trakt-Id or -Slug and the given language code.
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/translations/get-all-show-translations">"Trakt API Doc - Shows: Translations"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="id">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="languageCode">The language code, for which a translation should be queried.</param>
        /// <returns>
        /// A <see cref="TraktShowTranslation" /> instance, containing a translated title, overview and country code
        /// for the show with the given id.
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given id is null, empty or contains spaces.
        /// Thronw, if the given language code is null, empty, contains spaces or doesn't have the length 2.
        /// </exception>
        public async Task<TraktShowTranslation> GetShowSingleTranslationAsync(string id, string languageCode)
        {
            Validate(id, languageCode);

            return await QueryAsync(new TraktShowSingleTranslationRequest(Client)
            {
                Id = id,
                LanguageCode = languageCode
            });
        }

        /// <summary>
        /// Gets all comments for a <see cref="TraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/translations/get-all-show-comments">"Trakt API Doc - Shows: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="id">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="sorting">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="page">The page of the comments list, that should be queried. See also <see cref="TraktPaginationOptions" />.</param>
        /// <param name="limit">The maximum count of comments, that should be queried. See also <see cref="TraktPaginationOptions" />.</param>
        /// <returns>
        /// A <see cref="TraktPaginationListResult{TraktComment}"/> instance containing the queried show comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given id is null, empty or contains spaces.</exception>
        public async Task<TraktPaginationListResult<TraktComment>> GetShowCommentsAsync(string id,
                                                                                        TraktCommentSortOrder? sorting = null,
                                                                                        int? page = null, int? limit = null)
        {
            Validate(id);

            return await QueryAsync(new TraktShowCommentsRequest(Client)
            {
                Id = id,
                Sorting = sorting,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        /// <summary>
        /// Gets all people for a <see cref="TraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/people/get-all-people-for-a-show">"Trakt API Doc - Shows: People"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="id">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="extended">
        /// The extended option, which determines how much data about the persons should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <returns>A <see cref="TraktCastAndCrew" /> instance, containing the cast and crew for a show with the given id.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given id is null, empty or contains spaces.</exception>
        public async Task<TraktCastAndCrew> GetShowPeopleAsync(string id, TraktExtendedOption extended = null)
        {
            Validate(id);

            return await QueryAsync(new TraktShowPeopleRequest(Client)
            {
                Id = id,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        /// <summary>
        /// Gets the ratings for a <see cref="TraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/ratings/get-show-ratings">"Trakt API Doc - Shows: Ratings"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="id">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <returns>A <see cref="TraktRating" /> instance, containing the ratings for a show with the given id.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given id is null, empty or contains spaces.</exception>
        public async Task<TraktRating> GetShowRatingsAsync(string id)
        {
            Validate(id);

            return await QueryAsync(new TraktShowRatingsRequest(Client) { Id = id });
        }

        /// <summary>
        /// Gets all related shows for a <see cref="TraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/related/get-related-shows">"Trakt API Doc - Shows: Related"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="id">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="extended">
        /// The extended option, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <param name="page">The page of the comments list, that should be queried. See also <see cref="TraktPaginationOptions" />.</param>
        /// <param name="limit">The maximum count of comments, that should be queried. See also <see cref="TraktPaginationOptions" />.</param>
        /// <returns>
        /// A <see cref="TraktPaginationListResult{TraktShow}"/> instance containing the queried related shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given id is null, empty or contains spaces.</exception>
        public async Task<TraktPaginationListResult<TraktShow>> GetShowRelatedShowsAsync(string id, TraktExtendedOption extended = null,
                                                                                         int? page = null, int? limit = null)
        {
            Validate(id);

            return await QueryAsync(new TraktShowRelatedShowsRequest(Client)
            {
                Id = id,
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        /// <summary>
        /// Gets the statistics for a <see cref="TraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/stats/get-show-stats">"Trakt API Doc - Shows: Stats"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="id">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <returns>A <see cref="TraktStatistics" /> instance, containing the statistics for a show with the given id.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given id is null, empty or contains spaces.</exception>
        public async Task<TraktStatistics> GetShowStatisticsAsync(string id)
        {
            Validate(id);

            return await QueryAsync(new TraktShowStatisticsRequest(Client) { Id = id });
        }

        /// <summary>
        /// Gets all watching users of a <see cref="TraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/watching/get-users-watching-right-now">"Trakt API Doc - Shows: Watching"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="id">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="extended">
        /// The extended option, which determines how much data about the users should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <returns>A list of <see cref="TraktUser" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given id is null, empty or contains spaces.</exception>
        public async Task<TraktListResult<TraktUser>> GetShowWatchingUsersAsync(string id, TraktExtendedOption extended = null)
        {
            Validate(id);

            return await QueryAsync(new TraktShowWatchingUsersRequest(Client) { Id = id, ExtendedOption = extended ?? new TraktExtendedOption() });
        }

        /// <summary>
        /// Gets the collection progress for a <see cref="TraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/collection-progress/get-show-collection-progress">"Trakt API Doc - Shows: Collection Progress"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="id">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="hidden">Determines, if the returned collection progress should contain hidden seasons.</param>
        /// <param name="specials">Determines, if the returned collection progress should contain special seasons.</param>
        /// <returns>A <see cref="TraktShowCollectionProgress" /> instance, containing the collection progress for a show with the given id.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given id is null, empty or contains spaces.</exception>
        public async Task<TraktShowCollectionProgress> GetShowCollectionProgressAsync(string id, bool? hidden = null, bool? specials = null)
        {
            Validate(id);

            return await QueryAsync(new TraktShowCollectionProgressRequest(Client)
            {
                Id = id,
                Hidden = hidden,
                Specials = specials
            });
        }

        /// <summary>
        /// Gets the watched progress for a <see cref="TraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/watched-progress/get-show-watched-progress">"Trakt API Doc - Shows: Watched Progress"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="id">The show's Trakt-Id or -Slug. See also <seealso cref="TraktShowIds" />.</param>
        /// <param name="hidden">Determines, if the returned watched progress should contain hidden seasons.</param>
        /// <param name="specials">Determines, if the returned watched progress should contain special seasons.</param>
        /// <returns>A <see cref="TraktShowWatchedProgress" /> instance, containing the watched progress for a show with the given id.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given id is null, empty or contains spaces.</exception>
        public async Task<TraktShowWatchedProgress> GetShowWatchedProgressAsync(string id, bool? hidden = null, bool? specials = null)
        {
            Validate(id);

            return await QueryAsync(new TraktShowWatchedProgressRequest(Client)
            {
                Id = id,
                Hidden = hidden,
                Specials = specials
            });
        }

        /// <summary>
        /// Gets all trending shows.
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/trending/get-trending-shows">"Trakt API Doc - Shows: Trending"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="extended">
        /// The extended option, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <param name="page">The page of the trending shows list, that should be queried. See also <see cref="TraktPaginationOptions" />.</param>
        /// <param name="limit">The maximum item count of trending shows for each page, that should be queried. See also <see cref="TraktPaginationOptions" />.</param>
        /// <returns>
        /// A <see cref="TraktPaginationListResult{TraktTrendingShow}"/> instance containing the queried trending shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktTrendingShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktPaginationListResult<TraktTrendingShow>> GetTrendingShowsAsync(TraktExtendedOption extended = null,
                                                                                              TraktShowFilter filter = null,
                                                                                              int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowsTrendingRequest(Client)
            {
                ExtendedOption = extended ?? new TraktExtendedOption(),
                Filter = filter,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        /// <summary>
        /// Gets all popular shows.
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/popular/get-popular-shows">"Trakt API Doc - Shows: Popular"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="extended">
        /// The extended option, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <param name="page">The page of the popular shows list, that should be queried. See also <see cref="TraktPaginationOptions" />.</param>
        /// <param name="limit">The maximum item count of popular shows for each page, that should be queried. See also <see cref="TraktPaginationOptions" />.</param>
        /// <returns>
        /// A <see cref="TraktPaginationListResult{TraktShow}"/> instance containing the queried popular shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktPaginationListResult<TraktShow>> GetPopularShowsAsync(TraktExtendedOption extended = null,
                                                                                     TraktShowFilter filter = null,
                                                                                     int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowsPopularRequest(Client)
            {
                ExtendedOption = extended ?? new TraktExtendedOption(),
                Filter = filter,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        /// <summary>
        /// Gets the most played shows.
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/played/get-the-most-played-shows">"Trakt API Doc - Shows: Played"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="period">The time peried, for which the most played shows should be queried. See also <seealso cref="TraktPeriod" />.</param>
        /// <param name="extended">
        /// The extended option, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <param name="page">The page of the most played shows list, that should be queried. See also <see cref="TraktPaginationOptions" />.</param>
        /// <param name="limit">The maximum item count of most played shows for each page, that should be queried. See also <see cref="TraktPaginationOptions" />.</param>
        /// <returns>
        /// A <see cref="TraktPaginationListResult{TraktMostPlayedShow}"/> instance containing the queried most played shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktMostPlayedShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        // TODO add filters
        public async Task<TraktPaginationListResult<TraktMostPlayedShow>> GetMostPlayedShowsAsync(TraktPeriod? period = null,
                                                                                                  TraktExtendedOption extended = null,
                                                                                                  int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowsMostPlayedRequest(Client)
            {
                Period = period,
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        /// <summary>
        /// Gets the most watched shows.
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/watched/get-the-most-watched-shows">"Trakt API Doc - Shows: Watched"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="period">The time peried, for which the most watched shows should be queried. See also <seealso cref="TraktPeriod" />.</param>
        /// <param name="extended">
        /// The extended option, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <param name="page">The page of the most watched shows list, that should be queried. See also <see cref="TraktPaginationOptions" />.</param>
        /// <param name="limit">The maximum item count of most watched shows for each page, that should be queried. See also <see cref="TraktPaginationOptions" />.</param>
        /// <returns>
        /// A <see cref="TraktPaginationListResult{TraktMostWatchedShow}"/> instance containing the queried most watched shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktMostWatchedShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        // TODO add filters
        public async Task<TraktPaginationListResult<TraktMostWatchedShow>> GetMostWatchedShowsAsync(TraktPeriod? period = null,
                                                                                                    TraktExtendedOption extended = null,
                                                                                                    int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowsMostWatchedRequest(Client)
            {
                Period = period,
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        /// <summary>
        /// Gets the most collected shows.
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/collected/get-the-most-collected-shows">"Trakt API Doc - Shows: Collected"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="period">The time peried, for which the most collected shows should be queried. See also <seealso cref="TraktPeriod" />.</param>
        /// <param name="extended">
        /// The extended option, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <param name="page">The page of the most collected shows list, that should be queried. See also <see cref="TraktPaginationOptions" />.</param>
        /// <param name="limit">The maximum item count of most collected shows for each page, that should be queried. See also <see cref="TraktPaginationOptions" />.</param>
        /// <returns>
        /// A <see cref="TraktPaginationListResult{TraktMostCollectedShow}"/> instance containing the queried most collected shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktMostCollectedShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        // TODO add filters
        public async Task<TraktPaginationListResult<TraktMostCollectedShow>> GetMostCollectedShowsAsync(TraktPeriod? period = null,
                                                                                                        TraktExtendedOption extended = null,
                                                                                                        int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowsMostCollectedRequest(Client)
            {
                Period = period,
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        /// <summary>
        /// Gets the most anticipated shows.
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/anticipated/get-the-most-anticipated-shows">"Trakt API Doc - Shows: Anticipated"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="extended">
        /// The extended option, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <param name="page">The page of the most anticipated shows list, that should be queried. See also <see cref="TraktPaginationOptions" />.</param>
        /// <param name="limit">The maximum item count of most anticipated shows for each page, that should be queried. See also <see cref="TraktPaginationOptions" />.</param>
        /// <returns>
        /// A <see cref="TraktPaginationListResult{TraktMostAnticipatedShow}"/> instance containing the queried most anticipated shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktMostAnticipatedShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        // TODO add filters
        public async Task<TraktPaginationListResult<TraktMostAnticipatedShow>> GetMostAnticipatedShowsAsync(TraktExtendedOption extended = null,
                                                                                                            int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowsMostAnticipatedRequest(Client)
            {
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        /// <summary>
        /// Gets the updated shows since the given <paramref name="startDate" />.
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/anticipated/get-recently-updated-shows">"Trakt API Doc - Shows: Updates"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The start date, after which updated shows should be queried.</param>
        /// <param name="extended">
        /// The extended option, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <param name="page">The page of the updated shows list, that should be queried. See also <see cref="TraktPaginationOptions" />.</param>
        /// <param name="limit">The maximum item count of updated shows for each page, that should be queried. See also <see cref="TraktPaginationOptions" />.</param>
        /// <returns>
        /// A <see cref="TraktPaginationListResult{TraktRecentlyUpdatedShow}"/> instance containing the queried updated shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktRecentlyUpdatedShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktPaginationListResult<TraktRecentlyUpdatedShow>> GetRecentlyUpdatedShowsAsync(DateTime? startDate = null,
                                                                                                            TraktExtendedOption extended = null,
                                                                                                            int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowsRecentlyUpdatedRequest(Client)
            {
                StartDate = startDate,
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        private void Validate(string id)
        {
            if (string.IsNullOrEmpty(id) || id.ContainsSpace())
                throw new ArgumentException("show id not valid", nameof(id));
        }

        private void Validate(string id, string languageCode)
        {
            Validate(id);

            if (string.IsNullOrEmpty(languageCode) || languageCode.Length != 2)
                throw new ArgumentException("show language code not valid", nameof(languageCode));
        }
    }
}
