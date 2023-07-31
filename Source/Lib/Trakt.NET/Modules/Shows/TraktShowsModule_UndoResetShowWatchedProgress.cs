namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Shows;
    using Requests.Handler;
    using Requests.Shows.OAuth;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktShowsModule : ATraktModule
    {
        /// <summary>
        /// Undo the reset and have watched progress use all watched history for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization required.</para>
        /// <para>VIP only.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/shows/reset-watched-progress/undo-reset-show-progress">"Trakt API Doc - Shows: Reset Watched Progress"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktNoContentResponse> UndoResetShowWatchedProgressAsync(string showIdOrSlug, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new ShowUndoResetWatchedProgressRequest
            {
                Id = showIdOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Undo the reset and have watched progress use all watched history for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization required.</para>
        /// <para>VIP only.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/shows/reset-watched-progress/undo-reset-show-progress">"Trakt API Doc - Shows: Reset Watched Progress"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktShowID">The show's Trakt-Id. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktNoContentResponse> UndoResetShowWatchedProgressAsync(uint traktShowID, CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return UndoResetShowWatchedProgressAsync(traktShowID.ToString(), cancellationToken);
        }

        /// <summary>
        /// Undo the reset and have watched progress use all watched history for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization required.</para>
        /// <para>VIP only.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/shows/reset-watched-progress/undo-reset-show-progress">"Trakt API Doc - Shows: Reset Watched Progress"</a> for more information.
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
        public Task<TraktNoContentResponse> UndoResetShowWatchedProgressAsync(ITraktShowIds showIds, CancellationToken cancellationToken = default)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (!showIds.HasAnyId)
                throw new ArgumentException($"{nameof(showIds)} has not any ids set", nameof(showIds));

            return UndoResetShowWatchedProgressAsync(showIds.GetBestId(), cancellationToken);
        }

        /// <summary>
        /// Undo the reset and have watched progress use all watched history for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization required.</para>
        /// <para>VIP only.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/shows/reset-watched-progress/undo-reset-show-progress">"Trakt API Doc - Shows: Reset Watched Progress"</a> for more information.
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
        public Task<TraktNoContentResponse> UndoResetShowWatchedProgressAsync(ITraktShow show, CancellationToken cancellationToken = default)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            return UndoResetShowWatchedProgressAsync(show.Ids, cancellationToken);
        }
    }
}
