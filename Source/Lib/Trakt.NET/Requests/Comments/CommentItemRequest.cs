namespace TraktNet.Requests.Comments
{
    using Base;
    using Exceptions;
    using Extensions;
    using Interfaces;
    using Objects.Basic;
    using Parameters;
    using System.Collections.Generic;
    using TraktNet.Parameters;

    internal sealed class CommentItemRequest : AGetRequest<ITraktCommentItem>, IHasId, ISupportsExtendedInfo
    {
        public string Id { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public RequestObjectType RequestObjectType => RequestObjectType.Comments;

        public override string UriTemplate => "comments/{id}/item{?extended}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object> { ["id"] = Id };

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            return uriParams;
        }

        public override void Validate()
        {
            if (Id == null)
                throw new TraktRequestValidationException(nameof(Id), "comment id must not be null");

            if (Id == string.Empty || Id.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Id), "comment id not valid");
        }
    }
}
