namespace TraktNet.Modules
{
    using Exceptions;
    using Extensions;
    using Objects.Get.Movies;
    using Parameters;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktMoviesModule : ATraktModule
    {
        /// <summary>
        /// Gets a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/summary/get-a-movie">"Trakt API Doc - Movies: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleMoviesAsync(TraktMultipleObjectsQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movie should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktMovie" /> instance with the queried movie's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktMovie>> GetMovieAsync(string movieIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                              CancellationToken cancellationToken = default)
            => GetMovieImplementationAsync(false, movieIdOrSlug, extendedInfo, cancellationToken);

        /// <summary>
        /// Gets a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/summary/get-a-movie">"Trakt API Doc - Movies: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleMoviesAsync(TraktMultipleObjectsQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="traktMovieId">The movie's Trakt-Id. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movie should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktMovie" /> instance with the queried movie's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktMovieId"/> is 0.</exception>
        public Task<TraktResponse<ITraktMovie>> GetMovieAsync(uint traktMovieId, TraktExtendedInfo extendedInfo = null,
                                                              CancellationToken cancellationToken = default)
        {
            if (traktMovieId == 0)
                throw new ArgumentException("movie id must not be 0", nameof(traktMovieId));

            return GetMovieImplementationAsync(false, traktMovieId.ToString(), extendedInfo, cancellationToken);
        }

        /// <summary>
        /// Gets a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/summary/get-a-movie">"Trakt API Doc - Movies: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleMoviesAsync(TraktMultipleObjectsQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="movieIds">The movie's ids. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movie should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktMovie" /> instance with the queried movie's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        public Task<TraktResponse<ITraktMovie>> GetMovieAsync(ITraktMovieIds movieIds, TraktExtendedInfo extendedInfo = null,
                                                              CancellationToken cancellationToken = default)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            return GetMovieImplementationAsync(false, movieIds.GetBestId(), extendedInfo, cancellationToken);
        }

        /// <summary>
        /// Gets multiple different <see cref="ITraktMovie" />s at once with the given Trakt-Ids or -Slugs.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/summary/get-a-movie">"Trakt API Doc - Movies: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMovieAsync(string, TraktExtendedInfo, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="moviesQueryParams">A list of movie ids and optional extended infos. See also <seealso cref="TraktMultipleObjectsQueryParams" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktMovie" /> instances with the data of each queried movie.</returns>
        /// <exception cref="TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        [Obsolete("GetMultipleMoviesAsync is deprecated, please use GetMoviesStreamAsync instead.")]
        public async Task<IEnumerable<TraktResponse<ITraktMovie>>> GetMultipleMoviesAsync(TraktMultipleObjectsQueryParams moviesQueryParams,
                                                                                          CancellationToken cancellationToken = default)
        {
            if (moviesQueryParams == null || moviesQueryParams.Count == 0)
                return new List<TraktResponse<ITraktMovie>>();

            var tasks = new List<Task<TraktResponse<ITraktMovie>>>();

            foreach (TraktObjectsQueryParams queryParam in moviesQueryParams)
            {
                Task<TraktResponse<ITraktMovie>> task = GetMovieAsync(queryParam.Id, queryParam.ExtendedInfo, cancellationToken);
                tasks.Add(task);
            }

            TraktResponse<ITraktMovie>[] movies = await Task.WhenAll(tasks).ConfigureAwait(false);
            return movies.ToList();
        }

        /// <summary>
        /// Gets multiple different <see cref="ITraktMovie" />s at once with the given Trakt-Ids or -Slugs.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/summary/get-a-movie">"Trakt API Doc - Movies: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMovieAsync(string, TraktExtendedInfo, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="moviesQueryParams">A list of movie ids and optional extended infos. See also <seealso cref="TraktMultipleObjectsQueryParams" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <a href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1?view=net-7.0">async stream</a> of <see cref="ITraktMovie" /> instances with the data of each queried movie.</returns>
        /// <exception cref="TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public async IAsyncEnumerable<TraktResponse<ITraktMovie>> GetMoviesStreamAsync(TraktMultipleObjectsQueryParams moviesQueryParams,
                                                                                       [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (moviesQueryParams == null || moviesQueryParams.Count == 0)
                yield break;

            var tasks = new List<Task<TraktResponse<ITraktMovie>>>();

            foreach (TraktObjectsQueryParams queryParam in moviesQueryParams)
            {
                Task<TraktResponse<ITraktMovie>> task = GetMovieInStreamAsync(queryParam.Id, queryParam.ExtendedInfo, cancellationToken);
                tasks.Add(task);
            }

            await foreach (TraktResponse<ITraktMovie> result in tasks.StreamFinishedTaskResultsAsync())
            {
                yield return result;
            }
        }
    }
}
