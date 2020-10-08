namespace TraktNet.Objects.Post
{
    using Builder.Implementation;
    using Builder.Interfaces;

    public sealed class TraktPost
    {
        private TraktPost()
        {
        }

        public static ITraktSyncCollectionPostBuilder NewSyncCollectionPost() => new TraktSyncCollectionPostBuilder();

        public static ITraktSyncHistoryPostBuilder NewSyncHistoryPost() => new TraktSyncHistoryPostBuilder();

        public static ITraktSyncRatingsPostBuilder NewSyncRatingsPost() => new TraktSyncRatingsPostBuilder();

        public static ITraktSyncWatchlistPostBuilder NewSyncWatchlistPost() => new TraktSyncWatchlistPostBuilder();

        public static ITraktUserCustomListItemsPostBuilder NewUserCustomListItemsPost() => new TraktUserCustomListItemsPostBuilder();

        public static ITraktUserHiddenItemsPostBuilder NewUserHiddenItemsPost() => new TraktUserHiddenItemsPostBuilder();
    }
}
