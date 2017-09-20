namespace TraktApiSharp.Modules
{
    using Exceptions;
    using Objects.Basic;
    using Requests.Handler;
    using Requests.Networks;
    using Responses;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to networks.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/networks">"Trakt API Doc - Networks"</a> section.
    /// </para>
    /// </summary>
    public class TraktNetworksModule : ITraktModule
    {
        internal TraktNetworksModule(TraktClient client)
        {
            Client = client;
        }

        /// <summary>Gets a reference to the associated <see cref="TraktClient" /> instance.</summary>
        public TraktClient Client { get; }

        /// <summary>
        /// Gets a list of all networks.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/networks/list/get-networks">"Trakt API Doc - Networks: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of <see cref="ITraktNetwork" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktListResponse<ITraktNetwork>> GetNetworksAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteListRequestAsync(new NetworksRequest(), cancellationToken);
        }
    }
}
