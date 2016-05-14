namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Delete;
    using System.Collections.Generic;

    internal class TraktUserCustomListDeleteRequest : TraktDeleteByIdRequest
    {
        internal TraktUserCustomListDeleteRequest(TraktClient client) : base(client) { }

        internal string Username { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "id", Id },
                                                    { "username", Username } };
        }

        protected override string UriTemplate => "users/{username}/lists/{id}";
    }
}
