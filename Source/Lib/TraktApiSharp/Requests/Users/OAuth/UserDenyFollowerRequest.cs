namespace TraktNet.Requests.Users.OAuth
{
    using Base;

    internal sealed class UserDenyFollowerRequest : AUsersDeleteByIdRequest
    {
        public override RequestObjectType RequestObjectType => RequestObjectType.Unspecified;

        public override string UriTemplate => "users/requests/{id}";
    }
}
