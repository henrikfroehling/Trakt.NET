namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal sealed class TraktUserFollowingRequest : ATraktUsersListGetRequest<TraktUserFollower>
    {
        internal TraktUserFollowingRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("username", Username);
            return uriParams;
        }
        
        public override string UriTemplate => "users/{username}/following{?extended}";
    }
}
