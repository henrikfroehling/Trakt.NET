namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Collection;

    internal sealed class TraktUserCollectionMoviesRequest : ATraktUsersListGetRequest<TraktCollectionMovie>
    {
        internal TraktUserCollectionMoviesRequest(TraktClient client) : base(client) {}

        public override string UriTemplate => "users/{username}/collection/movies{?extended}";
    }
}
