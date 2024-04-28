namespace TraktNet.Modules
{
    using Exceptions;
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
    using TraktNet.Extensions;

    public partial class TraktSeasonsModule : ATraktModule
    {
        /// <summary>
        /// Gets all <see cref="ITraktEpisode" />s in a single season in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/seasons/season/get-single-season-for-a-show">"Trakt API Doc - Seasons: Season"</a> for more information.
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
            => GetSeasonImplementationAsync(false, showIdOrSlug, seasonNumber, extendedInfo, translationLanguageCode, cancellationToken);

        /// <summary>
        /// Gets all <see cref="ITraktEpisode" />s in a single season in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/seasons/season/get-single-season-for-a-show">"Trakt API Doc - Seasons: Season"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleSeasonsAsync(TraktMultipleSeasonsQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="traktShowID">The show's Trakt-Id. See also <seealso cref="ITraktShowIds" />.</param>
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
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktListResponse<ITraktEpisode>> GetSeasonAsync(uint traktShowID, uint seasonNumber,
                                                                     TraktExtendedInfo extendedInfo = null,
                                                                     string translationLanguageCode = null,
                                                                     CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return GetSeasonImplementationAsync(false, traktShowID.ToString(), seasonNumber, extendedInfo, translationLanguageCode, cancellationToken);
        }

        /// <summary>
        /// Gets all <see cref="ITraktEpisode" />s in a single season in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/seasons/season/get-single-season-for-a-show">"Trakt API Doc - Seasons: Season"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleSeasonsAsync(TraktMultipleSeasonsQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="showIds">The show's ids. See also <seealso cref="ITraktShowIds" />.</param>
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
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="showIds"/> has not any ids set.</exception>
        public Task<TraktListResponse<ITraktEpisode>> GetSeasonAsync(ITraktShowIds showIds, uint seasonNumber,
                                                                     TraktExtendedInfo extendedInfo = null,
                                                                     string translationLanguageCode = null,
                                                                     CancellationToken cancellationToken = default)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (!showIds.HasAnyId)
                throw new ArgumentException($"{nameof(showIds)} has not any ids set", nameof(showIds));

            return GetSeasonImplementationAsync(false, showIds.GetBestId(), seasonNumber, extendedInfo, translationLanguageCode, cancellationToken);
        }

        /// <summary>
        /// Gets all <see cref="ITraktEpisode" />s in a single season in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/seasons/season/get-single-season-for-a-show">"Trakt API Doc - Seasons: Season"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleSeasonsAsync(TraktMultipleSeasonsQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="show">The show. See also <seealso cref="ITraktShow" />.</param>
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
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        public Task<TraktListResponse<ITraktEpisode>> GetSeasonAsync(ITraktShow show, uint seasonNumber,
                                                                     TraktExtendedInfo extendedInfo = null,
                                                                     string translationLanguageCode = null,
                                                                     CancellationToken cancellationToken = default)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            return GetSeasonAsync(show.Ids, seasonNumber, extendedInfo, translationLanguageCode, cancellationToken);
        }

        /// <summary>
        /// Gets multiple different seasons at once in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/seasons/season/get-single-season-for-a-show">"Trakt API Doc - Seasons: Season"</a> for more information.
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
        /// See <a href="http://trakt.docs.apiary.io/#reference/seasons/season/get-single-season-for-a-show">"Trakt API Doc - Seasons: Season"</a> for more information.
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
                Task<TraktListResponse<ITraktEpisode>> task = GetSeasonInStreamAsync(queryParam.ShowId, queryParam.Season, queryParam.ExtendedInfo,
                                                                                     queryParam.TranslationLanguageCode, cancellationToken);

                tasks.Add(task);
            }

            await foreach (TraktListResponse<ITraktEpisode> result in tasks.StreamFinishedTaskResultsAsync())
            {
                yield return result;
            }
        }
    }
}
