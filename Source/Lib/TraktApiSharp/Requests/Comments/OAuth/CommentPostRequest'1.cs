namespace TraktApiSharp.Requests.Comments.OAuth
{
    using Base;
    using Objects.Post.Comments;
    using Objects.Post.Comments.Responses;
    using System.Collections.Generic;

    internal sealed class CommentPostRequest<TRequestBodyType> : APostRequest<ITraktCommentPostResponse, TRequestBodyType> where TRequestBodyType : TraktCommentPost
    {
        public override TRequestBodyType RequestBody { get; set; }

        public override string UriTemplate => "comments";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();
    }
}
