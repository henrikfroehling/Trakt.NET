namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Shows;
    using Requests.Handler;
    using Requests.Recommendations.OAuth;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktRecommendationsModule : ATraktModule
    {
        /// <summary>
        /// Hides a show with the given Trakt-Id or -Slug or IMDB-Id from getting recommended anymore.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/recommendations/hide-show/hide-a-show-recommendation">"Trakt API Doc - Recommendations: Shows"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The Trakt-Id or -Slug or an IMDB-Id of the show, which should be hidden from recommendations.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktNoContentResponse> HideShowRecommendationAsync(string showIdOrSlug, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new UserRecommendationHideShowRequest
            {
                Id = showIdOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Hides a show with the given Trakt-Id or -Slug or IMDB-Id from getting recommended anymore.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/recommendations/hide-show/hide-a-show-recommendation">"Trakt API Doc - Recommendations: Shows"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktShowId">The Trakt-Id of the show, which should be hidden from recommendations.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowId"/> is 0.</exception>
        public Task<TraktNoContentResponse> HideShowRecommendationAsync(uint traktShowId, CancellationToken cancellationToken = default)
        {
            if (traktShowId == 0)
                throw new ArgumentException("movie id must not be 0", nameof(traktShowId));

            return HideShowRecommendationAsync(traktShowId.ToString(), cancellationToken);
        }

        /// <summary>
        /// Hides a show with the given Trakt-Id or -Slug or IMDB-Id from getting recommended anymore.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/recommendations/hide-show/hide-a-show-recommendation">"Trakt API Doc - Recommendations: Shows"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIds">The ids of the show, which should be hidden from recommendations.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        public Task<TraktNoContentResponse> HideShowRecommendationAsync(ITraktShowIds showIds, CancellationToken cancellationToken = default)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            return HideShowRecommendationAsync(showIds.GetBestId(), cancellationToken);
        }
    }
}
