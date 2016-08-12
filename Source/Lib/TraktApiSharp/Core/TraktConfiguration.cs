namespace TraktApiSharp.Core
{
    using System.Net.Http;

    /// <summary>Provides global client settings.</summary>
    public class TraktConfiguration
    {
        internal static HttpClient HTTP_CLIENT = null;

        /// <summary>
        /// Gets or sets the Trakt API version.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#introduction/required-headers">"Trakt API Doc - Required Headers"</a> for more information.
        /// </para>
        /// </summary>
        public int ApiVersion { get; set; } = 2;

        /// <summary>
        /// Gets or sets, whether the Trakt API staging environment should be used. This is disabled by default.
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#introduction/api-url">"Trakt API Doc - API URL"</a> for more information.
        /// </para>
        /// </summary>
        public bool UseStagingUrl { get; set; } = false;

        /// <summary>Returns the Trakt API base URL based on, whether <see cref="UseStagingUrl" /> is false or true.</summary>
        public string BaseUrl => UseStagingUrl ? TraktConstants.API_STAGING_URL : TraktConstants.API_URL;

        /// <summary>Gets or sets, whether authorization should be enforced, even if it is optional. This is disabled by default.</summary>
        public bool ForceAuthorization { get; set; } = false;
    }
}
