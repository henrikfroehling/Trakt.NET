namespace TraktApiSharp.Modules
{
    using Enums;
    using Extensions;
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

        public async Task<TraktShow> GetShowAsync(string id, TraktExtendedOption extended = null)
        {
            Validate(id);

            return await QueryAsync(new TraktShowSummaryRequest(Client)
            {
                Id = id,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktListResult<TraktShow>> GetShowsAsync(string[] ids, TraktExtendedOption extended = null)
        {
            if (ids == null || ids.Length <= 0)
                return null;

            var shows = new List<TraktShow>(ids.Length);

            for (int i = 0; i < ids.Length; i++)
            {
                var show = await GetShowAsync(ids[i], extended);

                if (show != null)
                    shows.Add(show);
            }

            return new TraktListResult<TraktShow> { Items = shows };
        }

        public async Task<TraktListResult<TraktShowAlias>> GetShowAliasesAsync(string id)
        {
            Validate(id);

            return await QueryAsync(new TraktShowAliasesRequest(Client) { Id = id });
        }

        public async Task<TraktListResult<TraktShowTranslation>> GetShowTranslationsAsync(string id)
        {
            Validate(id);

            return await QueryAsync(new TraktShowTranslationsRequest(Client) { Id = id });
        }

        public async Task<TraktShowTranslation> GetShowSingleTranslationAsync(string id, string languageCode)
        {
            Validate(id, languageCode);

            return await QueryAsync(new TraktShowSingleTranslationRequest(Client)
            {
                Id = id,
                LanguageCode = languageCode
            });
        }

        public async Task<TraktPaginationListResult<TraktComment>> GetShowCommentsAsync(string id,
                                                                                        TraktCommentSortOrder? sorting = null,
                                                                                        int? page = null, int? limit = null)
        {
            Validate(id);

            return await QueryAsync(new TraktShowCommentsRequest(Client)
            {
                Id = id,
                Sorting = sorting,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktShowPeople> GetShowPeopleAsync(string id, TraktExtendedOption extended = null)
        {
            Validate(id);

            return await QueryAsync(new TraktShowPeopleRequest(Client)
            {
                Id = id,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktShowRating> GetShowRatingsAsync(string id)
        {
            Validate(id);

            return await QueryAsync(new TraktShowRatingsRequest(Client) { Id = id });
        }

        public async Task<TraktPaginationListResult<TraktShow>> GetShowRelatedShowsAsync(string id, TraktExtendedOption extended = null,
                                                                                         int? page = null, int? limit = null)
        {
            Validate(id);

            return await QueryAsync(new TraktShowRelatedShowsRequest(Client)
            {
                Id = id,
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktShowStatistics> GetShowStatisticsAsync(string id)
        {
            Validate(id);

            return await QueryAsync(new TraktShowStatisticsRequest(Client) { Id = id });
        }

        public async Task<TraktListResult<TraktShowWatchingUser>> GetShowWatchingUsersAsync(string id, TraktExtendedOption extended = null)
        {
            Validate(id);

            return await QueryAsync(new TraktShowWatchingUsersRequest(Client) { Id = id, ExtendedOption = extended ?? new TraktExtendedOption() });
        }

        public async Task<TraktShowCollectionProgress> GetShowCollectionProgressAsync(string id, bool? hidden = null, bool? specials = null)
        {
            Validate(id);

            return await QueryAsync(new TraktShowCollectionProgressRequest(Client)
            {
                Id = id,
                Hidden = hidden,
                Specials = specials
            });
        }

        public async Task<TraktShowWatchedProgress> GetShowWatchedProgressAsync(string id, bool? hidden = null, bool? specials = null)
        {
            Validate(id);

            return await QueryAsync(new TraktShowWatchedProgressRequest(Client)
            {
                Id = id,
                Hidden = hidden,
                Specials = specials
            });
        }

        public async Task<TraktPaginationListResult<TraktTrendingShow>> GetTrendingShowsAsync(TraktExtendedOption extended = null,
                                                                                              int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowsTrendingRequest(Client)
            {
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktShow>> GetPopularShowsAsync(TraktExtendedOption extended = null,
                                                                                     int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowsPopularRequest(Client)
            {
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktMostPlayedShow>> GetMostPlayedShowsAsync(TraktPeriod? period = null,
                                                                                                  TraktExtendedOption extended = null,
                                                                                                  int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowsMostPlayedRequest(Client)
            {
                Period = period,
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktMostWatchedShow>> GetMostWatchedShowsAsync(TraktPeriod? period = null,
                                                                                                    TraktExtendedOption extended = null,
                                                                                                    int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowsMostWatchedRequest(Client)
            {
                Period = period,
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktMostCollectedShow>> GetMostCollectedShowsAsync(TraktPeriod? period = null,
                                                                                                        TraktExtendedOption extended = null,
                                                                                                        int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowsMostCollectedRequest(Client)
            {
                Period = period,
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktMostAnticipatedShow>> GetMostAnticipatedShowsAsync(TraktExtendedOption extended = null,
                                                                                                            int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowsMostAnticipatedRequest(Client)
            {
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktRecentlyUpdatedShow>> GetRecentlyUpdatedShowsAsync(DateTime? startDate = null,
                                                                                                            TraktExtendedOption extended = null,
                                                                                                            int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktShowsRecentlyUpdatedRequest(Client)
            {
                StartDate = startDate,
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        private void Validate(string id)
        {
            if (string.IsNullOrEmpty(id) || id.ContainsSpace())
                throw new ArgumentException("show id not valid", nameof(id));
        }

        private void Validate(string id, string languageCode)
        {
            Validate(id);

            if (string.IsNullOrEmpty(languageCode) || languageCode.Length != 2)
                throw new ArgumentException("show language code not valid", nameof(languageCode));
        }
    }
}
