namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Base;
    using Objects.Post.Comments;
    using Objects.Post.Comments.Responses;
    using System.Collections.Generic;

    internal sealed class TraktCommentPostRequest<TRequestBody> : ATraktPostRequest<TraktCommentPostResponse, TRequestBody> where TRequestBody : TraktCommentPost
    {
        public override TRequestBody RequestBody { get; set; }

        public override string UriTemplate => "comments";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();
    }
}
