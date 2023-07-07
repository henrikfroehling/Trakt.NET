namespace TraktNet.Requests.Comments
{
    using Base;
    using Exceptions;
    using Extensions;
    using Interfaces;
    using Objects.Basic;
    using Parameters;
    using System.Collections.Generic;

    internal sealed class CommentRepliesRequest : AGetRequest<ITraktComment>, IHasId, ISupportsPagination
    {
        public string Id { get; set; }

        public RequestObjectType RequestObjectType => RequestObjectType.Comments;

        internal TraktExtendedInfo ExtendedInfo { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override string UriTemplate => "comments/{id}/replies{?extended,page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>
            {
                ["id"] = Id
            };

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

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
