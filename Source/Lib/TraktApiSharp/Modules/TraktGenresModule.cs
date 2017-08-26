namespace TraktApiSharp.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Basic;
    using Requests.Genres;
    using Requests.Handler;
    using Responses;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to genres.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/genres">"Trakt API Doc - Genres"</a> section.
    /// </para>
    /// </summary>
    public class TraktGenresModule : ITraktModule
    {
        internal TraktGenresModule(TraktClient client)
        {
            Client = client;
        }

        /// <summary>Gets a reference to the associated <see cref="TraktClient" /> instance.</summary>
        public TraktClient Client { get; }

        /// <summary>
        /// Gets a list of all movie genres.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/genres/list/get-genres">"Trakt API Doc - Genres: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of <see cref="ITraktGenre" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktListResponse<ITraktGenre>> GetMovieGenresAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);
            var response = await requestHandler.ExecuteListRequestAsync(new TraktGenresMoviesRequest(), cancellationToken);

            if (response)
            {
                foreach (var genre in response)
                    genre.Type = TraktGenreType.Movies;
            }

            return response;
        }

        /// <summary>
        /// Gets a list of all show genres.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/genres/list/get-genres">"Trakt API Doc - Genres: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of <see cref="ITraktGenre" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktListResponse<ITraktGenre>> GetShowGenresAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);
            var response = await requestHandler.ExecuteListRequestAsync(new TraktGenresShowsRequest(), cancellationToken);

            if (response)
            {
                foreach (var genre in response)
                    genre.Type = TraktGenreType.Shows;
            }

            return response;
        }
    }
}
