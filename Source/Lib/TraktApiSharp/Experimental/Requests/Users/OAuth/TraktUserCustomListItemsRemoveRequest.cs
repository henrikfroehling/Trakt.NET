namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Post.Users.CustomListItems;
    using Objects.Post.Users.CustomListItems.Responses;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserCustomListItemsRemoveRequest : ATraktUsersPostByIdRequest<TraktUserCustomListItemsRemovePostResponse, TraktUserCustomListItemsPost>
    {
        internal TraktUserCustomListItemsRemoveRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Lists;

        public override string UriTemplate => "users/{username}/lists/{id}/items/remove";
    }
}
