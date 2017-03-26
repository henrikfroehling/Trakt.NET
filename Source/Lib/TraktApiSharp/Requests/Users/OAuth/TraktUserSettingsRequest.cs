namespace TraktApiSharp.Requests.Users.OAuth
{
    using Base;
    using Objects.Get.Users;
    using System.Collections.Generic;
    using TraktApiSharp.Objects.Get.Users.Implementations;

    internal sealed class TraktUserSettingsRequest : ATraktGetRequest<TraktUserSettings>
    {
        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override string UriTemplate => "users/settings";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();

        public override void Validate() { }
    }
}
