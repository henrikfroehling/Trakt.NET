namespace TraktApiSharp.Core
{
    using System.Net.Http;

    /// <summary>Provides global client settings.</summary>
    public class TraktConfiguration
    {
        internal TraktConfiguration()
        {
            ApiVersion = 2;
            UseStagingUrl = false;
        }

        internal static HttpClient HTTP_CLIENT = null;

        /// <summary>
        /// Gets or sets the Trakt API version.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#introduction/api-url">"Trakt API Doc - API URL"</a> for more information.
        /// </para>
        /// </summary>
        public int ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets, whether the Trakt API staging environment should be used. By default disabled.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#introduction/api-url">"Trakt API Doc - API URL"</a> for more information.
        /// </para>
        /// </summary>
        public bool UseStagingUrl { get; set; }

        /// <summary>Returns the Trakt API base URL based on, whether <see cref="UseStagingUrl" /> is false or true.</summary>
        public string BaseUrl => UseStagingUrl ? "https://api-staging.trakt.tv/" : $"https://api-v{ApiVersion}launch.trakt.tv/";
    }
}
