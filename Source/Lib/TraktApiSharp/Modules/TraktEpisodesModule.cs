namespace TraktApiSharp.Modules
{
    using Attributes;
    using Enums;
    using Extensions;
    using Objects.Basic;
    using Objects.Get.Shows.Episodes;
    using Objects.Get.Users;
    using Requests;
    using Requests.Params;
    using Requests.WithoutOAuth.Shows.Episodes;
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
        /// Gets a <see cref="TraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/summary/get-a-single-episode-for-a-show">"Trakt API Doc - Episodes: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleEpisodesAsync(TraktMultipleEpisodesQueryParams)" />.</para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="Objects.Get.Shows.TraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, which should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, which should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the episode should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>An <see cref="TraktEpisode" /> instance with the queried episode's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given season- or episode-number is below zero.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktEpisode> GetEpisodeAsync([NotNull] string showIdOrSlug, int seasonNumber, int episodeNumber,
                                                        TraktExtendedInfo extendedInfo = null)
        {
            Validate(showIdOrSlug, seasonNumber, episodeNumber);

            return await QueryAsync(new TraktEpisodeSummaryRequest(Client)
            {
                Id = showIdOrSlug,
                Season = seasonNumber,
                Episode = episodeNumber,
                ExtendedInfo = extendedInfo
            });
        }

        /// <summary>
        /// Gets multiple different <see cref="TraktEpisode" />s at once in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/summary/get-a-single-episode-for-a-show">"Trakt API Doc - Episodes: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetEpisodeAsync(string, int, int, TraktExtendedInfo)" />.</para>
        /// </summary>
        /// <param name="episodesQueryParams">A list of show ids, season numbers, episode numbers and optional extended infos. See also <seealso cref="TraktMultipleEpisodesQueryParams" />.</param>
        /// <returns>A list of <see cref="TraktEpisode" /> instances with the data of each queried episode.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if one of the given show ids is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if one of the given season- or episode-numbers is below zero.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktEpisode>> GetMultipleEpisodesAsync(TraktMultipleEpisodesQueryParams episodesQueryParams)
        {
            if (episodesQueryParams == null || episodesQueryParams.Count <= 0)
                return new List<TraktEpisode>();

            var tasks = new List<Task<TraktEpisode>>();

            foreach (var queryParam in episodesQueryParams)
            {
                Task<TraktEpisode> task = GetEpisodeAsync(queryParam.ShowId, queryParam.Season, queryParam.Episode,
                                                          queryParam.ExtendedInfo);
                tasks.Add(task);
            }

            var episodes = await Task.WhenAll(tasks);
            return episodes.ToList();
        }

        /// <summary>
        /// Gets top level comments for a <see cref="TraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/comments/get-all-episode-comments">"Trakt API Doc - Episodes: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="Objects.Get.Shows.TraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the comments should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the comments should be queried.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="page">The page of the comments list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of comments for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktComment}"/> instance containing the queried episode comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given season- or episode-number is below zero.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktComment>> GetEpisodeCommentsAsync([NotNull] string showIdOrSlug, int seasonNumber, int episodeNumber,
                                                                                           TraktCommentSortOrder commentSortOrder = null,
                                                                                           int? page = null, int? limitPerPage = null)
        {
            Validate(showIdOrSlug, seasonNumber, episodeNumber);

            return await QueryAsync(new TraktEpisodeCommentsRequest(Client)
            {
                Id = showIdOrSlug,
                Season = seasonNumber,
                Episode = episodeNumber,
                Sorting = commentSortOrder,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });
        }

        /// <summary>
        /// Gets the ratings for a <see cref="TraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/ratings/get-episode-ratings">"Trakt API Doc - Episodes: Ratings"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="Objects.Get.Shows.TraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the ratings should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the ratings should be queried.</param>
        /// <returns>An <see cref="TraktRating" /> instance, containing the ratings for a episode with the given showIdOrSlug.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given season- or episode-number is below zero.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktRating> GetEpisodeRatingsAsync([NotNull] string showIdOrSlug, int seasonNumber, int episodeNumber)
        {
            Validate(showIdOrSlug, seasonNumber, episodeNumber);

            return await QueryAsync(new TraktEpisodeRatingsRequest(Client)
            {
                Id = showIdOrSlug,
                Season = seasonNumber,
                Episode = episodeNumber
            });
        }

        /// <summary>
        /// Gets the statistics for a <see cref="TraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/ratings/get-episode-stats">"Trakt API Doc - Episodes: Stats"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="Objects.Get.Shows.TraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the statistics should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the statistics should be queried.</param>
        /// <returns>An <see cref="TraktStatistics" /> instance, containing the statistics for a episode with the given showIdOrSlug.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given season- or episode-number is below zero.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktStatistics> GetEpisodeStatisticsAsync([NotNull] string showIdOrSlug, int seasonNumber, int episodeNumber)
        {
            Validate(showIdOrSlug, seasonNumber, episodeNumber);

            return await QueryAsync(new TraktEpisodeStatisticsRequest(Client)
            {
                Id = showIdOrSlug,
                Season = seasonNumber,
                Episode = episodeNumber
            });
        }

        /// <summary>
        /// Gets all watching users of a <see cref="TraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/watching/get-users-watching-right-now">"Trakt API Doc - Episodes: Watching"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="Objects.Get.Shows.TraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the watching users should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the watching users should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the users should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>A list of <see cref="TraktUser" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given season- or episode-number is below zero.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktUser>> GetEpisodeWatchingUsersAsync([NotNull] string showIdOrSlug, int seasonNumber, int episodeNumber,
                                                                               TraktExtendedInfo extendedInfo = null)
        {
            Validate(showIdOrSlug, seasonNumber, episodeNumber);

            return await QueryAsync(new TraktEpisodeWatchingUsersRequest(Client)
            {
                Id = showIdOrSlug,
                Season = seasonNumber,
                Episode = episodeNumber,
                ExtendedInfo = extendedInfo
            });
        }

        private void Validate(string showIdOrSlug, int seasonNumber, int episodeNumber)
        {
            if (string.IsNullOrEmpty(showIdOrSlug) || showIdOrSlug.ContainsSpace())
                throw new ArgumentException("show id or slug not valid", nameof(showIdOrSlug));

            if (seasonNumber < 0)
                throw new ArgumentOutOfRangeException(nameof(seasonNumber), "season number not valid");

            if (episodeNumber < 0)
                throw new ArgumentOutOfRangeException(nameof(episodeNumber), "episode number not valid");
        }
    }
}
