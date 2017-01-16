namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Put;
    using Objects.Get.Users.Lists;
    using Objects.Post.Users;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserCustomListUpdateRequest : ATraktSingleItemPutByIdRequest<TraktList, TraktUserCustomListPost>
    {
        internal TraktUserCustomListUpdateRequest(TraktClient client) : base(client) {}

        public override TraktRequestObjectType RequestObjectType => throw new NotImplementedException();

        public override string UriTemplate => throw new NotImplementedException();
    }
}
