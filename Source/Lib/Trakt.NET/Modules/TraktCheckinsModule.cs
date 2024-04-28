namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Episodes;
    using Objects.Get.Movies;
    using Objects.Post.Checkins;
    using Objects.Post.Checkins.Responses;
    using PostBuilder;
    using Requests.Checkins.OAuth;
    using Requests.Handler;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to checkins.
    /// <para>
    /// This module contains all methods of the <a href ="http://trakt.docs.apiary.io/#reference/checkin">"Trakt API Doc - Checkin"</a> section.
    /// </para>
    /// </summary>
    public class TraktCheckinsModule : ATraktModule
    {
        internal TraktCheckinsModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Checks into the given <see cref="ITraktMovie" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/checkin/check-into-an-item">"Trakt API Doc - Checkin: Checkin"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktMovieCheckinPostBuilder" /> to create an instance
        /// of the required <see cref="ITraktMovieCheckinPost" />.
        /// See also <seealso cref="TraktPost.NewMovieCheckinPost()" />.
        /// </para>
        /// </summary>
        /// <param name="movieCheckinPost">An <see cref="ITraktMovieCheckinPost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktMovieCheckinPostResponse" /> instance, containing the successfully checked in movie's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktMovieCheckinPostResponse>> CheckIntoMovieAsync(ITraktMovieCheckinPost movieCheckinPost,
                                                                                       CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CheckinRequest<ITraktMovieCheckinPostResponse, ITraktMovieCheckinPost>
            {
                RequestBody = movieCheckinPost
            },
            cancellationToken);
        }

        /// <summary>
        /// Checks into the given <see cref="ITraktEpisode" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/checkin/check-into-an-item">"Trakt API Doc - Checkin: Checkin"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktEpisodeCheckinPostBuilder" /> to create an instance
        /// of the required <see cref="ITraktEpisodeCheckinPost" />.
        /// See also <seealso cref="TraktPost.NewEpisodeCheckinPost()" />.
        /// </para>
        /// </summary>
        /// <param name="episodeCheckinPost">An <see cref="ITraktEpisodeCheckinPost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktEpisodeCheckinPostResponse" /> instance, containing the successfully checked in episode's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktEpisodeCheckinPostResponse>> CheckIntoEpisodeAsync(ITraktEpisodeCheckinPost episodeCheckinPost,
                                                                                           CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CheckinRequest<ITraktEpisodeCheckinPostResponse, ITraktEpisodeCheckinPost>
            {
                RequestBody = episodeCheckinPost
            },
            cancellationToken);
        }

        /// <summary>
        /// Deletes any active checkins.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/checkin/checkin/delete-any-active-checkins">"Trakt API Doc - Checkin: Checkin"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktNoContentResponse> DeleteAnyActiveCheckinsAsync(CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteNoContentRequestAsync(new CheckinsDeleteRequest(), cancellationToken);
        }
    }
}
