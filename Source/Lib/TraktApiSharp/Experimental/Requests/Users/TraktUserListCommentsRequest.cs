namespace TraktApiSharp.Experimental.Requests.Users
{
    using Enums;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserListCommentsRequest
    {
        internal TraktUserListCommentsRequest(TraktClient client) {}

        internal string Username { get; set; }

        internal TraktCommentSortOrder SortOrder { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            uriParams.Add("username", Username);

            if (SortOrder != null && SortOrder != TraktCommentSortOrder.Unspecified)
                uriParams.Add("sort_order", SortOrder.UriName);

            return uriParams;
        }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Lists;

        public string UriTemplate => "users/{username}/lists/{id}/comments{/sort_order}{?page,limit}";
    }
}
