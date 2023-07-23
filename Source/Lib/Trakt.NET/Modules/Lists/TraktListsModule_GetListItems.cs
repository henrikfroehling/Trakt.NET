namespace TraktNet.Modules
{
    using Enums;
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
        /// Gets the items on a list.
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/list-items/get-items-on-a-list">"Trakt API Doc - Lists: List Items"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="listIdOrSlug">The id or slug of the list, for which the items should be queried.</param>
        /// <param name="listItemType">Determines, which type of list items should be queried. See also <seealso cref="TraktListItemType" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the list items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktListItem" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktListItem>> GetListItemsAsync(string listIdOrSlug, TraktListItemType listItemType = null,
                                                                          TraktExtendedInfo extendedInfo = null, TraktPagedParameters pagedParameters = null,
                                                                          CancellationToken cancellationToken = default)
        {
            var request = new ListItemsRequest
            {
                Id = listIdOrSlug,
                Type = listItemType,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets the items on a list.
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/list-items/get-items-on-a-list">"Trakt API Doc - Lists: List Items"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktListId">The list's Trakt-Id. See also <seealso cref="ITraktListIds" />.</param>
        /// <param name="listItemType">Determines, which type of list items should be queried. See also <seealso cref="TraktListItemType" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the list items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktListItem" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktPagedResponse<ITraktListItem>> GetListItemsAsync(uint traktListId, TraktListItemType listItemType = null,
                                                                          TraktExtendedInfo extendedInfo = null, TraktPagedParameters pagedParameters = null,
                                                                          CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return GetListItemsAsync(traktListId.ToString(), listItemType, extendedInfo, pagedParameters, cancellationToken);
        }

        /// <summary>
        /// Gets the items on a list.
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/list-items/get-items-on-a-list">"Trakt API Doc - Lists: List Items"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="listIds">The list's ids. See also <seealso cref="ITraktListIds" />.</param>
        /// <param name="listItemType">Determines, which type of list items should be queried. See also <seealso cref="TraktListItemType" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the list items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktListItem" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        public Task<TraktPagedResponse<ITraktListItem>> GetListItemsAsync(ITraktListIds listIds, TraktListItemType listItemType = null,
                                                                          TraktExtendedInfo extendedInfo = null, TraktPagedParameters pagedParameters = null,
                                                                          CancellationToken cancellationToken = default)
        {
            if (listIds == null)
                throw new ArgumentNullException(nameof(listIds));

            return GetListItemsAsync(listIds.GetBestId(), listItemType, extendedInfo, pagedParameters, cancellationToken);
        }
    }
}
