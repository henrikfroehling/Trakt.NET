namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Users;
    using System;

    internal sealed class TraktUserFollowingRequest : ATraktUsersListGetRequest<TraktUserFollower>
    {
        internal TraktUserFollowingRequest(TraktClient client) : base(client) {}

        public override string UriTemplate => throw new NotImplementedException();
    }
}
