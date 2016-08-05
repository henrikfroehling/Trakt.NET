namespace TraktApiSharp.Modules
{
    using Attributes;
    using Enums;
    using Objects.Basic;
    using Requests.WithoutOAuth.Genres;
    using System.Collections.Generic;
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
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktGenre>> GetMovieGenresAsync()
        {
            var movieGenres = await QueryAsync(new TraktGenresMoviesRequest(Client));

            foreach (var genre in movieGenres)
                genre.Type = TraktGenreType.Movies;

            return movieGenres;
        }

        /// <summary>
        /// Gets a list of all show genres.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/genres/list/get-genres">"Trakt API Doc - Genres: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <returns>A list of <see cref="TraktGenre" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktGenre>> GetShowGenresAsync()
        {
            var showGenres = await QueryAsync(new TraktGenresShowsRequest(Client));

            foreach (var genre in showGenres)
                genre.Type = TraktGenreType.Shows;

            return showGenres;
        }
    }
}
