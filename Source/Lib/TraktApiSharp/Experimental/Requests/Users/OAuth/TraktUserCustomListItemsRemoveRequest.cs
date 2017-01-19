namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Post.Users.CustomListItems;
    using Objects.Post.Users.CustomListItems.Responses;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserCustomListItemsRemoveRequest : ATraktUsersPostByIdRequest<TraktUserCustomListItemsRemovePostResponse, TraktUserCustomListItemsPost>
    {
        internal TraktUserCustomListItemsRemoveRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();
            uriParams.Add("username", Username);
            return uriParams;
        }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Lists;

        public string UriTemplate => "users/{username}/lists/{id}/items/remove";
    }
}
