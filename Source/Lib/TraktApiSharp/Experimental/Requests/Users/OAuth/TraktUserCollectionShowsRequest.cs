namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Collection;
    using System.Collections.Generic;

    internal sealed class TraktUserCollectionShowsRequest : ATraktUsersListGetRequest<TraktCollectionShow>
    {
        internal TraktUserCollectionShowsRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("username", Username);
            return uriParams;
        }
        
        public override string UriTemplate => "users/{username}/collection/shows{?extended}";
    }
}
