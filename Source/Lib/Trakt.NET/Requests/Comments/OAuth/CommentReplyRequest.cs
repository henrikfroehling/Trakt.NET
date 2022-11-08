namespace TraktNet.Requests.Comments.OAuth
{
    using Base;
    using Exceptions;
    using Extensions;
    using Interfaces;
    using Objects.Post.Comments;
    using Objects.Post.Comments.Responses;
    using System.Collections.Generic;

    internal sealed class CommentReplyRequest : APostRequest<ITraktCommentPostResponse, ITraktCommentReplyPost>, IHasId
    {
        public string Id { get; set; }

        public override ITraktCommentReplyPost RequestBody { get; set; }

        public RequestObjectType RequestObjectType => RequestObjectType.Comments;

        public override string UriTemplate => "comments/{id}/replies";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object> { ["id"] = Id };

        public override void Validate()
        {
            base.Validate();

            if (Id == null)
                throw new TraktRequestValidationException(nameof(Id), "comment id must not be null");

            if (Id == string.Empty || Id.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Id), "comment id not valid");
        }
    }
}
