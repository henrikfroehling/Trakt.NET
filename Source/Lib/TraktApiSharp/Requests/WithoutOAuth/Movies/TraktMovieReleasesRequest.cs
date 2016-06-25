namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Movies;

    internal class TraktMovieReleasesRequest : TraktGetByIdRequest<TraktListResult<TraktMovieRelease>, TraktMovieRelease>
    {
        internal TraktMovieReleasesRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/releases";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Movies;

        protected override bool IsListResult => true;
    }
}
