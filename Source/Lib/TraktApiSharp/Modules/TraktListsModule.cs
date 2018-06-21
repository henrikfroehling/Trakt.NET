namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Users.Lists;
    using Requests.Handler;
    using Requests.Lists;
    using Requests.Parameters;
    using Responses;
    using System.Threading;
    using System.Threading.Tasks;

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
        /// <param name="pagedParameters"></param>
        /// <param name="cancellationToken"></param>
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
            }, cancellationToken);
        }

        /// <summary>
        /// Gets trending lists.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/trending/get-trending-lists">"Trakt API Doc - Lists: Trending"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="pagedParameters"></param>
        /// <param name="cancellationToken"></param>
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
            }, cancellationToken);
        }
    }
}
