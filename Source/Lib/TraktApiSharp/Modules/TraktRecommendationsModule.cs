namespace TraktApiSharp.Modules
{
    using Attributes;
    using Extensions;
    using Objects.Basic;
    using Objects.Get.Movies;
    using Objects.Get.Shows;
    using Requests;
    using Requests.Params;
    using Requests.WithOAuth.Recommendations;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to recommendations.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/recommendations">"Trakt API Doc - Recommendations"</a> section.
    /// </para>
    /// </summary>
    public class TraktRecommendationsModule : TraktBaseModule
    {
        internal TraktRecommendationsModule(TraktClient client) : base(client) { }

        /// <summary>
        /// Gets personalized movie recommendations for an user.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/recommendations/movies/get-movie-recommendations">"Trakt API Doc - Recommendations: Movies"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="limit">Determines, how many movie recommendations should be queried. Maximum is 100.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktMovie}"/> instance containing the queried movies and which also
        /// contains the queried page number and the page's item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktMovie" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktPaginationListResult<TraktMovie>> GetMovieRecommendationsAsync(int? limit = null,
                                                                                  TraktExtendedInfo extendedInfo = null)
            => await QueryAsync(new TraktUserMovieRecommendationsRequest(Client)
            {
                PaginationOptions = new TraktPaginationOptions(null, limit),
                ExtendedInfo = extendedInfo
            });

        /// <summary>
        /// Hides a movie with the given Trakt-Id or -Slug or IMDB-Id from getting recommended anymore.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/recommendations/hide-movie/hide-a-movie-recommendation">"Trakt API Doc - Recommendations: Movies"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The Trakt-Id or -Slug or an IMDB-Id of the movie, which should be hidden from recommendations.</param>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given movieIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired]
        public async Task HideMovieRecommendationAsync([NotNull] string movieIdOrSlug)
        {
            Validate(movieIdOrSlug);

            await QueryAsync(new TraktUserRecommendationHideMovieRequest(Client) { Id = movieIdOrSlug });
        }

        /// <summary>
        /// Gets personalized show recommendations for an user.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/recommendations/shows/get-show-recommendations">"Trakt API Doc - Recommendations: Shows"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="limit">Determines, how many show recommendations should be queried. Maximum is 100.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktShow}"/> instance containing the queried shows and which also
        /// contains the queried page number and the page's item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktShow" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktPaginationListResult<TraktShow>> GetShowRecommendationsAsync(int? limit = null,
                                                                                TraktExtendedInfo extendedInfo = null)
            => await QueryAsync(new TraktUserShowRecommendationsRequest(Client)
            {
                PaginationOptions = new TraktPaginationOptions(null, limit),
                ExtendedInfo = extendedInfo
            });

        /// <summary>
        /// Hides a show with the given Trakt-Id or -Slug or IMDB-Id from getting recommended anymore.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/recommendations/hide-show/hide-a-show-recommendation">"Trakt API Doc - Recommendations: Shows"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The Trakt-Id or -Slug or an IMDB-Id of the show, which should be hidden from recommendations.</param>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given showIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired]
        public async Task HideShowRecommendationAsync([NotNull] string showIdOrSlug)
        {
            Validate(showIdOrSlug);

            await QueryAsync(new TraktUserRecommendationHideShowRequest(Client) { Id = showIdOrSlug });
        }

        private void Validate(string id)
        {
            if (string.IsNullOrEmpty(id) || id.ContainsSpace())
                throw new ArgumentException("id not valid", nameof(id));
        }
    }
}
