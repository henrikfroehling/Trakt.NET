namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Objects.Post.Comments;
    using System;

    internal sealed class TraktShowCommentPostRequest : ATraktCommentPostRequest<TraktShowCommentPost>
    {
        internal TraktShowCommentPostRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
