namespace TraktApiSharp.Modules
{
    using Enums;
    using Objects.Basic;
    using Objects.Get.Shows.Episodes;
    using Requests;
    using Requests.WithoutOAuth.Shows.Episodes;
    using System;
    using System.Threading.Tasks;

    public class TraktEpisodesModule : TraktBaseModule
    {
        public TraktEpisodesModule(TraktClient client) : base(client) { }

        public async Task<TraktEpisode> GetEpisodeAsync(string showId, int season, int episode,
                                                        TraktExtendedOption extended = null)
        {
            Validate(showId, season, episode);

            return await QueryAsync(new TraktEpisodeSummaryRequest(Client)
            {
                Id = showId,
                Season = season,
                Episode = episode,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktPaginationListResult<TraktComment>> GetEpisodeCommentsAsync(string showId, int season, int episode,
                                                                                           TraktCommentSortOrder? sorting = null,
                                                                                           int? page = null, int? limit = null)
        {
            Validate(showId, season, episode);

            return await QueryAsync(new TraktEpisodeCommentsRequest(Client)
            {
                Id = showId,
                Season = season,
                Episode = episode,
                Sorting = sorting,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktEpisodeRating> GetEpisodeRatingsAsync(string showId, int season, int episode)
        {
            Validate(showId, season, episode);

            return await QueryAsync(new TraktEpisodeRatingsRequest(Client)
            {
                Id = showId,
                Season = season,
                Episode = episode
            });
        }

        public async Task<TraktEpisodeStatistics> GetEpisodeStatisticsAsync(string showId, int season, int episode)
        {
            Validate(showId, season, episode);

            return await QueryAsync(new TraktEpisodeStatisticsRequest(Client)
            {
                Id = showId,
                Season = season,
                Episode = episode
            });
        }

        public async Task<TraktListResult<TraktEpisodeWatchingUser>> GetEpisodeWatchingUsersAsync(string showId, int season, int episode,
                                                                                                  TraktExtendedOption extended = null)
        {
            Validate(showId, season, episode);

            return await QueryAsync(new TraktEpisodeWatchingUsersRequest(Client)
            {
                Id = showId,
                Season = season,
                Episode = episode,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        private void Validate(string showId, int season, int episode)
        {
            if (string.IsNullOrEmpty(showId))
                throw new ArgumentException("show id not valid", "showId");

            if (season < 0)
                throw new ArgumentException("season nr not valid", "season");

            if (episode < 0)
                throw new ArgumentException("episode nr not valid", "episode");
        }
    }
}
