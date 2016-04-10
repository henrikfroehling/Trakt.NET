namespace TraktApiSharp.Requests.Movies
{
    using Base.Get;
    using Objects;
    using Objects.Movies;

    internal class TraktMovieAliasesRequest : TraktGetByIdRequest<TraktListResult<TraktMovieAlias>, TraktMovieAlias>
    {
        internal TraktMovieAliasesRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/aliases";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;
    }
}
