namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Users;
    using System;

    internal sealed class TraktUserFriendsRequest : ATraktUsersListGetRequest<TraktUserFriend>
    {
        internal TraktUserFriendsRequest(TraktClient client) : base(client) {}

        public override string UriTemplate => throw new NotImplementedException();
    }
}
