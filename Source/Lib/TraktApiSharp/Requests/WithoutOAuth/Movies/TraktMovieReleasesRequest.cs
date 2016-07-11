namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Base.Get;
    using Objects.Get.Movies;
    using System.Collections.Generic;

    internal class TraktMovieReleasesRequest : TraktGetByIdRequest<IEnumerable<TraktMovieRelease>, TraktMovieRelease>
    {
        internal TraktMovieReleasesRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/releases";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Movies;

        protected override bool IsListResult => true;
    }
}
