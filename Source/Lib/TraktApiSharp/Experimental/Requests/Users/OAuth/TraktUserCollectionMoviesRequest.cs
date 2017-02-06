namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Collection;
    using System.Collections.Generic;

    internal sealed class TraktUserCollectionMoviesRequest// : ATraktUsersListGetRequest<TraktCollectionMovie>
    {
        internal TraktUserCollectionMoviesRequest(TraktClient client)  {}

        internal string Username { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();
            uriParams.Add("username", Username);
            return uriParams;
        }
        
        public string UriTemplate => "users/{username}/collection/movies{?extended}";
    }
}
