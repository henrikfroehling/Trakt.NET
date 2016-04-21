namespace TraktApiSharp.Requests.WithoutOAuth.Movies.Common
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Movies.Common;

    internal class TraktMoviesBoxOfficeRequest : TraktGetRequest<TraktListResult<TraktMoviesBoxOfficeItem>, TraktMoviesBoxOfficeItem>
    {
        internal TraktMoviesBoxOfficeRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "movies/boxoffice";

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        protected override bool IsListResult => true;
    }
}
