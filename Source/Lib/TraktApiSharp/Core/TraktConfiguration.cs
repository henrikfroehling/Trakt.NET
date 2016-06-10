namespace TraktApiSharp.Core
{
    using System;
    using System.Net.Http;

    /// <summary>
    /// Provides configuration options for the <see cref="TraktClient" />.
    /// <para>Access it by calling <see cref="TraktClient.Configuration" />.</para>
    /// </summary>
    public class TraktConfiguration
    {
        internal TraktConfiguration()
        {
            ApiVersion = 2;
            UseStagingApi = false;
        }

        internal static HttpClient HTTP_CLIENT = null;

        /// <summary>Gets or sets the Trakt API version.</summary>
        public int ApiVersion { get; set; }

        /// <summary>Gets or sets, whether the Trakt Staging API should be used.</summary>
        public bool UseStagingApi { get; set; }

        /// <summary>Gets the Trakt base URL as <see cref="string" />. See also <seealso cref="UseStagingApi" />.</summary>
        public string BaseUrl => UseStagingApi ? "https://api-staging.trakt.tv/" : $"https://api-v{ApiVersion}launch.trakt.tv/";

        /// <summary>Gets the Trakt base URL as <see cref="Uri" />. See also <seealso cref="UseStagingApi" />.</summary>
        public Uri BaseUri => new Uri(BaseUrl);
    }
}
