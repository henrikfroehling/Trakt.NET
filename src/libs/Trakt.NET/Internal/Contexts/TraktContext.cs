namespace TraktNET
{
    public abstract class TraktContext : ITraktContext
    {
        private string _clientID = string.Empty;
        private string _clientSecret = string.Empty;

        public string ID { get; }

        public Uri BaseUri { get; internal set; }

        public TraktAuthorization? Authorization { get; set; }

        public bool IgnoreOAuthIfOptional { get; set; }

        /// <summary>Provides access to the authentication module. See <seealso cref="TraktAuthModule" />.</summary>
        public TraktAuthModule Auth { get; }

        /// <summary>Provides access to the calendar module. See <seealso cref="TraktCalendarModule" />.</summary>
        public TraktCalendarModule Calendar { get; }

        /// <summary>Provides access to the certifications module. See <seealso cref="TraktCertificationsModule" />.</summary>
        public TraktCertificationsModule Certifications { get; }

        /// <summary>Provides access to the checkins module. See <seealso cref="TraktCheckinsModule" />.</summary>
        public TraktCheckinsModule Checkins { get; }

        /// <summary>Provides access to the commends module. See <seealso cref="TraktCommentsModule" />.</summary>
        public TraktCommentsModule Comments { get; }

        /// <summary>Provides access to the countries module. See <seealso cref="TraktCountriesModule" />.</summary>
        public TraktCountriesModule Countries { get; }

        /// <summary>Provides access to the episodes module. See <seealso cref="TraktEpisodesModule" />.</summary>
        public TraktEpisodesModule Episodes { get; }

        /// <summary>Provides access to the genres module. See <seealso cref="TraktGenresModule" />.</summary>
        public TraktGenresModule Genres { get; }

        /// <summary>Provides access to the languages module. See <seealso cref="TraktLanguagesModule" />.</summary>
        public TraktLanguagesModule Languages { get; }

        /// <summary>Provides access to the lists module. See <seealso cref="TraktListsModule" />.</summary>
        public TraktListsModule Lists { get; }

        /// <summary>Provides access to the movies module. See <seealso cref="TraktMoviesModule" />.</summary>
        public TraktMoviesModule Movies { get; }

        /// <summary>Provides access to the networks module. See <seealso cref="TraktNetworksModule" />.</summary>
        public TraktNetworksModule Networks { get; }

        /// <summary>Provides access to the notes module. See <seealso cref="TraktNotesModule" />.</summary>
        public TraktNotesModule Notes { get; }

        /// <summary>Provides access to the people module. See <seealso cref="TraktPeopleModule" />.</summary>
        public TraktPeopleModule People { get; }

        /// <summary>Provides access to the recommendations module. See <seealso cref="TraktRecommendationsModule" />.</summary>
        public TraktRecommendationsModule Recommendations { get; }

        /// <summary>Provides access to the scrobble module. See <seealso cref="TraktScrobbleModule" />.</summary>
        public TraktScrobbleModule Scrobble { get; }

        /// <summary>Provides access to the search module. See <seealso cref="TraktSearchModule" />.</summary>
        public TraktSearchModule Search { get; }

        /// <summary>Provides access to the seasons module. See <seealso cref="TraktSeasonsModule" />.</summary>
        public TraktSeasonsModule Seasons { get; }

        /// <summary>Provides access to the shows module. See <seealso cref="TraktShowsModule" />.</summary>
        public TraktShowsModule Shows { get; }

        /// <summary>Provides access to the sync module. See <seealso cref="TraktSyncModule" />.</summary>
        public TraktSyncModule Sync { get; }

        /// <summary>Provides access to the users module. See <seealso cref="TraktUsersModule" />.</summary>
        public TraktUsersModule Users { get; }

        public static TraktContext Create(string clientID, string clientSecret)
            => new TraktDefaultContext(clientID, clientSecret);

        public static TraktContext CreateForSandbox(string clientID, string clientSecret)
            => new TraktSandboxContext(clientID, clientSecret);

        protected TraktContext(string clientID, string clientSecret)
        {
            ID = Guid.NewGuid().ToString();
            ClientID = clientID;
            ClientSecret = clientSecret;
            BaseUri = new Uri(Constants.API.BaseURL);
            BaseAuthorizationUri = new Uri(Constants.API.BaseAuthorizationURL);
            HttpClientProvider = new DefaultHttpClientProvider();

            Auth = new TraktAuthModule(this);
            Calendar = new TraktCalendarModule(this);
            Certifications = new TraktCertificationsModule(this);
            Checkins = new TraktCheckinsModule(this);
            Comments = new TraktCommentsModule(this);
            Countries = new TraktCountriesModule(this);
            Episodes = new TraktEpisodesModule(this);
            Genres = new TraktGenresModule(this);
            Languages = new TraktLanguagesModule(this);
            Lists = new TraktListsModule(this);
            Movies = new TraktMoviesModule(this);
            Networks = new TraktNetworksModule(this);
            Notes = new TraktNotesModule(this);
            People = new TraktPeopleModule(this);
            Recommendations = new TraktRecommendationsModule(this);
            Scrobble = new TraktScrobbleModule(this);
            Search = new TraktSearchModule(this);
            Seasons = new TraktSeasonsModule(this);
            Shows = new TraktShowsModule(this);
            Sync = new TraktSyncModule(this);
            Users = new TraktUsersModule(this);
        }

        internal string ClientID
        {
            get => _clientID;

            set
            {
                ArgumentValidator.ThrowIfNullOrWhiteSpace(value, "client ID must not be null or empty or only whitespace", checkSpaces: true);
                _clientID = value;
            }
        }

        internal string ClientSecret
        {
            get => _clientSecret;

            set
            {
                ArgumentValidator.ThrowIfNullOrWhiteSpace(value, "client secret must not be null or empty or only whitespace", checkSpaces: true);
                _clientSecret = value;
            }
        }

        internal Uri BaseAuthorizationUri { get; set; }

        internal HttpClientProvider<TraktContext> HttpClientProvider { get; set; }

        internal HttpClient GetHttpClient() => HttpClientProvider.GetHttpClient(this);
    }
}
