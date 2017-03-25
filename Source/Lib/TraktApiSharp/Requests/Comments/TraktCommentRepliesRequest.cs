namespace TraktApiSharp.Requests.Comments
{
    using Base;
    using Extensions;
    using Interfaces;
    using Objects.Basic;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Objects.Basic.Implementations;

    internal sealed class TraktCommentRepliesRequest : ATraktGetRequest<TraktComment>, ITraktHasId, ITraktSupportsPagination
    {
        public string Id { get; set; }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Comments;

        public int? Page { get; set; }

        public int? Limit { get; set; }

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
                throw new ArgumentNullException(nameof(Id));

            if (Id == string.Empty || Id.ContainsSpace())
                throw new ArgumentException("comment id not valid", nameof(Id));
        }
    }
}
