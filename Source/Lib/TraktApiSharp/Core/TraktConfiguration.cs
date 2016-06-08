namespace TraktApiSharp.Core
{
    using System;
    using System.Net.Http;

    public class TraktConfiguration
    {
        internal TraktConfiguration()
        {
            ApiVersion = 2;
            UseStagingUrl = false;
        }

        internal static HttpClient HTTP_CLIENT = null;

        public int ApiVersion { get; set; }

        public bool UseStagingUrl { get; set; }

        public string BaseUrl => UseStagingUrl ? "https://api-staging.trakt.tv/" : $"https://api-v{ApiVersion}launch.trakt.tv/";
        public Uri BaseUri => new Uri(BaseUrl);
    }
}
