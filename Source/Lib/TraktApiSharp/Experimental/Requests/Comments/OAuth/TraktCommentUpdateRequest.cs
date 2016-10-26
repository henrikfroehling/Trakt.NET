namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Base.Put;
    using Objects.Post.Comments;
    using Objects.Post.Comments.Responses;
    using System;

    internal sealed class TraktCommentUpdateRequest : ATraktSingleItemPutByIdRequest<TraktCommentPostResponse, TraktCommentUpdatePost>
    {
        internal TraktCommentUpdateRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
