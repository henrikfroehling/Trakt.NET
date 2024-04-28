namespace TraktNet.Modules
{
    using Exceptions;
    using Extensions;
    using Objects.Get.Episodes;
    using Objects.Get.Shows;
    using Parameters;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktEpisodesModule : ATraktModule
    {
        /// <summary>
        /// Gets a <see cref="ITraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/episodes/summary/get-a-single-episode-for-a-show">"Trakt API Doc - Episodes: Summary"</a> for more information.
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
        /// Gets a <see cref="ITraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/episodes/summary/get-a-single-episode-for-a-show">"Trakt API Doc - Episodes: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleEpisodesAsync(TraktMultipleEpisodesQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="traktShowID">The show's Trakt-Id. See also <seealso cref="ITraktShowIds" />.</param>
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
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktResponse<ITraktEpisode>> GetEpisodeAsync(uint traktShowID, uint seasonNumber, uint episodeNumber,
                                                                  TraktExtendedInfo extendedInfo = null,
                                                                  CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return GetEpisodeImplementationAsync(false, traktShowID.ToString(), seasonNumber, episodeNumber, extendedInfo, cancellationToken);
        }

        /// <summary>
        /// Gets a <see cref="ITraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/episodes/summary/get-a-single-episode-for-a-show">"Trakt API Doc - Episodes: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleEpisodesAsync(TraktMultipleEpisodesQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="showIds">The show's ids. See also <seealso cref="ITraktShowIds" />.</param>
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
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="showIds"/> has not any ids set.</exception>
        public Task<TraktResponse<ITraktEpisode>> GetEpisodeAsync(ITraktShowIds showIds, uint seasonNumber, uint episodeNumber,
                                                                  TraktExtendedInfo extendedInfo = null,
                                                                  CancellationToken cancellationToken = default)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (!showIds.HasAnyId)
                throw new ArgumentException($"{nameof(showIds)} has not any ids set", nameof(showIds));

            return GetEpisodeImplementationAsync(false, showIds.GetBestId(), seasonNumber, episodeNumber, extendedInfo, cancellationToken);
        }

        /// <summary>
        /// Gets a <see cref="ITraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/episodes/summary/get-a-single-episode-for-a-show">"Trakt API Doc - Episodes: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleEpisodesAsync(TraktMultipleEpisodesQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="show">The show. See also <seealso cref="ITraktShow" />.</param>
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
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        public Task<TraktResponse<ITraktEpisode>> GetEpisodeAsync(ITraktShow show, uint seasonNumber, uint episodeNumber,
                                                                  TraktExtendedInfo extendedInfo = null,
                                                                  CancellationToken cancellationToken = default)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            return GetEpisodeAsync(show.Ids, seasonNumber, episodeNumber, extendedInfo, cancellationToken);
        }

        /// <summary>
        /// Gets multiple different <see cref="ITraktEpisode" />s at once in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/episodes/summary/get-a-single-episode-for-a-show">"Trakt API Doc - Episodes: Summary"</a> for more information.
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
        /// See <a href="http://trakt.docs.apiary.io/#reference/episodes/summary/get-a-single-episode-for-a-show">"Trakt API Doc - Episodes: Summary"</a> for more information.
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
    }
}
