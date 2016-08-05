namespace TraktApiSharp.Modules
{
    using Attributes;
    using Extensions;
    using Objects.Basic;
    using Objects.Get.Movies;
    using Objects.Get.Shows;
    using Objects.Get.Shows.Episodes;
    using Objects.Post.Checkins;
    using Objects.Post.Checkins.Responses;
    using Requests.WithOAuth.Checkins;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to checkins.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/checkin">"Trakt API Doc - Checkin"</a> section.
    /// </para>
    /// </summary>
    public class TraktCheckinsModule : TraktBaseModule
    {
        internal TraktCheckinsModule(TraktClient client) : base(client) { }

        /// <summary>
        /// Checks into the given <see cref="TraktMovie" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/checkin/check-into-an-item">"Trakt API Doc - Checkin: Checkin"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movie">The <see cref="TraktMovie" />, which will be checked in.</param>
        /// <param name="appVersion">Optional application version for the checkin.</param>
        /// <param name="appBuildDate">Optional application build date for the checkin. Will be converted to the Trakt date-format.</param>
        /// <param name="message">The message, which will be used for sharing. If none is given, the user's default message will be used.</param>
        /// <param name="sharing">Optional sharing settings, which will override the user's default sharing settings.</param>
        /// <param name="foursquareVenueID">Optional Foursquare venue id for the checkin.</param>
        /// <param name="foursquareVenueName">Optional Foursquare venue name for the checkin.</param>
        /// <returns>An <see cref="TraktMovieCheckinPostResponse" /> instance, containing the successfully checked in movie's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movie's title is null or empty.
        /// Thrown, if the given movie has no valid ids set.
        /// </exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given movie is null or if its ids are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given movie's year is not valid.</exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktMovieCheckinPostResponse> CheckIntoMovieAsync([NotNull] TraktMovie movie, string appVersion = null, DateTime? appBuildDate = null,
                                                                             string message = null, TraktSharing sharing = null,
                                                                             string foursquareVenueID = null, string foursquareVenueName = null)
        {
            Validate(movie);

            var requestBody = new TraktMovieCheckinPost
            {
                Movie = new TraktMovie
                {
                    Title = movie.Title,
                    Year = movie.Year,
                    Ids = movie.Ids
                },
                Message = message,
                Sharing = sharing,
                FoursquareVenueId = foursquareVenueID,
                FoursquareVenueName = foursquareVenueName
            };

            if (!string.IsNullOrEmpty(appVersion))
                requestBody.AppVersion = appVersion;

            if (appBuildDate.HasValue)
                requestBody.AppDate = appBuildDate.Value.ToTraktDateString();

            return await QueryAsync(new TraktCheckinRequest<TraktMovieCheckinPostResponse, TraktMovieCheckinPost>(Client)
            {
                RequestBody = requestBody
            });
        }

        /// <summary>
        /// Checks into the given <see cref="TraktEpisode" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/checkin/check-into-an-item">"Trakt API Doc - Checkin: Checkin"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">The <see cref="TraktEpisode" />, which will be checked in.</param>
        /// <param name="appVersion">Optional application version for the checkin.</param>
        /// <param name="appBuildDate">Optional application build date for the checkin. Will be converted to the Trakt date-format.</param>
        /// <param name="message">The message, which will be used for sharing. If none is given, the user's default message will be used.</param>
        /// <param name="sharing">Optional sharing settings, which will override the user's default sharing settings.</param>
        /// <param name="foursquareVenueID">Optional Foursquare venue id for the checkin.</param>
        /// <param name="foursquareVenueName">Optional Foursquare venue name for the checkin.</param>
        /// <returns>An <see cref="TraktEpisodeCheckinPostResponse" /> instance, containing the successfully checked in episode's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given episode is null or if its ids are null.</exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktEpisodeCheckinPostResponse> CheckIntoEpisodeAsync([NotNull] TraktEpisode episode, string appVersion = null, DateTime? appBuildDate = null,
                                                                                 string message = null, TraktSharing sharing = null,
                                                                                 string foursquareVenueID = null, string foursquareVenueName = null)
        {
            Validate(episode);

            var requestBody = new TraktEpisodeCheckinPost
            {
                Episode = new TraktEpisode
                {
                    Ids = episode.Ids,
                    SeasonNumber = episode.SeasonNumber,
                    Number = episode.Number
                },
                Show = null,
                Message = message,
                Sharing = sharing,
                FoursquareVenueId = foursquareVenueID,
                FoursquareVenueName = foursquareVenueName
            };

            if (!string.IsNullOrEmpty(appVersion))
                requestBody.AppVersion = appVersion;

            if (appBuildDate.HasValue)
                requestBody.AppDate = appBuildDate.Value.ToTraktDateString();

            return await QueryAsync(new TraktCheckinRequest<TraktEpisodeCheckinPostResponse, TraktEpisodeCheckinPost>(Client)
            {
                RequestBody = requestBody
            });
        }

        /// <summary>
        /// Checks into the given <see cref="TraktEpisode" />. Use this method, if the given episode has no valid ids.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/checkin/check-into-an-item">"Trakt API Doc - Checkin: Checkin"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">The <see cref="TraktEpisode" />, which will be checked in.</param>
        /// <param name="show">The <see cref="TraktShow" />, which will be used to check into the given episode.</param>
        /// <param name="appVersion">Optional application version for the checkin.</param>
        /// <param name="appBuildDate">Optional application build date for the checkin. Will be converted to the Trakt date-format.</param>
        /// <param name="message">The message, which will be used for sharing. If none is given, the user's default message will be used.</param>
        /// <param name="sharing">Optional sharing settings, which will override the user's default sharing settings.</param>
        /// <param name="foursquareVenueID">Optional Foursquare venue id for the checkin.</param>
        /// <param name="foursquareVenueName">Optional Foursquare venue name for the checkin.</param>
        /// <returns>An <see cref="TraktEpisodeCheckinPostResponse" /> instance, containing the successfully checked in episode's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given show's title is null or empty.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given episode is null. Thrown, if the given show is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given episode's season number or the given episode's number is below zero.</exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktEpisodeCheckinPostResponse> CheckIntoEpisodeWithShowAsync([NotNull] TraktEpisode episode, [NotNull] TraktShow show,
                                                                                         string appVersion = null, DateTime? appBuildDate = null,
                                                                                         string message = null, TraktSharing sharing = null,
                                                                                         string foursquareVenueID = null, string foursquareVenueName = null)
        {
            Validate(episode, show);

            var requestBody = new TraktEpisodeCheckinPost
            {
                Episode = new TraktEpisode
                {
                    Ids = episode.Ids,
                    SeasonNumber = episode.SeasonNumber,
                    Number = episode.Number
                },
                Show = new TraktShow { Title = show.Title },
                Message = message,
                Sharing = sharing,
                FoursquareVenueId = foursquareVenueID,
                FoursquareVenueName = foursquareVenueName
            };

            if (!string.IsNullOrEmpty(appVersion))
                requestBody.AppVersion = appVersion;

            if (appBuildDate.HasValue)
                requestBody.AppDate = appBuildDate.Value.ToTraktDateString();

            return await QueryAsync(new TraktCheckinRequest<TraktEpisodeCheckinPostResponse, TraktEpisodeCheckinPost>(Client)
            {
                RequestBody = requestBody
            });
        }

        /// <summary>
        /// Deletes any active checkins.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/checkin/checkin/delete-any-active-checkins">"Trakt API Doc - Checkin: Checkin"</a> for more information.
        /// </para>
        /// </summary>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired]
        public async Task DeleteAnyActiveCheckinsAsync()
        {
            await QueryAsync(new TraktCheckinsDeleteRequest(Client));
        }

        private void Validate(TraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie), "movie must not be null");

            if (string.IsNullOrEmpty(movie.Title))
                throw new ArgumentException("movie title not valid", nameof(movie.Title));

            if (movie.Year <= 0 || movie.Year.ToString().Length != 4)
                throw new ArgumentOutOfRangeException(nameof(movie), "movie year not valid");

            if (movie.Ids == null)
                throw new ArgumentNullException(nameof(movie.Ids), "movie.Ids must not be null");

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("movie.Ids have no valid id", nameof(movie.Ids));
        }

        private void Validate(TraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode), "episode must not be null");

            if (episode.Ids == null)
                throw new ArgumentNullException(nameof(episode.Ids), "episode.Ids must not be null");

            if (!episode.Ids.HasAnyId)
                throw new ArgumentException("episode.Ids have no valid id", nameof(episode.Ids));
        }

        private void Validate(TraktEpisode episode, TraktShow show)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode), "episode must not be null");

            if (episode.SeasonNumber < 0)
                throw new ArgumentOutOfRangeException(nameof(episode.SeasonNumber), "episode season number not valid");

            if (episode.Number < 0)
                throw new ArgumentOutOfRangeException(nameof(episode.Number), "episode number not valid");

            if (show == null)
                throw new ArgumentNullException(nameof(show), "show must not be null");

            if (string.IsNullOrEmpty(show.Title))
                throw new ArgumentException("show title not valid", nameof(show.Title));
        }
    }
}
