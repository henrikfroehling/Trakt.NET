namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Get;
    using Objects.Get.Users;
    using System;

    internal sealed class TraktUserLikesRequest : ATraktPaginationGetRequest<TraktUserLikeItem>
    {
        internal TraktUserLikesRequest(TraktClient client) : base(client) {}

        public override string UriTemplate => throw new NotImplementedException();
    }
}
