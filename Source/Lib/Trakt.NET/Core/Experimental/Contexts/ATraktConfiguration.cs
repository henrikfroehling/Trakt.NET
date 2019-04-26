namespace TraktNet.Core.Experimental.Contexts
{
    using Interfaces;

    public abstract class ATraktConfiguration : ITraktConfiguration
    {
        public abstract int ApiVersion { get; set; }

        public abstract bool UseSandboxEnvironment { get; set; }

        public abstract bool ForceAuthorization { get; set; }

        public abstract bool ThrowResponseExceptions { get; set; }

        public string BaseUrl => UseSandboxEnvironment ? Constants.API_STAGING_URL : Constants.API_URL;

        public string BaseOAuthAuthorizationUrl => UseSandboxEnvironment
            ? Constants.OAuthBaseAuthorizeStagingUrl : Constants.OAuthBaseAuthorizeUrl;
    }
}
