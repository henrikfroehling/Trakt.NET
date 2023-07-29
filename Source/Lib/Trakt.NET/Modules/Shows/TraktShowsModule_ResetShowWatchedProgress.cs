namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Shows;
    using Objects.Post.Shows;
    using Requests.Handler;
    using Requests.Shows.OAuth;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktShowsModule : ATraktModule
    {
        /// <summary>
        /// Resets the watched progress for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/shows/watched-progress/reset-show-progress">"Trakt API Doc - Shows: Reset Watched Progress"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="resetAt">An optional reset_at UTC date to have it calculate progress from that specific date onwards.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktShowResetWatchedProgressPost" /> instance, containing an optional reset_at UTC date to have it
        /// calculate progress from that specific date onwards.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktShowResetWatchedProgressPost>> ResetShowWatchedProgressAsync(string showIdOrSlug, DateTime? resetAt = null,
                                                                                                     CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new ShowResetWatchedProgressRequest
            {
                Id = showIdOrSlug,
                RequestBody = new TraktShowResetWatchedProgressPost
                {
                    ResetAt = resetAt
                }
            },
            cancellationToken);
        }

        /// <summary>
        /// Resets the watched progress for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/shows/watched-progress/reset-show-progress">"Trakt API Doc - Shows: Reset Watched Progress"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktShowID">The show's Trakt-Id. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="resetAt">An optional reset_at UTC date to have it calculate progress from that specific date onwards.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktShowResetWatchedProgressPost" /> instance, containing an optional reset_at UTC date to have it
        /// calculate progress from that specific date onwards.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktResponse<ITraktShowResetWatchedProgressPost>> ResetShowWatchedProgressAsync(uint traktShowID, DateTime? resetAt = null,
                                                                                                     CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return ResetShowWatchedProgressAsync(traktShowID.ToString(), resetAt, cancellationToken);
        }

        /// <summary>
        /// Resets the watched progress for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/shows/watched-progress/reset-show-progress">"Trakt API Doc - Shows: Reset Watched Progress"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIds">The show's ids. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="resetAt">An optional reset_at UTC date to have it calculate progress from that specific date onwards.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktShowResetWatchedProgressPost" /> instance, containing an optional reset_at UTC date to have it
        /// calculate progress from that specific date onwards.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="showIds"/> has not any ids set.</exception>
        public Task<TraktResponse<ITraktShowResetWatchedProgressPost>> ResetShowWatchedProgressAsync(ITraktShowIds showIds, DateTime? resetAt = null,
                                                                                                     CancellationToken cancellationToken = default)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (!showIds.HasAnyId)
                throw new ArgumentException($"{nameof(showIds)} has not any ids set", nameof(showIds));

            return ResetShowWatchedProgressAsync(showIds.GetBestId(), resetAt, cancellationToken);
        }
    }
}
