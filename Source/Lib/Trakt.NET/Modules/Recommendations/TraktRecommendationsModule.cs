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
    /// This module contains all methods of the <a href ="http://trakt.docs.apiary.io/#reference/recommendations">"Trakt API Doc - Recommendations"</a> section.
    /// </para>
    /// </summary>
    public partial class TraktRecommendationsModule : ATraktModule
    {
        internal TraktRecommendationsModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Gets personalized movie recommendations for an user.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/recommendations/movies/get-movie-recommendations">"Trakt API Doc - Recommendations: Movies"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="ignoreCollected">Determines, if already collected movies should be filtered out.</param>
        /// <param name="ignoreWatchlisted">Determines, if already watchlisted movies should be filtered out.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktRecommendedMovie}"/> instance containing the queried recommended movies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktRecommendedMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktRecommendedMovie>> GetMovieRecommendationsAsync(bool? ignoreCollected = null,
                                                                                             bool? ignoreWatchlisted = null,
                                                                                             TraktExtendedInfo extendedInfo = null,
                                                                                             TraktPagedParameters pagedParameters = null,
                                                                                             CancellationToken cancellationToken = default)
        {
            var request = new UserMovieRecommendationsRequest
            {
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit,
                IgnoreCollected = ignoreCollected,
                IgnoreWatchlisted = ignoreWatchlisted
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets personalized show recommendations for an user.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/recommendations/shows/get-show-recommendations">"Trakt API Doc - Recommendations: Shows"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="ignoreCollected">Determines, if already collected shows should be filtered out.</param>
        /// <param name="ignoreWatchlisted">Determines, if already watchlisted shows should be filtered out.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktRecommendedShow}"/> instance containing the queried recommended shows and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktRecommendedShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktRecommendedShow>> GetShowRecommendationsAsync(bool? ignoreCollected = null,
                                                                                           bool? ignoreWatchlisted = null,
                                                                                           TraktExtendedInfo extendedInfo = null,
                                                                                           TraktPagedParameters pagedParameters = null,
                                                                                           CancellationToken cancellationToken = default)
        {
            var request = new UserShowRecommendationsRequest
            {
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit,
                IgnoreCollected = ignoreCollected,
                IgnoreWatchlisted = ignoreWatchlisted
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }
    }
}
