namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Objects.Get.Users;

    internal class TraktUserSettingsRequest : TraktGetRequest<TraktUserSettings, TraktUserSettings>
    {
        internal TraktUserSettingsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

        protected override string UriTemplate => "users/settings";
    }
}
