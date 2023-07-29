namespace TraktNet.Modules
{
    using Enums;
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
        /// Gets the collection progress for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/collection-progress/get-show-collection-progress">"Trakt API Doc - Shows: Collection Progress"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="includingHiddenSeasons">Determines, if the returned collection progress should contain hidden seasons.</param>
        /// <param name="includingSpecialSeasons">Determines, if the returned collection progress should contain special seasons.</param>
        /// <param name="countSpecialSeasons">Determins, if special seasons should be counted in the statistics of the returned collection progress.</param>
        /// <param name="lastActivity">Determines the last activity type of the collection progress.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktShowCollectionProgress" /> instance, containing the collection progress for a show with the given showIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktShowCollectionProgress>> GetShowCollectionProgressAsync(string showIdOrSlug, bool? includingHiddenSeasons = null,
                                                                                                bool? includingSpecialSeasons = null,
                                                                                                bool? countSpecialSeasons = null,
                                                                                                TraktLastActivity lastActivity = null,
                                                                                                CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new ShowCollectionProgressRequest
            {
                Id = showIdOrSlug,
                Hidden = includingHiddenSeasons,
                Specials = includingSpecialSeasons,
                CountSpecials = countSpecialSeasons,
                LastActivity = lastActivity
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the collection progress for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/collection-progress/get-show-collection-progress">"Trakt API Doc - Shows: Collection Progress"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktShowID">The show's Trakt-Id. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="includingHiddenSeasons">Determines, if the returned collection progress should contain hidden seasons.</param>
        /// <param name="includingSpecialSeasons">Determines, if the returned collection progress should contain special seasons.</param>
        /// <param name="countSpecialSeasons">Determins, if special seasons should be counted in the statistics of the returned collection progress.</param>
        /// <param name="lastActivity">Determines the last activity type of the collection progress.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktShowCollectionProgress" /> instance, containing the collection progress for a show with the given showIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktResponse<ITraktShowCollectionProgress>> GetShowCollectionProgressAsync(uint traktShowID, bool? includingHiddenSeasons = null,
                                                                                                bool? includingSpecialSeasons = null,
                                                                                                bool? countSpecialSeasons = null,
                                                                                                TraktLastActivity lastActivity = null,
                                                                                                CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return GetShowCollectionProgressAsync(traktShowID.ToString(), includingHiddenSeasons, includingSpecialSeasons,
                                                  countSpecialSeasons, lastActivity, cancellationToken);
        }

        /// <summary>
        /// Gets the collection progress for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/shows/collection-progress/get-show-collection-progress">"Trakt API Doc - Shows: Collection Progress"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIds">The show's ids. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="includingHiddenSeasons">Determines, if the returned collection progress should contain hidden seasons.</param>
        /// <param name="includingSpecialSeasons">Determines, if the returned collection progress should contain special seasons.</param>
        /// <param name="countSpecialSeasons">Determins, if special seasons should be counted in the statistics of the returned collection progress.</param>
        /// <param name="lastActivity">Determines the last activity type of the collection progress.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktShowCollectionProgress" /> instance, containing the collection progress for a show with the given showIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="showIds"/> has not any ids set.</exception>
        public Task<TraktResponse<ITraktShowCollectionProgress>> GetShowCollectionProgressAsync(ITraktShowIds showIds, bool? includingHiddenSeasons = null,
                                                                                                bool? includingSpecialSeasons = null,
                                                                                                bool? countSpecialSeasons = null,
                                                                                                TraktLastActivity lastActivity = null,
                                                                                                CancellationToken cancellationToken = default)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (!showIds.HasAnyId)
                throw new ArgumentException($"{nameof(showIds)} has not any ids set", nameof(showIds));

            return GetShowCollectionProgressAsync(showIds.GetBestId(), includingHiddenSeasons, includingSpecialSeasons,
                                                  countSpecialSeasons, lastActivity, cancellationToken);
        }
    }
}
