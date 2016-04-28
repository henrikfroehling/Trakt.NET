using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TraktApiSharp.Tests")]

namespace TraktApiSharp
{
    using Authentication;
    using Core;
    using Modules;

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

        internal TraktClient()
        {
            Configuration = new TraktConfiguration();
            Authentication = new TraktAuthentication(this);
            OAuth = new TraktOAuth(this);
            DeviceAuth = new TraktDeviceAuth(this);
        }

        public TraktClient(string clientId) : this()
        {
            ClientId = clientId;
        }

        public TraktClient(string clientId, string clientSecret) : this(clientId)
        {
            ClientSecret = clientSecret;
        }

        public string ClientId
        {
            get { return Authentication.ClientId; }
            set { Authentication.ClientId = value; }
        }

        public string ClientSecret
        {
            get { return Authentication.ClientSecret; }
            set { Authentication.ClientSecret = value; }
        }

        public bool IsValidForUseWithoutAuthorization => !string.IsNullOrEmpty(ClientId);

        public bool IsValid => !string.IsNullOrEmpty(ClientId) && !string.IsNullOrEmpty(ClientSecret);

        public TraktConfiguration Configuration
        {
            get { return _configuration = _configuration ?? new TraktConfiguration(); }
            private set { _configuration = value; }
        }

        public TraktAuthentication Authentication
        {
            get { return _authentication = _authentication ?? new TraktAuthentication(this); }
            private set { _authentication = value; }
        }

        public TraktOAuth OAuth
        {
            get { return _oauth = _oauth ?? new TraktOAuth(this); }
            private set { _oauth = value; }
        }

        public TraktDeviceAuth DeviceAuth
        {
            get { return _deviceAuth = _deviceAuth ?? new TraktDeviceAuth(this); }
            private set { _deviceAuth = value; }
        }

        public TraktShowsModule Shows
        {
            get { return _shows = _shows ?? new TraktShowsModule(this); }
            private set { _shows = value; }
        }

        public TraktSeasonsModule Seasons
        {
            get { return _seasons = _seasons ?? new TraktSeasonsModule(this); }
            private set { _seasons = value; }
        }

        public TraktEpisodesModule Episodes
        {
            get { return _episodes = _episodes ?? new TraktEpisodesModule(this); }
            private set { _episodes = value; }
        }

        public TraktMoviesModule Movies
        {
            get { return _movies = _movies ?? new TraktMoviesModule(this); }
            private set { _movies = value; }
        }

        public TraktCalendarModule Calendar
        {
            get { return _calendar = _calendar ?? new TraktCalendarModule(this); }
            private set { _calendar = value; }
        }

        public TraktCommentsModule Comments
        {
            get { return _comments = _comments ?? new TraktCommentsModule(this); }
            private set { _comments = value; }
        }

        public TraktPeopleModule People
        {
            get { return _people = _people ?? new TraktPeopleModule(this); }
            private set { _people = value; }
        }

        public TraktGenresModule Genres
        {
            get { return _genres = _genres ?? new TraktGenresModule(this); }
            private set { _genres = value; }
        }

        public TraktSearchModule Search
        {
            get { return _search = _search ?? new TraktSearchModule(this); }
            private set { _search = value; }
        }

        public TraktRecommendationsModule Recommendations
        {
            get { return _recommendations = _recommendations ?? new TraktRecommendationsModule(this); }
            private set { _recommendations = value; }
        }

        public TraktSyncModule Sync
        {
            get { return _sync = _sync ?? new TraktSyncModule(this); }
            private set { _sync = value; }
        }
    }
}
