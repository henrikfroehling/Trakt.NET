namespace TraktApiSharp.Modules
{
    using Enums;
    using Objects.Basic;
    using Objects.Get.Syncs.Activities;
    using Objects.Get.Syncs.Collection;
    using Objects.Get.Syncs.History;
    using Objects.Get.Syncs.Playback;
    using Objects.Get.Syncs.Ratings;
    using Objects.Get.Syncs.Watched;
    using Objects.Get.Syncs.Watchlist;
    using Requests;
    using Requests.WithOAuth.Syncs;
    using System.Threading.Tasks;

    public class TraktSyncModule : TraktBaseModule
    {
        public TraktSyncModule(TraktClient client) : base(client) { }

        public async Task<TraktSyncLastActivities> GetSyncLastActivitiesAsync()
        {
            return await QueryAsync(new TraktSyncLastActivitiesRequest(Client));
        }

        public async Task<TraktListResult<TraktSyncPlaybackProgressItem>> GetSyncPlaybackProgressAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified,
                                                                                                       TraktSyncType? type = null)
        {
            return await QueryAsync(new TraktSyncPlaybackProgressRequest(Client)
            {
                Type = type,
                ExtendedOption = extended
            });
        }

        public async Task<TraktListResult<TraktSyncCollectionMovieItem>> GetSyncCollectionMoviesAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified)
        {
            return await QueryAsync(new TraktSyncCollectionMoviesRequest(Client)
            {
                ExtendedOption = extended
            });
        }

        public async Task<TraktListResult<TraktSyncCollectionShowItem>> GetSyncCollectionShowsAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified)
        {
            return await QueryAsync(new TraktSyncCollectionShowsRequest(Client)
            {
                ExtendedOption = extended
            });
        }

        public async Task<TraktListResult<TraktSyncWatchedMovieItem>> GetSyncWatchedMoviesAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified)
        {
            return await QueryAsync(new TraktSyncWatchedMoviesRequest(Client)
            {
                ExtendedOption = extended
            });
        }

        public async Task<TraktListResult<TraktSyncWatchedShowItem>> GetSyncWatchedShowsAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified)
        {
            return await QueryAsync(new TraktSyncWatchedShowsRequest(Client)
            {
                ExtendedOption = extended
            });
        }

        public async Task<TraktPaginationListResult<TraktSyncHistoryItem>> GetSyncWatchedHistoryAsync(TraktSyncHistoryItemType? type = null, string id = null,
                                                                                                      TraktExtendedOption extended = TraktExtendedOption.Unspecified,
                                                                                                      int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktSyncWatchedHistoryRequest(Client)
            {
                Type = type,
                ItemId = id,
                ExtendedOption = extended,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktListResult<TraktSyncRatingsItem>> GetSyncRatingsAsync(TraktSyncRatingsItemType? type = null,
                                                                                     int[] rating = null,
                                                                                     TraktExtendedOption extended = TraktExtendedOption.Unspecified)
        {
            return await QueryAsync(new TraktSyncRatingsRequest(Client)
            {
                Type = type,
                Rating = rating,
                ExtendedOption = extended
            });
        }

        public async Task<TraktListResult<TraktSyncWatchlistItem>> GetSyncWatchlistAsync(TraktSyncWatchlistItemType? type = null,
                                                                                         TraktExtendedOption extended = TraktExtendedOption.Unspecified)
        {
            return await QueryAsync(new TraktSyncWatchlistRequest(Client)
            {
                Type = type,
                ExtendedOption = extended
            });
        }
    }
}
