﻿namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Enums;
    using Extensions;
    using Interfaces;
    using Objects.Basic;
    using System;
    using System.Collections.Generic;

    internal sealed class UserListCommentsRequest : AGetRequest<ITraktComment>, IHasId, ISupportsPagination
    {
        internal string Username { get; set; }

        public string Id { get; set; }

        internal TraktCommentSortOrder SortOrder { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Optional;

        public RequestObjectType RequestObjectType => RequestObjectType.Lists;

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
                throw new ArgumentException("username not valid", nameof(Username));

            if (Id == null)
                throw new ArgumentNullException(nameof(Id));

            if (Id == string.Empty || Id.ContainsSpace())
                throw new ArgumentException("list id not valid", nameof(Id));
        }
    }
}
