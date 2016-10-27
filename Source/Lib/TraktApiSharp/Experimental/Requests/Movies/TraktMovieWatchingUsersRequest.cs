namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Base.Get;
    using Objects.Get.Users;
    using TraktApiSharp.Requests;

    internal sealed class TraktMovieWatchingUsersRequest : ATraktListGetByIdRequest<TraktUser>
    {
        internal TraktMovieWatchingUsersRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "movies/{id}/watching{?extended}";
    }
}
