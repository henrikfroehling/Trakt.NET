namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Post;
    using Enums;
    using Objects.Post.Users.ListItems;
    using Objects.Post.Users.ListItems.Responses;
    using System.Collections.Generic;

    internal class TraktUserListItemsAddRequest : TraktPostByIdRequest<TraktUserListItemsPostResponse, TraktUserListItemsPostResponse, TraktUserListItemsPost>
    {
        internal TraktUserListItemsAddRequest(TraktClient client) : base(client) { }

        internal string Username { get; set; }

        internal TraktListItemType? Type { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "id", Id },
                                                    { "username", Username },
                                                    { "type", Type.HasValue ? Type.Value.AsStringUriParameter() : string.Empty } };
        }

        protected override string UriTemplate => "users/{username}/lists/{id}/items/{type}";

        protected override void Validate()
        {
            base.Validate();
            RequestBody.Validate();
        }
    }
}
