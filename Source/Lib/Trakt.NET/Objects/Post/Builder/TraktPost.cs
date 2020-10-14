﻿namespace TraktNet.Objects.Post
{
    using Builder.Implementation;
    using Builder.Interfaces;

    public sealed class TraktPost
    {
        private TraktPost()
        {
        }

        public static ITraktSyncCollectionPostBuilder NewSyncCollectionPost() => new SyncCollectionPostBuilder();

        public static ITraktSyncHistoryPostBuilder NewSyncHistoryPost() => new SyncHistoryPostBuilder();

        public static ITraktSyncRatingsPostBuilder NewSyncRatingsPost() => new SyncRatingsPostBuilder();

        public static ITraktSyncWatchlistPostBuilder NewSyncWatchlistPost() => new SyncWatchlistPostBuilder();

        public static ITraktUserCustomListItemsPostBuilder NewUserCustomListItemsPost() => new UserCustomListItemsPostBuilder();

        public static ITraktUserHiddenItemsPostBuilder NewUserHiddenItemsPost() => new UserHiddenItemsPostBuilder();
    }
}
