namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Interfaces;
    using Objects.Get.Users.Lists;
    using System;
    using System.Collections.Generic;

    internal sealed class UserListLikesRequest : AGetRequest<ITraktListLike>, ISupportsPagination
    {
        internal string Username { get; set; }

        public string ListId { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Optional;

        public override string UriTemplate => "users/{username}/lists/{list_id}/likes{?page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>
            {
                { "username", Username },
                { "list_id", ListId }
            };

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Username))
                throw new ArgumentException("username not valid", nameof(Username));

            if (string.IsNullOrWhiteSpace(ListId))
                throw new ArgumentException("list id not valid", nameof(ListId));
        }
    }
}
