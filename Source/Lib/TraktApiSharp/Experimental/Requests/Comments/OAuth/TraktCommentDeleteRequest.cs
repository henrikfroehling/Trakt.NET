namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Base.Delete;
    using System;

    internal sealed class TraktCommentDeleteRequest : ATraktNoContentDeleteByIdRequest
    {
        internal TraktCommentDeleteRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
