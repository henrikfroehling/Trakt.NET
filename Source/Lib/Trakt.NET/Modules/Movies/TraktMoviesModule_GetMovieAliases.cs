﻿namespace TraktNet.Modules
{
    using Exceptions;
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
        /// Gets all title aliases for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/movies/aliases/get-all-movie-aliases">"Trakt API Doc - Movies: Aliases"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktMovieAlias" /> instances, each containing a title and country code.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktMovieAlias>> GetMovieAliasesAsync(string movieIdOrSlug,
                                                                              CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new MovieAliasesRequest
            {
                Id = movieIdOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all title aliases for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/movies/aliases/get-all-movie-aliases">"Trakt API Doc - Movies: Aliases"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktMovieId">The movie's Trakt-Id. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktMovieAlias" /> instances, each containing a title and country code.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktMovieId"/> is 0.</exception>
        public Task<TraktListResponse<ITraktMovieAlias>> GetMovieAliasesAsync(uint traktMovieId,
                                                                              CancellationToken cancellationToken = default)
        {
            if (traktMovieId == 0)
                throw new ArgumentException("movie id must not be 0", nameof(traktMovieId));

            return GetMovieAliasesAsync(traktMovieId.ToString(), cancellationToken);
        }

        /// <summary>
        /// Gets all title aliases for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/movies/aliases/get-all-movie-aliases">"Trakt API Doc - Movies: Aliases"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIds">The movie's ids. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktMovieAlias" /> instances, each containing a title and country code.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="movieIds"/> has not any ids set.</exception>
        public Task<TraktListResponse<ITraktMovieAlias>> GetMovieAliasesAsync(ITraktMovieIds movieIds,
                                                                              CancellationToken cancellationToken = default)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            if (!movieIds.HasAnyId)
                throw new ArgumentException($"{nameof(movieIds)} has not any ids set", nameof(movieIds));

            return GetMovieAliasesAsync(movieIds.GetBestId(), cancellationToken);
        }

        /// <summary>
        /// Gets all title aliases for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/movies/aliases/get-all-movie-aliases">"Trakt API Doc - Movies: Aliases"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movie">The movie. See also <seealso cref="ITraktMovie" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktMovieAlias" /> instances, each containing a title and country code.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        public Task<TraktListResponse<ITraktMovieAlias>> GetMovieAliasesAsync(ITraktMovie movie,
                                                                              CancellationToken cancellationToken = default)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            return GetMovieAliasesAsync(movie.Ids, cancellationToken);
        }
    }
}
