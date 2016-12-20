namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserListUnlikeRequest : ATraktUsersDeleteByIdRequest
    {
        internal TraktUserListUnlikeRequest(TraktClient client) : base(client) { }

        internal string Username { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("username", Username);
            return uriParams;
        }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Lists;

        public override string UriTemplate => "users/{username}/lists/{id}/like";
    }
}
