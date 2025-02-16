using System.Net;

namespace TraktNET
{
    public static class TraktTMDBExtensions
    {
        public static async Task<TMDBResponse<TMDBMovieImages>> GetTMDBImagesAsync(this TraktMovieMinimal traktMovie, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(TMDBResponse<TMDBMovieImages>.Create(HttpStatusCode.OK, null, null, null));
        }

        public static async Task<TMDBResponse<TMDBMovieImages>> GetTMDBImagesAsync(this TraktMovie traktMovie, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(TMDBResponse<TMDBMovieImages>.Create(HttpStatusCode.OK, null, null, null));
        }

        public static async Task<TMDBResponse<TMDBShowImages>> GetTMDBImagesAsync(this TraktShowMinimal traktShow, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(TMDBResponse<TMDBShowImages>.Create(HttpStatusCode.OK, null, null, null));
        }

        public static async Task<TMDBResponse<TMDBShowImages>> GetTMDBImagesAsync(this TraktShow traktShow, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(TMDBResponse<TMDBShowImages>.Create(HttpStatusCode.OK, null, null, null));
        }

        public static async Task<TMDBResponse<TMDBSeasonImages>> GetTMDBImagesAsync(this TraktSeasonMinimal traktSeason, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(TMDBResponse<TMDBSeasonImages>.Create(HttpStatusCode.OK, null, null, null));
        }

        public static async Task<TMDBResponse<TMDBSeasonImages>> GetTMDBImagesAsync(this TraktSeason traktSeason, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(TMDBResponse<TMDBSeasonImages>.Create(HttpStatusCode.OK, null, null, null));
        }

        public static async Task<TMDBResponse<TMDBEpisodeImages>> GetTMDBImagesAsync(this TraktEpisodeMinimal traktEpisode, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(TMDBResponse<TMDBEpisodeImages>.Create(HttpStatusCode.OK, null, null, null));
        }

        public static async Task<TMDBResponse<TMDBEpisodeImages>> GetTMDBImagesAsync(this TraktEpisode traktEpisode, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(TMDBResponse<TMDBEpisodeImages>.Create(HttpStatusCode.OK, null, null, null));
        }

        public static async Task<TMDBResponse<TMDBPersonImages>> GetTMDBImagesAsync(this TraktPersonMinimal traktPerson, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(TMDBResponse<TMDBPersonImages>.Create(HttpStatusCode.OK, null, null, null));
        }

        public static async Task<TMDBResponse<TMDBPersonImages>> GetTMDBImagesAsync(this TraktPerson traktPerson, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(TMDBResponse<TMDBPersonImages>.Create(HttpStatusCode.OK, null, null, null));
        }

        public static async Task<TMDBResponse<TMDBVideos>> GetTMDBVideosAsync(this TraktMovieMinimal traktMovie, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(TMDBResponse<TMDBVideos>.Create(HttpStatusCode.OK, null, null, null));
        }

        public static async Task<TMDBResponse<TMDBVideos>> GetTMDBVideosAsync(this TraktMovie traktMovie, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(TMDBResponse<TMDBVideos>.Create(HttpStatusCode.OK, null, null, null));
        }

        public static async Task<TMDBResponse<TMDBVideos>> GetTMDBVideosAsync(this TraktShowMinimal traktShow, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(TMDBResponse<TMDBVideos>.Create(HttpStatusCode.OK, null, null, null));
        }

        public static async Task<TMDBResponse<TMDBVideos>> GetTMDBVideosAsync(this TraktShow traktShow, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(TMDBResponse<TMDBVideos>.Create(HttpStatusCode.OK, null, null, null));
        }

        public static async Task<TMDBResponse<TMDBVideos>> GetTMDBVideosAsync(this TraktSeasonMinimal traktSeason, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(TMDBResponse<TMDBVideos>.Create(HttpStatusCode.OK, null, null, null));
        }

        public static async Task<TMDBResponse<TMDBVideos>> GetTMDBVideosAsync(this TraktSeason traktSeason, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(TMDBResponse<TMDBVideos>.Create(HttpStatusCode.OK, null, null, null));
        }

        public static async Task<TMDBResponse<TMDBVideos>> GetTMDBVideosAsync(this TraktEpisodeMinimal traktEpisode, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(TMDBResponse<TMDBVideos>.Create(HttpStatusCode.OK, null, null, null));
        }

        public static async Task<TMDBResponse<TMDBVideos>> GetTMDBVideosAsync(this TraktEpisode traktEpisode, CancellationToken cancellationToken = default)
        {
            // TODO
            return await Task.FromResult(TMDBResponse<TMDBVideos>.Create(HttpStatusCode.OK, null, null, null));
        }
    }
}
