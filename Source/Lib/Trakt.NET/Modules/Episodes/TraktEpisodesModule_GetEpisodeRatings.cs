namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Basic;
    using Objects.Get.Episodes;
    using Objects.Get.Shows;
    using Requests.Episodes;
    using Requests.Handler;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktEpisodesModule : ATraktModule
    {
        /// <summary>
        /// Gets the ratings for a <see cref="ITraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/ratings/get-episode-ratings">"Trakt API Doc - Episodes: Ratings"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the ratings should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the ratings should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktRating" /> instance, containing the ratings for a episode with the given showIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktRating>> GetEpisodeRatingsAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
                                                                        CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new EpisodeRatingsRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the ratings for a <see cref="ITraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/ratings/get-episode-ratings">"Trakt API Doc - Episodes: Ratings"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktShowID">The show's Trakt-Id. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the ratings should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the ratings should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktRating" /> instance, containing the ratings for a episode with the given showIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktResponse<ITraktRating>> GetEpisodeRatingsAsync(uint traktShowID, uint seasonNumber, uint episodeNumber,
                                                                        CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return GetEpisodeRatingsAsync(traktShowID.ToString(), seasonNumber, episodeNumber, cancellationToken);
        }

        /// <summary>
        /// Gets the ratings for a <see cref="ITraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/ratings/get-episode-ratings">"Trakt API Doc - Episodes: Ratings"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIds">The show's ids. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the ratings should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the ratings should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktRating" /> instance, containing the ratings for a episode with the given showIdOrSlug.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        public Task<TraktResponse<ITraktRating>> GetEpisodeRatingsAsync(ITraktShowIds showIds, uint seasonNumber, uint episodeNumber,
                                                                        CancellationToken cancellationToken = default)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (!showIds.HasAnyId)
                throw new ArgumentException($"{nameof(showIds)} has not any ids set", nameof(showIds));

            return GetEpisodeRatingsAsync(showIds.GetBestId(), seasonNumber, episodeNumber, cancellationToken);
        }
    }
}
