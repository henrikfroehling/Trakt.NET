namespace TraktApiSharp.Requests.Users.OAuth
{
    using Base;

    internal sealed class TraktUserDenyFollowerRequest : ATraktUsersDeleteByIdRequest
    {
        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Unspecified;

        public override string UriTemplate => "users/requests/{id}";
    }
}
