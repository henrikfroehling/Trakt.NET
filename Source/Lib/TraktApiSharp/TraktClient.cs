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
    /// <para>
    /// Provides the only access to all of the library's modules.
    /// You can instantiate multiple clients.
    /// </para>
    /// </summary>
    public class TraktClient
    {
        private TraktConfiguration _configuration;
        private TraktAuthentication _authentication;
        private TraktOAuth _oauth;
        private TraktDeviceAuth _deviceAuth;
        private TraktShowsModule _shows;
        private TraktSeasonsModule _seasons;
        private TraktEpisodesModule _episodes;
        private TraktMoviesModule _movies;
        private TraktCalendarModule _calendar;
        private TraktCommentsModule _comments;
        private TraktPeopleModule _people;
        private TraktGenresModule _genres;
        private TraktSearchModule _search;
        private TraktRecommendationsModule _recommendations;
        private TraktSyncModule _sync;
        private TraktUsersModule _users;
        private TraktCheckinsModule _checkins;
        private TraktScrobbleModule _scrobble;

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

        /// <summary>Gets or sets the Trakt Access Token. See also <seealso cref="TraktAuthentication.AccessToken" />.</summary>
        public string AccessToken
        {
            get { return Authentication.AccessToken.AccessToken; }
            set
            {
                Authentication.AccessToken = new TraktAccessToken
                {
                    AccessToken = value,
                    IgnoreExpiration = true
                };
            }
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
        /// See <seealso cref="AccessToken" />.
        /// See <seealso cref="TraktAuthentication.AccessToken" />.
        /// </summary>
        public bool IsValidForUseWithAuthorization => IsValidForUseWithoutAuthorization && Authentication.AccessToken.IsValid;

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
        public TraktConfiguration Configuration
        {
            get { return _configuration = _configuration ?? new TraktConfiguration(); }
            private set { _configuration = value; }
        }

        /// <summary>Provides access to the authentication module. See <seealso cref="TraktAuthentication" />.</summary>
        public TraktAuthentication Authentication
        {
            get { return _authentication = _authentication ?? new TraktAuthentication(this); }
            private set { _authentication = value; }
        }

        /// <summary>Provides access to the OAuth authentication module. See <seealso cref="TraktOAuth" />.</summary>
        public TraktOAuth OAuth
        {
            get { return _oauth = _oauth ?? new TraktOAuth(this); }
            private set { _oauth = value; }
        }

        /// <summary>Provides accesss to the Device authentication module. See <seealso cref="TraktDeviceAuth" />.</summary>
        public TraktDeviceAuth DeviceAuth
        {
            get { return _deviceAuth = _deviceAuth ?? new TraktDeviceAuth(this); }
            private set { _deviceAuth = value; }
        }

        /// <summary>Provides access to the shows module. See <seealso cref="TraktShowsModule" />.</summary>
        public TraktShowsModule Shows
        {
            get { return _shows = _shows ?? new TraktShowsModule(this); }
            private set { _shows = value; }
        }

        /// <summary>Provides access to the seasons module. See <seealso cref="TraktSeasonsModule" />.</summary>
        public TraktSeasonsModule Seasons
        {
            get { return _seasons = _seasons ?? new TraktSeasonsModule(this); }
            private set { _seasons = value; }
        }

        /// <summary>Provides access to the episodes module. See <seealso cref="TraktEpisodesModule" />.</summary>
        public TraktEpisodesModule Episodes
        {
            get { return _episodes = _episodes ?? new TraktEpisodesModule(this); }
            private set { _episodes = value; }
        }

        /// <summary>Provides access to the movies module. See <seealso cref="TraktMoviesModule" />.</summary>
        public TraktMoviesModule Movies
        {
            get { return _movies = _movies ?? new TraktMoviesModule(this); }
            private set { _movies = value; }
        }

        /// <summary>Provides access to the calendar module. See <seealso cref="TraktCalendarModule" />.</summary>
        public TraktCalendarModule Calendar
        {
            get { return _calendar = _calendar ?? new TraktCalendarModule(this); }
            private set { _calendar = value; }
        }

        /// <summary>Provides access to the commends module. See <seealso cref="TraktCommentsModule" />.</summary>
        public TraktCommentsModule Comments
        {
            get { return _comments = _comments ?? new TraktCommentsModule(this); }
            private set { _comments = value; }
        }

        /// <summary>Provides access to the people module. See <seealso cref="TraktPeopleModule" />.</summary>
        public TraktPeopleModule People
        {
            get { return _people = _people ?? new TraktPeopleModule(this); }
            private set { _people = value; }
        }

        /// <summary>Provides access to the genres module. See <seealso cref="TraktGenresModule" />.</summary>
        public TraktGenresModule Genres
        {
            get { return _genres = _genres ?? new TraktGenresModule(this); }
            private set { _genres = value; }
        }

        /// <summary>Provides access to the search module. See <seealso cref="TraktSearchModule" />.</summary>
        public TraktSearchModule Search
        {
            get { return _search = _search ?? new TraktSearchModule(this); }
            private set { _search = value; }
        }

        /// <summary>Provides access to the recommendations module. See <seealso cref="TraktRecommendationsModule" />.</summary>
        public TraktRecommendationsModule Recommendations
        {
            get { return _recommendations = _recommendations ?? new TraktRecommendationsModule(this); }
            private set { _recommendations = value; }
        }

        /// <summary>Provides access to the sync module. See <seealso cref="TraktSyncModule" />.</summary>
        public TraktSyncModule Sync
        {
            get { return _sync = _sync ?? new TraktSyncModule(this); }
            private set { _sync = value; }
        }

        /// <summary>Provides access to the users module. See <seealso cref="TraktUsersModule" />.</summary>
        public TraktUsersModule Users
        {
            get { return _users = _users ?? new TraktUsersModule(this); }
            private set { _users = value; }
        }

        /// <summary>Provides access to the checkins module. See <seealso cref="TraktCheckinsModule" />.</summary>
        public TraktCheckinsModule Checkins
        {
            get { return _checkins = _checkins ?? new TraktCheckinsModule(this); }
            private set { _checkins = value; }
        }

        /// <summary>Provides access to the scrobble module. See <seealso cref="TraktScrobbleModule" />.</summary>
        public TraktScrobbleModule Scrobble
        {
            get { return _scrobble = _scrobble ?? new TraktScrobbleModule(this); }
            private set { _scrobble = value; }
        }
    }
}
