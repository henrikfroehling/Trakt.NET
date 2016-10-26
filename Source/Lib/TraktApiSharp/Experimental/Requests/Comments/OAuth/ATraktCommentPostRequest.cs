namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Base.Post;
    using Objects.Post.Comments.Responses;

    internal abstract class ATraktCommentPostRequest<TRequestBody> : ATraktSingleItemPostRequest<TraktCommentPostResponse, TRequestBody>
    {
        internal ATraktCommentPostRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "comments";
    }
}
