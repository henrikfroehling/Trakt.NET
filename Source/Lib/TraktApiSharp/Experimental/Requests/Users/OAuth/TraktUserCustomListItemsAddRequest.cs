namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Enums;
    using Objects.Post.Users.CustomListItems;
    using Objects.Post.Users.CustomListItems.Responses;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserCustomListItemsAddRequest : ATraktUsersPostByIdRequest<TraktUserCustomListItemsPostResponse, TraktUserCustomListItemsPost>
    {
        internal TraktUserCustomListItemsAddRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        internal TraktListItemType Type { get; set; }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Lists;

        public override string UriTemplate => "users/{username}/lists/{id}/items{/type}";
    }
}
