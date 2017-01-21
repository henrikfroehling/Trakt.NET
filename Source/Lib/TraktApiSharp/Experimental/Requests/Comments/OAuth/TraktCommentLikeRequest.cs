namespace TraktApiSharp.Experimental.Requests.Comments.OAuth
{
    using Base;
    using Extensions;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktCommentLikeRequest : ATraktBodylessPostRequest, ITraktHasId
    {
        public string Id { get; set; }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comments;

        public override string UriTemplate => "comments/{id}/like";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object> { ["id"] = Id };

        public override void Validate()
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id));

            if (Id == string.Empty || Id.ContainsSpace())
                throw new ArgumentException("comment id not valid", nameof(Id));
        }
    }
}
