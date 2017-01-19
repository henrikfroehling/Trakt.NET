namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserCustomListDeleteRequest
    {
        internal TraktUserCustomListDeleteRequest(TraktClient client) { }

        internal string Username { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();
            uriParams.Add("username", Username);
            return uriParams;
        }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Lists;

        public string UriTemplate => "users/{username}/lists/{id}";
    }
}
