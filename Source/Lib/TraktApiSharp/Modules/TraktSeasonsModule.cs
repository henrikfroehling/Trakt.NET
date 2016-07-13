namespace TraktApiSharp.Modules
{
    using Enums;
    using Extensions;
    using Objects.Basic;
    using Objects.Get.Shows.Episodes;
    using Objects.Get.Shows.Seasons;
    using Objects.Get.Users;
    using Requests;
    using Requests.Params;
    using Requests.WithoutOAuth.Shows.Seasons;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TraktSeasonsModule : TraktBaseModule
    {
        internal TraktSeasonsModule(TraktClient client) : base(client) { }

        public async Task<IEnumerable<TraktSeason>> GetAllSeasonsAsync(string showId, TraktExtendedOption extended = null)
        {
            Validate(showId);

            return await QueryAsync(new TraktSeasonsAllRequest(Client)
            {
                Id = showId,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<IEnumerable<TraktEpisode>> GetSeasonAsync(string showId, int season,
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

        public async Task<IEnumerable<IEnumerable<TraktEpisode>>> GetMultipleSeasonsAsync(TraktMultipleSeasonsQueryParams seasonsQueryParams)
        {
            if (seasonsQueryParams == null || seasonsQueryParams.Count <= 0)
                return new List<List<TraktEpisode>>();

            var tasks = new List<Task<IEnumerable<TraktEpisode>>>();

            foreach (var queryParam in seasonsQueryParams)
            {
                Task<IEnumerable<TraktEpisode>> task = GetSeasonAsync(queryParam.ShowId, queryParam.Season,
                                                                      queryParam.ExtendedOption);

                tasks.Add(task);
            }

            var seasons = await Task.WhenAll(tasks);
            return seasons.ToList();
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

        public async Task<TraktRating> GetSeasonRatingsAsync(string showId, int season)
        {
            Validate(showId, season);

            return await QueryAsync(new TraktSeasonRatingsRequest(Client)
            {
                Id = showId,
                Season = season
            });
        }

        public async Task<TraktStatistics> GetSeasonStatisticsAsync(string showId, int season)
        {
            Validate(showId, season);

            return await QueryAsync(new TraktSeasonStatisticsRequest(Client)
            {
                Id = showId,
                Season = season
            });
        }

        public async Task<IEnumerable<TraktUser>> GetSeasonWatchingUsersAsync(string showId, int season,
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
            if (string.IsNullOrEmpty(showId) || showId.ContainsSpace())
                throw new ArgumentException("show id not valid", nameof(showId));

            if (season < 0)
                throw new ArgumentException("season nr not valid", nameof(season));
        }
    }
}
