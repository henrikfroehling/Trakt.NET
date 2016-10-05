namespace TraktApiSharp.Example.UWP.Services.TraktService
{
    using Enums;
    using Models;
    using Models.ModelConverter;
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

        public async Task<Show> GetShowAsync(string showId, TraktExtendedInfo extendedInfo = null,
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

        public async Task<PaginationList<TrendingShow>> GetTrendingShowsAsync(TraktExtendedInfo extendedInfo = null,
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
                var trendingShow = ShowModelConverter.Convert<TrendingShow>(traktTrendingShow.Show);

                if (trendingShow != null)
                {
                    trendingShow.Watchers = traktTrendingShow.Watchers ?? 0;
                    results.Items.Add(trendingShow);
                }
            }

            return results;
        }

        // -------------------------------------------------------------
        // Popular Shows

        public async Task<PaginationList<Show>> GetPopularShowsAsync(TraktExtendedInfo extendedInfo = null,
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
            {
                var popularShow = ShowModelConverter.Convert<Show>(traktPopularShow);

                if (popularShow != null)
                    results.Items.Add(popularShow);
            }

            return results;
        }

        // -------------------------------------------------------------
        // Most Played Shows

        public async Task<PaginationList<MostPWCShow>> GetMostPlayedShowsAsync(TraktExtendedInfo extendedInfo = null,
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
                var mostPlayedShow = ShowModelConverter.Convert<MostPWCShow>(traktMostPlayedShow.Show);

                if (mostPlayedShow != null)
                {
                    mostPlayedShow.WatcherCount = traktMostPlayedShow.WatcherCount.GetValueOrDefault();
                    mostPlayedShow.PlayCount = traktMostPlayedShow.PlayCount.GetValueOrDefault();
                    mostPlayedShow.CollectedCount = traktMostPlayedShow.CollectedCount.GetValueOrDefault();
                    mostPlayedShow.CollectorCount = traktMostPlayedShow.CollectorCount.GetValueOrDefault();

                    results.Items.Add(mostPlayedShow);
                }
            }

            return results;
        }

        // -------------------------------------------------------------
        // Most Watched Shows

        public async Task<PaginationList<MostPWCShow>> GetMostWatchedShowsAsync(TraktExtendedInfo extendedInfo = null,
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
                var mostWatchedShow = ShowModelConverter.Convert<MostPWCShow>(traktMostWatchedShow.Show);

                if (mostWatchedShow != null)
                {
                    mostWatchedShow.WatcherCount = traktMostWatchedShow.WatcherCount.GetValueOrDefault();
                    mostWatchedShow.PlayCount = traktMostWatchedShow.PlayCount.GetValueOrDefault();
                    mostWatchedShow.CollectedCount = traktMostWatchedShow.CollectedCount.GetValueOrDefault();
                    mostWatchedShow.CollectorCount = traktMostWatchedShow.CollectorCount.GetValueOrDefault();

                    results.Items.Add(mostWatchedShow);
                }
            }

            return results;
        }

        // -------------------------------------------------------------
        // Most Collected Shows

        public async Task<PaginationList<MostPWCShow>> GetMostCollectedShowsAsync(TraktExtendedInfo extendedInfo = null,
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
                var mostCollectedShow = ShowModelConverter.Convert<MostPWCShow>(traktMostCollectedShow.Show);

                if (mostCollectedShow != null)
                {
                    mostCollectedShow.WatcherCount = traktMostCollectedShow.WatcherCount.GetValueOrDefault();
                    mostCollectedShow.PlayCount = traktMostCollectedShow.PlayCount.GetValueOrDefault();
                    mostCollectedShow.CollectedCount = traktMostCollectedShow.CollectedCount.GetValueOrDefault();
                    mostCollectedShow.CollectorCount = traktMostCollectedShow.CollectorCount.GetValueOrDefault();

                    results.Items.Add(mostCollectedShow);
                }
            }

            return results;
        }

        // -------------------------------------------------------------
        // Most Anticipated Shows

        public async Task<PaginationList<AnticipatedShow>> GetMostAnticipatedShowsAsync(TraktExtendedInfo extendedInfo = null,
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
                var anticipatedShow = ShowModelConverter.Convert<AnticipatedShow>(traktAnticipatedShow.Show);

                if (anticipatedShow != null)
                {
                    anticipatedShow.ListCount = traktAnticipatedShow.ListCount.GetValueOrDefault();
                    results.Items.Add(anticipatedShow);
                }
            }

            return results;
        }

        // -------------------------------------------------------------
        // Recently Updated Shows

        public async Task<PaginationList<RecentlyUpdatedShow>> GetRecentlyUpdatedShowsAsync(DateTime? startDate = null,
                                                                                            TraktExtendedInfo extendedInfo = null,
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
                var recentlyUpdatedShow = ShowModelConverter.Convert<RecentlyUpdatedShow>(traktRecentlyUpdatedShow.Show);

                if (recentlyUpdatedShow != null)
                {
                    var updatedAt = traktRecentlyUpdatedShow.UpdatedAt;
                    recentlyUpdatedShow.ShowUpdatedAt = updatedAt.HasValue ? updatedAt.ToString() : string.Empty;
                    results.Items.Add(recentlyUpdatedShow);
                }
            }

            return results;
        }
    }
}
