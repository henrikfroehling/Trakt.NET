namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Episodes;
    using Objects.Get.Shows;
    using Parameters;
    using Requests.Handler;
    using Requests.Shows;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktShowsModule : ATraktModule
    {
        /// <summary>
        /// Gets the most recently aired <see cref="ITraktEpisode" /> for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/shows/next-episode/get-last-episode">"Trakt API Doc - Shows: Last Episode"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the episode should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktEpisode" /> instance with the queried episode's data or null, if there is no most recently aired episode.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktEpisode>> GetShowLastEpisodeAsync(string showIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                          CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new ShowLastEpisodeRequest
            {
                Id = showIdOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the most recently aired <see cref="ITraktEpisode" /> for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/shows/next-episode/get-last-episode">"Trakt API Doc - Shows: Last Episode"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktShowID">The show's Trakt-Id. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the episode should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktEpisode" /> instance with the queried episode's data or null, if there is no most recently aired episode.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktResponse<ITraktEpisode>> GetShowLastEpisodeAsync(uint traktShowID, TraktExtendedInfo extendedInfo = null,
                                                                          CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return GetShowLastEpisodeAsync(traktShowID.ToString(), extendedInfo, cancellationToken);
        }

        /// <summary>
        /// Gets the most recently aired <see cref="ITraktEpisode" /> for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/shows/next-episode/get-last-episode">"Trakt API Doc - Shows: Last Episode"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIds">The show's ids. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the episode should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktEpisode" /> instance with the queried episode's data or null, if there is no most recently aired episode.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="showIds"/> has not any ids set.</exception>
        public Task<TraktResponse<ITraktEpisode>> GetShowLastEpisodeAsync(ITraktShowIds showIds, TraktExtendedInfo extendedInfo = null,
                                                                          CancellationToken cancellationToken = default)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (!showIds.HasAnyId)
                throw new ArgumentException($"{nameof(showIds)} has not any ids set", nameof(showIds));

            return GetShowLastEpisodeAsync(showIds.GetBestId(), extendedInfo, cancellationToken);
        }

        /// <summary>
        /// Gets the most recently aired <see cref="ITraktEpisode" /> for a <see cref="ITraktShow" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/shows/next-episode/get-last-episode">"Trakt API Doc - Shows: Last Episode"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="show">The show. See also <seealso cref="ITraktShow" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the episode should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktEpisode" /> instance with the queried episode's data or null, if there is no most recently aired episode.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        public Task<TraktResponse<ITraktEpisode>> GetShowLastEpisodeAsync(ITraktShow show, TraktExtendedInfo extendedInfo = null,
                                                                          CancellationToken cancellationToken = default)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            return GetShowLastEpisodeAsync(show.Ids, extendedInfo, cancellationToken);
        }
    }
}
