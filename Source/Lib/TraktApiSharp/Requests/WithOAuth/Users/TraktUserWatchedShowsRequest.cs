namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Objects.Get.Watched;
    using System.Collections.Generic;

    internal class TraktUserWatchedShowsRequest : TraktGetRequest<IEnumerable<TraktWatchedShow>, TraktWatchedShow>
    {
        internal TraktUserWatchedShowsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

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
