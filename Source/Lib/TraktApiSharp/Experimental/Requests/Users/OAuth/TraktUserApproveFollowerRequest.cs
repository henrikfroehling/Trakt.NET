namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Post.Bodyless;
    using Objects.Get.Users;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserApproveFollowerRequest : ATraktSingleItemBodylessPostByIdRequest<TraktUserFollower>
    {
        internal TraktUserApproveFollowerRequest(TraktClient client) : base(client) {}

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Unspecified;

        public override string UriTemplate => "users/requests/{id}";
    }
}
