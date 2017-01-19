namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Enums;
    using Objects.Post.Users.CustomListItems;
    using Objects.Post.Users.CustomListItems.Responses;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserCustomListItemsAddRequest : ATraktUsersPostByIdRequest<TraktUserCustomListItemsPostResponse, TraktUserCustomListItemsPost>
    {
        internal TraktUserCustomListItemsAddRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        internal TraktListItemType Type { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            uriParams.Add("username", Username);

            if (Type != null && Type != TraktListItemType.Unspecified)
                uriParams.Add("type", Type.UriName);

            return uriParams;
        }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Lists;

        public string UriTemplate => "users/{username}/lists/{id}/items{/type}";
    }
}
