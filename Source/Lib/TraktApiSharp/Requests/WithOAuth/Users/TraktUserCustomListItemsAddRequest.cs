namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Post;
    using Enums;
    using Objects.Post.Users.CustomListItems;
    using Objects.Post.Users.CustomListItems.Responses;
    using System.Collections.Generic;

    internal class TraktUserCustomListItemsAddRequest : TraktPostByIdRequest<TraktUserCustomListItemsPostResponse, TraktUserCustomListItemsPostResponse, TraktUserCustomListItemsPost>
    {
        internal TraktUserCustomListItemsAddRequest(TraktClient client) : base(client) { }

        internal string Username { get; set; }

        internal TraktListItemType Type { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("username", Username);

            if (Type != null && Type != TraktListItemType.Unspecified)
                uriParams.Add("type", Type.UriName);

            return uriParams;
        }

        protected override string UriTemplate => "users/{username}/lists/{id}/items{/type}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Lists;
    }
}
