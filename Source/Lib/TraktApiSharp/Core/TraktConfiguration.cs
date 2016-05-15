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
            UseStagingUrl = false;
        }

        public int ApiVersion { get; set; }

        public bool UseStagingUrl { get; set; }

        public string BaseUrl => UseStagingUrl ? "https://api-staging.trakt.tv/" : $"https://api-v{ApiVersion}launch.trakt.tv/";
        public Uri BaseUri => new Uri(BaseUrl);

        public TraktAuthenticationMode AuthenticationMode { get; set; }
    }
}
