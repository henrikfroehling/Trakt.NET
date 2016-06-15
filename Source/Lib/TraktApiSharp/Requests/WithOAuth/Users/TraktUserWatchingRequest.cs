namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal class TraktUserWatchingRequest : TraktGetRequest<TraktUserWatchingItem, TraktUserWatchingItem>
    {
        internal TraktUserWatchingRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Optional;

        internal string Username { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("username", Username);
            return uriParams;
        }

        protected override string UriTemplate => "users/{username}/watching{?extended}";
    }
}
