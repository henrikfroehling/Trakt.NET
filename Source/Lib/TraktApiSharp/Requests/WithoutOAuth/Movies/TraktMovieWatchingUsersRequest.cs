namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Users;

    internal class TraktMovieWatchingUsersRequest : TraktGetByIdRequest<TraktListResult<TraktUser>, TraktUser>
    {
        internal TraktMovieWatchingUsersRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/watching{?extended}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Movies;

        protected override bool IsListResult => true;
    }
}
