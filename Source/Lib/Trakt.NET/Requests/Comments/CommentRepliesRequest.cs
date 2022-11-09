namespace TraktNet.Requests.Comments
{
    using Base;
    using Exceptions;
    using Extensions;
    using Interfaces;
    using Objects.Basic;
    using System.Collections.Generic;

    internal sealed class CommentRepliesRequest : AGetRequest<ITraktComment>, IHasId, ISupportsPagination
    {
        public string Id { get; set; }

        public RequestObjectType RequestObjectType => RequestObjectType.Comments;

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override string UriTemplate => "comments/{id}/replies{?page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>
            {
                ["id"] = Id
            };

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

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
