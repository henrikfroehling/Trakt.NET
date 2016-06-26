namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Delete;

    internal class TraktUserDenyFollowerRequest : TraktDeleteByIdRequest
    {
        internal TraktUserDenyFollowerRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "users/requests/{id}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Unspecified;
    }
}
