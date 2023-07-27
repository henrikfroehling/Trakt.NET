namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Basic;
    using Objects.Get.Movies;
    using Requests.Handler;
    using Requests.Movies;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktMoviesModule : ATraktModule
    {
        /// <summary>
        /// Gets the statistics for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/stats/get-movie-stats">"Trakt API Doc - Movies: Stats"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktStatistics" /> instance, containing the statistics for a movie with the given movieIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktStatistics>> GetMovieStatisticsAsync(string movieIdOrSlug, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new MovieStatisticsRequest
            {
                Id = movieIdOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the statistics for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/stats/get-movie-stats">"Trakt API Doc - Movies: Stats"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktMovieId">The movie's Trakt-Id. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktStatistics" /> instance, containing the statistics for a movie with the given movieIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktMovieId"/> is 0.</exception>
        public Task<TraktResponse<ITraktStatistics>> GetMovieStatisticsAsync(uint traktMovieId, CancellationToken cancellationToken = default)
        {
            if (traktMovieId == 0)
                throw new ArgumentException("movie id must not be 0", nameof(traktMovieId));

            return GetMovieStatisticsAsync(traktMovieId.ToString(), cancellationToken);
        }

        /// <summary>
        /// Gets the statistics for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/stats/get-movie-stats">"Trakt API Doc - Movies: Stats"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIds">The movie's ids. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktStatistics" /> instance, containing the statistics for a movie with the given movieIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        public Task<TraktResponse<ITraktStatistics>> GetMovieStatisticsAsync(ITraktMovieIds movieIds, CancellationToken cancellationToken = default)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            return GetMovieStatisticsAsync(movieIds.GetBestId(), cancellationToken);
        }
    }
}
