namespace TraktApiSharp.Modules
{
    using Extensions;
    using Objects.Basic;
    using Objects.Get.Movies;
    using Objects.Get.Shows;
    using Objects.Get.Shows.Episodes;
    using Objects.Post.Checkins;
    using Objects.Post.Checkins.Responses;
    using Requests;
    using Requests.WithOAuth.Checkins;
    using System;
    using System.Threading.Tasks;

    public class TraktCheckinsModule : TraktBaseModule
    {
        internal TraktCheckinsModule(TraktClient client) : base(client) { }

        public async Task<TraktMovieCheckinPostResponse> CheckIntoMovieAsync(TraktMovie movie, string appVersion = null, DateTime? appBuildDate = null,
                                                                             string message = null, TraktSharing sharing = null,
                                                                             string foursquareVenueID = null, string foursquareVenueName = null,
                                                                             TraktExtendedOption extended = null)
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
                requestBody.AppDate = appBuildDate.Value.ToTraktDateString();

            return await QueryAsync(new TraktCheckinRequest<TraktMovieCheckinPostResponse, TraktMovieCheckinPost>(Client)
            {
                RequestBody = requestBody,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktEpisodeCheckinPostResponse> CheckIntoEpisodeAsync(TraktEpisode episode, string appVersion = null, DateTime? appBuildDate = null,
                                                                                 string message = null, TraktSharing sharing = null,
                                                                                 string foursquareVenueID = null, string foursquareVenueName = null,
                                                                                 TraktExtendedOption extended = null)
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
                requestBody.AppDate = appBuildDate.Value.ToTraktDateString();

            return await QueryAsync(new TraktCheckinRequest<TraktEpisodeCheckinPostResponse, TraktEpisodeCheckinPost>(Client)
            {
                RequestBody = requestBody,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktEpisodeCheckinPostResponse> CheckIntoEpisodeWithShowAsync(TraktEpisode episode, TraktShow show,
                                                                                         string appVersion = null, DateTime? appBuildDate = null,
                                                                                         string message = null, TraktSharing sharing = null,
                                                                                         string foursquareVenueID = null, string foursquareVenueName = null,
                                                                                         TraktExtendedOption extended = null)
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
                requestBody.AppDate = appBuildDate.Value.ToTraktDateString();

            return await QueryAsync(new TraktCheckinRequest<TraktEpisodeCheckinPostResponse, TraktEpisodeCheckinPost>(Client)
            {
                RequestBody = requestBody,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task DeleteAnyActiveCheckinsAsync()
        {
            await QueryAsync(new TraktCheckinsDeleteRequest(Client));
        }

        private void Validate(TraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentException("movie must not be null", nameof(movie));

            if (string.IsNullOrEmpty(movie.Title))
                throw new ArgumentException("movie title not valid", nameof(movie.Title));

            if (movie.Year <= 0)
                throw new ArgumentException("movie year not valid", nameof(movie));

            if (movie.Ids == null)
                throw new ArgumentException("movie.Ids must not be null", nameof(movie.Ids));

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("movie.Ids have no valid id", nameof(movie.Ids));
        }

        private void Validate(TraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentException("episode must not be null", nameof(episode));

            if (episode.Ids == null)
                throw new ArgumentException("episode.Ids must not be null", nameof(episode.Ids));

            if (!episode.Ids.HasAnyId)
                throw new ArgumentException("episode.Ids have no valid id", nameof(episode.Ids));
        }

        private void Validate(TraktEpisode episode, TraktShow show)
        {
            if (episode == null)
                throw new ArgumentException("episode must not be null", nameof(episode));

            if (episode.SeasonNumber < 0)
                throw new ArgumentException("episode season number not valid", nameof(episode.SeasonNumber));

            if (episode.Number < 0)
                throw new ArgumentException("episode number not valid", nameof(episode.Number));

            if (show == null)
                throw new ArgumentException("show must not be null", nameof(show));

            if (string.IsNullOrEmpty(show.Title))
                throw new ArgumentException("show title not valid", nameof(show.Title));
        }
    }
}
