namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Watched;
    using System.Collections.Generic;

    internal sealed class TraktUserWatchedShowsRequest : ATraktUsersListGetRequest<TraktWatchedShow>
    {
        internal TraktUserWatchedShowsRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("username", Username);
            return uriParams;
        }

        public override string UriTemplate => "users/{username}/watched/shows{?extended}";
    }
}
