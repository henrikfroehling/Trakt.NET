namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Post;
    using Objects.Post.Users;
    using Objects.Post.Users.Responses;
    using System.Collections.Generic;

    internal class TraktUserListAddRequest : TraktPostRequest<TraktUserListPostResponse, TraktUserListPostResponse, TraktUserListPost>
    {
        internal TraktUserListAddRequest(TraktClient client) : base(client) { }

        internal string Username { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "username", Username } };
        }

        protected override string UriTemplate => "users/{username}/lists";

        protected override void Validate()
        {
            base.Validate();
            RequestBody.Validate();
        }
    }
}
