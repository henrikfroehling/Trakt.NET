namespace TraktApiSharp.Experimental.Requests.Users
{
    using Base;
    using Enums;
    using Extensions;
    using Interfaces;
    using Objects.Basic;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserListCommentsRequest : ATraktGetRequest<TraktComment>, ITraktHasId, ITraktSupportsPagination
    {
        internal string Username { get; set; }

        public string Id { get; set; }

        internal TraktCommentSortOrder SortOrder { get; set; }

        public int? Page { get; set; }

        public int? Limit { get; set; }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Lists;

        public override string UriTemplate => "users/{username}/lists/{id}/comments{/sort_order}{?page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>
            {
                ["username"] = Username,
                ["id"] = Id
            };

            if (SortOrder != null && SortOrder != TraktCommentSortOrder.Unspecified)
                uriParams.Add("sort_order", SortOrder.UriName);

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }

        public override void Validate()
        {
            if (Username == null)
                throw new ArgumentNullException(nameof(Username));

            if (Username == string.Empty || Username.ContainsSpace())
                throw new ArgumentException("username not valid", nameof(Id));

            if (Id == null)
                throw new ArgumentNullException(nameof(Id));

            if (Id == string.Empty || Id.ContainsSpace())
                throw new ArgumentException("list id not valid", nameof(Id));
        }
    }
}
