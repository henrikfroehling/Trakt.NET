namespace TraktNET
{
    public sealed class TraktClient
    {
        public ITraktContext Context { get; }

        public string ClientID
        {
            get => Context.ClientID;
            set => Context.ClientID = value;
        }

        public string ClientSecret
        {
            get => Context.ClientSecret;
            set => Context.ClientSecret = value;
        }

        public TraktAuthModule Auth { get; }

        public TraktCalendarModule Calendar { get; }

        public TraktCertificationsModule Certifications { get; }

        public TraktCheckinsModule Checkins { get; }

        public TraktCommentsModule Comments { get; }

        public TraktCountriesModule Countries { get; }

        public TraktEpisodesModule Episodes { get; }

        public TraktGenresModule Genres { get; }

        public TraktLanguagesModule Languages { get; }

        public TraktListsModule Lists { get; }

        public TraktMoviesModule Movies { get; }

        public TraktNetworksModule Networks { get; }

        public TraktPeopleModule People { get; }

        public TraktRecommendationsModule Recommendations { get; }

        public TraktScrobbleModule Scrobble { get; }

        public TraktSearchModule Search { get; }

        public TraktSeasonsModule Seasons { get; }

        public TraktShowsModule Shows { get; }

        public TraktSyncModule Sync { get; }

        public TraktUsersModule Users { get; }

        public TraktClient(string clientID, string clientSecret)
            : this(new TraktContext(clientID, clientSecret))
        { }

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
