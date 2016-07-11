namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Base.Get;
    using Objects.Get.Movies;
    using System.Collections.Generic;

    internal class TraktMovieAliasesRequest : TraktGetByIdRequest<IEnumerable<TraktMovieAlias>, TraktMovieAlias>
    {
        internal TraktMovieAliasesRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/aliases";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Movies;

        protected override bool IsListResult => true;
    }
}
