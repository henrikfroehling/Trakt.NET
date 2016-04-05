namespace TraktApiSharp.Core
{
    using Enums;
    using System;

    public class TraktConfiguration
    {
        internal TraktConfiguration()
        {
            ApiVersion = 2;
            AuthenticationMode = TraktAuthenticationMode.Device;
        }

        public int ApiVersion { get; set; }

        public string BaseUrl => string.Format("https://api-v{0}launch.trakt.tv/", ApiVersion);
        public Uri BaseUri => new Uri(BaseUrl);

        public TraktAuthenticationMode AuthenticationMode { get; set; }
    }
}
