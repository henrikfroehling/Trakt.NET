namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Episodes;
    using Objects.Get.Movies;
    using Objects.Post.Scrobbles;
    using Objects.Post.Scrobbles.Responses;
    using PostBuilder;
    using Requests.Handler;
    using Requests.Interfaces;
    using Requests.Scrobbles.OAuth;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to scrobbles.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/scrobble">"Trakt API Doc - Scrobble"</a> section.
    /// </para>
    /// </summary>
    public class TraktScrobbleModule : ATraktModule
    {
        internal TraktScrobbleModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Starts watching a <see cref="ITraktMovie" /> in a media center.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktMovieScrobblePostBuilder" /> to create an instance
        /// of the required <see cref="ITraktMovieScrobblePost" />.
        /// See also <seealso cref="TraktPost.NewMovieScrobblePost()" />.
        /// </para>
        /// </summary>
        /// <param name="movieScrobblePost">An <see cref="ITraktMovieScrobblePost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktMovieScrobblePostResponse" /> instance, containing the successfully scrobbled movie's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktMovieScrobblePostResponse>> StartMovieAsync(ITraktMovieScrobblePost movieScrobblePost,
                                                                                    CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteSingleItemRequestAsync(CreateScrobbleStartRequest<ITraktMovieScrobblePostResponse, ITraktMovieScrobblePost>(movieScrobblePost), cancellationToken);
        }

        /// <summary>
        /// Pauses watching a <see cref="ITraktMovie" /> in a media center.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktMovieScrobblePostBuilder" /> to create an instance
        /// of the required <see cref="ITraktMovieScrobblePost" />.
        /// See also <seealso cref="TraktPost.NewMovieScrobblePost()" />.
        /// </para>
        /// </summary>
        /// <param name="movieScrobblePost">An <see cref="ITraktMovieScrobblePost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktMovieScrobblePostResponse" /> instance, containing the successfully scrobbled movie's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktMovieScrobblePostResponse>> PauseMovieAsync(ITraktMovieScrobblePost movieScrobblePost,
                                                                                    CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteSingleItemRequestAsync(CreateScrobblePauseRequest<ITraktMovieScrobblePostResponse, ITraktMovieScrobblePost>(movieScrobblePost), cancellationToken);
        }

        /// <summary>
        /// Stops watching a <see cref="ITraktMovie" /> in a media center.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktMovieScrobblePostBuilder" /> to create an instance
        /// of the required <see cref="ITraktMovieScrobblePost" />.
        /// See also <seealso cref="TraktPost.NewMovieScrobblePost()" />.
        /// </para>
        /// </summary>
        /// <param name="movieScrobblePost">An <see cref="ITraktMovieScrobblePost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktMovieScrobblePostResponse" /> instance, containing the successfully scrobbled movie's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktMovieScrobblePostResponse>> StopMovieAsync(ITraktMovieScrobblePost movieScrobblePost,
                                                                                   CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteSingleItemRequestAsync(CreateScrobbleStopRequest<ITraktMovieScrobblePostResponse, ITraktMovieScrobblePost>(movieScrobblePost), cancellationToken);
        }

        /// <summary>
        /// Starts watching a <see cref="ITraktEpisode" /> in a media center.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktEpisodeScrobblePostBuilder" /> to create an instance
        /// of the required <see cref="ITraktEpisodeScrobblePost" />.
        /// See also <seealso cref="TraktPost.NewEpisodeScrobblePost()" />.
        /// </para>
        /// </summary>
        /// <param name="episodeScrobblePost">An <see cref="ITraktEpisodeScrobblePost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktEpisodeScrobblePostResponse" /> instance, containing the successfully scrobbled episode's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktEpisodeScrobblePostResponse>> StartEpisodeAsync(ITraktEpisodeScrobblePost episodeScrobblePost,
                                                                                        CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteSingleItemRequestAsync(CreateScrobbleStartRequest<ITraktEpisodeScrobblePostResponse, ITraktEpisodeScrobblePost>(episodeScrobblePost), cancellationToken);
        }

        /// <summary>
        /// Pauses watching a <see cref="ITraktEpisode" /> in a media center.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktEpisodeScrobblePostBuilder" /> to create an instance
        /// of the required <see cref="ITraktEpisodeScrobblePost" />.
        /// See also <seealso cref="TraktPost.NewEpisodeScrobblePost()" />.
        /// </para>
        /// </summary>
        /// <param name="episodeScrobblePost">An <see cref="ITraktEpisodeScrobblePost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktEpisodeScrobblePostResponse" /> instance, containing the successfully scrobbled episode's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktEpisodeScrobblePostResponse>> PauseEpisodeAsync(ITraktEpisodeScrobblePost episodeScrobblePost,
                                                                                        CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteSingleItemRequestAsync(CreateScrobblePauseRequest<ITraktEpisodeScrobblePostResponse, ITraktEpisodeScrobblePost>(episodeScrobblePost), cancellationToken);
        }

        /// <summary>
        /// Stops watching a <see cref="ITraktEpisode" /> in a media center.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/scrobble/start-watching-in-a-media-center">"Trakt API Doc - Scrobble: Start"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktEpisodeScrobblePostBuilder" /> to create an instance
        /// of the required <see cref="ITraktEpisodeScrobblePost" />.
        /// See also <seealso cref="TraktPost.NewEpisodeScrobblePost()" />.
        /// </para>
        /// </summary>
        /// <param name="episodeScrobblePost">An <see cref="ITraktEpisodeScrobblePost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktEpisodeScrobblePostResponse" /> instance, containing the successfully scrobbled episode's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktEpisodeScrobblePostResponse>> StopEpisodeAsync(ITraktEpisodeScrobblePost episodeScrobblePost,
                                                                                       CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteSingleItemRequestAsync(CreateScrobbleStopRequest<ITraktEpisodeScrobblePostResponse, ITraktEpisodeScrobblePost>(episodeScrobblePost), cancellationToken);
        }

        private ScrobbleStartRequest<T, U> CreateScrobbleStartRequest<T, U>(U requestBody) where U : ITraktScrobblePost, IRequestBody
            => new() { RequestBody = requestBody };

        private ScrobblePauseRequest<T, U> CreateScrobblePauseRequest<T, U>(U requestBody) where U : ITraktScrobblePost, IRequestBody
            => new() { RequestBody = requestBody };

        private ScrobbleStopRequest<T, U> CreateScrobbleStopRequest<T, U>(U requestBody) where U : ITraktScrobblePost, IRequestBody
            => new() { RequestBody = requestBody };
    }
}
