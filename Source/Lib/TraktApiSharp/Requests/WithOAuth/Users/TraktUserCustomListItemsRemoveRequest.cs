namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Post;
    using Objects.Post.Users.ListItems;
    using Objects.Post.Users.ListItems.Responses;
    using System.Collections.Generic;

    internal class TraktUserCustomListItemsRemoveRequest : TraktPostByIdRequest<TraktUserListItemsRemovePostResponse, TraktUserListItemsRemovePostResponse, TraktUserListItemsRemovePost>
    {
        internal TraktUserCustomListItemsRemoveRequest(TraktClient client) : base(client) { }

        internal string Username { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "id", Id },
                                                    { "username", Username } };
        }

        protected override string UriTemplate => "users/{username}/lists/{id}/items/remove";

        protected override void Validate()
        {
            base.Validate();
            RequestBody.Validate();
        }
    }
}
