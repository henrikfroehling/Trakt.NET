namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Collection;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserCollectionMoviesRequest : ATraktUsersListGetRequest<TraktCollectionMovie>
    {
        internal TraktUserCollectionMoviesRequest(TraktClient client) : base(client) {}

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        public override string UriTemplate => "users/{username}/collection/movies{?extended}";
    }
}
