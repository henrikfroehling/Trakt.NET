using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TraktApiSharp.Tests")]

namespace TraktApiSharp
{
    using Authentication;
    using Core;
    using Extensions;
    using Modules;

    /// <summary>
    /// Provides access to all functionality of this library.
    /// <para>Provides the only access to all of the library's modules.</para>
    /// </summary>
    public class TraktClient
    {
        internal TraktClient()
        {
            Configuration = new TraktConfiguration();
            Authentication = new TraktAuthentication(this);
            OAuth = new TraktOAuth(this);
            DeviceAuth = new TraktDeviceAuth(this);
            Shows = new TraktShowsModule(this);
            Seasons = new TraktSeasonsModule(this);
            Episodes = new TraktEpisodesModule(this);
            Movies = new TraktMoviesModule(this);
            Calendar = new TraktCalendarModule(this);
            Comments = new TraktCommentsModule(this);
            People = new TraktPeopleModule(this);
            Genres = new TraktGenresModule(this);
            Search = new TraktSearchModule(this);
            Recommendations = new TraktRecommendationsModule(this);
            Sync = new TraktSyncModule(this);
            Users = new TraktUsersModule(this);
            Checkins = new TraktCheckinsModule(this);
            Scrobble = new TraktScrobbleModule(this);
        }

        /// <summary>Initializes a new instance of the <see cref="TraktClient" /> class.</summary>
        /// <param name="clientId">The Trakt Client Id. See <seealso cref="ClientId" />.</param>
        public TraktClient(string clientId) : this()
        {
            ClientId = clientId;
        }

        /// <summary>Initializes a new instance of the <see cref="TraktClient" /> class.</summary>
        /// <param name="clientId">The Trakt Client Id. See <seealso cref="ClientId" />.</param>
        /// <param name="clientSecret">The Trakt Client Secret. See <seealso cref="ClientSecret" />.</param>
        public TraktClient(string clientId, string clientSecret) : this(clientId)
        {
            ClientSecret = clientSecret;
        }

        /// <summary>Gets or sets the Trakt Client Id. See also <seealso cref="ClientSecret" />.</summary>
        public string ClientId
        {
            get { return Authentication.ClientId; }
            set { Authentication.ClientId = value; }
        }

        /// <summary>Gets or sets the Trakt Client Secret. See also <seealso cref="ClientId" />.</summary>
        public string ClientSecret
        {
            get { return Authentication.ClientSecret; }
            set { Authentication.ClientSecret = value; }
        }
        
        /// <summary>Gets or sets the Trakt Authorization information. See also <seealso cref="TraktAuthorization" />.</summary>
        public TraktAuthorization Authorization
        {
            get { return Authentication.Authorization; }
            set { Authentication.Authorization = value; }
        }

        /// <summary>
        /// Returns, whether the client is valid to use for API requests, that do not require OAuth authorization.
        /// <para>To enable this behavior, you must set a valid Trakt Client Id.</para>
        /// See <seealso cref="ClientId" />.
        /// </summary>
        public bool IsValidForUseWithoutAuthorization => !string.IsNullOrEmpty(ClientId) && !ClientId.ContainsSpace();

        /// <summary>
        /// Returns, whether the client is valid to use for API requests, that require OAuth authorization.
        /// <para>To enable this behavior, you must set a valid Trakt Client Id and a valid Trakt Access Token.</para>
        /// See <seealso cref="ClientId" />.
        /// See <seealso cref="TraktAuthentication.IsAuthorized" />.
        /// </summary>
        public bool IsValidForUseWithAuthorization => IsValidForUseWithoutAuthorization && Authentication.IsAuthorized;

        /// <summary>
        /// Returns, whether the client is valid to use for OAuth authentication.
        /// <para>To enable this behavior, you must set a valid Trakt Client Id and a valid Trakt Client Secret.</para>
        /// See <seealso cref="ClientId" />.
        /// See <seealso cref="ClientSecret" />.
        /// </summary>
        public bool IsValidForAuthenticationProcess => IsValidForUseWithoutAuthorization && !string.IsNullOrEmpty(ClientSecret) && !ClientSecret.ContainsSpace();

        /// <summary>
        /// Provides access to the configuration settings for the <see cref="TraktClient" />.
        /// See <seealso cref="TraktConfiguration" />.
        /// </summary>
        public TraktConfiguration Configuration { get; }

        /// <summary>Provides access to the authentication module. See <seealso cref="TraktAuthentication" />.</summary>
        public TraktAuthentication Authentication { get; }

        /// <summary>Provides access to the OAuth authentication module. See <seealso cref="TraktOAuth" />.</summary>
        public TraktOAuth OAuth { get; }

        /// <summary>Provides accesss to the Device authentication module. See <seealso cref="TraktDeviceAuth" />.</summary>
        public TraktDeviceAuth DeviceAuth { get; }

        /// <summary>Provides access to the shows module. See <seealso cref="TraktShowsModule" />.</summary>
        public TraktShowsModule Shows { get; }

        /// <summary>Provides access to the seasons module. See <seealso cref="TraktSeasonsModule" />.</summary>
        public TraktSeasonsModule Seasons { get; }

        /// <summary>Provides access to the episodes module. See <seealso cref="TraktEpisodesModule" />.</summary>
        public TraktEpisodesModule Episodes { get; }

        /// <summary>Provides access to the movies module. See <seealso cref="TraktMoviesModule" />.</summary>
        public TraktMoviesModule Movies { get; }

        /// <summary>Provides access to the calendar module. See <seealso cref="TraktCalendarModule" />.</summary>
        public TraktCalendarModule Calendar { get; }

        /// <summary>Provides access to the commends module. See <seealso cref="TraktCommentsModule" />.</summary>
        public TraktCommentsModule Comments { get; }

        /// <summary>Provides access to the people module. See <seealso cref="TraktPeopleModule" />.</summary>
        public TraktPeopleModule People { get; }

        /// <summary>Provides access to the genres module. See <seealso cref="TraktGenresModule" />.</summary>
        public TraktGenresModule Genres { get; }

        /// <summary>Provides access to the search module. See <seealso cref="TraktSearchModule" />.</summary>
        public TraktSearchModule Search { get; }

        /// <summary>Provides access to the recommendations module. See <seealso cref="TraktRecommendationsModule" />.</summary>
        public TraktRecommendationsModule Recommendations { get; }

        /// <summary>Provides access to the sync module. See <seealso cref="TraktSyncModule" />.</summary>
        public TraktSyncModule Sync { get; }

        /// <summary>Provides access to the users module. See <seealso cref="TraktUsersModule" />.</summary>
        public TraktUsersModule Users { get; }

        /// <summary>Provides access to the checkins module. See <seealso cref="TraktCheckinsModule" />.</summary>
        public TraktCheckinsModule Checkins { get; }

        /// <summary>Provides access to the scrobble module. See <seealso cref="TraktScrobbleModule" />.</summary>
        public TraktScrobbleModule Scrobble { get; }
    }
}
