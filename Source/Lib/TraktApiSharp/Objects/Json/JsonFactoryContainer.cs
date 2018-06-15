namespace TraktApiSharp.Objects.Json
{
    using Authentication;
    using Authentication.Json.Factories;
    using Basic;
    using Basic.Json.Factories;
    using Get.Calendars;
    using Get.Calendars.Json.Factories;
    using Get.Collections;
    using Get.Collections.Json.Factories;
    using Get.Episodes;
    using Get.Episodes.Json.Factories;
    using Get.History;
    using Get.History.Json.Factories;
    using Get.Movies;
    using Get.Movies.Json.Factories;
    using Get.People;
    using Get.People.Credits;
    using Get.People.Credits.Json.Factories;
    using Get.People.Json.Factories;
    using Get.Ratings;
    using Get.Ratings.Json.Factories;
    using Get.Seasons;
    using Get.Seasons.Json.Factories;
    using Get.Shows;
    using Get.Shows.Json.Factories;
    using Get.Syncs.Activities;
    using Get.Syncs.Activities.Json.Factories;
    using Get.Syncs.Playback;
    using Get.Syncs.Playback.Json.Factories;
    using Get.Users;
    using Get.Users.Json.Factories;
    using Get.Users.Lists;
    using Get.Users.Lists.Json.Factories;
    using Get.Users.Statistics;
    using Get.Users.Statistics.Json.Factories;
    using Get.Watched;
    using Get.Watched.Json.Factories;
    using Get.Watchlist;
    using Get.Watchlist.Json.Factories;
    using Post.Checkins;
    using Post.Checkins.Json.Factories;
    using Post.Checkins.Responses;
    using Post.Checkins.Responses.Json.Factories;
    using Post.Comments;
    using Post.Comments.Json.Factories;
    using Post.Comments.Responses;
    using Post.Comments.Responses.Json.Factories;
    using Post.Responses;
    using Post.Responses.Json.Factories;
    using Post.Scrobbles;
    using Post.Scrobbles.Json.Factories;
    using Post.Scrobbles.Responses;
    using Post.Scrobbles.Responses.Json.Factories;
    using Post.Syncs.Collection;
    using Post.Syncs.Collection.Json.Factories;
    using Post.Syncs.Collection.Responses;
    using Post.Syncs.Collection.Responses.Json.Factories;
    using Post.Syncs.History;
    using Post.Syncs.History.Json.Factories;
    using Post.Syncs.History.Responses;
    using Post.Syncs.History.Responses.Json.Factories;
    using Post.Syncs.Ratings;
    using Post.Syncs.Ratings.Json.Factories;
    using Post.Syncs.Ratings.Responses;
    using Post.Syncs.Ratings.Responses.Json.Factories;
    using Post.Syncs.Responses;
    using Post.Syncs.Responses.Json.Factories;
    using Post.Syncs.Watchlist;
    using Post.Syncs.Watchlist.Json.Factories;
    using Post.Syncs.Watchlist.Responses;
    using Post.Syncs.Watchlist.Responses.Json.Factories;
    using Post.Users;
    using Post.Users.CustomListItems;
    using Post.Users.CustomListItems.Json.Factories;
    using Post.Users.CustomListItems.Responses;
    using Post.Users.CustomListItems.Responses.Json.Factories;
    using Post.Users.Json.Factories;
    using Post.Users.Responses;
    using Post.Users.Responses.Json.Factories;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    internal static class JsonFactoryContainer
    {
        private static readonly Dictionary<Type, object> s_jsonIOFactories = new Dictionary<Type, object>();

        public static IObjectJsonReader<TReturnType> CreateObjectReader<TReturnType>()
        {
            var factory = GetJsonIOFactory<TReturnType>();
            Debug.Assert(factory != null, $"factory for {nameof(TReturnType)} should not be null");
            return factory.CreateObjectReader();
        }

        public static IArrayJsonReader<TReturnType> CreateArrayReader<TReturnType>()
        {
            var factory = GetJsonIOFactory<TReturnType>();
            Debug.Assert(factory != null, $"factory for {nameof(TReturnType)} should not be null");
            return factory.CreateArrayReader();
        }

        public static IObjectJsonWriter<TObjectType> CreateObjectWriter<TObjectType>()
        {
            var factory = GetJsonIOFactory<TObjectType>();
            Debug.Assert(factory != null, $"factory for {nameof(TObjectType)} should not be null");
            return factory.CreateObjectWriter();
        }

        public static IJsonIOFactory<TReturnType> GetJsonIOFactory<TReturnType>()
        {
            var type = typeof(TReturnType);

            if (!s_jsonIOFactories.ContainsKey(type))
                throw new NotSupportedException($"A json io factory for {nameof(TReturnType)} is not supported.");

            return (IJsonIOFactory<TReturnType>)s_jsonIOFactories[type];
        }

        static JsonFactoryContainer()
        {
            // authentication objects
            s_jsonIOFactories.Add(typeof(ITraktAuthorization), new AuthorizationJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktDevice), new DeviceJsonIOFactory());

            // basic objects
            s_jsonIOFactories.Add(typeof(ITraktCastAndCrew), new CastAndCrewJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktCastMember), new CastMemberJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktCertification), new CertificationJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktCertifications), new CertificationsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktComment), new CommentJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktCommentItem), new CommentItemJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktCommentLike), new CommentLikeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktCrew), new CrewJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktCrewMember), new CrewMemberJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktError), new ErrorJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktGenre), new GenreJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktIds), new IdsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktImage), new ImageJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktMetadata), new MetadataJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktNetwork), new NetworkJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktRating), new RatingJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSearchResult), new SearchResultJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSharing), new SharingJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktStatistics), new StatisticsJsonIOFactory());

            // calendar objects
            s_jsonIOFactories.Add(typeof(ITraktCalendarMovie), new CalendarMovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktCalendarShow), new CalendarShowJsonIOFactory());

            // checkin post objects
            s_jsonIOFactories.Add(typeof(ITraktEpisodeCheckinPost), new EpisodeCheckinPostJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktMovieCheckinPost), new MovieCheckinPostJsonIOFactory());

            // checkin post response objects
            s_jsonIOFactories.Add(typeof(ITraktCheckinPostErrorResponse), new CheckinPostErrorResponseJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktEpisodeCheckinPostResponse), new EpisodeCheckinPostResponseJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktMovieCheckinPostResponse), new MovieCheckinPostResponseJsonIOFactory());

            // collection objects
            s_jsonIOFactories.Add(typeof(ITraktCollectionShowEpisode), new CollectionShowEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktCollectionShowSeason), new CollectionShowSeasonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktCollectionShow), new CollectionShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktCollectionMovie), new CollectionMovieJsonIOFactory());

            // comment post objects
            s_jsonIOFactories.Add(typeof(ITraktCommentReplyPost), new CommentReplyPostJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktCommentUpdatePost), new CommentUpdatePostJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktEpisodeCommentPost), new EpisodeCommentPostJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktListCommentPost), new ListCommentPostJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktMovieCommentPost), new MovieCommentPostJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSeasonCommentPost), new SeasonCommentPostJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktShowCommentPost), new ShowCommentPostJsonIOFactory());

            // comment post response objects
            s_jsonIOFactories.Add(typeof(ITraktCommentPostResponse), new CommentPostResponseJsonIOFactory());

            // episode objects
            s_jsonIOFactories.Add(typeof(ITraktEpisode), new EpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktEpisodeIds), new EpisodeIdsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktEpisodeTranslation), new EpisodeTranslationJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktEpisodeCollectionProgress), new EpisodeCollectionProgressJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktEpisodeWatchedProgress), new EpisodeWatchedProgressJsonIOFactory());

            // history objects
            s_jsonIOFactories.Add(typeof(ITraktHistoryItem), new HistoryItemJsonIOFactory());

            // movie objects
            s_jsonIOFactories.Add(typeof(ITraktMovie), new MovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktMovieAlias), new MovieAliasJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktMovieIds), new MovieIdsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktMovieRelease), new MovieReleaseJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktMovieTranslation), new MovieTranslationJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktBoxOfficeMovie), new BoxOfficeMovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktMostAnticipatedMovie), new MostAnticipatedMovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktMostPWCMovie), new MostPWCMovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktRecentlyUpdatedMovie), new RecentlyUpdatedMovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktTrendingMovie), new TrendingMovieJsonIOFactory());

            // people objects
            s_jsonIOFactories.Add(typeof(ITraktPerson), new PersonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktPersonIds), new PersonIdsJsonIOFactory());

            // people credit objects
            s_jsonIOFactories.Add(typeof(ITraktPersonMovieCredits), new PersonMovieCreditsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktPersonMovieCreditsCastItem), new PersonMovieCreditsCastItemJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktPersonMovieCreditsCrew), new PersonMovieCreditsCrewJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktPersonMovieCreditsCrewItem), new PersonMovieCreditsCrewItemJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktPersonShowCredits), new PersonShowCreditsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktPersonShowCreditsCastItem), new PersonShowCreditsCastItemJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktPersonShowCreditsCrew), new PersonShowCreditsCrewJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktPersonShowCreditsCrewItem), new PersonShowCreditsCrewItemJsonIOFactory());

            // post response objects
            s_jsonIOFactories.Add(typeof(ITraktPostResponseNotFoundEpisode), new PostResponseNotFoundEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktPostResponseNotFoundMovie), new PostResponseNotFoundMovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktPostResponseNotFoundPerson), new PostResponseNotFoundPersonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktPostResponseNotFoundSeason), new PostResponseNotFoundSeasonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktPostResponseNotFoundShow), new PostResponseNotFoundShowJsonIOFactory());

            // rating objects
            s_jsonIOFactories.Add(typeof(ITraktRatingsItem), new RatingsItemJsonIOFactory());

            // season objects
            s_jsonIOFactories.Add(typeof(ITraktSeason), new SeasonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSeasonIds), new SeasonIdsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSeasonCollectionProgress), new SeasonCollectionProgressJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSeasonWatchedProgress), new SeasonWatchedProgressJsonIOFactory());

            // scrobble post objects
            s_jsonIOFactories.Add(typeof(ITraktEpisodeScrobblePost), new EpisodeScrobblePostJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktMovieScrobblePost), new MovieScrobblePostJsonIOFactory());

            // scrobble post response objects
            s_jsonIOFactories.Add(typeof(ITraktEpisodeScrobblePostResponse), new EpisodeScrobblePostResponseJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktMovieScrobblePostResponse), new MovieScrobblePostResponseJsonIOFactory());

            // show objects
            s_jsonIOFactories.Add(typeof(ITraktShow), new ShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktShowAirs), new ShowAirsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktShowAlias), new ShowAliasJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktShowIds), new ShowIdsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktShowTranslation), new ShowTranslationJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktShowCollectionProgress), new ShowCollectionProgressJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktShowWatchedProgress), new ShowWatchedProgressJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktMostAnticipatedShow), new MostAnticipatedShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktMostPWCShow), new MostPWCShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktRecentlyUpdatedShow), new RecentlyUpdatedShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktTrendingShow), new TrendingShowJsonIOFactory());

            // sync activities objects
            s_jsonIOFactories.Add(typeof(ITraktSyncLastActivities), new SyncLastActivitiesJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncCommentsLastActivities), new SyncCommentsLastActivitiesJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncEpisodesLastActivities), new SyncEpisodesLastActivitiesJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncListsLastActivities), new SyncListsLastActivitiesJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncMoviesLastActivities), new SyncMoviesLastActivitiesJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncSeasonsLastActivities), new SyncSeasonsLastActivitiesJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncShowsLastActivities), new SyncShowsLastActivitiesJsonIOFactory());

            // sync collection post objects
            s_jsonIOFactories.Add(typeof(ITraktSyncCollectionPost), new SyncCollectionPostJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncCollectionPostEpisode), new SyncCollectionPostEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncCollectionPostMovie), new SyncCollectionPostMovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncCollectionPostShow), new SyncCollectionPostShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncCollectionPostShowEpisode), new SyncCollectionPostShowEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncCollectionPostShowSeason), new SyncCollectionPostShowSeasonJsonIOFactory());

            // sync collection post response objects
            s_jsonIOFactories.Add(typeof(ITraktSyncCollectionPostResponse), new SyncCollectionPostResponseJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncCollectionRemovePostResponse), new SyncCollectionRemovePostResponseJsonIOFactory());

            // sync history post objects
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryPost), new SyncHistoryPostJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryPostEpisode), new SyncHistoryPostEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryPostMovie), new SyncHistoryPostMovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryPostShow), new SyncHistoryPostShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryPostShowEpisode), new SyncHistoryPostShowEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryPostShowSeason), new SyncHistoryPostShowSeasonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryRemovePost), new SyncHistoryRemovePostJsonIOFactory());

            // sync history post response objects
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryPostResponse), new SyncHistoryPostResponseJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryRemovePostResponse), new SyncHistoryRemovePostResponseJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryRemovePostResponseGroup), new SyncHistoryRemovePostResponseGroupJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryRemovePostResponseNotFoundGroup), new SyncHistoryRemovePostResponseNotFoundGroupJsonIOFactory());

            // sync rating post objects
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPost), new SyncRatingsPostJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostEpisode), new SyncRatingsPostEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostMovie), new SyncRatingsPostMovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostShow), new SyncRatingsPostShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostShowEpisode), new SyncRatingsPostShowEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostShowSeason), new SyncRatingsPostShowSeasonJsonIOFactory());

            // sync rating post response objects
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostResponse), new SyncRatingsPostResponseJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostResponseNotFoundEpisode), new SyncRatingsPostResponseNotFoundEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostResponseNotFoundGroup), new SyncRatingsPostResponseNotFoundGroupJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostResponseNotFoundMovie), new SyncRatingsPostResponseNotFoundMovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostResponseNotFoundSeason), new SyncRatingsPostResponseNotFoundSeasonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostResponseNotFoundShow), new SyncRatingsPostResponseNotFoundShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsRemovePostResponse), new SyncRatingsRemovePostResponseJsonIOFactory());

            // sync playback objects
            s_jsonIOFactories.Add(typeof(ITraktSyncPlaybackProgressItem), new SyncPlaybackProgressItemJsonIOFactory());

            // sync response objects
            s_jsonIOFactories.Add(typeof(ITraktSyncPostResponseGroup), new SyncPostResponseGroupJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncPostResponseNotFoundGroup), new SyncPostResponseNotFoundGroupJsonIOFactory());

            // sync watchlist post objects
            s_jsonIOFactories.Add(typeof(ITraktSyncWatchlistPost), new SyncWatchlistPostJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncWatchlistPostEpisode), new SyncWatchlistPostEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncWatchlistPostMovie), new SyncWatchlistPostMovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncWatchlistPostShow), new SyncWatchlistPostShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncWatchlistPostShowEpisode), new SyncWatchlistPostShowEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncWatchlistPostShowSeason), new SyncWatchlistPostShowSeasonJsonIOFactory());

            // sync watchlist post response objects
            s_jsonIOFactories.Add(typeof(ITraktSyncWatchlistPostResponse), new SyncWatchlistPostResponseJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncWatchlistRemovePostResponse), new SyncWatchlistRemovePostResponseJsonIOFactory());

            // user custom list items post objects
            s_jsonIOFactories.Add(typeof(ITraktUserCustomListItemsPost), new UserCustomListItemsPostJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserCustomListItemsPostMovie), new UserCustomListItemsPostMovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserCustomListItemsPostShow), new UserCustomListItemsPostShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserCustomListItemsPostShowEpisode), new UserCustomListItemsPostShowEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserCustomListItemsPostShowSeason), new UserCustomListItemsPostShowSeasonJsonIOFactory());

            // user custom list items post response objects
            s_jsonIOFactories.Add(typeof(ITraktUserCustomListItemsPostResponse), new UserCustomListItemsPostResponseJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserCustomListItemsPostResponseGroup), new UserCustomListItemsPostResponseGroupJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserCustomListItemsPostResponseNotFoundGroup), new UserCustomListItemsPostResponseNotFoundGroupJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserCustomListItemsRemovePostResponse), new UserCustomListItemsRemovePostResponseJsonIOFactory());

            // user objects
            s_jsonIOFactories.Add(typeof(ITraktUser), new UserJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserComment), new UserCommentJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserFollower), new UserFollowerJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserFollowRequest), new UserFollowRequestJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserFriend), new UserFriendJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserHiddenItem), new UserHiddenItemJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserIds), new UserIdsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserImages), new UserImagesJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserLikeItem), new UserLikeItemJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserSettings), new UserSettingsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserWatchingItem), new UserWatchingItemJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktAccountSettings), new AccountSettingsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSharingText), new SharingTextJsonIOFactory());

            // user list objects
            s_jsonIOFactories.Add(typeof(ITraktList), new ListJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktListIds), new ListIdsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktListItem), new ListItemJsonIOFactory());

            // user post objects
            s_jsonIOFactories.Add(typeof(ITraktUserCustomListPost), new UserCustomListPostJsonIOFactory());

            // user response post objects
            s_jsonIOFactories.Add(typeof(ITraktUserFollowUserPostResponse), new UserFollowUserPostResponseJsonIOFactory());

            // user statistic objects
            s_jsonIOFactories.Add(typeof(ITraktUserStatistics), new UserStatisticsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserEpisodesStatistics), new UserEpisodesStatisticsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserMoviesStatistics), new UserMoviesStatisticsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserNetworkStatistics), new UserNetworkStatisticsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserRatingsStatistics), new UserRatingsStatisticsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserSeasonsStatistics), new UserSeasonsStatisticsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserShowsStatistics), new UserShowsStatisticsJsonIOFactory());

            // watched objects
            s_jsonIOFactories.Add(typeof(ITraktWatchedShowEpisode), new WatchedShowEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktWatchedShowSeason), new WatchedShowSeasonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktWatchedShow), new WatchedShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktWatchedMovie), new WatchedMovieJsonIOFactory());

            // watchlist objects
            s_jsonIOFactories.Add(typeof(ITraktWatchlistItem), new WatchlistItemJsonIOFactory());
        }
    }
}
