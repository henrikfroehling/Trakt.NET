namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Collection;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserCollectionShowsRequest : ATraktUsersListGetRequest<TraktCollectionShow>
    {
        internal TraktUserCollectionShowsRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        public override string UriTemplate => "users/{username}/collection/shows{?extended}";
    }
}
