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

        public string BaseUrl => $"https://api-v{ApiVersion}launch.trakt.tv/";
        public Uri BaseUri => new Uri(BaseUrl);

        public TraktAuthenticationMode AuthenticationMode { get; set; }
    }
}
