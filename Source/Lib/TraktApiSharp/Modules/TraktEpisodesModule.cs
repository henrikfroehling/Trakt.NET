namespace TraktApiSharp.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Basic;
    using Objects.Get.Episodes;
    using Objects.Get.Shows;
    using Objects.Get.Users;
    using Objects.Get.Users.Lists;
    using Requests.Episodes;
    using Requests.Handler;
    using Requests.Parameters;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to episodes.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/episodes">"Trakt API Doc - Episodes"</a> section.
    /// </para>
    /// </summary>
    public class TraktEpisodesModule : TraktBaseModule
    {
        internal TraktEpisodesModule(TraktClient client) : base(client) { }

        /// <summary>
        /// Gets a <see cref="ITraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/summary/get-a-single-episode-for-a-show">"Trakt API Doc - Episodes: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleEpisodesAsync(TraktMultipleEpisodesQueryParams)" />.</para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, which should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, which should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the episode should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>An <see cref="ITraktEpisode" /> instance with the queried episode's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given season-number is below zero.
        /// Thrown, if the given episode-number is below one.
        /// </exception>
        public async Task<TraktResponse<ITraktEpisode>> GetEpisodeAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
                                                                        TraktExtendedInfo extendedInfo = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecuteSingleItemRequestAsync(new TraktEpisodeSummaryRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber,
                ExtendedInfo = extendedInfo
            });
        }

        /// <summary>
        /// Gets multiple different <see cref="ITraktEpisode" />s at once in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/summary/get-a-single-episode-for-a-show">"Trakt API Doc - Episodes: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetEpisodeAsync(string, uint, uint, TraktExtendedInfo)" />.</para>
        /// </summary>
        /// <param name="episodesQueryParams">A list of show ids, season numbers, episode numbers and optional extended infos. See also <seealso cref="TraktMultipleEpisodesQueryParams" />.</param>
        /// <returns>A list of <see cref="ITraktEpisode" /> instances with the data of each queried episode.</returns>
        /// <exception cref="TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if one of the given show ids is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given season-number is below zero.
        /// Thrown, if the given episode-number is below one.
        /// </exception>
        public async Task<IEnumerable<TraktResponse<ITraktEpisode>>> GetMultipleEpisodesAsync(TraktMultipleEpisodesQueryParams episodesQueryParams)
        {
            if (episodesQueryParams == null || episodesQueryParams.Count <= 0)
                return new List<TraktResponse<ITraktEpisode>>();

            var tasks = new List<Task<TraktResponse<ITraktEpisode>>>();

            foreach (var queryParam in episodesQueryParams)
            {
                Task<TraktResponse<ITraktEpisode>> task = GetEpisodeAsync(queryParam.ShowId, queryParam.Season, queryParam.Episode,
                                                                         queryParam.ExtendedInfo);
                tasks.Add(task);
            }

            var episodes = await Task.WhenAll(tasks);
            return episodes.ToList();
        }

        /// <summary>
        /// Gets top level comments for a <see cref="ITraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/comments/get-all-episode-comments">"Trakt API Doc - Episodes: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the comments should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the comments should be queried.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="page">The page of the comments list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of comments for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktComment}"/> instance containing the queried episode comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given season-number is below zero.
        /// Thrown, if the given episode-number is below one.
        /// </exception>
        public async Task<TraktPagedResponse<ITraktComment>> GetEpisodeCommentsAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
                                                                                     TraktCommentSortOrder commentSortOrder = null,
                                                                                     int? page = null, int? limitPerPage = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecutePagedRequestAsync(new TraktEpisodeCommentsRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber,
                SortOrder = commentSortOrder,
                Page = page,
                Limit = limitPerPage
            });
        }

        /// <summary>
        /// Gets all <see cref="ITraktList" />s containing the given <see cref="ITraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/lists/get-lists-containing-this-episode">"Trakt API Doc - Episodes: Lists"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the lists should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the lists should be queried.</param>
        /// <param name="listType">The type of lists, that should be queried. Defaults to personal lists.</param>
        /// <param name="listSortOrder">The list sort order. See also <seealso cref="TraktListSortOrder" />. Defaults to sorted by popularity.</param>
        /// <param name="page">The page of the <see cref="ITraktList" /> list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of <see cref="ITraktList" />s for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktList}"/> instance containing the queried episode lists and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktList" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given season-number is below zero.
        /// Thrown, if the given episode-number is below one.
        /// </exception>
        public async Task<TraktPagedResponse<ITraktList>> GetEpisodeListsAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
                                                                               TraktListType listType = null, TraktListSortOrder listSortOrder = null,
                                                                               int? page = null, int? limitPerPage = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecutePagedRequestAsync(new TraktEpisodeListsRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber,
                Type = listType,
                SortOrder = listSortOrder,
                Page = page,
                Limit = limitPerPage
            });
        }

        /// <summary>
        /// Gets the ratings for a <see cref="ITraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/ratings/get-episode-ratings">"Trakt API Doc - Episodes: Ratings"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the ratings should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the ratings should be queried.</param>
        /// <returns>An <see cref="ITraktRating" /> instance, containing the ratings for a episode with the given showIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given season-number is below zero.
        /// Thrown, if the given episode-number is below one.
        /// </exception>
        public async Task<TraktResponse<ITraktRating>> GetEpisodeRatingsAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecuteSingleItemRequestAsync(new TraktEpisodeRatingsRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber
            });
        }

        /// <summary>
        /// Gets the statistics for a <see cref="ITraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/ratings/get-episode-stats">"Trakt API Doc - Episodes: Stats"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the statistics should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the statistics should be queried.</param>
        /// <returns>An <see cref="ITraktStatistics" /> instance, containing the statistics for a episode with the given showIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given season-number is below zero.
        /// Thrown, if the given episode-number is below one.
        /// </exception>
        public async Task<TraktResponse<ITraktStatistics>> GetEpisodeStatisticsAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecuteSingleItemRequestAsync(new TraktEpisodeStatisticsRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber
            });
        }

        /// <summary>
        /// Gets all translations for a <see cref="ITraktEpisode" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/translations/get-all-episode-translations">"Trakt API Doc - Episodes: Translations"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the translations should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the translations should be queried.</param>
        /// <param name="languageCode">An optional two letter language code to query a specific translation language.</param>
        /// <returns>A list of <see cref="ITraktEpisodeTranslation" /> instances, each containing a title, overview and language code.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given season-number is below zero.
        /// Thrown, if the given episode-number is below one.
        /// Thrown, if the given languageCode is shorter or longer than two characters.
        /// </exception>
        public async Task<TraktListResponse<ITraktEpisodeTranslation>> GetEpisodeTranslationsAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
                                                                                                   string languageCode = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecuteListRequestAsync(new TraktEpisodeTranslationsRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber,
                LanguageCode = languageCode
            });
        }

        /// <summary>
        /// Gets all watching users of a <see cref="ITraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/watching/get-users-watching-right-now">"Trakt API Doc - Episodes: Watching"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the watching users should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the watching users should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the users should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>A list of <see cref="ITraktUser" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given season-number is below zero.
        /// Thrown, if the given episode-number is below one.
        /// </exception>
        public async Task<TraktListResponse<ITraktUser>> GetEpisodeWatchingUsersAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
                                                                                      TraktExtendedInfo extendedInfo = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecuteListRequestAsync(new TraktEpisodeWatchingUsersRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber,
                ExtendedInfo = extendedInfo
            });
        }
    }
}
