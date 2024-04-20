namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Shows;
    using Requests.Handler;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Requests.Shows.OAuth;

    public partial class TraktShowsModule : ATraktModule
    {
        /// <summary>
        /// Queue a <see cref="ITraktShow" /> for a full metadata and image refresh.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/shows/refresh/refresh-show-metadata">"Trakt API Doc - Refresh: Refresh show metadata"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktNoContentResponse> RefreshShowAsync(string showIdOrSlug, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new ShowRefreshRequest
            {
                Id = showIdOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Queue a <see cref="ITraktShow" /> for a full metadata and image refresh.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/shows/refresh/refresh-show-metadata">"Trakt API Doc - Refresh: Refresh show metadata"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktShowId">The show's Trakt-Id. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowId"/> is 0.</exception>
        public Task<TraktNoContentResponse> RefreshShowAsync(uint traktShowId, CancellationToken cancellationToken = default)
        {
            if (traktShowId == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowId));

            return RefreshShowAsync(traktShowId.ToString(), cancellationToken);
        }

        /// <summary>
        /// Queue a <see cref="ITraktShow" /> for a full metadata and image refresh.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/shows/refresh/refresh-show-metadata">"Trakt API Doc - Refresh: Refresh show metadata"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIds">The show's ids. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="showIds"/> has not any ids set.</exception>
        public Task<TraktNoContentResponse> RefreshShowAsync(ITraktShowIds showIds, CancellationToken cancellationToken = default)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (!showIds.HasAnyId)
                throw new ArgumentException($"{nameof(showIds)} has not any ids set", nameof(showIds));

            return RefreshShowAsync(showIds.GetBestId(), cancellationToken);
        }

        /// <summary>
        /// Queue a <see cref="ITraktShow" /> for a full metadata and image refresh.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/shows/refresh/refresh-show-metadata">"Trakt API Doc - Refresh: Refresh show metadata"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="show">The show. See also <seealso cref="ITraktShow" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        public Task<TraktNoContentResponse> RefreshShowAsync(ITraktShow show, CancellationToken cancellationToken = default)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            return RefreshShowAsync(show.Ids, cancellationToken);
        }
    }
}
