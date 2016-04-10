namespace TraktApiSharp.Requests.Movies
{
    using Base.Get;
    using Objects;
    using Objects.Movies;

    internal class TraktMovieTranslationsRequest : TraktGetByIdRequest<TraktListResult<TraktMovieTranslation>, TraktMovieTranslation>
    {
        internal TraktMovieTranslationsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/translations";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        protected override bool IsListResult => true;
    }
}
