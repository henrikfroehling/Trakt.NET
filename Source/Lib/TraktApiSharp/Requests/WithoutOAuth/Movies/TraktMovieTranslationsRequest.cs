namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Movies;

    internal class TraktMovieTranslationsRequest : TraktGetByIdRequest<TraktListResult<TraktMovieTranslation>, TraktMovieTranslation>
    {
        internal TraktMovieTranslationsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/translations";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Movies;

        protected override bool IsListResult => true;
    }
}
