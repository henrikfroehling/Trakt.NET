namespace TraktApiSharp.Requests.WithOAuth.Recommendations
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Recommendations;

    internal class TraktUserMovieRecommendationsRequest : TraktGetRequest<TraktListResult<TraktMovieRecommendation>, TraktMovieRecommendation>
    {
        internal TraktUserMovieRecommendationsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

        protected override string UriTemplate => "recommendations/movies";
    }
}
