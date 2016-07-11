namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Base.Get;
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal class TraktMovieWatchingUsersRequest : TraktGetByIdRequest<IEnumerable<TraktUser>, TraktUser>
    {
        internal TraktMovieWatchingUsersRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/watching{?extended}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Movies;

        protected override bool IsListResult => true;
    }
}
