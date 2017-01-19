namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Interfaces;
    using Objects.Get.Users;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktUserWatchingRequest : ATraktUsersSingleItemGetRequest<TraktUserWatchingItem>, ITraktSupportsExtendedInfo
    {
        internal TraktUserWatchingRequest(TraktClient client) : base(client) {}

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        internal string Username { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("username", Username);
            return uriParams;
        }

        public override string UriTemplate => "users/{username}/watching{?extended}";
    }
}
