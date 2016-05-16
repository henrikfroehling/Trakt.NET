namespace TraktApiSharp.Modules
{
    using Enums;
    using Objects.Basic;
    using Objects.Get.Shows.Episodes;
    using Requests;
    using Requests.WithoutOAuth.Shows.Episodes;
    using System.Threading.Tasks;

    public class TraktEpisodesModule : TraktBaseModule
    {
        public TraktEpisodesModule(TraktClient client) : base(client) { }

        public async Task<TraktEpisode> GetEpisodeAsync(string showId, int season, int episode,
                                                        TraktExtendedOption extended = null)
        {
            return await QueryAsync(new TraktEpisodeSummaryRequest(Client)
            {
                Id = showId,
                Season = season,
                Episode = episode,
                ExtendedOption = extended != null ? extended : new TraktExtendedOption()
            });
        }

        public async Task<TraktPaginationListResult<TraktEpisodeComment>> GetEpisodeCommentsAsync(string showId, int season, int episode,
                                                                                                  TraktCommentSortOrder? sorting = null,
                                                                                                  int? page = null, int? limit = null)
        {
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
            return await QueryAsync(new TraktEpisodeRatingsRequest(Client)
            {
                Id = showId,
                Season = season,
                Episode = episode
            });
        }

        public async Task<TraktEpisodeStatistics> GetEpisodeStatisticsAsync(string showId, int season, int episode)
        {
            return await QueryAsync(new TraktEpisodeStatisticsRequest(Client)
            {
                Id = showId,
                Season = season,
                Episode = episode
            });
        }

        public async Task<TraktListResult<TraktEpisodeWatchingUser>> GetEpisodeWatchingUsersAsync(string showId, int season, int episode)
        {
            return await QueryAsync(new TraktEpisodeWatchingUsersRequest(Client)
            {
                Id = showId,
                Season = season,
                Episode = episode
            });
        }
    }
}
