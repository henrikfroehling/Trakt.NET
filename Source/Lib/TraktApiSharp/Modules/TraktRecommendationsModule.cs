namespace TraktApiSharp.Modules
{
    using Extensions;
    using Objects.Basic;
    using Objects.Get.Movies;
    using Objects.Get.Shows;
    using Requests;
    using Requests.WithOAuth.Recommendations;
    using System;
    using System.Threading.Tasks;

    public class TraktRecommendationsModule : TraktBaseModule
    {
        internal TraktRecommendationsModule(TraktClient client) : base(client) { }

        public async Task<TraktPaginationListResult<TraktMovie>> GetMovieRecommendationsAsync(int? limit = null,
                                                                                              TraktExtendedOption extended = null)
        {
            return await QueryAsync(new TraktUserMovieRecommendationsRequest(Client)
            {
                PaginationOptions = new TraktPaginationOptions(null, limit),
                ExtendedOption = extended != null ? extended : new TraktExtendedOption()
            });
        }

        public async Task HideMovieRecommendationAsync(string movieId)
        {
            Validate(movieId);

            await QueryAsync(new TraktUserRecommendationHideMovieRequest(Client) { Id = movieId });
        }

        public async Task<TraktPaginationListResult<TraktShow>> GetShowRecommendationsAsync(int? limit = null,
                                                                                            TraktExtendedOption extended = null)
        {
            return await QueryAsync(new TraktUserShowRecommendationsRequest(Client)
            {
                PaginationOptions = new TraktPaginationOptions(null, limit),
                ExtendedOption = extended != null ? extended : new TraktExtendedOption()
            });
        }

        public async Task HideShowRecommendationAsync(string showId)
        {
            Validate(showId);

            await QueryAsync(new TraktUserRecommendationHideShowRequest(Client) { Id = showId });
        }

        private void Validate(string id)
        {
            if (string.IsNullOrEmpty(id) || id.ContainsSpace())
                throw new ArgumentException("id not valid", nameof(id));
        }
    }
}
