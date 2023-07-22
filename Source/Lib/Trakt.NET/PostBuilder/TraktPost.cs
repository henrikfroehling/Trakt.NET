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

        /// <summary>Creates a new <see cref="ITraktSyncFavoritesPostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktSyncFavoritesPostBuilder"/> instance.</returns>
        public static ITraktSyncFavoritesPostBuilder NewSyncFavoritesPost() => new SyncFavoritesPostBuilder();

        /// <summary>Creates a new <see cref="ITraktSyncFavoritesRemovePostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktSyncFavoritesRemovePostBuilder"/> instance.</returns>
        public static ITraktSyncFavoritesRemovePostBuilder NewSyncFavoritesRemovePost() => new SyncFavoritesRemovePostBuilder();

        /// <summary>Creates a new <see cref="ITraktSyncWatchlistPostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktSyncWatchlistPostBuilder"/> instance.</returns>
        public static ITraktSyncWatchlistPostBuilder NewSyncWatchlistPost() => new SyncWatchlistPostBuilder();

        /// <summary>Creates a new <see cref="ITraktSyncWatchlistRemovePostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktSyncWatchlistRemovePostBuilder"/> instance.</returns>
        public static ITraktSyncWatchlistRemovePostBuilder NewSyncWatchlistRemovePost() => new SyncWatchlistRemovePostBuilder();

        /// <summary>Creates a new <see cref="ITraktUserHiddenItemsPostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktUserHiddenItemsPostBuilder"/> instance.</returns>
        public static ITraktUserHiddenItemsPostBuilder NewUserHiddenItemsPost() => new UserHiddenItemsPostBuilder();

        /// <summary>Creates a new <see cref="ITraktUserHiddenItemsRemovePostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktUserHiddenItemsRemovePostBuilder"/> instance.</returns>
        public static ITraktUserHiddenItemsRemovePostBuilder NewUserHiddenItemsRemovePost() => new UserHiddenItemsRemovePostBuilder();

        /// <summary>Creates a new <see cref="ITraktUserPersonalListItemsPostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktUserPersonalListItemsPostBuilder"/> instance.</returns>
        public static ITraktUserPersonalListItemsPostBuilder NewUserPersonalListItemsPost() => new UserPersonalListItemsPostBuilder();

        /// <summary>Creates a new <see cref="ITraktUserPersonalListItemsRemovePostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktUserPersonalListItemsRemovePostBuilder"/> instance.</returns>
        public static ITraktUserPersonalListItemsRemovePostBuilder NewUserPersonalListItemsRemovePost() => new UserPersonalListItemsRemovePostBuilder();

        /// <summary>Creates a new <see cref="ITraktMovieCommentPostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktMovieCommentPostBuilder"/> instance.</returns>
        public static ITraktMovieCommentPostBuilder NewMovieCommentPost() => new MovieCommentPostBuilder();

        /// <summary>Creates a new <see cref="ITraktShowCommentPostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktShowCommentPostBuilder"/> instance.</returns>
        public static ITraktShowCommentPostBuilder NewShowCommentPost() => new ShowCommentPostBuilder();

        /// <summary>Creates a new <see cref="ITraktSeasonCommentPostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktSeasonCommentPostBuilder"/> instance.</returns>
        public static ITraktSeasonCommentPostBuilder NewSeasonCommentPost() => new SeasonCommentPostBuilder();

        /// <summary>Creates a new <see cref="ITraktEpisodeCommentPostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktEpisodeCommentPostBuilder"/> instance.</returns>
        public static ITraktEpisodeCommentPostBuilder NewEpisodeCommentPost() => new EpisodeCommentPostBuilder();

        /// <summary>Creates a new <see cref="ITraktListCommentPostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktListCommentPostBuilder"/> instance.</returns>
        public static ITraktListCommentPostBuilder NewListCommentPost() => new ListCommentPostBuilder();

        /// <summary>Creates a new <see cref="ITraktMovieCheckinPostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktMovieCheckinPostBuilder"/> instance.</returns>
        public static ITraktMovieCheckinPostBuilder NewMovieCheckinPost() => new MovieCheckinPostBuilder();

        /// <summary>Creates a new <see cref="ITraktEpisodeCheckinPostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktEpisodeCheckinPostBuilder"/> instance.</returns>
        public static ITraktEpisodeCheckinPostBuilder NewEpisodeCheckinPost() => new EpisodeCheckinPostBuilder();

        /// <summary>Creates a new <see cref="ITraktMovieScrobblePostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktMovieScrobblePostBuilder"/> instance.</returns>
        public static ITraktMovieScrobblePostBuilder NewMovieScrobblePost() => new MovieScrobblePostBuilder();

        /// <summary>Creates a new <see cref="ITraktEpisodeScrobblePostBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktEpisodeScrobblePostBuilder"/> instance.</returns>
        public static ITraktEpisodeScrobblePostBuilder NewEpisodeScrobblePost() => new EpisodeScrobblePostBuilder();
    }
}
