namespace TraktNET
{
    /// <summary>
    /// Provides access to all functionality of this library.<para/>
    /// Provides the only access to all of the library's modules.
    /// </summary>
    public sealed class TraktClient
    {
        /// <summary>Gets the context of the Trakt Client. See also <seealso cref="ITraktContext" />.</summary>
        public ITraktContext Context { get; }

        /// <summary>Gets or sets the Trakt Client Id. See also <seealso cref="ClientSecret" />.</summary>
        public string ClientID
        {
            get => Context.ClientID;
            set => Context.ClientID = value;
        }

        /// <summary>Gets or sets the Trakt Client Secret. See also <seealso cref="ClientID" />.</summary>
        public string ClientSecret
        {
            get => Context.ClientSecret;
            set => Context.ClientSecret = value;
        }

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

        /// <summary>Initializes a new instance of the <see cref="TraktClient" /> class.</summary>
        /// <param name="clientID">The Trakt Client Id. See <seealso cref="ClientID" />.</param>
        /// <param name="clientSecret">The Trakt Client Secret. See <seealso cref="ClientSecret" />.</param>
        public TraktClient(string clientID, string clientSecret)
            : this(new TraktContext(clientID, clientSecret))
        { }

        /// <summary>Initializes a new instance of the <see cref="TraktClient" /> class.</summary>
        /// <param name="context">The context of Trakt Client. See <seealso cref="Context" />.</param>
        public TraktClient(ITraktContext context)
        {
            ArgumentValidator.ThrowIfNull(context);
            Context = context;

            Auth = new TraktAuthModule(Context);
            Calendar = new TraktCalendarModule(Context);
            Certifications = new TraktCertificationsModule(Context);
            Checkins = new TraktCheckinsModule(Context);
            Comments = new TraktCommentsModule(Context);
            Countries = new TraktCountriesModule(Context);
            Episodes = new TraktEpisodesModule(Context);
            Genres = new TraktGenresModule(Context);
            Languages = new TraktLanguagesModule(Context);
            Lists = new TraktListsModule(Context);
            Movies = new TraktMoviesModule(Context);
            Networks = new TraktNetworksModule(Context);
            Notes = new TraktNotesModule(Context);
            People = new TraktPeopleModule(Context);
            Recommendations = new TraktRecommendationsModule(Context);
            Scrobble = new TraktScrobbleModule(Context);
            Search = new TraktSearchModule(Context);
            Seasons = new TraktSeasonsModule(Context);
            Shows = new TraktShowsModule(Context);
            Sync = new TraktSyncModule(Context);
            Users = new TraktUsersModule(Context);
        }
    }
}
