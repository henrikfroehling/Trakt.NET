namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Objects.Get.Watched;
    using System.Collections.Generic;

    internal class TraktUserWatchedMoviesRequest : TraktGetRequest<IEnumerable<TraktWatchedMovie>, TraktWatchedMovie>
    {
        internal TraktUserWatchedMoviesRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        internal string Username { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("username", Username);
            return uriParams;
        }

        protected override string UriTemplate => "users/{username}/watched/movies{?extended}";

        protected override bool IsListResult => true;
    }
}
