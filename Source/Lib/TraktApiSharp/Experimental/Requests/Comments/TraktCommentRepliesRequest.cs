namespace TraktApiSharp.Experimental.Requests.Comments
{
    using Base.Get;
    using Objects.Basic;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktCommentRepliesRequest : ATraktPaginationGetByIdRequest<TraktComment>
    {
        internal TraktCommentRepliesRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
