namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Lists;
    using Requests.Handler;
    using Requests.Lists;
    using Requests.Parameters;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

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
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new ListsPopularRequest
            {
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
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
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new ListsTrendingRequest
            {
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets a <see cref="ITraktList" /> with the given Trakt-Id.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/list/get-list">"Trakt API Doc - Lists: Get List"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="listId">The list's Trakt-Id.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktList" /> instance with the queried list's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given listId is less or equal to 0.</exception>
        public Task<TraktResponse<ITraktList>> GetListAsync(int listId, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new SingleListRequest
            {
                Id = listId
            },
            cancellationToken);
        }
    }
}
