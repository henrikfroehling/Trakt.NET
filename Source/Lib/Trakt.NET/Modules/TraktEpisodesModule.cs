namespace TraktNet.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Basic;
    using Objects.Get.Episodes;
    using Objects.Get.Lists;
    using Objects.Get.Shows;
    using Objects.Get.Users;
    using Requests.Episodes;
    using Requests.Handler;
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
    /// Provides access to data retrieving methods specific to episodes.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/episodes">"Trakt API Doc - Episodes"</a> section.
    /// </para>
    /// </summary>
    public class TraktEpisodesModule : ATraktModule
    {
        internal TraktEpisodesModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Gets a <see cref="ITraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/summary/get-a-single-episode-for-a-show">"Trakt API Doc - Episodes: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleEpisodesAsync(TraktMultipleEpisodesQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, which should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, which should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the episode should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktEpisode" /> instance with the queried episode's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktEpisode>> GetEpisodeAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
                                                                  TraktExtendedInfo extendedInfo = null,
                                                                  CancellationToken cancellationToken = default)
            => GetEpisodeImplementationAsync(false, showIdOrSlug, seasonNumber, episodeNumber, extendedInfo, cancellationToken);

        /// <summary>
        /// Gets multiple different <see cref="ITraktEpisode" />s at once in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/summary/get-a-single-episode-for-a-show">"Trakt API Doc - Episodes: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetEpisodeAsync(string, uint, uint, TraktExtendedInfo, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="episodesQueryParams">A list of show ids, season numbers, episode numbers and optional extended infos. See also <seealso cref="TraktMultipleEpisodesQueryParams" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktEpisode" /> instances with the data of each queried episode.</returns>
        /// <exception cref="TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        [Obsolete("GetMultipleEpisodesAsync is deprecated, please use GetEpisodesStreamAsync instead.")]
        public async Task<IEnumerable<TraktResponse<ITraktEpisode>>> GetMultipleEpisodesAsync(TraktMultipleEpisodesQueryParams episodesQueryParams,
                                                                                              CancellationToken cancellationToken = default)
        {
            if (episodesQueryParams == null || episodesQueryParams.Count == 0)
                return new List<TraktResponse<ITraktEpisode>>();

            var tasks = new List<Task<TraktResponse<ITraktEpisode>>>();

            foreach (TraktEpisodeQueryParams queryParam in episodesQueryParams)
            {
                Task<TraktResponse<ITraktEpisode>> task = GetEpisodeAsync(queryParam.ShowId, queryParam.Season, queryParam.Episode,
                                                                          queryParam.ExtendedInfo, cancellationToken);
                tasks.Add(task);
            }

            TraktResponse<ITraktEpisode>[] episodes = await Task.WhenAll(tasks).ConfigureAwait(false);
            return episodes.ToList();
        }

        /// <summary>
        /// Gets multiple different <see cref="ITraktEpisode" />s at once in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/summary/get-a-single-episode-for-a-show">"Trakt API Doc - Episodes: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetEpisodeAsync(string, uint, uint, TraktExtendedInfo, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="episodesQueryParams">A list of show ids, season numbers, episode numbers and optional extended infos. See also <seealso cref="TraktMultipleEpisodesQueryParams" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <a href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1?view=net-7.0">async stream</a> of <see cref="ITraktEpisode" /> instances with the data of each queried episode.</returns>
        /// <exception cref="TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public async IAsyncEnumerable<TraktResponse<ITraktEpisode>> GetEpisodesStreamAsync(TraktMultipleEpisodesQueryParams episodesQueryParams,
                                                                                              [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (episodesQueryParams == null || episodesQueryParams.Count == 0)
                yield break;

            var tasks = new List<Task<TraktResponse<ITraktEpisode>>>();

            foreach (TraktEpisodeQueryParams queryParam in episodesQueryParams)
            {
                Task<TraktResponse<ITraktEpisode>> task = GetEpisodeInStreamAsync(queryParam.ShowId, queryParam.Season, queryParam.Episode,
                                                                                  queryParam.ExtendedInfo, cancellationToken);
                tasks.Add(task);
            }

            await foreach (TraktResponse<ITraktEpisode> result in tasks.StreamFinishedTaskResultsAsync())
            {
                yield return result;
            }
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
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktExtendedCommentSortOrder" />.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktComment}"/> instance containing the queried episode comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktComment>> GetEpisodeCommentsAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
                                                                               TraktExtendedCommentSortOrder commentSortOrder = null,
                                                                               TraktPagedParameters pagedParameters = null,
                                                                               CancellationToken cancellationToken = default)
        {
            var request = new EpisodeCommentsRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber,
                SortOrder = commentSortOrder,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
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
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktList}"/> instance containing the queried episode lists and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktList" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktList>> GetEpisodeListsAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
                                                                         TraktListType listType = null, TraktListSortOrder listSortOrder = null,
                                                                         TraktPagedParameters pagedParameters = null,
                                                                         CancellationToken cancellationToken = default)
        {
            var request = new EpisodeListsRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber,
                Type = listType,
                SortOrder = listSortOrder,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets all people for a <see cref="ITraktEpisode" /> in a show with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/episodes/people/get-all-people-for-an-episode">"Trakt API Doc - Episodes: People"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, for which the people should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the people should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktShowCastAndCrew" /> instance, containing the cast and crew for a episode with the given showIdOrSlug and the given season number.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktShowCastAndCrew>> GetEpisodePeopleAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
                                                                            TraktExtendedInfo extendedInfo = null,
                                                                            CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new EpisodePeopleRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktRating" /> instance, containing the ratings for a episode with the given showIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktRating>> GetEpisodeRatingsAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
                                                                        CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new EpisodeRatingsRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber
            },
            cancellationToken);
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktStatistics" /> instance, containing the statistics for a episode with the given showIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktStatistics>> GetEpisodeStatisticsAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
                                                                               CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new EpisodeStatisticsRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber
            },
            cancellationToken);
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktEpisodeTranslation" /> instances, each containing a title, overview and language code.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktEpisodeTranslation>> GetEpisodeTranslationsAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
                                                                                             string languageCode = null,
                                                                                             CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new EpisodeTranslationsRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber,
                LanguageCode = languageCode
            },
            cancellationToken);
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktUser" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktUser>> GetEpisodeWatchingUsersAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
                                                                                TraktExtendedInfo extendedInfo = null,
                                                                                CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new EpisodeWatchingUsersRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        private Task<TraktResponse<ITraktEpisode>> GetEpisodeInStreamAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
                                                                           TraktExtendedInfo extendedInfo = null,
                                                                           CancellationToken cancellationToken = default)
            => GetEpisodeImplementationAsync(true, showIdOrSlug, seasonNumber, episodeNumber, extendedInfo, cancellationToken);

        private Task<TraktResponse<ITraktEpisode>> GetEpisodeImplementationAsync(bool asyncStream, string showIdOrSlug, uint seasonNumber, uint episodeNumber,
                                                                                 TraktExtendedInfo extendedInfo = null,
                                                                                 CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            var request = new EpisodeSummaryRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber,
                ExtendedInfo = extendedInfo
            };

            if (asyncStream)
                return requestHandler.ExecuteSingleItemStreamRequestAsync(request, cancellationToken);

            return requestHandler.ExecuteSingleItemRequestAsync(request, cancellationToken);
        }
    }
}
