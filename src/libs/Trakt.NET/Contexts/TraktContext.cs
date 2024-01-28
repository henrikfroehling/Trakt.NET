namespace TraktNET
{
    public class TraktContext : ITraktContext
    {
        public string ID { get;  }

        public string ClientID { get; set; }
        
        public string ClientSecret { get; set; }

        public Uri BaseUri { get; internal set; }

        public Uri BaseAuthorizationUri { get; internal set; }

        public TraktContext(string contextID, string clientID, string clientSecret)
        {
            ArgumentValidator.ThrowIfNullOrWhiteSpace(contextID, "invalid context id");
            ArgumentValidator.ThrowIfNullOrWhiteSpace(clientID, "invalid client id", true);
            ArgumentValidator.ThrowIfNullOrWhiteSpace(clientSecret, "invalid client secret", true);

            ID = contextID;
            ClientID = clientID;
            ClientSecret = clientSecret;
            BaseUri = new Uri(Constants.API.BaseURL);
            BaseAuthorizationUri = new Uri(Constants.API.BaseAuthorizationURL);
        }

        public TraktContext(string clientID, string clientSecret)
            : this(Guid.NewGuid().ToString(), clientID, clientSecret)
        {
        }
    }
}
