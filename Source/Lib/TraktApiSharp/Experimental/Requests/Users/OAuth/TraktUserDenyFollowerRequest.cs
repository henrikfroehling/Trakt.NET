namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using TraktApiSharp.Requests;

    internal sealed class TraktUserDenyFollowerRequest : ATraktUsersDeleteByIdRequest
    {
        internal TraktUserDenyFollowerRequest(TraktClient client) : base(client) { }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Unspecified;

        public override string UriTemplate => "users/requests/{id}";
    }
}
