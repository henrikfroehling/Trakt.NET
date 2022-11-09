namespace TraktNet.Requests.Comments
{
    using Base;
    using Exceptions;
    using Extensions;
    using Interfaces;
    using Objects.Basic;
    using System.Collections.Generic;

    internal sealed class CommentSummaryRequest : AGetRequest<ITraktComment>, IHasId
    {
        public string Id { get; set; }

        public RequestObjectType RequestObjectType => RequestObjectType.Comments;

        public override string UriTemplate => "comments/{id}";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object> { ["id"] = Id };

        public override void Validate()
        {
            if (Id == null)
                throw new TraktRequestValidationException(nameof(Id), "comment id must not be null");

            if (Id == string.Empty || Id.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Id), "comment id not valid");
        }
    }
}
