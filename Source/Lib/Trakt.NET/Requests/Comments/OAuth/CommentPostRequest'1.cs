namespace TraktNet.Requests.Comments.OAuth
{
    using Base;
    using Objects.Post.Comments;
    using Objects.Post.Comments.Responses;
    using Requests.Interfaces;
    using System.Collections.Generic;

    internal sealed class CommentPostRequest<TRequestBodyType> : APostRequest<ITraktCommentPostResponse, TRequestBodyType> where TRequestBodyType : ITraktCommentPost, IRequestBody
    {
        public override TRequestBodyType RequestBody { get; set; }

        public override string UriTemplate => "comments";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();
    }
}
