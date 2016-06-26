namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Post;
    using Objects.Get.Users;

    internal class TraktUserApproveFollowerRequest : TraktBodylessPostByIdRequest<TraktUserFollower, TraktUserFollower>
    {
        internal TraktUserApproveFollowerRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "users/requests/{id}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Unspecified;
    }
}
