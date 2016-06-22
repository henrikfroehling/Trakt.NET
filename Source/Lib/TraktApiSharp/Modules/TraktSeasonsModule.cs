namespace TraktApiSharp.Modules
{
    using Enums;
    using Objects.Basic;
    using Objects.Get.Shows.Episodes;
    using Objects.Get.Shows.Seasons;
    using Requests;
    using Requests.WithoutOAuth.Shows.Seasons;
    using System;
    using System.Threading.Tasks;

    public class TraktSeasonsModule : TraktBaseModule
    {
        public TraktSeasonsModule(TraktClient client) : base(client) { }

        public async Task<TraktListResult<TraktSeason>> GetSeasonsAllAsync(string showId, TraktExtendedOption extended = null)
        {
            Validate(showId);

            return await QueryAsync(new TraktSeasonsAllRequest(Client)
            {
                Id = showId,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktListResult<TraktEpisode>> GetSeasonAsync(string showId, int season,
                                                                        TraktExtendedOption extended = null)
        {
            Validate(showId, season);

            return await QueryAsync(new TraktSeasonSingleRequest(Client)
            {
                Id = showId,
                Season = season,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktPaginationListResult<TraktComment>> GetSeasonCommentsAsync(string showId, int season,
                                                                                          TraktCommentSortOrder? sorting = null,
                                                                                          int? page = null, int? limit = null)
        {
            Validate(showId, season);

            return await QueryAsync(new TraktSeasonCommentsRequest(Client)
            {
                Id = showId,
                Season = season,
                Sorting = sorting,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktSeasonRating> GetSeasonRatingsAsync(string showId, int season)
        {
            Validate(showId, season);

            return await QueryAsync(new TraktSeasonRatingsRequest(Client)
            {
                Id = showId,
                Season = season
            });
        }

        public async Task<TraktSeasonStatistics> GetSeasonStatisticsAsync(string showId, int season)
        {
            Validate(showId, season);

            return await QueryAsync(new TraktSeasonStatisticsRequest(Client)
            {
                Id = showId,
                Season = season
            });
        }

        public async Task<TraktListResult<TraktSeasonWatchingUser>> GetSeasonWatchingUsersAsync(string showId, int season,
                                                                                                TraktExtendedOption extended = null)
        {
            Validate(showId, season);

            return await QueryAsync(new TraktSeasonWatchingUsersRequest(Client)
            {
                Id = showId,
                Season = season,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        private void Validate(string showId, int season = 0)
        {
            if (string.IsNullOrEmpty(showId))
                throw new ArgumentException("show id not valid", "showId");

            if (season < 0)
                throw new ArgumentException("season nr not valid", "season");
        }
    }
}
