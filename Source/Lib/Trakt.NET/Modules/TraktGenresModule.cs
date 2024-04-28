namespace TraktNet.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Basic;
    using Requests.Genres;
    using Requests.Handler;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to genres.
    /// <para>
    /// This module contains all methods of the <a href ="http://trakt.docs.apiary.io/#reference/genres">"Trakt API Doc - Genres"</a> section.
    /// </para>
    /// </summary>
    public class TraktGenresModule : ATraktModule
    {
        internal TraktGenresModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Gets a list of all movie genres.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/genres/list/get-genres">"Trakt API Doc - Genres: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktGenre" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktListResponse<ITraktGenre>> GetMovieGenresAsync(CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            TraktListResponse<ITraktGenre> response = await requestHandler.ExecuteListRequestAsync(new GenresMoviesRequest(), cancellationToken);

            if (response)
            {
                foreach (ITraktGenre genre in response)
                    genre.Type = TraktGenreType.Movies;
            }

            return response;
        }

        /// <summary>
        /// Gets a list of all show genres.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/genres/list/get-genres">"Trakt API Doc - Genres: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktGenre" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktListResponse<ITraktGenre>> GetShowGenresAsync(CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            TraktListResponse<ITraktGenre> response = await requestHandler.ExecuteListRequestAsync(new GenresShowsRequest(), cancellationToken);

            if (response)
            {
                foreach (ITraktGenre genre in response)
                    genre.Type = TraktGenreType.Shows;
            }

            return response;
        }
    }
}
