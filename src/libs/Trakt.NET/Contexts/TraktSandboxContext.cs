namespace TraktNET
{
    public class TraktSandboxContext : TraktContext, ITraktSandboxContext
    {
        public TraktSandboxContext(string contextID, string clientID, string clientSecret)
            : base(contextID, clientID, clientSecret)
            => SetupBaseUris();

        public TraktSandboxContext(string clientID, string clientSecret)
            : base(clientID, clientSecret)
            => SetupBaseUris();

        private void SetupBaseUris()
        {
            BaseUri = new Uri(Constants.API.StagingBaseURL);
            BaseAuthorizationUri = new Uri(Constants.API.StagingBaseAuthorizationURL);
        }
    }
}
