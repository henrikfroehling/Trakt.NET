namespace TraktApiSharp.Modules
{
    using Attributes;
    using Objects.Get.Calendars;
    using Requests.Params;
    using Requests.WithOAuth.Calendars;
    using Requests.WithoutOAuth.Calendars;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to calendars.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/calendars">"Trakt API Doc - Calendars"</a> section.
    /// </para>
    /// </summary>
    public class TraktCalendarModule : TraktBaseModule
    {
        internal TraktCalendarModule(TraktClient client) : base(client) { }

        /// <summary>
        /// Gets all users <see cref="TraktCalendarShow" />s airing during the given time period.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/calendars/my-shows/get-shows">"Trakt API Doc - Calendars: My Shows"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The date, on which the time period should start. Defaults to today. Will be converted to the Trakt date-format.</param>
        /// <param name="days">1 - 31 days, specifying the length of the time period. Defaults to 7 days.</param>
        /// <param name="extendedOption">
        /// The extended option, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktCalendarFilter" />.</param>
        /// <returns>A list of <see cref="TraktCalendarShow" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given days value is not between 1 and 31.</exception>
        [OAuthAuthorizationRequired]
        public async Task<IEnumerable<TraktCalendarShow>> GetUserShowsAsync(DateTime? startDate = null, int? days = null,
                                                                            TraktExtendedOption extendedOption = null,
                                                                            TraktCalendarFilter filter = null)
        {
            ValidateDays(days);

            return await QueryAsync(new TraktCalendarUserShowsRequest(Client)
            {
                StartDate = startDate,
                Days = days,
                ExtendedOption = extendedOption,
                Filter = filter
            });
        }

        /// <summary>
        /// Gets all new users <see cref="TraktCalendarShow" />s airing during the given time period.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/calendars/my-new-shows/get-new-shows">"Trakt API Doc - Calendars: My New Shows"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The date, on which the time period should start. Defaults to today. Will be converted to the Trakt date-format.</param>
        /// <param name="days">1 - 31 days, specifying the length of the time period. Defaults to 7 days.</param>
        /// <param name="extendedOption">
        /// The extended option, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktCalendarFilter" />.</param>
        /// <returns>A list of <see cref="TraktCalendarShow" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given days value is not between 1 and 31.</exception>
        [OAuthAuthorizationRequired]
        public async Task<IEnumerable<TraktCalendarShow>> GetUserNewShowsAsync(DateTime? startDate = null, int? days = null,
                                                                               TraktExtendedOption extendedOption = null,
                                                                               TraktCalendarFilter filter = null)
        {
            ValidateDays(days);

            return await QueryAsync(new TraktCalendarUserNewShowsRequest(Client)
            {
                StartDate = startDate,
                Days = days,
                ExtendedOption = extendedOption,
                Filter = filter
            });
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
        /// <param name="extendedOption">
        /// The extended option, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktCalendarFilter" />.</param>
        /// <returns>A list of <see cref="TraktCalendarShow" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given days value is not between 1 and 31.</exception>
        [OAuthAuthorizationRequired]
        public async Task<IEnumerable<TraktCalendarShow>> GetUserSeasonPremieresAsync(DateTime? startDate = null, int? days = null,
                                                                                      TraktExtendedOption extendedOption = null,
                                                                                      TraktCalendarFilter filter = null)
        {
            ValidateDays(days);

            return await QueryAsync(new TraktCalendarUserSeasonPremieresRequest(Client)
            {
                StartDate = startDate,
                Days = days,
                ExtendedOption = extendedOption,
                Filter = filter
            });
        }

        /// <summary>
        /// Gets all users <see cref="TraktCalendarMovie" />s airing during the given time period.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/calendars/my-movies/get-movies">"Trakt API Doc - Calendars: My Movies"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The date, on which the time period should start. Defaults to today. Will be converted to the Trakt date-format.</param>
        /// <param name="days">1 - 31 days, specifying the length of the time period. Defaults to 7 days.</param>
        /// <param name="extendedOption">
        /// The extended option, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktCalendarFilter" />.</param>
        /// <returns>A list of <see cref="TraktCalendarMovie" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given days value is not between 1 and 31.</exception>
        [OAuthAuthorizationRequired]
        public async Task<IEnumerable<TraktCalendarMovie>> GetUserMoviesAsync(DateTime? startDate = null, int? days = null,
                                                                              TraktExtendedOption extendedOption = null,
                                                                              TraktCalendarFilter filter = null)
        {
            ValidateDays(days);

            return await QueryAsync(new TraktCalendarUserMoviesRequest(Client)
            {
                StartDate = startDate,
                Days = days,
                ExtendedOption = extendedOption,
                Filter = filter
            });
        }

        /// <summary>
        /// Gets all <see cref="TraktCalendarShow" />s airing during the given time period.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/calendars/all-shows/get-shows">"Trakt API Doc - Calendars: All Shows"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The date, on which the time period should start. Defaults to today. Will be converted to the Trakt date-format.</param>
        /// <param name="days">1 - 31 days, specifying the length of the time period. Defaults to 7 days.</param>
        /// <param name="extendedOption">
        /// The extended option, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktCalendarFilter" />.</param>
        /// <returns>A list of <see cref="TraktCalendarShow" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given days value is not between 1 and 31.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktCalendarShow>> GetAllShowsAsync(DateTime? startDate = null, int? days = null,
                                                                           TraktExtendedOption extendedOption = null,
                                                                           TraktCalendarFilter filter = null)
        {
            ValidateDays(days);

            return await QueryAsync(new TraktCalendarAllShowsRequest(Client)
            {
                StartDate = startDate,
                Days = days,
                ExtendedOption = extendedOption,
                Filter = filter
            });
        }

        /// <summary>
        /// Gets all new <see cref="TraktCalendarShow" />s airing during the given time period.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/calendars/all-new-shows/get-new-shows">"Trakt API Doc - Calendars: All New Shows"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The date, on which the time period should start. Defaults to today. Will be converted to the Trakt date-format.</param>
        /// <param name="days">1 - 31 days, specifying the length of the time period. Defaults to 7 days.</param>
        /// <param name="extendedOption">
        /// The extended option, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktCalendarFilter" />.</param>
        /// <returns>A list of <see cref="TraktCalendarShow" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given days value is not between 1 and 31.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktCalendarShow>> GetAllNewShowsAsync(DateTime? startDate = null, int? days = null,
                                                                              TraktExtendedOption extendedOption = null,
                                                                              TraktCalendarFilter filter = null)
        {
            ValidateDays(days);

            return await QueryAsync(new TraktCalendarAllNewShowsRequest(Client)
            {
                StartDate = startDate,
                Days = days,
                ExtendedOption = extendedOption,
                Filter = filter
            });
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
        /// <param name="extendedOption">
        /// The extended option, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktCalendarFilter" />.</param>
        /// <returns>A list of <see cref="TraktCalendarShow" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given days value is not between 1 and 31.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktCalendarShow>> GetAllSeasonPremieresAsync(DateTime? startDate = null, int? days = null,
                                                                                     TraktExtendedOption extendedOption = null,
                                                                                     TraktCalendarFilter filter = null)
        {
            ValidateDays(days);

            return await QueryAsync(new TraktCalendarAllSeasonPremieresRequest(Client)
            {
                StartDate = startDate,
                Days = days,
                ExtendedOption = extendedOption,
                Filter = filter
            });
        }

        /// <summary>
        /// Gets all <see cref="TraktCalendarMovie" />s airing during the given time period.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/calendars/my-movies/get-movies">"Trakt API Doc - Calendars: My Movies"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The date, on which the time period should start. Defaults to today. Will be converted to the Trakt date-format.</param>
        /// <param name="days">1 - 31 days, specifying the length of the time period. Defaults to 7 days.</param>
        /// <param name="extendedOption">
        /// The extended option, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <param name="filter">Optional filters for genres, languages, year, runtimes, ratings, etc. See also <seealso cref="TraktCalendarFilter" />.</param>
        /// <returns>A list of <see cref="TraktCalendarMovie" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given days value is not between 1 and 31.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktCalendarMovie>> GetAllMoviesAsync(DateTime? startDate = null, int? days = null,
                                                                             TraktExtendedOption extendedOption = null,
                                                                             TraktCalendarFilter filter = null)
        {
            ValidateDays(days);

            return await QueryAsync(new TraktCalendarAllMoviesRequest(Client)
            {
                StartDate = startDate,
                Days = days,
                ExtendedOption = extendedOption,
                Filter = filter
            });
        }

        private void ValidateDays(int? days)
        {
            if (days.HasValue && (days.Value < 1 || days.Value > 31))
                throw new ArgumentOutOfRangeException(nameof(days), "days must have a value between 1 and 31");
        }
    }
}
