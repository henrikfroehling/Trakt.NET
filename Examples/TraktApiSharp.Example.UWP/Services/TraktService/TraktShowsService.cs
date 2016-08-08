namespace TraktApiSharp.Example.UWP.Services.TraktService
{
    using Enums;
    using Models;
    using Models.Shows;
    using Objects.Get.Shows;
    using Requests.Params;
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    public class TraktShowsService
    {
        private TraktClient Client { get; }

        private TraktShowsService()
        {
            Client = TraktServiceProvider.Instance.Client;
        }

        public static TraktShowsService Instance { get; } = new TraktShowsService();

        // -------------------------------------------------------------
        // Single Show

        public async Task<Show> GetShowAsync(string showId, TraktExtendedOption extendedInfo = null,
                                             bool withAdditionalContent = false)
        {
            var show = await Client.Shows.GetShowAsync(showId, extendedInfo) as Show;

            if (withAdditionalContent)
            {
                var aliases = await Client.Shows.GetShowAliasesAsync(showId);
                show.Aliases = new ObservableCollection<TraktShowAlias>(aliases);

                var translations = await Client.Shows.GetShowTranslationsAsync(showId);
                show.Translations = new ObservableCollection<TraktShowTranslation>(translations);

                show.ShowRating = await Client.Shows.GetShowRatingsAsync(showId);
                show.Statistics = await Client.Shows.GetShowStatisticsAsync(showId);
            }

            return show;
        }

        // -------------------------------------------------------------
        // Trending Shows

        public async Task<PaginationList<TrendingShow>> GetTrendingShowsAsync(TraktExtendedOption extendedInfo = null,
                                                                              TraktShowFilter showFilter = null,
                                                                              int? whichPage = null, int? limitPerPage = null)
        {
            var traktResults = await Client.Shows.GetTrendingShowsAsync(extendedInfo, showFilter, whichPage, limitPerPage);

            var results = new PaginationList<TrendingShow>
            {
                CurrentPage = traktResults.Page,
                TotalPages = traktResults.PageCount,
                LimitPerPage = traktResults.Limit,
                TotalItemCount = traktResults.ItemCount,
                TotalUserCount = traktResults.UserCount
            };

            results.Items = new ObservableCollection<TrendingShow>();

            foreach (var traktTrendingShow in traktResults)
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
            var traktResults = await Client.Shows.GetPopularShowsAsync(extendedInfo, showFilter, whichPage, limitPerPage);

            var results = new PaginationList<Show>
            {
                CurrentPage = traktResults.Page,
                TotalPages = traktResults.PageCount,
                LimitPerPage = traktResults.Limit,
                TotalItemCount = traktResults.ItemCount,
                TotalUserCount = traktResults.UserCount
            };

            results.Items = new ObservableCollection<Show>();

            foreach (var traktPopularShow in traktResults)
                results.Items.Add(traktPopularShow as Show);

            return results;
        }

        // -------------------------------------------------------------
        // Most Played Shows

        public async Task<PaginationList<MostPWCShow>> GetMostPlayedShowsAsync(TraktExtendedOption extendedInfo = null,
                                                                               TraktShowFilter showFilter = null,
                                                                               TraktTimePeriod period = null,
                                                                               int? whichPage = null, int? limitPerPage = null)
        {
            var traktResults = await Client.Shows.GetMostPlayedShowsAsync(period, extendedInfo, showFilter, whichPage, limitPerPage);

            var results = new PaginationList<MostPWCShow>
            {
                CurrentPage = traktResults.Page,
                TotalPages = traktResults.PageCount,
                LimitPerPage = traktResults.Limit,
                TotalItemCount = traktResults.ItemCount,
                TotalUserCount = traktResults.UserCount
            };

            results.Items = new ObservableCollection<MostPWCShow>();

            foreach (var traktMostPlayedShow in traktResults)
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
                                                                                TraktTimePeriod period = null,
                                                                                int? whichPage = null, int? limitPerPage = null)
        {
            var traktResults = await Client.Shows.GetMostWatchedShowsAsync(period, extendedInfo, showFilter, whichPage, limitPerPage);

            var results = new PaginationList<MostPWCShow>
            {
                CurrentPage = traktResults.Page,
                TotalPages = traktResults.PageCount,
                LimitPerPage = traktResults.Limit,
                TotalItemCount = traktResults.ItemCount,
                TotalUserCount = traktResults.UserCount
            };

            results.Items = new ObservableCollection<MostPWCShow>();

            foreach (var traktMostWatchedShow in traktResults)
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
                                                                                  TraktTimePeriod period = null,
                                                                                  int? whichPage = null, int? limitPerPage = null)
        {
            var traktResults = await Client.Shows.GetMostCollectedShowsAsync(period, extendedInfo, showFilter, whichPage, limitPerPage);

            var results = new PaginationList<MostPWCShow>
            {
                CurrentPage = traktResults.Page,
                TotalPages = traktResults.PageCount,
                LimitPerPage = traktResults.Limit,
                TotalItemCount = traktResults.ItemCount,
                TotalUserCount = traktResults.UserCount
            };

            results.Items = new ObservableCollection<MostPWCShow>();

            foreach (var traktMostCollectedShow in traktResults)
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
            var traktResults = await Client.Shows.GetMostAnticipatedShowsAsync(extendedInfo, showFilter, whichPage, limitPerPage);

            var results = new PaginationList<AnticipatedShow>
            {
                CurrentPage = traktResults.Page,
                TotalPages = traktResults.PageCount,
                LimitPerPage = traktResults.Limit,
                TotalItemCount = traktResults.ItemCount,
                TotalUserCount = traktResults.UserCount
            };

            results.Items = new ObservableCollection<AnticipatedShow>();

            foreach (var traktAnticipatedShow in traktResults)
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
            var traktResults = await Client.Shows.GetRecentlyUpdatedShowsAsync(startDate, extendedInfo, whichPage, limitPerPage);

            var results = new PaginationList<RecentlyUpdatedShow>
            {
                CurrentPage = traktResults.Page,
                TotalPages = traktResults.PageCount,
                LimitPerPage = traktResults.Limit,
                TotalItemCount = traktResults.ItemCount,
                TotalUserCount = traktResults.UserCount
            };

            results.Items = new ObservableCollection<RecentlyUpdatedShow>();

            foreach (var traktRecentlyUpdatedShow in traktResults)
            {
                var recentlyUpdatedShow = traktRecentlyUpdatedShow.Show as RecentlyUpdatedShow;
                recentlyUpdatedShow.ShowUpdatedAt = traktRecentlyUpdatedShow.UpdatedAt;
                results.Items.Add(recentlyUpdatedShow);
            }

            return results;
        }
    }
}
