namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Movies;
    using Requests.Handler;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Requests.Movies.OAuth;

    public partial class TraktMoviesModule : ATraktModule
    {
        /// <summary>
        /// Queue a <see cref="ITraktMovie" /> for a full metadata and image refresh.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/movies/refresh/refresh-movie-metadata">"Trakt API Doc - Refresh: Refresh movie metadata"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktNoContentResponse> RefreshMovieAsync(string movieIdOrSlug, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new MovieRefreshRequest
            {
                Id = movieIdOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Queue a <see cref="ITraktMovie" /> for a full metadata and image refresh.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/movies/refresh/refresh-movie-metadata">"Trakt API Doc - Refresh: Refresh movie metadata"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktMovieId">The movie's Trakt-Id. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktMovieId"/> is 0.</exception>
        public Task<TraktNoContentResponse> RefreshMovieAsync(uint traktMovieId, CancellationToken cancellationToken = default)
        {
            if (traktMovieId == 0)
                throw new ArgumentException("movie id must not be 0", nameof(traktMovieId));

            return RefreshMovieAsync(traktMovieId.ToString(), cancellationToken);
        }

        /// <summary>
        /// Queue a <see cref="ITraktMovie" /> for a full metadata and image refresh.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/movies/refresh/refresh-movie-metadata">"Trakt API Doc - Refresh: Refresh movie metadata"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIds">The movie's ids. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="movieIds"/> has not any ids set.</exception>
        public Task<TraktNoContentResponse> RefreshMovieAsync(ITraktMovieIds movieIds, CancellationToken cancellationToken = default)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            if (!movieIds.HasAnyId)
                throw new ArgumentException($"{nameof(movieIds)} has not any ids set", nameof(movieIds));

            return RefreshMovieAsync(movieIds.GetBestId(), cancellationToken);
        }

        /// <summary>
        /// Queue a <see cref="ITraktMovie" /> for a full metadata and image refresh.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/movies/refresh/refresh-movie-metadata">"Trakt API Doc - Refresh: Refresh movie metadata"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movie">The movie. See also <seealso cref="ITraktMovie" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        public Task<TraktNoContentResponse> RefreshMovieAsync(ITraktMovie movie, CancellationToken cancellationToken = default)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            return RefreshMovieAsync(movie.Ids, cancellationToken);
        }
    }
}
