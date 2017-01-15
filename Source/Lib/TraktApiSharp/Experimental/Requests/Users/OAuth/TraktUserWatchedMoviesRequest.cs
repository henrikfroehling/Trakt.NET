namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Watched;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserWatchedMoviesRequest : ATraktUsersListGetRequest<TraktWatchedMovie>
    {
        internal TraktUserWatchedMoviesRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        public override string UriTemplate => "users/{username}/watched/movies{?extended}";
    }
}
