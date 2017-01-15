namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Post.Bodyless;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserListLikeRequest : ATraktNoContentBodylessPostByIdRequest
    {
        internal TraktUserListLikeRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            return base.GetUriPathParameters();
        }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Lists;

        public override string UriTemplate => "users/{username}/lists/{id}/like";
    }
}
