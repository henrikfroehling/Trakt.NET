namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Get;
    using Objects.Get.Users.Lists;
    using System;

    internal sealed class TraktUserCustomListsRequest : ATraktListGetRequest<TraktList>
    {
        internal TraktUserCustomListsRequest(TraktClient client) : base(client) {}

        public override string UriTemplate => throw new NotImplementedException();
    }
}
