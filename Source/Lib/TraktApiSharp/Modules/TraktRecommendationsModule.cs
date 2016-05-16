namespace TraktApiSharp.Modules
{
    using Objects.Basic;
    using Objects.Get.Recommendations;
    using Requests;
    using Requests.WithOAuth.Recommendations;
    using System.Threading.Tasks;

    public class TraktRecommendationsModule : TraktBaseModule
    {
        public TraktRecommendationsModule(TraktClient client) : base(client) { }

        public async Task<TraktListResult<TraktMovieRecommendation>> GetUserMovieRecommendationsAsync(int? limit = null,
                                                                                                      TraktExtendedOptionOld extended = TraktExtendedOptionOld.Unspecified)
        {
            return await QueryAsync(new TraktUserMovieRecommendationsRequest(Client)
            {
                PaginationOptions = new TraktPaginationOptions(null, limit),
                ExtendedOption = extended
            });
        }

        public async Task HideMovieRecommendationAsync(string movieId)
        {
            await QueryAsync(new TraktUserRecommendationHideMovieRequest(Client)
            {
                Id = movieId
            });
        }

        public async Task<TraktListResult<TraktShowRecommendation>> GetUserShowRecommendationsAsync(int? limit = null,
                                                                                                    TraktExtendedOptionOld extended = TraktExtendedOptionOld.Unspecified)
        {
            return await QueryAsync(new TraktUserShowRecommendationsRequest(Client)
            {
                PaginationOptions = new TraktPaginationOptions(null, limit),
                ExtendedOption = extended
            });
        }

        public async Task HideShowRecommendationAsync(string showId)
        {
            await QueryAsync(new TraktUserRecommendationHideShowRequest(Client)
            {
                Id = showId
            });
        }
    }
}
