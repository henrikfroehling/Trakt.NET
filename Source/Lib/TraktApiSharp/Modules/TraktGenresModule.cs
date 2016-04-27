namespace TraktApiSharp.Modules
{
    using Enums;
    using Objects.Basic;
    using Requests.WithoutOAuth.Genres;
    using System.Threading.Tasks;

    public class TraktGenresModule : TraktBaseModule
    {
        public TraktGenresModule(TraktClient client) : base(client) { }

        public async Task<TraktListResult<TraktGenre>> GetMovieGenresAsync()
        {
            var movieGenres = await QueryAsync(new TraktGenresMoviesRequest(Client));

            foreach (var genre in movieGenres.Items)
                genre.Type = TraktGenreType.Movies;

            return movieGenres;
        }

        public async Task<TraktListResult<TraktGenre>> GetShowGenresAsync()
        {
            var showGenres = await QueryAsync(new TraktGenresShowsRequest(Client));

            foreach (var genre in showGenres.Items)
                genre.Type = TraktGenreType.Shows;

            return showGenres;
        }
    }
}
