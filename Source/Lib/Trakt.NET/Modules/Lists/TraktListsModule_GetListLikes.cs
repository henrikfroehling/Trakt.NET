namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Lists;
    using Parameters;
    using Requests.Handler;
    using Requests.Lists;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktListsModule : ATraktModule
    {
        /// <summary>
        /// Gets the users who liked a list.
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/list-likes/get-all-users-who-liked-a-list">"Trakt API Doc - Lists: List Likes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="listIdOrSlug">The id or slug of the list, for which the likes should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the list items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktListLike" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktListLike>> GetListLikesAsync(string listIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                          TraktPagedParameters pagedParameters = null,
                                                                          CancellationToken cancellationToken = default)
        {
            var request = new ListLikesRequest
            {
                Id = listIdOrSlug,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets the users who liked a list.
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/list-likes/get-all-users-who-liked-a-list">"Trakt API Doc - Lists: List Likes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktListId">The list's Trakt-Id. See also <seealso cref="ITraktListIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the list items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktListLike" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktPagedResponse<ITraktListLike>> GetListLikesAsync(uint traktListId, TraktExtendedInfo extendedInfo = null,
                                                                          TraktPagedParameters pagedParameters = null,
                                                                          CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return GetListLikesAsync(traktListId.ToString(), extendedInfo, pagedParameters, cancellationToken);
        }

        /// <summary>
        /// Gets the users who liked a list.
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/list-likes/get-all-users-who-liked-a-list">"Trakt API Doc - Lists: List Likes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="listIds">The list's ids. See also <seealso cref="ITraktListIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the list items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktListLike" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        public Task<TraktPagedResponse<ITraktListLike>> GetListLikesAsync(ITraktListIds listIds, TraktExtendedInfo extendedInfo = null,
                                                                          TraktPagedParameters pagedParameters = null,
                                                                          CancellationToken cancellationToken = default)
        {
            if (listIds == null)
                throw new ArgumentNullException(nameof(listIds));

            if (!listIds.HasAnyId)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return GetListLikesAsync(listIds.GetBestId(), extendedInfo, pagedParameters, cancellationToken);
        }
    }
}
