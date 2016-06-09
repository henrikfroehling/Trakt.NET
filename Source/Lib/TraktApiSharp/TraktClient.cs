using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TraktApiSharp.Tests")]

namespace TraktApiSharp
{
    using Authentication;
    using Core;
    using Modules;

    /// <summary>
    /// A Trakt client, which provides access to all functionality of this library.
    /// </summary>
    /// <remarks>
    /// The client provides the only access to all of its library modules.
    /// You can instantiate multiple clients.
    /// </remarks>
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
        }

        /// <summary>
        /// Instantiates a new TraktClient and initializes all of its modules.
        /// </summary>
        /// <param name="clientId">The Trakt client id. <seealso cref="ClientId" /></param>
        public TraktClient(string clientId) : this()
        {
            ClientId = clientId;
        }

        /// <summary>
        /// Instantiates a new TraktClient and initializes all of its modules.
        /// </summary>
        /// <param name="clientId">The Trakt client id. <seealso cref="ClientId" /></param>
        /// <param name="clientSecret">The Trakt client secret. <seealso cref="ClientSecret" /></param>
        public TraktClient(string clientId, string clientSecret) : this(clientId)
        {
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Gets or sets the Trakt client id. <seealso cref="ClientSecret" />
        /// </summary>
        public string ClientId
        {
            get { return Authentication.ClientId; }
            set { Authentication.ClientId = value; }
        }

        /// <summary>
        /// Gets or sets the Trakt client secret. <seealso cref="ClientId" />
        /// </summary>
        public string ClientSecret
        {
            get { return Authentication.ClientSecret; }
            set { Authentication.ClientSecret = value; }
        }

        /// <summary>
        /// Returns, whether the client is valid to use for API requests, that do not require OAuth authentication.
        /// </summary>
        /// <remarks>
        /// To enable this behavior, you must set a valid Trakt client id.
        /// </remarks>
        /// <seealso cref="ClientId" />
        public bool IsValidForUseWithoutAuthorization => !string.IsNullOrEmpty(ClientId);

        /// <summary>
        /// Returns, whether the client is valid to use for API requests, that require OAuth authentication.
        /// </summary>
        /// <remarks>
        /// To enable this behavior, you must set a valid Trakt client id and a valid Trakt client secret.
        /// </remarks>
        /// <seealso cref="ClientId" /> <seealso cref="ClientSecret" />
        public bool IsValid => !string.IsNullOrEmpty(ClientId) && !string.IsNullOrEmpty(ClientSecret);

        /// <summary>
        /// Provides access to the configuration settings for the <see cref="TraktClient" />.
        /// <seealso cref="TraktConfiguration" />
        /// </summary>
        public TraktConfiguration Configuration
        {
            get { return _configuration = _configuration ?? new TraktConfiguration(); }
            private set { _configuration = value; }
        }

        /// <summary>
        /// Provides access to the authentication module.
        /// <seealso cref="TraktAuthentication" />
        /// </summary>
        public TraktAuthentication Authentication
        {
            get { return _authentication = _authentication ?? new TraktAuthentication(this); }
            private set { _authentication = value; }
        }

        /// <summary>
        /// Provides access to the OAuth authentication module.
        /// <seealso cref="TraktOAuth" />
        /// </summary>
        public TraktOAuth OAuth
        {
            get { return _oauth = _oauth ?? new TraktOAuth(this); }
            private set { _oauth = value; }
        }

        /// <summary>
        /// Provides accesss to the Device authentication module.
        /// <seealso cref="TraktDeviceAuth" />
        /// </summary>
        public TraktDeviceAuth DeviceAuth
        {
            get { return _deviceAuth = _deviceAuth ?? new TraktDeviceAuth(this); }
            private set { _deviceAuth = value; }
        }

        /// <summary>
        /// Provides access to the shows module.
        /// <seealso cref="TraktShowsModule" />
        /// </summary>
        public TraktShowsModule Shows
        {
            get { return _shows = _shows ?? new TraktShowsModule(this); }
            private set { _shows = value; }
        }

        /// <summary>
        /// Provides access to the seasons module.
        /// <seealso cref="TraktSeasonsModule" />
        /// </summary>
        public TraktSeasonsModule Seasons
        {
            get { return _seasons = _seasons ?? new TraktSeasonsModule(this); }
            private set { _seasons = value; }
        }

        /// <summary>
        /// Provides access to the episodes module.
        /// <seealso cref="TraktEpisodesModule" />
        /// </summary>
        public TraktEpisodesModule Episodes
        {
            get { return _episodes = _episodes ?? new TraktEpisodesModule(this); }
            private set { _episodes = value; }
        }

        /// <summary>
        /// Provides access to the movies module.
        /// <seealso cref="TraktMoviesModule" />
        /// </summary>
        public TraktMoviesModule Movies
        {
            get { return _movies = _movies ?? new TraktMoviesModule(this); }
            private set { _movies = value; }
        }

        /// <summary>
        /// Provides access to the calendar module.
        /// <seealso cref="TraktCalendarModule" />
        /// </summary>
        public TraktCalendarModule Calendar
        {
            get { return _calendar = _calendar ?? new TraktCalendarModule(this); }
            private set { _calendar = value; }
        }

        /// <summary>
        /// Provides access to the commends module.
        /// <seealso cref="TraktCommentsModule" />
        /// </summary>
        public TraktCommentsModule Comments
        {
            get { return _comments = _comments ?? new TraktCommentsModule(this); }
            private set { _comments = value; }
        }

        /// <summary>
        /// Provides access to the people module.
        /// <seealso cref="TraktPeopleModule" />
        /// </summary>
        public TraktPeopleModule People
        {
            get { return _people = _people ?? new TraktPeopleModule(this); }
            private set { _people = value; }
        }

        /// <summary>
        /// Provides access to the genres module.
        /// <seealso cref="TraktGenresModule" />
        /// </summary>
        public TraktGenresModule Genres
        {
            get { return _genres = _genres ?? new TraktGenresModule(this); }
            private set { _genres = value; }
        }

        /// <summary>
        /// Provides access to the search module.
        /// <seealso cref="TraktSearchModule" />
        /// </summary>
        public TraktSearchModule Search
        {
            get { return _search = _search ?? new TraktSearchModule(this); }
            private set { _search = value; }
        }

        /// <summary>
        /// Provides access to the recommendations module.
        /// <seealso cref="TraktRecommendationsModule" />
        /// </summary>
        public TraktRecommendationsModule Recommendations
        {
            get { return _recommendations = _recommendations ?? new TraktRecommendationsModule(this); }
            private set { _recommendations = value; }
        }

        /// <summary>
        /// Provides access to the sync module.
        /// <seealso cref="TraktSyncModule" />
        /// </summary>
        public TraktSyncModule Sync
        {
            get { return _sync = _sync ?? new TraktSyncModule(this); }
            private set { _sync = value; }
        }

        /// <summary>
        /// Provides access to the users module.
        /// <seealso cref="TraktUsersModule" />
        /// </summary>
        public TraktUsersModule Users
        {
            get { return _users = _users ?? new TraktUsersModule(this); }
            private set { _users = value; }
        }

        /// <summary>
        /// Provides access to the checkins module.
        /// <seealso cref="TraktCheckinsModule" />
        /// </summary>
        public TraktCheckinsModule Checkins
        {
            get { return _checkins = _checkins ?? new TraktCheckinsModule(this); }
            private set { _checkins = value; }
        }

        /// <summary>
        /// Provides access to the scrobble module.
        /// <seealso cref="TraktScrobbleModule" />
        /// </summary>
        public TraktScrobbleModule Scrobble
        {
            get { return _scrobble = _scrobble ?? new TraktScrobbleModule(this); }
            private set { _scrobble = value; }
        }
    }
}
