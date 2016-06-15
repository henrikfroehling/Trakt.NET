namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Users.Watched;
    using System.Collections.Generic;

    internal class TraktUserWatchedShowsRequest : TraktGetRequest<TraktListResult<TraktUserWatchedShowItem>, TraktUserWatchedShowItem>
    {
        internal TraktUserWatchedShowsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Optional;

        internal string Username { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("username", Username);
            return uriParams;
        }

        protected override string UriTemplate => "users/{username}/watched/shows{?extended}";

        protected override bool IsListResult => true;
    }
}
