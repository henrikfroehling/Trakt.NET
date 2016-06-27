namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Base.Get;
    using Objects.Get.Movies;

    internal class TraktMovieSummaryRequest : TraktGetByIdRequest<TraktMovie, TraktMovie>
    {
        internal TraktMovieSummaryRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}{?extended}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Movies;
    }
}
