namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Basic;
    using Objects.Get.Movies;
    using Parameters;
    using Requests.Handler;
    using Requests.Movies;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktMoviesModule : ATraktModule
    {
        /// <summary>
        /// Gets all people for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/people/get-all-people-for-a-movie">"Trakt API Doc - Movies: People"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktCastAndCrew" /> instance, containing the cast and crew for a movie with the given movieIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktCastAndCrew>> GetMoviePeopleAsync(string movieIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                          CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new MoviePeopleRequest
            {
                Id = movieIdOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all people for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/people/get-all-people-for-a-movie">"Trakt API Doc - Movies: People"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktMovieId">The movie's Trakt-Id. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktCastAndCrew" /> instance, containing the cast and crew for a movie with the given movieIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktMovieId"/> is 0.</exception>
        public Task<TraktResponse<ITraktCastAndCrew>> GetMoviePeopleAsync(uint traktMovieId, TraktExtendedInfo extendedInfo = null,
                                                                          CancellationToken cancellationToken = default)
        {
            if (traktMovieId == 0)
                throw new ArgumentException("movie id must not be 0", nameof(traktMovieId));

            return GetMoviePeopleAsync(traktMovieId.ToString(), extendedInfo, cancellationToken);
        }

        /// <summary>
        /// Gets all people for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/movies/people/get-all-people-for-a-movie">"Trakt API Doc - Movies: People"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIds">The movie's ids. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktCastAndCrew" /> instance, containing the cast and crew for a movie with the given movieIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="movieIds"/> has not any ids set.</exception>
        public Task<TraktResponse<ITraktCastAndCrew>> GetMoviePeopleAsync(ITraktMovieIds movieIds, TraktExtendedInfo extendedInfo = null,
                                                                          CancellationToken cancellationToken = default)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            if (!movieIds.HasAnyId)
                throw new ArgumentException($"{nameof(movieIds)} has not any ids set", nameof(movieIds));

            return GetMoviePeopleAsync(movieIds.GetBestId(), extendedInfo, cancellationToken);
        }
    }
}
