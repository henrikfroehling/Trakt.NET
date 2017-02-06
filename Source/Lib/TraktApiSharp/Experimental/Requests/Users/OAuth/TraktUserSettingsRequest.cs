namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Users;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserSettingsRequest //: ATraktUsersSingleItemGetRequest<TraktUserSettings>
    {
        internal TraktUserSettingsRequest(TraktClient client)  {}

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public string UriTemplate => "users/settings";
    }
}
