namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Enums;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserLikesRequest
    {
        internal TraktUserLikesRequest(TraktClient client) {}

        internal TraktUserLikeType Type { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (Type != null && Type != TraktUserLikeType.Unspecified)
                uriParams.Add("type", Type.UriName);

            return uriParams;
        }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public string UriTemplate => "users/likes{/type}{?page,limit}";
    }
}
