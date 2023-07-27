namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Movies;
    using Requests.Handler;
    using Requests.Recommendations.OAuth;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktRecommendationsModule : ATraktModule
    {
        /// <summary>
        /// Hides a movie with the given Trakt-Id or -Slug or IMDB-Id from getting recommended anymore.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/recommendations/hide-movie/hide-a-movie-recommendation">"Trakt API Doc - Recommendations: Movies"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The Trakt-Id or -Slug or an IMDB-Id of the movie, which should be hidden from recommendations.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktNoContentResponse> HideMovieRecommendationAsync(string movieIdOrSlug, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new UserRecommendationHideMovieRequest
            {
                Id = movieIdOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Hides a movie with the given Trakt-Id or -Slug or IMDB-Id from getting recommended anymore.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/recommendations/hide-movie/hide-a-movie-recommendation">"Trakt API Doc - Recommendations: Movies"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktMovieId">The Trakt-Id of the movie, which should be hidden from recommendations.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktMovieId"/> is 0.</exception>
        public Task<TraktNoContentResponse> HideMovieRecommendationAsync(uint traktMovieId, CancellationToken cancellationToken = default)
        {
            if (traktMovieId == 0)
                throw new ArgumentException("movie id must not be 0", nameof(traktMovieId));

            return HideMovieRecommendationAsync(traktMovieId.ToString(), cancellationToken);
        }

        /// <summary>
        /// Hides a movie with the given Trakt-Id or -Slug or IMDB-Id from getting recommended anymore.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/recommendations/hide-movie/hide-a-movie-recommendation">"Trakt API Doc - Recommendations: Movies"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIds">The ids of the movie, which should be hidden from recommendations.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        public Task<TraktNoContentResponse> HideMovieRecommendationAsync(ITraktMovieIds movieIds, CancellationToken cancellationToken = default)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            return HideMovieRecommendationAsync(movieIds.GetBestId(), cancellationToken);
        }
    }
}
