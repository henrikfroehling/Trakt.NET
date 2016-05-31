namespace TraktApiSharp.Modules
{
    using Objects.Basic;
    using Objects.Get.Recommendations;
    using Requests;
    using Requests.WithOAuth.Recommendations;
    using System;
    using System.Threading.Tasks;

    public class TraktRecommendationsModule : TraktBaseModule
    {
        public TraktRecommendationsModule(TraktClient client) : base(client) { }

        public async Task<TraktListResult<TraktMovieRecommendation>> GetUserMovieRecommendationsAsync(int? limit = null,
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

        public async Task<TraktListResult<TraktShowRecommendation>> GetUserShowRecommendationsAsync(int? limit = null,
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
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("id not valid", "id");
        }
    }
}
