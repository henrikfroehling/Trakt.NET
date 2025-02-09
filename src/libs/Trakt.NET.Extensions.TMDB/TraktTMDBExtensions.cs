namespace TraktNET
{
    public static class TraktTMDBExtensions
    {
        public static async Task<TMDBMovieImages> GetTMDBImagesAsync(this TraktMovieMinimal traktMovie, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(new TMDBMovieImages());
        }

        public static async Task<TMDBMovieImages> GetTMDBImagesAsync(this TraktMovie traktMovie, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(new TMDBMovieImages());
        }

        public static async Task<TMDBShowImages> GetTMDBImagesAsync(this TraktShowMinimal traktShow, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(new TMDBShowImages());
        }

        public static async Task<TMDBShowImages> GetTMDBImagesAsync(this TraktShow traktShow, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(new TMDBShowImages());
        }

        public static async Task<TMDBPersonImages> GetTMDBImagesAsync(this TraktPersonMinimal traktPerson, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(new TMDBPersonImages());
        }

        public static async Task<TMDBPersonImages> GetTMDBImagesAsync(this TraktPerson traktPerson, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(new TMDBPersonImages());
        }
    }
}
