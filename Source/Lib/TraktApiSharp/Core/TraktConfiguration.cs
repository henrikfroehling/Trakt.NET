namespace TraktApiSharp.Core
{
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

        public string BaseUrl => UseStagingUrl ? "https://api-staging.trakt.tv/" : "https://api.trakt.tv/";
    }
}
