namespace TraktApiSharp.Requests.WithoutOAuth.Movies.Common
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Movies.Common;

    internal class TraktMoviesBoxOfficeRequest : TraktGetRequest<TraktListResult<TraktBoxOfficeMovie>, TraktBoxOfficeMovie>
    {
        internal TraktMoviesBoxOfficeRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "movies/boxoffice{?extended}";

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool IsListResult => true;
    }
}
