namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Objects.Post.Comments;
    using System;

    internal sealed class TraktMovieCommentPostRequest : ATraktCommentPostRequest<TraktMovieCommentPost>
    {
        internal TraktMovieCommentPostRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
