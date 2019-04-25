namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Basic;
    using Requests.Countries;
    using Requests.Handler;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to countries.
    /// <para>
    /// This module contains all methods of the <a href ="https://trakt.docs.apiary.io/#reference/countries">"Trakt API Doc - Countries"</a> section.
    /// </para>
    /// </summary>
    public class TraktCountriesModule : ATraktModule
    {
        internal TraktCountriesModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Gets a list of all movie countries.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/countries/list/get-countries">"Trakt API Doc - Countries: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktCountry" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktListResponse<ITraktCountry>> GetMovieCountriesAsync(CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            return await requestHandler.ExecuteListRequestAsync(new CountriesMoviesRequest(), cancellationToken);
        }

        /// <summary>
        /// Gets a list of all show countries.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/countries/list/get-countries">"Trakt API Doc - Countries: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktCountry" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktListResponse<ITraktCountry>> GetShowCountriesAsync(CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            return await requestHandler.ExecuteListRequestAsync(new CountriesShowsRequest(), cancellationToken);
        }
    }
}
