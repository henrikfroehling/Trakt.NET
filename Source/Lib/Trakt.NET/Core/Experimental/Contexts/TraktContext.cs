namespace TraktNet.Core.Experimental.Contexts
{
    using System;

    public class TraktContext : ATraktContext
    {
        public TraktContext(string clientId, string clientSecret = "")
        {
            UniqueContextId = Guid.NewGuid().ToString();
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public override string UniqueContextId { get; }

        public override string ClientId { get; set; }

        public override string ClientSecret { get; set; }
    }
}
