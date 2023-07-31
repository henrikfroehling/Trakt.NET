namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Lists;
    using Parameters;
    using Requests.Handler;
    using Requests.Users.OAuth;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktUsersModule : ATraktModule
    {
        /// <summary>
        /// Gets all likes for an user's list.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/list-likes/get-all-users-who-liked-a-list">"Trakt API Doc - Users: List Likes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the list likes should be queried.</param>
        /// <param name="listIdOrSlug">The id or slug of the list, for which the likes should be queried.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktListLike}"/> instance containing the queried list likes and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktListLike" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktListLike>> GetListLikesAsync(string usernameOrSlug, string listIdOrSlug,
                                                                          TraktPagedParameters pagedParameters = null,
                                                                          CancellationToken cancellationToken = default)
        {
            var request = new UserListLikesRequest
            {
                Username = usernameOrSlug,
                ListId = listIdOrSlug,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets all likes for an user's list.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/list-likes/get-all-users-who-liked-a-list">"Trakt API Doc - Users: List Likes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the list likes should be queried.</param>
        /// <param name="traktListId">The Trakt-ID of the list, for which the likes should be queried.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktListLike}"/> instance containing the queried list likes and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktListLike" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktPagedResponse<ITraktListLike>> GetListLikesAsync(string usernameOrSlug, uint traktListId,
                                                                          TraktPagedParameters pagedParameters = null,
                                                                          CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return GetListLikesAsync(usernameOrSlug, traktListId.ToString(), pagedParameters, cancellationToken);
        }

        /// <summary>
        /// Gets all likes for an user's list.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/list-likes/get-all-users-who-liked-a-list">"Trakt API Doc - Users: List Likes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the list likes should be queried.</param>
        /// <param name="listIds">The ids of the list, for which the likes should be queried.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktListLike}"/> instance containing the queried list likes and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktListLike" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktPagedResponse<ITraktListLike>> GetListLikesAsync(string usernameOrSlug, ITraktListIds listIds,
                                                                          TraktPagedParameters pagedParameters = null,
                                                                          CancellationToken cancellationToken = default)
        {
            if (listIds == null)
                throw new ArgumentNullException(nameof(listIds));

            if (!listIds.HasAnyId)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return GetListLikesAsync(usernameOrSlug, listIds.GetBestId(), pagedParameters, cancellationToken);
        }

        /// <summary>
        /// Gets all likes for an user's list.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/list-likes/get-all-users-who-liked-a-list">"Trakt API Doc - Users: List Likes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the list likes should be queried.</param>
        /// <param name="list">The list, for which the likes should be queried.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktListLike}"/> instance containing the queried list likes and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktListLike" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktPagedResponse<ITraktListLike>> GetListLikesAsync(string usernameOrSlug, ITraktList list,
                                                                          TraktPagedParameters pagedParameters = null,
                                                                          CancellationToken cancellationToken = default)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            return GetListLikesAsync(usernameOrSlug, list.Ids, pagedParameters, cancellationToken);
        }
    }
}
