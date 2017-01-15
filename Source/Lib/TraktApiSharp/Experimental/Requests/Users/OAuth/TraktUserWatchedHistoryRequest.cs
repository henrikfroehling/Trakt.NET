namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.History;
    using System;

    internal sealed class TraktUserWatchedHistoryRequest : ATraktUsersPaginationGetRequest<TraktHistoryItem>
    {
        internal TraktUserWatchedHistoryRequest(TraktClient client) : base(client) {}

        public override string UriTemplate => throw new NotImplementedException();
    }
}
