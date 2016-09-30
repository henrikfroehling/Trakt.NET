namespace TraktApiSharp.Experimental.Requests.Recommendations.OAuth
{
    using Objects.Get.Movies;

    internal sealed class TraktUserMovieRecommendationsRequest : ATraktUserRecommendationsRequest<TraktMovie>
    {
        internal TraktUserMovieRecommendationsRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "recommendations/movies{?extended,limit}";
    }
}
