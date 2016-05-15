namespace TraktApiSharp.Modules
{
    using Enums;
    using Objects.Basic;
    using Objects.Get.Shows;
    using Objects.Get.Shows.Common;
    using Requests;
    using Requests.WithOAuth.Shows;
    using Requests.WithoutOAuth.Shows;
    using Requests.WithoutOAuth.Shows.Common;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TraktShowsModule : TraktBaseModule
    {
        public TraktShowsModule(TraktClient client) : base(client) { }

        public async Task<TraktShow> GetShowAsync(string id, TraktExtendedOption extended = TraktExtendedOption.Unspecified)
        {
            return await QueryAsync(new TraktShowSummaryRequest(Client)
            {
                Id = id,
                ExtendedOption = extended
            });
        }

        public async Task<TraktListResult<TraktShow>> GetShowsAsync(string[] ids, TraktExtendedOption extended = TraktExtendedOption.Unspecified)
        {
            if (ids == null || ids.Length <= 0)
                return null;

            var shows = new List<TraktShow>();

            foreach (var id in ids)
            {
                var show = await GetShowAsync(id, extended);

                if (show != null)
                    shows.Add(show);
            }

            return new TraktListResult<TraktShow> { Items = shows };
        }

        public async Task<TraktListResult<TraktShowAlias>> GetShowAliasesAsync(string id)
        {
            return await QueryAsync(new TraktShowAliasesRequest(Client)
            {
                Id = id
            });
        }

        public async Task<TraktListResult<TraktShowTranslation>> GetShowTranslationsAsync(string id)
        {
            return await QueryAsync(new TraktShowTranslationsRequest(Client)
            {
                Id = id
            });
        }

        public async Task<TraktShowTranslation> GetShowSingleTranslationAsync(string id, string languageCode)
        {
            return await QueryAsync(new TraktShowSingleTranslationRequest(Client)
            {
                Id = id,
                LanguageCode = languageCode
            });
        }

        public async Task<TraktPaginationListResult<TraktShowComment>> GetShowCommentsAsync(string id,
                                                                                            TraktCommentSortOrder sorting = TraktCommentSortOrder.Unspecified,
                                                                                            int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowCommentsRequest(Client)
            {
                Id = id,
                Sorting = sorting,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktShowPeople> GetShowPeopleAsync(string id)
        {
            return await QueryAsync(new TraktShowPeopleRequest(Client)
            {
                Id = id
            });
        }

        public async Task<TraktShowRating> GetShowRatingsAsync(string id)
        {
            return await QueryAsync(new TraktShowRatingsRequest(Client)
            {
                Id = id
            });
        }

        public async Task<TraktPaginationListResult<TraktShow>> GetShowRelatedShowsAsync(string id, int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowRelatedShowsRequest(Client)
            {
                Id = id,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktShowStatistics> GetShowStatisticsAsync(string id)
        {
            return await QueryAsync(new TraktShowStatisticsRequest(Client)
            {
                Id = id
            });
        }

        public async Task<TraktListResult<TraktShowWatchingUser>> GetShowWatchingUsersAsync(string id)
        {
            return await QueryAsync(new TraktShowWatchingUsersRequest(Client)
            {
                Id = id
            });
        }

        public async Task<TraktShowCollectionProgress> GetShowCollectionProgressAsync(string id, bool? hidden = false, bool? specials = false)
        {
            return await QueryAsync(new TraktShowCollectionProgressRequest(Client)
            {
                Id = id,
                Hidden = hidden,
                Specials = specials
            });
        }

        public async Task<TraktShowWatchedProgress> GetShowWatchedProgressAsync(string id, bool? hidden = false, bool? specials = false)
        {
            return await QueryAsync(new TraktShowWatchedProgressRequest(Client)
            {
                Id = id,
                Hidden = hidden,
                Specials = specials
            });
        }

        public async Task<TraktPaginationListResult<TraktTrendingShow>> GetTrendingShowsAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified,
                                                                                                   int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowsTrendingRequest(Client)
            {
                ExtendedOption = extended,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktPopularShow>> GetPopularShowsAsync(TraktExtendedOption extend = TraktExtendedOption.Unspecified,
                                                                                                 int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowsPopularRequest(Client)
            {
                ExtendedOption = extend,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktMostPlayedShow>> GetMostPlayedShowsAsync(TraktPeriod period = TraktPeriod.Weekly,
                                                                                                       TraktExtendedOption extended = TraktExtendedOption.Unspecified,
                                                                                                       int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowsMostPlayedRequest(Client)
            {
                Period = period,
                ExtendedOption = extended,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktMostWatchedShow>> GetMostWatchedShowsAsync(TraktPeriod period = TraktPeriod.Weekly,
                                                                                                         TraktExtendedOption extended = TraktExtendedOption.Unspecified,
                                                                                                         int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowsMostWatchedRequest(Client)
            {
                Period = period,
                ExtendedOption = extended,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktMostCollectedShow>> GetMostCollectedShowsAsync(TraktPeriod period = TraktPeriod.Weekly,
                                                                                                             TraktExtendedOption extended = TraktExtendedOption.Unspecified,
                                                                                                             int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowsMostCollectedRequest(Client)
            {
                Period = period,
                ExtendedOption = extended,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktShowsMostAnticipatedItem>> GetMostAnticipatedShowsAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified,
                                                                                                                 int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowsMostAnticipatedRequest(Client)
            {
                ExtendedOption = extended,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktShowsRecentlyUpdatedItem>> GetRecentlyUpdatedShowsAsync(DateTime? startDate,
                                                                                                                 TraktExtendedOption extended = TraktExtendedOption.Unspecified,
                                                                                                                 int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowsRecentlyUpdatedRequest(Client)
            {
                StartDate = startDate,
                ExtendedOption = extended,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }
    }
}
