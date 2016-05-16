namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Put;
    using Objects.Post.Users;
    using Objects.Post.Users.Responses;
    using System.Collections.Generic;

    internal class TraktUserCustomListUpdateRequest : TraktPutByIdRequest<TraktUserCustomListUpdatePostResponse, TraktUserCustomListUpdatePostResponse, TraktUserCustomListUpdatePost>
    {
        internal TraktUserCustomListUpdateRequest(TraktClient client) : base(client) { }

        internal string Username { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("username", Username);
            return uriParams;
        }

        protected override string UriTemplate => "users/{username}/lists/{id}";

        protected override void Validate()
        {
            base.Validate();
            RequestBody.Validate();
        }
    }
}
