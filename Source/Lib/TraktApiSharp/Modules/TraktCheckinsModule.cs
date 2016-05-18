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

        public async Task<TraktMovieCheckinPostResponse> CheckinMovieAsync(TraktMovie movie, string appVersion, DateTime appBuildDate,
                                                                           string message = null, TraktSharing sharing = null,
                                                                           string foursquareVenueID = null, string foursquareVenueName = null)
        {
            return await QueryAsync(new TraktCheckinRequest<TraktMovieCheckinPostResponse, TraktMovieCheckinPost>(Client)
            {
                RequestBody = new TraktMovieCheckinPost
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
                    FoursquareVenueName = foursquareVenueName,
                    AppVersion = appVersion,
                    AppDate = appBuildDate.ToString("yyyy-MM-dd")
                }
            });
        }

        public async Task<TraktEpisodeCheckinPostResponse> CheckinEpisodeAsync(TraktEpisode episode, string appVersion, DateTime appBuildDate,
                                                                               string message = null, TraktSharing sharing = null,
                                                                               string foursquareVenueID = null, string foursquareVenueName = null)
        {
            return await QueryAsync(new TraktCheckinRequest<TraktEpisodeCheckinPostResponse, TraktEpisodeCheckinPost>(Client)
            {
                RequestBody = new TraktEpisodeCheckinPost
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
                    FoursquareVenueName = foursquareVenueName,
                    AppVersion = appVersion,
                    AppDate = appBuildDate.ToString("yyyy-MM-dd")
                }
            });
        }

        public async Task<TraktEpisodeCheckinPostResponse> CheckinEpisodeAsync(TraktEpisode episode, TraktShow show,
                                                                               string appVersion, DateTime appBuildDate,
                                                                               string message = null, TraktSharing sharing = null,
                                                                               string foursquareVenueID = null, string foursquareVenueName = null)
        {
            return await QueryAsync(new TraktCheckinRequest<TraktEpisodeCheckinPostResponse, TraktEpisodeCheckinPost>(Client)
            {
                RequestBody = new TraktEpisodeCheckinPost
                {
                    Episode = new TraktEpisode
                    {
                        Ids = episode.Ids,
                        SeasonNumber = episode.SeasonNumber,
                        Number = episode.Number
                    },
                    Show = show != null ? new TraktShow
                    {
                        Title = show.Title
                    } : null,
                    Message = message,
                    Sharing = sharing,
                    FoursquareVenueId = foursquareVenueID,
                    FoursquareVenueName = foursquareVenueName,
                    AppVersion = appVersion,
                    AppDate = appBuildDate.ToString("yyyy-MM-dd")
                }
            });
        }

        public async Task DeleteActiveCheckinsAsync()
        {
            await QueryAsync(new TraktCheckinsDeleteRequest(Client));
        }
    }
}
