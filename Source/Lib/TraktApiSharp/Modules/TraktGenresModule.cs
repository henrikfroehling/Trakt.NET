namespace TraktApiSharp.Modules
{
    using Attributes;
    using Enums;
    using Exceptions;
    using Objects.Basic;
    using Requests.Genres;
    using Requests.Handler;
    using Responses;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to genres.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/genres">"Trakt API Doc - Genres"</a> section.
    /// </para>
    /// </summary>
    public class TraktGenresModule : TraktBaseModule
    {
        internal TraktGenresModule(TraktClient client) : base(client) { }

        /// <summary>
        /// Gets a list of all movie genres.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/genres/list/get-genres">"Trakt API Doc - Genres: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <returns>A list of <see cref="TraktGenre" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktListResponse<TraktGenre>> GetMovieGenresAsync()
        {
            var requestHandler = new TraktRequestHandler(Client);
            var response = await requestHandler.ExecuteListRequestAsync(new TraktGenresMoviesRequest());

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
        /// <returns>A list of <see cref="TraktGenre" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktListResponse<TraktGenre>> GetShowGenresAsync()
        {
            var requestHandler = new TraktRequestHandler(Client);
            var response = await requestHandler.ExecuteListRequestAsync(new TraktGenresShowsRequest());

            if (response)
            {
                foreach (var genre in response)
                    genre.Type = TraktGenreType.Shows;
            }

            return response;
        }
    }
}
