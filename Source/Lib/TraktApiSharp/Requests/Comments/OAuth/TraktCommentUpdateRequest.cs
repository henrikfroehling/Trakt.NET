namespace TraktApiSharp.Requests.Comments.OAuth
{
    using Base;
    using Extensions;
    using Interfaces;
    using Objects.Post.Comments;
    using Objects.Post.Comments.Responses;
    using System;
    using System.Collections.Generic;

    internal sealed class TraktCommentUpdateRequest : APutRequest<ITraktCommentPostResponse, TraktCommentUpdatePost>, ITraktHasId
    {
        public string Id { get; set; }

        public override TraktCommentUpdatePost RequestBody { get; set; }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comments;

        public override string UriTemplate => "comments/{id}";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object> { ["id"] = Id };

        public override void Validate()
        {
            base.Validate();

            if (Id == null)
                throw new ArgumentNullException(nameof(Id));

            if (Id == string.Empty || Id.ContainsSpace())
                throw new ArgumentException("comment id not valid", nameof(Id));
        }
    }
}
