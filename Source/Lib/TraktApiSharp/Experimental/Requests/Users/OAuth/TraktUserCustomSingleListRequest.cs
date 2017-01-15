namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Get;
    using Objects.Get.Users.Lists;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserCustomSingleListRequest : ATraktSingleItemGetByIdRequest<TraktList>
    {
        internal TraktUserCustomSingleListRequest(TraktClient client) : base(client) {}

        public override TraktRequestObjectType RequestObjectType => throw new NotImplementedException();

        public override string UriTemplate => throw new NotImplementedException();
    }
}
