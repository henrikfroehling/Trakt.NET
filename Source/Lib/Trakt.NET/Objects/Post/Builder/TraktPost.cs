namespace TraktNet.Objects.Post
{
    public sealed class TraktPost
    {
        private TraktPost()
        {
        }

        public static ITraktSyncCollectionPostBuilder NewSyncCollectionPost() => new SyncCollectionPostBuilder();

        public static ITraktSyncHistoryPostBuilder NewSyncHistoryPost() => new SyncHistoryPostBuilder();

        public static ITraktSyncHistoryRemovePostBuilder NewSyncHistoryRemovePost() => new SyncHistoryRemovePostBuilder();

        public static ITraktSyncRatingsPostBuilder NewSyncRatingsPost() => new SyncRatingsPostBuilder();

        public static ITraktSyncRecommendationsPostBuilder NewSyncRecommendationsPost() => new SyncRecommendationsPostBuilder();

        public static ITraktSyncWatchlistPostBuilder NewSyncWatchlistPost() => new SyncWatchlistPostBuilder();

        public static ITraktUserPersonalListItemsPostBuilder NewUserPersonalListItemsPost() => new UserPersonalListItemsPostBuilder();

        public static ITraktUserHiddenItemsPostBuilder NewUserHiddenItemsPost() => new UserHiddenItemsPostBuilder();
    }
}
