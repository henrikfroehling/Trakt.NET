namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Put;
    using Objects.Post.Users;
    using Objects.Post.Users.Responses;
    using System.Collections.Generic;

    internal class TraktUserListUpdateRequest : TraktPutByIdRequest<TraktUserListUpdatePostResponse, TraktUserListUpdatePostResponse, TraktUserListUpdatePost>
    {
        internal TraktUserListUpdateRequest(TraktClient client) : base(client) { }

        internal string Username { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "id", Id },
                                                    { "username", Username } };
        }

        protected override string UriTemplate => "users/{username}/lists/{id}";

        protected override void Validate()
        {
            base.Validate();
            RequestBody.Validate();
        }
    }
}
