namespace TraktApiSharp.Requests.Users.OAuth
{
    using Base;

    internal sealed class TraktUserDenyFollowerRequest : ATraktUsersDeleteByIdRequest
    {
        public override RequestObjectType RequestObjectType => RequestObjectType.Unspecified;

        public override string UriTemplate => "users/requests/{id}";
    }
}
