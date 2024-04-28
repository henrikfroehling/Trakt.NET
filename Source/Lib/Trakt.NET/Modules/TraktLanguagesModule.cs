namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Basic;
    using Requests.Handler;
    using Requests.Languages;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to languages.
    /// <para>
    /// This module contains all methods of the <a href ="http://trakt.docs.apiary.io/#reference/languages">"Trakt API Doc - Languages"</a> section.
    /// </para>
    /// </summary>
    public class TraktLanguagesModule : ATraktModule
    {
        internal TraktLanguagesModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Gets a list of all movie languages.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/languages/list/get-languages">"Trakt API Doc - Languages: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktLanguage" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktListResponse<ITraktLanguage>> GetMovieLanguagesAsync(CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            return await requestHandler.ExecuteListRequestAsync(new LanguagesMoviesRequest(), cancellationToken);
        }

        /// <summary>
        /// Gets a list of all show languages.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/languages/list/get-languages">"Trakt API Doc - Languages: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktLanguage" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktListResponse<ITraktLanguage>> GetShowLanguagesAsync(CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            return await requestHandler.ExecuteListRequestAsync(new LanguagesShowsRequest(), cancellationToken);
        }
    }
}
