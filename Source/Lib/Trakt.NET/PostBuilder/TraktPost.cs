namespace TraktNet.PostBuilder
{
    public static class TraktPost
    {
        /// <summary>Creates a new <see cref="ITraktSyncCollectionPostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktSyncCollectionPostBuilder"/> instance.</returns>
        public static ITraktSyncCollectionPostBuilder NewSyncCollectionPost() => new SyncCollectionPostBuilder();

        /// <summary>Creates a new <see cref="ITraktSyncCollectionRemovePostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktSyncCollectionRemovePostBuilder"/> instance.</returns>
        public static ITraktSyncCollectionRemovePostBuilder NewSyncCollectionRemovePost() => new SyncCollectionRemovePostBuilder();

        /// <summary>Creates a new <see cref="ITraktSyncHistoryPostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktSyncHistoryPostBuilder"/> instance.</returns>
        public static ITraktSyncHistoryPostBuilder NewSyncHistoryPost() => new SyncHistoryPostBuilder();

        /// <summary>Creates a new <see cref="ITraktSyncHistoryRemovePostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktSyncHistoryRemovePostBuilder"/> instance.</returns>
        public static ITraktSyncHistoryRemovePostBuilder NewSyncHistoryRemovePost() => new SyncHistoryRemovePostBuilder();

        /// <summary>Creates a new <see cref="ITraktSyncRatingsPostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktSyncRatingsPostBuilder"/> instance.</returns>
        public static ITraktSyncRatingsPostBuilder NewSyncRatingsPost() => new SyncRatingsPostBuilder();

        /// <summary>Creates a new <see cref="ITraktSyncRatingsRemovePostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktSyncRatingsRemovePostBuilder"/> instance.</returns>
        public static ITraktSyncRatingsRemovePostBuilder NewSyncRatingsRemovePost() => new SyncRatingsRemovePostBuilder();

        /// <summary>Creates a new <see cref="ITraktSyncRecommendationsPostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktSyncRecommendationsPostBuilder"/> instance.</returns>
        public static ITraktSyncRecommendationsPostBuilder NewSyncRecommendationsPost() => new SyncRecommendationsPostBuilder();

        /// <summary>Creates a new <see cref="ITraktSyncRecommendationsRemovePostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktSyncRecommendationsRemovePostBuilder"/> instance.</returns>
        public static ITraktSyncRecommendationsRemovePostBuilder NewSyncRecommendationsRemovePost() => new SyncRecommendationsRemovePostBuilder();

        /// <summary>Creates a new <see cref="ITraktSyncWatchlistPostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktSyncWatchlistPostBuilder"/> instance.</returns>
        public static ITraktSyncWatchlistPostBuilder NewSyncWatchlistPost() => new SyncWatchlistPostBuilder();

        /// <summary>Creates a new <see cref="ITraktUserHiddenItemsPostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktUserHiddenItemsPostBuilder"/> instance.</returns>
        public static ITraktUserHiddenItemsPostBuilder NewUserHiddenItemsPost() => new UserHiddenItemsPostBuilder();

        /// <summary>Creates a new <see cref="ITraktUserPersonalListItemsPostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktUserPersonalListItemsPostBuilder"/> instance.</returns>
        public static ITraktUserPersonalListItemsPostBuilder NewUserPersonalListItemsPost() => new UserPersonalListItemsPostBuilder();
    }
}
