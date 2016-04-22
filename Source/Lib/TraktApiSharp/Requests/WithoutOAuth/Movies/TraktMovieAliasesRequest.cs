namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Movies;

    internal class TraktMovieAliasesRequest : TraktGetByIdRequest<TraktListResult<TraktMovieAlias>, TraktMovieAlias>
    {
        internal TraktMovieAliasesRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/aliases";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        protected override bool IsListResult => true;
    }
}
