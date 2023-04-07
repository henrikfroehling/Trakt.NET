namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Recommendations;
    using Parameters;
    using Requests.Handler;
    using Requests.Recommendations.OAuth;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to recommendations.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/recommendations">"Trakt API Doc - Recommendations"</a> section.
    /// </para>
    /// </summary>
    public class TraktRecommendationsModule : ATraktModule
    {
        internal TraktRecommendationsModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Gets personalized movie recommendations for an user.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/recommendations/movies/get-movie-recommendations">"Trakt API Doc - Recommendations: Movies"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="limit">Determines, how many movie recommendations should be queried. Maximum is 100.</param>
        /// <param name="ignoreCollected">Determines, if already collected movies should be filtered out.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktRecommendedMovie}"/> instance containing the queried movies and which also
        /// contains the queried page number and the page's item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktRecommendedMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktRecommendedMovie>> GetMovieRecommendationsAsync(uint? limit = null,
                                                                                             bool? ignoreCollected = null,
                                                                                             TraktExtendedInfo extendedInfo = null,
                                                                                             CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new UserMovieRecommendationsRequest
            {
                ExtendedInfo = extendedInfo,
                Limit = limit,
                IgnoreCollected = ignoreCollected
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
        /// Gets personalized show recommendations for an user.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/recommendations/shows/get-show-recommendations">"Trakt API Doc - Recommendations: Shows"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="limit">Determines, how many show recommendations should be queried. Maximum is 100.</param>
        /// <param name="ignoreCollected">Determines, if already collected shows should be filtered out.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktRecommendedShow}"/> instance containing the queried shows and which also
        /// contains the queried page number and the page's item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktRecommendedShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktRecommendedShow>> GetShowRecommendationsAsync(uint? limit = null,
                                                                                           bool? ignoreCollected = null,
                                                                                           TraktExtendedInfo extendedInfo = null,
                                                                                           CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new UserShowRecommendationsRequest
            {
                ExtendedInfo = extendedInfo,
                Limit = limit,
                IgnoreCollected = ignoreCollected
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
    }
}
