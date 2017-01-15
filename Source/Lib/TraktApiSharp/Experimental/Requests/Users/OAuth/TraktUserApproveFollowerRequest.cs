namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Post.Bodyless;
    using Objects.Get.Users;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserApproveFollowerRequest : ATraktSingleItemBodylessPostByIdRequest<TraktUserFollower>
    {
        internal TraktUserApproveFollowerRequest(TraktClient client) : base(client) {}

        public override TraktRequestObjectType RequestObjectType => throw new NotImplementedException();

        public override string UriTemplate => throw new NotImplementedException();
    }
}
