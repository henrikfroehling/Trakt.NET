namespace TraktNet.Modules
{
    using Exceptions;
    using Extensions;
    using Objects.Basic;
    using Objects.Get.Episodes;
    using Objects.Get.Movies;
    using Objects.Get.Shows;
    using Objects.Post.Checkins;
    using Objects.Post.Checkins.Responses;
    using Requests.Checkins.OAuth;
    using Requests.Handler;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to checkins.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/checkin">"Trakt API Doc - Checkin"</a> section.
    /// </para>
    /// </summary>
    public class TraktCheckinsModule : ATraktModule
    {
        internal TraktCheckinsModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Checks into the given <see cref="ITraktMovie" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/checkin/check-into-an-item">"Trakt API Doc - Checkin: Checkin"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movie">The <see cref="ITraktMovie" />, which will be checked in.</param>
        /// <param name="appVersion">Optional application version for the checkin.</param>
        /// <param name="appBuildDate">Optional application build date for the checkin. Will be converted to the Trakt date-format.</param>
        /// <param name="message">The message, which will be used for sharing. If none is given, the user's default message will be used.</param>
        /// <param name="sharing">Optional sharing settings, which will override the user's default sharing settings.</param>
        /// <param name="foursquareVenueID">Optional Foursquare venue id for the checkin.</param>
        /// <param name="foursquareVenueName">Optional Foursquare venue name for the checkin.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktMovieCheckinPostResponse" /> instance, containing the successfully checked in movie's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movie's title is null or empty.
        /// Thrown, if the given movie has no valid ids set.
        /// </exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given movie is null or if its ids are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given movie's year is not valid.</exception>
        public Task<TraktResponse<ITraktMovieCheckinPostResponse>> CheckIntoMovieAsync(ITraktMovie movie, string appVersion = null, DateTime? appBuildDate = null,
                                                                                       string message = null, ITraktSharing sharing = null,
                                                                                       string foursquareVenueID = null, string foursquareVenueName = null,
                                                                                       CancellationToken cancellationToken = default)
        {
            var requestBody = new TraktMovieCheckinPost
            {
                Movie = movie,
                Message = message,
                Sharing = sharing,
                FoursquareVenueId = foursquareVenueID,
                FoursquareVenueName = foursquareVenueName
            };

            if (!string.IsNullOrEmpty(appVersion))
                requestBody.AppVersion = appVersion;

            if (appBuildDate.HasValue)
                requestBody.AppDate = appBuildDate.Value.ToTraktDateString();

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CheckinRequest<ITraktMovieCheckinPostResponse, ITraktMovieCheckinPost>
            {
                RequestBody = requestBody
            }, cancellationToken);
        }

        /// <summary>
        /// Checks into the given <see cref="ITraktEpisode" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/checkin/check-into-an-item">"Trakt API Doc - Checkin: Checkin"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">The <see cref="ITraktEpisode" />, which will be checked in.</param>
        /// <param name="appVersion">Optional application version for the checkin.</param>
        /// <param name="appBuildDate">Optional application build date for the checkin. Will be converted to the Trakt date-format.</param>
        /// <param name="message">The message, which will be used for sharing. If none is given, the user's default message will be used.</param>
        /// <param name="sharing">Optional sharing settings, which will override the user's default sharing settings.</param>
        /// <param name="foursquareVenueID">Optional Foursquare venue id for the checkin.</param>
        /// <param name="foursquareVenueName">Optional Foursquare venue name for the checkin.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktEpisodeCheckinPostResponse" /> instance, containing the successfully checked in episode's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given episode has no valid ids set.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given episode is null or if its ids are null.</exception>
        public Task<TraktResponse<ITraktEpisodeCheckinPostResponse>> CheckIntoEpisodeAsync(ITraktEpisode episode, string appVersion = null, DateTime? appBuildDate = null,
                                                                                           string message = null, ITraktSharing sharing = null,
                                                                                           string foursquareVenueID = null, string foursquareVenueName = null,
                                                                                           CancellationToken cancellationToken = default)
        {
            var requestBody = new TraktEpisodeCheckinPost
            {
                Episode = episode,
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

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CheckinRequest<ITraktEpisodeCheckinPostResponse, ITraktEpisodeCheckinPost>
            {
                RequestBody = requestBody
            }, cancellationToken);
        }

        /// <summary>
        /// Checks into the given <see cref="ITraktEpisode" />. Use this method, if the given episode has no valid ids.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/checkin/check-into-an-item">"Trakt API Doc - Checkin: Checkin"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">The <see cref="ITraktEpisode" />, which will be checked in.</param>
        /// <param name="show">The <see cref="ITraktShow" />, which will be used to check into the given episode.</param>
        /// <param name="appVersion">Optional application version for the checkin.</param>
        /// <param name="appBuildDate">Optional application build date for the checkin. Will be converted to the Trakt date-format.</param>
        /// <param name="message">The message, which will be used for sharing. If none is given, the user's default message will be used.</param>
        /// <param name="sharing">Optional sharing settings, which will override the user's default sharing settings.</param>
        /// <param name="foursquareVenueID">Optional Foursquare venue id for the checkin.</param>
        /// <param name="foursquareVenueName">Optional Foursquare venue name for the checkin.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktEpisodeCheckinPostResponse" /> instance, containing the successfully checked in episode's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given show's title is null or empty.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given episode is null. Thrown, if the given show is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given episode's season number or the given episode's number is below zero.</exception>
        public Task<TraktResponse<ITraktEpisodeCheckinPostResponse>> CheckIntoEpisodeWithShowAsync(ITraktEpisode episode, ITraktShow show,
                                                                                                   string appVersion = null, DateTime? appBuildDate = null,
                                                                                                   string message = null, ITraktSharing sharing = null,
                                                                                                   string foursquareVenueID = null, string foursquareVenueName = null,
                                                                                                   CancellationToken cancellationToken = default)
        {
            var requestBody = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                Message = message,
                Sharing = sharing,
                FoursquareVenueId = foursquareVenueID,
                FoursquareVenueName = foursquareVenueName
            };

            if (!string.IsNullOrEmpty(appVersion))
                requestBody.AppVersion = appVersion;

            if (appBuildDate.HasValue)
                requestBody.AppDate = appBuildDate.Value.ToTraktDateString();

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CheckinRequest<ITraktEpisodeCheckinPostResponse, ITraktEpisodeCheckinPost>
            {
                RequestBody = requestBody
            }, cancellationToken);
        }

        /// <summary>
        /// Deletes any active checkins.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/checkin/checkin/delete-any-active-checkins">"Trakt API Doc - Checkin: Checkin"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktNoContentResponse> DeleteAnyActiveCheckinsAsync(CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteNoContentRequestAsync(new CheckinsDeleteRequest(), cancellationToken);
        }
    }
}
