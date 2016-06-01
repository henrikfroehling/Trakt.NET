namespace TraktApiSharp.Modules
{
    using Objects.Basic;
    using Objects.Get.Movies;
    using Objects.Get.Shows;
    using Objects.Get.Shows.Episodes;
    using Objects.Post.Checkins;
    using Objects.Post.Checkins.Responses;
    using Requests.WithOAuth.Checkins;
    using System;
    using System.Threading.Tasks;

    public class TraktCheckinsModule : TraktBaseModule
    {
        public TraktCheckinsModule(TraktClient client) : base(client) { }

        public async Task<TraktMovieCheckinPostResponse> CheckinMovieAsync(TraktMovie movie, string appVersion = null, DateTime? appBuildDate = null,
                                                                           string message = null, TraktSharing sharing = null,
                                                                           string foursquareVenueID = null, string foursquareVenueName = null)
        {
            Validate(movie);

            var requestBody = new TraktMovieCheckinPost
            {
                Movie = new TraktMovie
                {
                    Title = movie.Title,
                    Year = movie.Year,
                    Ids = movie.Ids
                },
                Message = message,
                Sharing = sharing,
                FoursquareVenueId = foursquareVenueID,
                FoursquareVenueName = foursquareVenueName
            };

            if (!string.IsNullOrEmpty(appVersion))
                requestBody.AppVersion = appVersion;

            if (appBuildDate.HasValue)
                requestBody.AppDate = appBuildDate.Value.ToString("yyyy-MM-dd");

            return await QueryAsync(new TraktCheckinRequest<TraktMovieCheckinPostResponse, TraktMovieCheckinPost>(Client) { RequestBody = requestBody });
        }

        public async Task<TraktEpisodeCheckinPostResponse> CheckinEpisodeAsync(TraktEpisode episode, string appVersion = null, DateTime? appBuildDate = null,
                                                                               string message = null, TraktSharing sharing = null,
                                                                               string foursquareVenueID = null, string foursquareVenueName = null)
        {
            Validate(episode);

            var requestBody = new TraktEpisodeCheckinPost
            {
                Episode = new TraktEpisode
                {
                    Ids = episode.Ids,
                    SeasonNumber = episode.SeasonNumber,
                    Number = episode.Number
                },
                Show = null,
                Message = message,
                Sharing = sharing,
                FoursquareVenueId = foursquareVenueID,
                FoursquareVenueName = foursquareVenueName
            };

            if (!string.IsNullOrEmpty(appVersion))
                requestBody.AppVersion = appVersion;

            if (appBuildDate.HasValue)
                requestBody.AppDate = appBuildDate.Value.ToString("yyyy-MM-dd");

            return await QueryAsync(new TraktCheckinRequest<TraktEpisodeCheckinPostResponse, TraktEpisodeCheckinPost>(Client) { RequestBody = requestBody });
        }

        public async Task<TraktEpisodeCheckinPostResponse> CheckinEpisodeAsync(TraktEpisode episode, TraktShow show,
                                                                               string appVersion = null, DateTime? appBuildDate = null,
                                                                               string message = null, TraktSharing sharing = null,
                                                                               string foursquareVenueID = null, string foursquareVenueName = null)
        {
            Validate(episode, show);

            var requestBody = new TraktEpisodeCheckinPost
            {
                Episode = new TraktEpisode
                {
                    Ids = episode.Ids,
                    SeasonNumber = episode.SeasonNumber,
                    Number = episode.Number
                },
                Show = new TraktShow { Title = show.Title },
                Message = message,
                Sharing = sharing,
                FoursquareVenueId = foursquareVenueID,
                FoursquareVenueName = foursquareVenueName
            };

            if (!string.IsNullOrEmpty(appVersion))
                requestBody.AppVersion = appVersion;

            if (appBuildDate.HasValue)
                requestBody.AppDate = appBuildDate.Value.ToString("yyyy-MM-dd");

            return await QueryAsync(new TraktCheckinRequest<TraktEpisodeCheckinPostResponse, TraktEpisodeCheckinPost>(Client) { RequestBody = requestBody });
        }

        public async Task DeleteActiveCheckinsAsync()
        {
            await QueryAsync(new TraktCheckinsDeleteRequest(Client));
        }

        private void Validate(TraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException("movie", "movie instance must not be null");

            if (string.IsNullOrEmpty(movie.Title))
                throw new ArgumentException("movie title not valid", "movie");

            if (movie.Year <= 0)
                throw new ArgumentException("movie year not valid", "movie");

            if (movie.Ids == null)
                throw new ArgumentNullException("movie.Ids", "movie.Ids must not be null");

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("movie.Ids have no valid id", "movie");
        }

        private void Validate(TraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException("episode", "episode instance must not be null");

            if (episode.Ids == null)
                throw new ArgumentNullException("episode.Ids", "episode.Ids must not be null");

            if (!episode.Ids.HasAnyId)
                throw new ArgumentException("episode.Ids have no valid id", "episode");

            if (episode.SeasonNumber < 0)
                throw new ArgumentException("episode season number not valid", "episode");

            if (episode.Number < 0)
                throw new ArgumentException("episode number not valid", "episode");
        }

        private void Validate(TraktEpisode episode, TraktShow show)
        {
            Validate(episode);

            if (show == null)
                throw new ArgumentNullException("show", "show instance must not be null");

            if (string.IsNullOrEmpty(show.Title))
                throw new ArgumentException("show title not valid", "show");
        }
    }
}
