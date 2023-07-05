namespace TraktNet.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Get.Lists;
    using Requests.Handler;
    using Requests.Lists;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Basic;
    using TraktNet.Parameters;

    /// <summary>
    /// Provides access to data retrieving methods specific to lists.
    /// <para>
    /// This module contains all methods of the <a href ="https://trakt.docs.apiary.io/#reference/lists">"Trakt API Doc - Lists"</a> section.
    /// </para>
    /// </summary>
    public class TraktListsModule : ATraktModule
    {
        internal TraktListsModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Gets popular lists.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/popular/get-popular-lists">"Trakt API Doc - Lists: Popular"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktList}"/> instance containing the queried popular lists and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktList" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktList>> GetPopularListsAsync(TraktPagedParameters pagedParameters = null,
                                                                         CancellationToken cancellationToken = default)
        {
            var request = new ListsPopularRequest
            {
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets trending lists.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/trending/get-trending-lists">"Trakt API Doc - Lists: Trending"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktList}"/> instance containing the queried trending lists and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktList" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktList>> GetTrendingListsAsync(TraktPagedParameters pagedParameters = null,
                                                                          CancellationToken cancellationToken = default)
        {
            var request = new ListsTrendingRequest
            {
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets a <see cref="ITraktList" /> with the given Trakt-Id.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/list/get-list">"Trakt API Doc - Lists: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="listIdOrSlug">The list's Trakt-Id or -Slug. See also <seealso cref="ITraktListIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktList" /> instance with the queried list's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktList>> GetListAsync(string listIdOrSlug, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new SingleListRequest
            {
                Id = listIdOrSlug
            },
            cancellationToken);
        }

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
        /// Gets top level comments for a list.
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/list-comments/get-all-list-comments">"Trakt API Doc - Lists: List Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="listIdOrSlug">The id or slug of the list, for which the comments should be queried.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktComment}"/> instance containing the queried list comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktComment>> GetListCommentsAsync(string listIdOrSlug, TraktCommentSortOrder commentSortOrder = null,
                                                                            TraktPagedParameters pagedParameters = null,
                                                                            CancellationToken cancellationToken = default)
        {
            var request = new ListCommentsRequest
            {
                Id = listIdOrSlug,
                SortOrder = commentSortOrder,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }
    }
}
