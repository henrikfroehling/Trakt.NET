namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using TraktApiSharp.Requests;

    internal sealed class TraktUserApproveFollowerRequest
    {
        internal TraktUserApproveFollowerRequest(TraktClient client) {}

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Unspecified;

        public string UriTemplate => "users/requests/{id}";
    }
}
