namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Users;
    using System;

    internal sealed class TraktUserCommentsRequest : ATraktUsersPaginationGetRequest<TraktUserComment>
    {
        internal TraktUserCommentsRequest(TraktClient client) : base(client) {}

        public override string UriTemplate => throw new NotImplementedException();
    }
}
