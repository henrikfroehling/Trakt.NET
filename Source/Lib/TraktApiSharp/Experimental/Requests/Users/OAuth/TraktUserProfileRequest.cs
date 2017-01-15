namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Interfaces;
    using Objects.Get.Users;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktUserProfileRequest : ATraktUsersSingleItemGetRequest<TraktUser>, ITraktExtendedInfo
    {
        internal TraktUserProfileRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("username", Username);
            return uriParams;
        }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        public override string UriTemplate => "users/{username}{?extended}";
    }
}
