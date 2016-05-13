namespace TraktApiSharp.Modules
{
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
        public TraktCheckinsModule(TraktClient client) : base(client) { }

        public async Task<TraktMovieCheckinPostResponse> CheckinMovieAsync(TraktMovie movie, TraktSharing sharing = null,
                                                                           string message = "", string foursquareVenueID = "",
                                                                           string foursquareVenueName = "", string appVersion = "",
                                                                           DateTime? appDate = null,
                                                                           TraktExtendedOption extended = TraktExtendedOption.Unspecified)
        {
            return await QueryAsync(new TraktCheckinMovieRequest(Client)
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
                    AppDate = appDate.HasValue ? appDate.Value.ToString("yyyy-MM-dd") : DateTime.UtcNow.ToString("yyyy-MM-dd")
                },
                ExtendedOption = extended
            });
        }

        public async Task<TraktEpisodeCheckinPostResponse> CheckinEpisodeAsync(TraktEpisode episode, TraktShow show = null, TraktSharing sharing = null,
                                                                               string message = "", string foursquareVenueID = "",
                                                                               string foursquareVenueName = "", string appVersion = "",
                                                                               DateTime? appDate = null,
                                                                               TraktExtendedOption extended = TraktExtendedOption.Unspecified)
        {
            return await QueryAsync(new TraktCheckinEpisodeRequest(Client)
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
                    AppDate = appDate.HasValue ? appDate.Value.ToString("yyyy-MM-dd") : DateTime.UtcNow.ToString("yyyy-MM-dd")
                },
                ExtendedOption = extended
            });
        }

        public async Task DeleteActiveCheckinsAsync()
        {
            await QueryAsync(new TraktCheckinsDeleteRequest(Client));
        }
    }
}
