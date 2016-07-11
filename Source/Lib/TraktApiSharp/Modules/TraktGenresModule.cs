namespace TraktApiSharp.Modules
{
    using Enums;
    using Objects.Basic;
    using Requests.WithoutOAuth.Genres;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TraktGenresModule : TraktBaseModule
    {
        internal TraktGenresModule(TraktClient client) : base(client) { }

        public async Task<IEnumerable<TraktGenre>> GetMovieGenresAsync()
        {
            var movieGenres = await QueryAsync(new TraktGenresMoviesRequest(Client));

            foreach (var genre in movieGenres)
                genre.Type = TraktGenreType.Movies;

            return movieGenres;
        }

        public async Task<IEnumerable<TraktGenre>> GetShowGenresAsync()
        {
            var showGenres = await QueryAsync(new TraktGenresShowsRequest(Client));

            foreach (var genre in showGenres)
                genre.Type = TraktGenreType.Shows;

            return showGenres;
        }
    }
}
