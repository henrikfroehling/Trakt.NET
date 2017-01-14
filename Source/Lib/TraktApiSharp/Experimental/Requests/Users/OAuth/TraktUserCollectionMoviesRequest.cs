namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Collection;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserCollectionMoviesRequest : ATraktUsersListGetRequest<TraktCollectionMovie>
    {
        internal TraktUserCollectionMoviesRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("username", Username);
            return uriParams;
        }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        public override string UriTemplate => "users/{username}/collection/movies{?extended}";
    }
}
