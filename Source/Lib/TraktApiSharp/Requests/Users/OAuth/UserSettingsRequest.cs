namespace TraktApiSharp.Requests.Users.OAuth
{
    using Base;
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal sealed class UserSettingsRequest : AGetRequest<ITraktUserSettings>
    {
        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Required;

        public override string UriTemplate => "users/settings";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();

        public override void Validate() { }
    }
}
