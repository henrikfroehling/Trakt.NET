namespace TraktNet.Requests.Comments
{
    using Base;
    using Extensions;
    using Interfaces;
    using Objects.Basic;
    using Parameters;
    using System;
    using System.Collections.Generic;

    internal sealed class CommentLikesRequest : AGetRequest<ITraktCommentLike>, IHasId, ISupportsExtendedInfo, ISupportsPagination
    {
        public string Id { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public RequestObjectType RequestObjectType => RequestObjectType.Comments;

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override string UriTemplate => "comments/{id}/likes{?extended,page,limit}";

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
                throw new ArgumentNullException(nameof(Id));

            if (Id == string.Empty || Id.ContainsSpace())
                throw new ArgumentException("comment id not valid", nameof(Id));
        }
    }
}
