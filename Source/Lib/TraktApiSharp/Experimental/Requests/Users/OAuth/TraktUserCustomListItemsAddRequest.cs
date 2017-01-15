namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Post.Users.CustomListItems;
    using Objects.Post.Users.CustomListItems.Responses;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserCustomListItemsAddRequest : ATraktUsersPostByIdRequest<TraktUserCustomListItemsPostResponse, TraktUserCustomListItemsPost>
    {
        internal TraktUserCustomListItemsAddRequest(TraktClient client) : base(client) {}

        public override TraktRequestObjectType RequestObjectType => throw new NotImplementedException();

        public override string UriTemplate => throw new NotImplementedException();
    }
}
