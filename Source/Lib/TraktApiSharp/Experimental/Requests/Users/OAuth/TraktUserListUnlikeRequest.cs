namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using TraktApiSharp.Requests;

    internal sealed class TraktUserListUnlikeRequest : ATraktUsersDeleteByIdRequest
    {
        internal TraktUserListUnlikeRequest(TraktClient client) : base(client) { }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Lists;

        public override string UriTemplate => "users/{username}/lists/{id}/like";
    }
}
