namespace TraktApiSharp.Experimental.Requests.Users
{
    using Base.Get;
    using Objects.Basic;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserListCommentsRequest : ATraktPaginationGetByIdRequest<TraktComment>
    {
        internal TraktUserListCommentsRequest(TraktClient client) : base(client) {}

        public override TraktRequestObjectType RequestObjectType => throw new NotImplementedException();

        public override string UriTemplate => throw new NotImplementedException();
    }
}
