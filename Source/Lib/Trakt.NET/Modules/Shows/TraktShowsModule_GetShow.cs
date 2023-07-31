namespace TraktNet.Modules
{
    using Exceptions;
    using Extensions;
    using Objects.Get.Shows;
    using Parameters;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktShowsModule : ATraktModule
    {
        /// <summary>
        /// Gets a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/summary/get-a-single-show">"Trakt API Doc - Shows: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleShowsAsync(TraktMultipleObjectsQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the show should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktShow" /> instance with the queried show's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktShow>> GetShowAsync(string showIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                            CancellationToken cancellationToken = default)
            => GetShowImplementationAsync(false, showIdOrSlug, extendedInfo, cancellationToken);

        /// <summary>
        /// Gets a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/summary/get-a-single-show">"Trakt API Doc - Shows: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleShowsAsync(TraktMultipleObjectsQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="traktShowID">The show's Trakt-Id. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the show should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktShow" /> instance with the queried show's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktResponse<ITraktShow>> GetShowAsync(uint traktShowID, TraktExtendedInfo extendedInfo = null,
                                                            CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return GetShowImplementationAsync(false, traktShowID.ToString(), extendedInfo, cancellationToken);
        }

        /// <summary>
        /// Gets a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/summary/get-a-single-show">"Trakt API Doc - Shows: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleShowsAsync(TraktMultipleObjectsQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="showIds">The show's ids. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the show should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktShow" /> instance with the queried show's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="showIds"/> has not any ids set.</exception>
        public Task<TraktResponse<ITraktShow>> GetShowAsync(ITraktShowIds showIds, TraktExtendedInfo extendedInfo = null,
                                                            CancellationToken cancellationToken = default)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (!showIds.HasAnyId)
                throw new ArgumentException($"{nameof(showIds)} has not any ids set", nameof(showIds));

            return GetShowImplementationAsync(false, showIds.GetBestId(), extendedInfo, cancellationToken);
        }

        /// <summary>
        /// Gets multiple different <see cref="ITraktShow" />s at once with the given Trakt-Ids or -Slugs.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/summary/get-a-single-show">"Trakt API Doc - Shows: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetShowAsync(string, TraktExtendedInfo, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="showsQueryParams">A list of show ids and optional extended infos. See also <seealso cref="TraktMultipleObjectsQueryParams" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktShow" /> instances with the data of each queried show.</returns>
        /// <exception cref="TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        [Obsolete("GetMultipleShowsAsync is deprecated, please use GetShowsStreamAsync instead.")]
        public async Task<IEnumerable<TraktResponse<ITraktShow>>> GetMultipleShowsAsync(TraktMultipleObjectsQueryParams showsQueryParams,
                                                                                        CancellationToken cancellationToken = default)
        {
            if (showsQueryParams == null || showsQueryParams.Count == 0)
                return new List<TraktResponse<ITraktShow>>();

            var tasks = new List<Task<TraktResponse<ITraktShow>>>();

            foreach (TraktObjectsQueryParams queryParam in showsQueryParams)
            {
                Task<TraktResponse<ITraktShow>> task = GetShowAsync(queryParam.Id, queryParam.ExtendedInfo, cancellationToken);
                tasks.Add(task);
            }

            TraktResponse<ITraktShow>[] shows = await Task.WhenAll(tasks).ConfigureAwait(false);
            return shows.ToList();
        }

        /// <summary>
        /// Gets multiple different <see cref="ITraktShow" />s at once with the given Trakt-Ids or -Slugs.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/summary/get-a-single-show">"Trakt API Doc - Shows: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetShowAsync(string, TraktExtendedInfo, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="showsQueryParams">A list of show ids and optional extended infos. See also <seealso cref="TraktMultipleObjectsQueryParams" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <a href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1?view=net-7.0">async stream</a> of <see cref="ITraktShow" /> instances with the data of each queried show.</returns>
        /// <exception cref="TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public async IAsyncEnumerable<TraktResponse<ITraktShow>> GetShowsStreamAsync(TraktMultipleObjectsQueryParams showsQueryParams,
                                                                                     [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (showsQueryParams == null || showsQueryParams.Count == 0)
                yield break;

            var tasks = new List<Task<TraktResponse<ITraktShow>>>();

            foreach (TraktObjectsQueryParams queryParam in showsQueryParams)
            {
                Task<TraktResponse<ITraktShow>> task = GetShowInStreamAsync(queryParam.Id, queryParam.ExtendedInfo, cancellationToken);
                tasks.Add(task);
            }

            await foreach (TraktResponse<ITraktShow> result in tasks.StreamFinishedTaskResultsAsync())
            {
                yield return result;
            }
        }
    }
}
