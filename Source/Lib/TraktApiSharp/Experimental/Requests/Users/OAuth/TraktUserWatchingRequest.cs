namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Users;
    using System;

    internal sealed class TraktUserWatchingRequest : ATraktUsersSingleItemGetRequest<TraktUserWatchingItem>
    {
        internal TraktUserWatchingRequest(TraktClient client) : base(client) {}

        public override string UriTemplate => throw new NotImplementedException();
    }
}
