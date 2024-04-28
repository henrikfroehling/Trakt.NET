namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Seasons;
    using Objects.Get.Shows;
    using Objects.Get.Users;
    using Parameters;
    using Requests.Handler;
    using Requests.Seasons;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktSeasonsModule : ATraktModule
    {
        /// <summary>
        /// Gets all watching users of a <see cref="ITraktSeason" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/seasons/watching/get-users-watching-right-now">"Trakt API Doc - Seasons: Watching"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, for which the watching users should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the users should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktUser" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktUser>> GetSeasonWatchingUsersAsync(string showIdOrSlug, uint seasonNumber,
                                                                               TraktExtendedInfo extendedInfo = null,
                                                                               CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new SeasonWatchingUsersRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all watching users of a <see cref="ITraktSeason" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/seasons/watching/get-users-watching-right-now">"Trakt API Doc - Seasons: Watching"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktShowID">The show's Trakt-Id. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, for which the watching users should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the users should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktUser" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktListResponse<ITraktUser>> GetSeasonWatchingUsersAsync(uint traktShowID, uint seasonNumber,
                                                                               TraktExtendedInfo extendedInfo = null,
                                                                               CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return GetSeasonWatchingUsersAsync(traktShowID.ToString(), seasonNumber, extendedInfo, cancellationToken);
        }

        /// <summary>
        /// Gets all watching users of a <see cref="ITraktSeason" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/seasons/watching/get-users-watching-right-now">"Trakt API Doc - Seasons: Watching"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIds">The show's ids. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season, for which the watching users should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the users should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktUser" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="showIds"/> has not any ids set.</exception>
        public Task<TraktListResponse<ITraktUser>> GetSeasonWatchingUsersAsync(ITraktShowIds showIds, uint seasonNumber,
                                                                               TraktExtendedInfo extendedInfo = null,
                                                                               CancellationToken cancellationToken = default)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (!showIds.HasAnyId)
                throw new ArgumentException($"{nameof(showIds)} has not any ids set", nameof(showIds));

            return GetSeasonWatchingUsersAsync(showIds.GetBestId(), seasonNumber, extendedInfo, cancellationToken);
        }

        /// <summary>
        /// Gets all watching users of a <see cref="ITraktSeason" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/seasons/watching/get-users-watching-right-now">"Trakt API Doc - Seasons: Watching"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="show">The show. See also <seealso cref="ITraktShow" />.</param>
        /// <param name="seasonNumber">The number of the season, for which the watching users should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the users should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktUser" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        public Task<TraktListResponse<ITraktUser>> GetSeasonWatchingUsersAsync(ITraktShow show, uint seasonNumber,
                                                                               TraktExtendedInfo extendedInfo = null,
                                                                               CancellationToken cancellationToken = default)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            return GetSeasonWatchingUsersAsync(show.Ids, seasonNumber, extendedInfo, cancellationToken);
        }
    }
}
