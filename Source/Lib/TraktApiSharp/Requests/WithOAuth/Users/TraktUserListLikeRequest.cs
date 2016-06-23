namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Post;
    using System.Collections.Generic;

    internal class TraktUserListLikeRequest : TraktBodylessPostByIdRequest<object, object>
    {
        internal TraktUserListLikeRequest(TraktClient client) : base(client) { }

        internal string Username { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("username", Username);
            return uriParams;
        }

        protected override string UriTemplate => "users/{username}/lists/{id}/like";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Lists;
    }
}
