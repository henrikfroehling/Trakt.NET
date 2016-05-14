namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Post;
    using System.Collections.Generic;

    internal class TraktUserListLikeRequest : TraktBodylessPostByIdRequest<object, object>
    {
        internal TraktUserListLikeRequest(TraktClient client) : base(client) { }

        internal string Username { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "id", Id },
                                                    { "username", Username } };
        }

        protected override string UriTemplate => "users/{username}/lists/{id}/like";
    }
}
