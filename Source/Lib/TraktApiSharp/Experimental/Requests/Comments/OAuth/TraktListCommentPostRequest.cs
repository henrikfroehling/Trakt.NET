namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Objects.Post.Comments;
    using System;

    internal sealed class TraktListCommentPostRequest : ATraktCommentPostRequest<TraktListCommentPost>
    {
        internal TraktListCommentPostRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
