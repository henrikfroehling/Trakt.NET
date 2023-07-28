namespace TraktNet.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Get.Episodes;
    using Objects.Get.Lists;
    using Objects.Get.Shows;
    using Parameters;
    using Requests.Episodes;
    using Requests.Handler;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktEpisodesModule : ATraktModule
    {
        /// <summary>
        /// Gets all <see cref="ITraktList" />s containing the given <see cref="ITraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/lists/get-lists-containing-this-episode">"Trakt API Doc - Episodes: Lists"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIdOrSlug">The show's Trakt-Id or -Slug. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the lists should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the lists should be queried.</param>
        /// <param name="listType">The type of lists, that should be queried. Defaults to personal lists.</param>
        /// <param name="listSortOrder">The list sort order. See also <seealso cref="TraktListSortOrder" />. Defaults to sorted by popularity.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the list items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktList}"/> instance containing the queried episode lists and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktList" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktList>> GetEpisodeListsAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
                                                                         TraktListType listType = null, TraktListSortOrder listSortOrder = null,
                                                                         TraktExtendedInfo extendedInfo = null,
                                                                         TraktPagedParameters pagedParameters = null,
                                                                         CancellationToken cancellationToken = default)
        {
            var request = new EpisodeListsRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber,
                Type = listType,
                SortOrder = listSortOrder,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets all <see cref="ITraktList" />s containing the given <see cref="ITraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/lists/get-lists-containing-this-episode">"Trakt API Doc - Episodes: Lists"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktShowID">The show's Trakt-Id. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the lists should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the lists should be queried.</param>
        /// <param name="listType">The type of lists, that should be queried. Defaults to personal lists.</param>
        /// <param name="listSortOrder">The list sort order. See also <seealso cref="TraktListSortOrder" />. Defaults to sorted by popularity.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the list items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktList}"/> instance containing the queried episode lists and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktList" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktShowID"/> is 0.</exception>
        public Task<TraktPagedResponse<ITraktList>> GetEpisodeListsAsync(uint traktShowID, uint seasonNumber, uint episodeNumber,
                                                                         TraktListType listType = null, TraktListSortOrder listSortOrder = null,
                                                                         TraktExtendedInfo extendedInfo = null,
                                                                         TraktPagedParameters pagedParameters = null,
                                                                         CancellationToken cancellationToken = default)
        {
            if (traktShowID == 0)
                throw new ArgumentException("show id must not be 0", nameof(traktShowID));

            return GetEpisodeListsAsync(traktShowID.ToString(), seasonNumber, episodeNumber, listType, listSortOrder,
                                        extendedInfo, pagedParameters, cancellationToken);
        }

        /// <summary>
        /// Gets all <see cref="ITraktList" />s containing the given <see cref="ITraktEpisode" /> in a show with the given Trakt-Show-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/episodes/lists/get-lists-containing-this-episode">"Trakt API Doc - Episodes: Lists"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="showIds">The show's ids. See also <seealso cref="ITraktShowIds" />.</param>
        /// <param name="seasonNumber">The number of the season containing the episode, for which the lists should be queried.</param>
        /// <param name="episodeNumber">The number of the episode, for which the lists should be queried.</param>
        /// <param name="listType">The type of lists, that should be queried. Defaults to personal lists.</param>
        /// <param name="listSortOrder">The list sort order. See also <seealso cref="TraktListSortOrder" />. Defaults to sorted by popularity.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the list items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktList}"/> instance containing the queried episode lists and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktList" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        public Task<TraktPagedResponse<ITraktList>> GetEpisodeListsAsync(ITraktShowIds showIds, uint seasonNumber, uint episodeNumber,
                                                                         TraktListType listType = null, TraktListSortOrder listSortOrder = null,
                                                                         TraktExtendedInfo extendedInfo = null,
                                                                         TraktPagedParameters pagedParameters = null,
                                                                         CancellationToken cancellationToken = default)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (!showIds.HasAnyId)
                throw new ArgumentException($"{nameof(showIds)} has not any ids set", nameof(showIds));

            return GetEpisodeListsAsync(showIds.GetBestId(), seasonNumber, episodeNumber, listType, listSortOrder,
                                        extendedInfo, pagedParameters, cancellationToken);
        }
    }
}
