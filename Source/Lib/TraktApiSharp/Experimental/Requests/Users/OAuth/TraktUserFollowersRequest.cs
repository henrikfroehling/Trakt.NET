namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Users;
    using System;

    internal sealed class TraktUserFollowersRequest : ATraktUsersListGetRequest<TraktUserFollower>
    {
        internal TraktUserFollowersRequest(TraktClient client) : base(client) {}

        public override string UriTemplate => throw new NotImplementedException();
    }
}
