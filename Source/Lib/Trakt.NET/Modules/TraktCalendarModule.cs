namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Calendars;
    using Requests.Calendars;
    using Requests.Calendars.OAuth;
    using Requests.Handler;
    using Requests.Parameters;
    using Requests.Parameters.Filter;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to calendars.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/calendars">"Trakt API Doc - Calendars"</a> section.
    /// </para>
    /// </summary>
    public class TraktCalendarModule : ATraktModule
    {
        internal TraktCalendarModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Gets all users <see cref="ITraktCalendarShow" />s airing during the given time period.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/calendars/my-shows/get-shows">"Trakt API Doc - Calendars: My Shows"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The date, on which the time period should start. Defaults to today. Will be converted to the Trakt date-format.</param>
        /// <param name="days">1 - 31 days, specifying the length of the time period. Defaults to 7 days.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktCalendarFilter" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktCalendarShow" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given days value is not between 1 and 31.</exception>
        public Task<TraktListResponse<ITraktCalendarShow>> GetUserShowsAsync(DateTime? startDate = null, int? days = null,
                                                                             TraktExtendedInfo extendedInfo = null,
                                                                             ITraktCalendarFilter filter = null,
                                                                             CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new CalendarUserShowsRequest
            {
                StartDate = startDate,
                Days = days,
                ExtendedInfo = extendedInfo,
                Filter = filter
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all new users <see cref="ITraktCalendarShow" />s airing during the given time period.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/calendars/my-new-shows/get-new-shows">"Trakt API Doc - Calendars: My New Shows"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The date, on which the time period should start. Defaults to today. Will be converted to the Trakt date-format.</param>
        /// <param name="days">1 - 31 days, specifying the length of the time period. Defaults to 7 days.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktCalendarFilter" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktCalendarShow" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given days value is not between 1 and 31.</exception>
        public Task<TraktListResponse<ITraktCalendarShow>> GetUserNewShowsAsync(DateTime? startDate = null, int? days = null,
                                                                                TraktExtendedInfo extendedInfo = null,
                                                                                ITraktCalendarFilter filter = null,
                                                                                CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new CalendarUserNewShowsRequest
            {
                StartDate = startDate,
                Days = days,
                ExtendedInfo = extendedInfo,
                Filter = filter
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all users season premieres airing during the given time period.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/calendars/my-season-premieres/get-season-premieres">"Trakt API Doc - Calendars: My Season Premieres"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The date, on which the time period should start. Defaults to today. Will be converted to the Trakt date-format.</param>
        /// <param name="days">1 - 31 days, specifying the length of the time period. Defaults to 7 days.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktCalendarFilter" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktCalendarShow" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given days value is not between 1 and 31.</exception>
        public Task<TraktListResponse<ITraktCalendarShow>> GetUserSeasonPremieresAsync(DateTime? startDate = null, int? days = null,
                                                                                       TraktExtendedInfo extendedInfo = null,
                                                                                       ITraktCalendarFilter filter = null,
                                                                                       CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new CalendarUserSeasonPremieresRequest
            {
                StartDate = startDate,
                Days = days,
                ExtendedInfo = extendedInfo,
                Filter = filter
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all users <see cref="ITraktCalendarMovie" />s airing during the given time period.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/calendars/my-movies/get-movies">"Trakt API Doc - Calendars: My Movies"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The date, on which the time period should start. Defaults to today. Will be converted to the Trakt date-format.</param>
        /// <param name="days">1 - 31 days, specifying the length of the time period. Defaults to 7 days.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktCalendarFilter" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktCalendarMovie" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given days value is not between 1 and 31.</exception>
        public Task<TraktListResponse<ITraktCalendarMovie>> GetUserMoviesAsync(DateTime? startDate = null, int? days = null,
                                                                               TraktExtendedInfo extendedInfo = null,
                                                                               ITraktCalendarFilter filter = null,
                                                                               CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new CalendarUserMoviesRequest
            {
                StartDate = startDate,
                Days = days,
                ExtendedInfo = extendedInfo,
                Filter = filter
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all users <see cref="ITraktCalendarMovie" />s with a DVD release during the given time period.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/calendars/my-dvd/get-dvd-releases">"Trakt API Doc - Calendars: My DVD"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The date, on which the time period should start. Defaults to today. Will be converted to the Trakt date-format.</param>
        /// <param name="days">1 - 31 days, specifying the length of the time period. Defaults to 7 days.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktCalendarFilter" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktCalendarMovie" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given days value is not between 1 and 31.</exception>
        public Task<TraktListResponse<ITraktCalendarMovie>> GetUserDVDMoviesAsync(DateTime? startDate = null, int? days = null,
                                                                                  TraktExtendedInfo extendedInfo = null,
                                                                                  ITraktCalendarFilter filter = null,
                                                                                  CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new CalendarUserDVDMoviesRequest
            {
                StartDate = startDate,
                Days = days,
                ExtendedInfo = extendedInfo,
                Filter = filter
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all <see cref="ITraktCalendarShow" />s airing during the given time period.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/calendars/all-shows/get-shows">"Trakt API Doc - Calendars: All Shows"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The date, on which the time period should start. Defaults to today. Will be converted to the Trakt date-format.</param>
        /// <param name="days">1 - 31 days, specifying the length of the time period. Defaults to 7 days.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktCalendarFilter" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktCalendarShow" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given days value is not between 1 and 31.</exception>
        public Task<TraktListResponse<ITraktCalendarShow>> GetAllShowsAsync(DateTime? startDate = null, int? days = null,
                                                                            TraktExtendedInfo extendedInfo = null,
                                                                            ITraktCalendarFilter filter = null,
                                                                            CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new CalendarAllShowsRequest
            {
                StartDate = startDate,
                Days = days,
                ExtendedInfo = extendedInfo,
                Filter = filter
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all new <see cref="ITraktCalendarShow" />s airing during the given time period.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/calendars/all-new-shows/get-new-shows">"Trakt API Doc - Calendars: All New Shows"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The date, on which the time period should start. Defaults to today. Will be converted to the Trakt date-format.</param>
        /// <param name="days">1 - 31 days, specifying the length of the time period. Defaults to 7 days.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktCalendarFilter" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktCalendarShow" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given days value is not between 1 and 31.</exception>
        public Task<TraktListResponse<ITraktCalendarShow>> GetAllNewShowsAsync(DateTime? startDate = null, int? days = null,
                                                                               TraktExtendedInfo extendedInfo = null,
                                                                               ITraktCalendarFilter filter = null,
                                                                               CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new CalendarAllNewShowsRequest
            {
                StartDate = startDate,
                Days = days,
                ExtendedInfo = extendedInfo,
                Filter = filter
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all season premieres airing during the given time period.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/calendars/all-season-premieres/get-season-premieres">"Trakt API Doc - Calendars: All Season Premieres"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The date, on which the time period should start. Defaults to today. Will be converted to the Trakt date-format.</param>
        /// <param name="days">1 - 31 days, specifying the length of the time period. Defaults to 7 days.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktCalendarFilter" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktCalendarShow" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given days value is not between 1 and 31.</exception>
        public Task<TraktListResponse<ITraktCalendarShow>> GetAllSeasonPremieresAsync(DateTime? startDate = null, int? days = null,
                                                                                      TraktExtendedInfo extendedInfo = null,
                                                                                      ITraktCalendarFilter filter = null,
                                                                                      CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new CalendarAllSeasonPremieresRequest
            {
                StartDate = startDate,
                Days = days,
                ExtendedInfo = extendedInfo,
                Filter = filter
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all <see cref="ITraktCalendarMovie" />s airing during the given time period.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/calendars/all-movies/get-movies">"Trakt API Doc - Calendars: All Movies"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The date, on which the time period should start. Defaults to today. Will be converted to the Trakt date-format.</param>
        /// <param name="days">1 - 31 days, specifying the length of the time period. Defaults to 7 days.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktCalendarFilter" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktCalendarMovie" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given days value is not between 1 and 31.</exception>
        public Task<TraktListResponse<ITraktCalendarMovie>> GetAllMoviesAsync(DateTime? startDate = null, int? days = null,
                                                                              TraktExtendedInfo extendedInfo = null,
                                                                              ITraktCalendarFilter filter = null,
                                                                              CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new CalendarAllMoviesRequest
            {
                StartDate = startDate,
                Days = days,
                ExtendedInfo = extendedInfo,
                Filter = filter
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all <see cref="ITraktCalendarMovie" />s with a DVD release during the given time period.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/calendars/all-movies/get-dvd-releases">"Trakt API Doc - Calendars: All DVD"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The date, on which the time period should start. Defaults to today. Will be converted to the Trakt date-format.</param>
        /// <param name="days">1 - 31 days, specifying the length of the time period. Defaults to 7 days.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktCalendarFilter" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktCalendarMovie" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given days value is not between 1 and 31.</exception>
        public Task<TraktListResponse<ITraktCalendarMovie>> GetAllDVDMoviesAsync(DateTime? startDate = null, int? days = null,
                                                                                 TraktExtendedInfo extendedInfo = null,
                                                                                 ITraktCalendarFilter filter = null,
                                                                                 CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new CalendarAllDVDMoviesRequest
            {
                StartDate = startDate,
                Days = days,
                ExtendedInfo = extendedInfo,
                Filter = filter
            },
            cancellationToken);
        }
    }
}
