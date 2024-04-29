﻿namespace TraktNet
{
    using Core;
    using Extensions;
    using Modules;
    using Objects.Authentication;
    using Requests.Handler;
    using System.Net.Http;

    /// <summary>
    /// Provides access to all functionality of this library.
    /// <para>Provides the only access to all of the library's modules.</para>
    /// </summary>
    public class TraktClient
    {
        internal TraktClient(IHttpClientProvider httpClientProvider = default)
        {
            HttpClientProvider = httpClientProvider ?? new HttpClientProvider();
            Configuration = new TraktConfiguration();
            Authentication = new TraktAuthenticationModule(this);
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

        /// <summary>Initializes a new instance of the <see cref="TraktClient" /> class.</summary>
        /// <param name="clientId">The Trakt Client Id. See <seealso cref="ClientId" />.</param>
        /// <param name="httpClientProvider">
        /// A custom <see cref="HttpClient" /> provider, which can be used to provide a <see cref="HttpClient" /> with a custom <see cref="HttpMessageHandler" />.
        /// If not set, a default implementation (<see cref="Requests.Handler.HttpClientProvider" />) will be used.
        /// </param>
        public TraktClient(string clientId, IHttpClientProvider httpClientProvider = default) : this(httpClientProvider)
        {
            ClientId = clientId;
        }

        /// <summary>Initializes a new instance of the <see cref="TraktClient" /> class.</summary>
        /// <param name="clientId">The Trakt Client Id. See <seealso cref="ClientId" />.</param>
        /// <param name="clientSecret">The Trakt Client Secret. See <seealso cref="ClientSecret" />.</param>
        /// <param name="httpClientProvider"></param>
        public TraktClient(string clientId, string clientSecret, IHttpClientProvider httpClientProvider = default) : this(clientId, httpClientProvider)
        {
            ClientSecret = clientSecret;
        }

        internal IHttpClientProvider HttpClientProvider { get; }

        /// <summary>Gets or sets the Trakt Client Id. See also <seealso cref="ClientSecret" />.</summary>
        public string ClientId
        {
            get => Authentication.ClientId;
            set => Authentication.ClientId = value;
        }

        /// <summary>Gets or sets the Trakt Client Secret. See also <seealso cref="ClientId" />.</summary>
        public string ClientSecret
        {
            get => Authentication.ClientSecret;
            set => Authentication.ClientSecret = value;
        }

        /// <summary>Gets or sets the Trakt Authorization information. See also <seealso cref="ITraktAuthorization" />.</summary>
        public ITraktAuthorization Authorization
        {
            get => Authentication.Authorization;
            set => Authentication.Authorization = value;
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
        /// See <seealso cref="TraktAuthenticationModule.IsAuthorized" />.
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

        /// <summary>Provides access to the authentication module. See <seealso cref="TraktAuthenticationModule" />.</summary>
        public TraktAuthenticationModule Authentication { get; }

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
    }
}
