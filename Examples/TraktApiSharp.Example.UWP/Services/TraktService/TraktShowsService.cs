namespace TraktApiSharp.Example.UWP.Services.TraktService
{
    using Enums;
    using Models;
    using Models.Shows;
    using Requests;
    using Requests.WithoutOAuth.Shows;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TraktShowsService
    {
        private TraktClient _client = TraktServiceProvider.Client;

        // -------------------------------------------------------------
        // Single Show

        public async Task<Show> GetShowAsync(string showId, TraktExtendedOption extendedInfo = null)
        {
            var show = await _client.Shows.GetShowAsync(showId, extendedInfo) as Show;

            show.Aliases = await _client.Shows.GetShowAliasesAsync(showId);
            show.Translations = await _client.Shows.GetShowTranslationsAsync(showId);
            show.ShowRating = await _client.Shows.GetShowRatingsAsync(showId);
            show.Statistics = await _client.Shows.GetShowStatisticsAsync(showId);

            return show;
        }

        // -------------------------------------------------------------
        // Trending Shows

        public async Task<PaginationList<TrendingShow>> GetTrendingShowsAsync(TraktExtendedOption extendedInfo = null,
                                                                              TraktShowFilter showFilter = null,
                                                                              int? whichPage = null, int? limitPerPage = null)
        {
            var traktResults = await _client.Shows.GetTrendingShowsAsync(extendedInfo, showFilter, whichPage, limitPerPage);

            var results = new PaginationList<TrendingShow>
            {
                CurrentPage = traktResults.Page,
                TotalPages = traktResults.PageCount,
                LimitPerPage = traktResults.Limit,
                TotalItemCount = traktResults.ItemCount,
                TotalUserCount = traktResults.UserCount
            };

            results.Items = new List<TrendingShow>();

            foreach (var traktTrendingShow in traktResults.Items)
            {
                var trendingShow = traktTrendingShow.Show as TrendingShow;
                trendingShow.Watchers = traktTrendingShow.Watchers;
                results.Items.Add(trendingShow);
            }

            return results;
        }

        // -------------------------------------------------------------
        // Popular Shows

        public async Task<PaginationList<Show>> GetPopularShowsAsync(TraktExtendedOption extendedInfo = null,
                                                                     TraktShowFilter showFilter = null,
                                                                     int? whichPage = null, int? limitPerPage = null)
        {
            var traktResults = await _client.Shows.GetPopularShowsAsync(extendedInfo, showFilter, whichPage, limitPerPage);

            var results = new PaginationList<Show>
            {
                CurrentPage = traktResults.Page,
                TotalPages = traktResults.PageCount,
                LimitPerPage = traktResults.Limit,
                TotalItemCount = traktResults.ItemCount,
                TotalUserCount = traktResults.UserCount
            };

            results.Items = new List<Show>();

            foreach (var traktPopularShow in traktResults.Items)
                results.Items.Add(traktPopularShow as Show);

            return results;
        }

        // -------------------------------------------------------------
        // Most Played Shows

        public async Task<PaginationList<MostPWCShow>> GetMostPlayedShowsAsync(TraktExtendedOption extendedInfo = null,
                                                                               TraktShowFilter showFilter = null,
                                                                               TraktPeriod? period = null,
                                                                               int? whichPage = null, int? limitPerPage = null)
        {
            var traktResults = await _client.Shows.GetMostPlayedShowsAsync(period, extendedInfo, showFilter, whichPage, limitPerPage);

            var results = new PaginationList<MostPWCShow>
            {
                CurrentPage = traktResults.Page,
                TotalPages = traktResults.PageCount,
                LimitPerPage = traktResults.Limit,
                TotalItemCount = traktResults.ItemCount,
                TotalUserCount = traktResults.UserCount
            };

            results.Items = new List<MostPWCShow>();

            foreach (var traktMostPlayedShow in traktResults.Items)
            {
                var mostPlayedShow = traktMostPlayedShow.Show as MostPWCShow;

                mostPlayedShow.CollectedCount = traktMostPlayedShow.CollectedCount;
                mostPlayedShow.PlayCount = traktMostPlayedShow.PlayCount;
                mostPlayedShow.WatcherCount = traktMostPlayedShow.WatcherCount;

                results.Items.Add(mostPlayedShow);
            }

            return results;
        }

        // -------------------------------------------------------------
        // Most Watched Shows

        public async Task<PaginationList<MostPWCShow>> GetMostWatchedShowsAsync(TraktExtendedOption extendedInfo = null,
                                                                                TraktShowFilter showFilter = null,
                                                                                TraktPeriod? period = null,
                                                                                int? whichPage = null, int? limitPerPage = null)
        {
            var traktResults = await _client.Shows.GetMostWatchedShowsAsync(period, extendedInfo, showFilter, whichPage, limitPerPage);

            var results = new PaginationList<MostPWCShow>
            {
                CurrentPage = traktResults.Page,
                TotalPages = traktResults.PageCount,
                LimitPerPage = traktResults.Limit,
                TotalItemCount = traktResults.ItemCount,
                TotalUserCount = traktResults.UserCount
            };

            results.Items = new List<MostPWCShow>();

            foreach (var traktMostWatchedShow in traktResults.Items)
            {
                var mostWatchedShow = traktMostWatchedShow.Show as MostPWCShow;

                mostWatchedShow.CollectedCount = traktMostWatchedShow.CollectedCount;
                mostWatchedShow.PlayCount = traktMostWatchedShow.PlayCount;
                mostWatchedShow.WatcherCount = traktMostWatchedShow.WatcherCount;

                results.Items.Add(mostWatchedShow);
            }

            return results;
        }

        // -------------------------------------------------------------
        // Most Collected Shows

        public async Task<PaginationList<MostPWCShow>> GetMostCollectedShowsAsync(TraktExtendedOption extendedInfo = null,
                                                                                  TraktShowFilter showFilter = null,
                                                                                  TraktPeriod? period = null,
                                                                                  int? whichPage = null, int? limitPerPage = null)
        {
            var traktResults = await _client.Shows.GetMostCollectedShowsAsync(period, extendedInfo, showFilter, whichPage, limitPerPage);

            var results = new PaginationList<MostPWCShow>
            {
                CurrentPage = traktResults.Page,
                TotalPages = traktResults.PageCount,
                LimitPerPage = traktResults.Limit,
                TotalItemCount = traktResults.ItemCount,
                TotalUserCount = traktResults.UserCount
            };

            results.Items = new List<MostPWCShow>();

            foreach (var traktMostCollectedShow in traktResults.Items)
            {
                var mostCollectedShow = traktMostCollectedShow.Show as MostPWCShow;

                mostCollectedShow.CollectedCount = traktMostCollectedShow.CollectedCount;
                mostCollectedShow.PlayCount = traktMostCollectedShow.PlayCount;
                mostCollectedShow.WatcherCount = traktMostCollectedShow.WatcherCount;

                results.Items.Add(mostCollectedShow);
            }

            return results;
        }

        // -------------------------------------------------------------
        // Most Anticipated Shows

        public async Task<PaginationList<AnticipatedShow>> GetMostAnticipatedShowsAsync(TraktExtendedOption extendedInfo = null,
                                                                                        TraktShowFilter showFilter = null,
                                                                                        int? whichPage = null, int? limitPerPage = null)
        {
            var traktResults = await _client.Shows.GetMostAnticipatedShowsAsync(extendedInfo, showFilter, whichPage, limitPerPage);

            var results = new PaginationList<AnticipatedShow>
            {
                CurrentPage = traktResults.Page,
                TotalPages = traktResults.PageCount,
                LimitPerPage = traktResults.Limit,
                TotalItemCount = traktResults.ItemCount,
                TotalUserCount = traktResults.UserCount
            };

            results.Items = new List<AnticipatedShow>();

            foreach (var traktAnticipatedShow in traktResults.Items)
            {
                var anticipatedShow = traktAnticipatedShow.Show as AnticipatedShow;
                anticipatedShow.ListCount = traktAnticipatedShow.ListCount;
                results.Items.Add(anticipatedShow);
            }

            return results;
        }

        // -------------------------------------------------------------
        // Recently Updated Shows

        public async Task<PaginationList<RecentlyUpdatedShow>> GetRecentlyUpdatedShowsAsync(DateTime? startDate = null,
                                                                                            TraktExtendedOption extendedInfo = null,
                                                                                            int? whichPage = null, int? limitPerPage = null)
        {
            var traktResults = await _client.Shows.GetRecentlyUpdatedShowsAsync(startDate, extendedInfo, whichPage, limitPerPage);

            var results = new PaginationList<RecentlyUpdatedShow>
            {
                CurrentPage = traktResults.Page,
                TotalPages = traktResults.PageCount,
                LimitPerPage = traktResults.Limit,
                TotalItemCount = traktResults.ItemCount,
                TotalUserCount = traktResults.UserCount
            };

            results.Items = new List<RecentlyUpdatedShow>();

            foreach (var traktRecentlyUpdatedShow in traktResults.Items)
            {
                var recentlyUpdatedShow = traktRecentlyUpdatedShow.Show as RecentlyUpdatedShow;
                recentlyUpdatedShow.ShowUpdatedAt = traktRecentlyUpdatedShow.UpdatedAt;
                results.Items.Add(recentlyUpdatedShow);
            }

            return results;
        }
    }
}
