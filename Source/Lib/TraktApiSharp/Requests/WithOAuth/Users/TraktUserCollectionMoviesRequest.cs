namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Objects.Get.Collection;
    using System.Collections.Generic;

    internal class TraktUserCollectionMoviesRequest : TraktGetRequest<IEnumerable<TraktCollectionMovie>, TraktCollectionMovie>
    {
        internal TraktUserCollectionMoviesRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        internal string Username { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("username", Username);
            return uriParams;
        }

        protected override string UriTemplate => "users/{username}/collection/movies{?extended}";

        protected override bool IsListResult => true;
    }
}
