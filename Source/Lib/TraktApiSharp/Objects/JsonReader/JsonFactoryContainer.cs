﻿namespace TraktApiSharp.Objects.JsonReader
{
    using Basic;
    using Basic.JsonReader.Factories;
    using Get.Calendars;
    using Get.Calendars.JsonReader.Factories;
    using Get.Collections;
    using Get.Collections.JsonReader.Factories;
    using Get.Episodes;
    using Get.Episodes.JsonReader.Factories;
    using Get.History;
    using Get.History.JsonReader.Factories;
    using Get.Movies;
    using Get.Movies.JsonReader.Factories;
    using Get.People;
    using Get.People.Credits;
    using Get.People.Credits.JsonReader.Factories;
    using Get.People.JsonReader.Factories;
    using Get.Ratings;
    using Get.Ratings.JsonReader.Factories;
    using Get.Seasons;
    using Get.Seasons.JsonReader.Factories;
    using Get.Shows;
    using Get.Shows.JsonReader.Factories;
    using Get.Syncs.Activities;
    using Get.Syncs.Activities.JsonReader.Factories;
    using Get.Syncs.Playback;
    using Get.Syncs.Playback.JsonReader.Factories;
    using Get.Users;
    using Get.Users.JsonReader.Factories;
    using Get.Users.Lists;
    using Get.Users.Lists.JsonReader.Factories;
    using Get.Users.Statistics;
    using Get.Users.Statistics.JsonReader.Factories;
    using Get.Watched;
    using Get.Watched.JsonReader.Factories;
    using Get.Watchlist;
    using Get.Watchlist.JsonReader.Factories;
    using Post.Checkins.Responses;
    using Post.Checkins.Responses.JsonReader.Factories;
    using Post.Comments.Responses;
    using Post.Comments.Responses.JsonReader.Factories;
    using Post.Responses;
    using Post.Responses.JsonReader.Factories;
    using Post.Scrobbles.Responses;
    using Post.Scrobbles.Responses.JsonReader.Factories;
    using Post.Syncs.Collection.Responses;
    using Post.Syncs.Collection.Responses.JsonReader.Factories;
    using Post.Syncs.History.Responses;
    using Post.Syncs.History.Responses.JsonReader.Factories;
    using Post.Syncs.Ratings.Responses;
    using Post.Syncs.Ratings.Responses.JsonReader.Factories;
    using Post.Syncs.Responses;
    using Post.Syncs.Responses.JsonReader.Factories;
    using Post.Syncs.Watchlist.Responses;
    using Post.Syncs.Watchlist.Responses.JsonReader.Factories;
    using Post.Users.CustomListItems.Responses;
    using Post.Users.CustomListItems.Responses.JsonReader.Factories;
    using Post.Users.Responses;
    using Post.Users.Responses.JsonReader.Factories;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    internal static class JsonFactoryContainer
    {
        private static readonly Dictionary<Type, object> s_readerFactories = new Dictionary<Type, object>();

        public static ITraktObjectJsonReader<TReturnType> CreateObjectReader<TReturnType>()
        {
            var factory = GetReaderFactory<TReturnType>();
            Debug.Assert(factory != null, $"factory for {nameof(TReturnType)} should not be null");
            return factory.CreateObjectReader();
        }

        public static ITraktArrayJsonReader<TReturnType> CreateArrayReader<TReturnType>()
        {
            var factory = GetReaderFactory<TReturnType>();
            Debug.Assert(factory != null, $"factory for {nameof(TReturnType)} should not be null");
            return factory.CreateArrayReader();
        }

        public static IJsonReaderFactory<TReturnType> GetReaderFactory<TReturnType>()
        {
            var type = typeof(TReturnType);

            if (!s_readerFactories.ContainsKey(type))
                throw new NotSupportedException($"A json reader factory for {nameof(TReturnType)} is not supported.");

            return (IJsonReaderFactory<TReturnType>)s_readerFactories[type];
        }

        static JsonFactoryContainer()
        {
            // basic objects
            s_readerFactories.Add(typeof(ITraktCastAndCrew), new TraktCastAndCrewJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktCastMember), new TraktCastMemberJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktComment), new TraktCommentJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktCrew), new TraktCrewJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktCrewMember), new TraktCrewMemberJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktError), new TraktErrorJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktGenre), new TraktGenreJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktIds), new TraktIdsJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktImage), new TraktImageJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktMetadata), new TraktMetadataJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktRating), new TraktRatingJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSearchResult), new TraktSearchResultJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSharing), new TraktSharingJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktStatistics), new TraktStatisticsJsonReaderFactory());

            // calendar objects
            s_readerFactories.Add(typeof(ITraktCalendarMovie), new TraktCalendarMovieJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktCalendarShow), new TraktCalendarShowJsonReaderFactory());

            // checkin post response objects
            s_readerFactories.Add(typeof(ITraktCheckinPostErrorResponse), new TraktCheckinPostErrorResponseJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktEpisodeCheckinPostResponse), new TraktEpisodeCheckinPostResponseJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktMovieCheckinPostResponse), new TraktMovieCheckinPostResponseJsonReaderFactory());

            // collection objects
            s_readerFactories.Add(typeof(ITraktCollectionShowEpisode), new TraktCollectionShowEpisodeJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktCollectionShowSeason), new TraktCollectionShowSeasonJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktCollectionShow), new TraktCollectionShowJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktCollectionMovie), new TraktCollectionMovieJsonReaderFactory());

            // comment post response objects
            s_readerFactories.Add(typeof(ITraktCommentPostResponse), new TraktCommentPostResponseJsonReaderFactory());

            // episode objects
            s_readerFactories.Add(typeof(ITraktEpisode), new TraktEpisodeJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktEpisodeIds), new TraktEpisodeIdsJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktEpisodeTranslation), new TraktEpisodeTranslationJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktEpisodeCollectionProgress), new TraktEpisodeCollectionProgressJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktEpisodeWatchedProgress), new TraktEpisodeWatchedProgressJsonReaderFactory());

            // history objects
            s_readerFactories.Add(typeof(ITraktHistoryItem), new TraktHistoryItemJsonReaderFactory());

            // movie objects
            s_readerFactories.Add(typeof(ITraktMovie), new TraktMovieJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktMovieAlias), new TraktMovieAliasJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktMovieIds), new TraktMovieIdsJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktMovieRelease), new TraktMovieReleaseJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktMovieTranslation), new TraktMovieTranslationJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktBoxOfficeMovie), new TraktBoxOfficeMovieJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktMostAnticipatedMovie), new TraktMostAnticipatedMovieJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktMostPWCMovie), new TraktMostPWCMovieJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktRecentlyUpdatedMovie), new TraktRecentlyUpdatedMovieJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktTrendingMovie), new TraktTrendingMovieJsonReaderFactory());

            // people objects
            s_readerFactories.Add(typeof(ITraktPerson), new TraktPersonJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktPersonIds), new TraktPersonIdsJsonReaderFactory());

            // people credit objects
            s_readerFactories.Add(typeof(ITraktPersonMovieCredits), new TraktPersonMovieCreditsJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktPersonMovieCreditsCastItem), new TraktPersonMovieCreditsCastItemJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktPersonMovieCreditsCrew), new TraktPersonMovieCreditsCrewJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktPersonMovieCreditsCrewItem), new TraktPersonMovieCreditsCrewItemJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktPersonShowCredits), new TraktPersonShowCreditsJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktPersonShowCreditsCastItem), new TraktPersonShowCreditsCastItemJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktPersonShowCreditsCrew), new TraktPersonShowCreditsCrewJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktPersonShowCreditsCrewItem), new TraktPersonShowCreditsCrewItemJsonReaderFactory());

            // post response objects
            s_readerFactories.Add(typeof(ITraktPostResponseNotFoundEpisode), new TraktPostResponseNotFoundEpisodeJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktPostResponseNotFoundMovie), new TraktPostResponseNotFoundMovieJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktPostResponseNotFoundPerson), new TraktPostResponseNotFoundPersonJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktPostResponseNotFoundSeason), new TraktPostResponseNotFoundSeasonJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktPostResponseNotFoundShow), new TraktPostResponseNotFoundShowJsonReaderFactory());

            // rating objects
            s_readerFactories.Add(typeof(ITraktRatingsItem), new TraktRatingsItemJsonReaderFactory());

            // season objects
            s_readerFactories.Add(typeof(ITraktSeason), new TraktSeasonJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSeasonIds), new TraktSeasonIdsJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSeasonCollectionProgress), new TraktSeasonCollectionProgressJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSeasonWatchedProgress), new TraktSeasonWatchedProgressJsonReaderFactory());

            // scrobble post response objects
            s_readerFactories.Add(typeof(ITraktEpisodeScrobblePostResponse), new TraktEpisodeScrobblePostResponseJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktMovieScrobblePostResponse), new TraktMovieScrobblePostResponseJsonReaderFactory());

            // show objects
            s_readerFactories.Add(typeof(ITraktShow), new TraktShowJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktShowAirs), new TraktShowAirsJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktShowAlias), new TraktShowAliasJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktShowIds), new TraktShowIdsJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktShowTranslation), new TraktShowTranslationJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktShowCollectionProgress), new TraktShowCollectionProgressJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktShowWatchedProgress), new TraktShowWatchedProgressJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktMostAnticipatedShow), new TraktMostAnticipatedShowJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktMostPWCShow), new TraktMostPWCShowJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktRecentlyUpdatedShow), new TraktRecentlyUpdatedShowJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktTrendingShow), new TraktTrendingShowJsonReaderFactory());

            // sync activities objects
            s_readerFactories.Add(typeof(ITraktSyncLastActivities), new TraktSyncLastActivitiesJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSyncCommentsLastActivities), new TraktSyncCommentsLastActivitiesJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSyncEpisodesLastActivities), new TraktSyncEpisodesLastActivitiesJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSyncListsLastActivities), new TraktSyncListsLastActivitiesJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSyncMoviesLastActivities), new TraktSyncMoviesLastActivitiesJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSyncSeasonsLastActivities), new TraktSyncSeasonsLastActivitiesJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSyncShowsLastActivities), new TraktSyncShowsLastActivitiesJsonReaderFactory());

            // sync collection post response objects
            s_readerFactories.Add(typeof(ITraktSyncCollectionPostResponse), new TraktSyncCollectionPostResponseJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSyncCollectionRemovePostResponse), new TraktSyncCollectionRemovePostResponseJsonReaderFactory());

            // sync history post response objects
            s_readerFactories.Add(typeof(ITraktSyncHistoryPostResponse), new TraktSyncHistoryPostResponseJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSyncHistoryRemovePostResponse), new TraktSyncHistoryRemovePostResponseJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSyncHistoryRemovePostResponseGroup), new TraktSyncHistoryRemovePostResponseGroupJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSyncHistoryRemovePostResponseNotFoundGroup), new TraktSyncHistoryRemovePostResponseNotFoundGroupJsonReaderFactory());

            // sync rating post response objects
            s_readerFactories.Add(typeof(ITraktSyncRatingsPostResponse), new TraktSyncRatingsPostResponseJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSyncRatingsPostResponseNotFoundEpisode), new TraktSyncRatingsPostResponseNotFoundEpisodeJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSyncRatingsPostResponseNotFoundGroup), new TraktSyncRatingsPostResponseNotFoundGroupJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSyncRatingsPostResponseNotFoundMovie), new TraktSyncRatingsPostResponseNotFoundMovieJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSyncRatingsPostResponseNotFoundSeason), new TraktSyncRatingsPostResponseNotFoundSeasonJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSyncRatingsPostResponseNotFoundShow), new TraktSyncRatingsPostResponseNotFoundShowJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSyncRatingsRemovePostResponse), new TraktSyncRatingsRemovePostResponseJsonReaderFactory());

            // sync playback objects
            s_readerFactories.Add(typeof(ITraktSyncPlaybackProgressItem), new TraktSyncPlaybackProgressItemJsonReaderFactory());

            // sync response objects
            s_readerFactories.Add(typeof(ITraktSyncPostResponseGroup), new TraktSyncPostResponseGroupJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSyncPostResponseNotFoundGroup), new TraktSyncPostResponseNotFoundGroupJsonReaderFactory());

            // sync watchlist post response objects
            s_readerFactories.Add(typeof(ITraktSyncWatchlistPostResponse), new TraktSyncWatchlistPostResponseJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSyncWatchlistRemovePostResponse), new TraktSyncWatchlistRemovePostResponseJsonReaderFactory());

            // user custom list items post response objects
            s_readerFactories.Add(typeof(ITraktUserCustomListItemsPostResponse), new TraktUserCustomListItemsPostResponseJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktUserCustomListItemsPostResponseGroup), new TraktUserCustomListItemsPostResponseGroupJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktUserCustomListItemsPostResponseNotFoundGroup), new TraktUserCustomListItemsPostResponseNotFoundGroupJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktUserCustomListItemsRemovePostResponse), new TraktUserCustomListItemsRemovePostResponseJsonReaderFactory());

            // user objects
            s_readerFactories.Add(typeof(ITraktUser), new TraktUserJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktUserComment), new TraktUserCommentJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktUserFollower), new TraktUserFollowerJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktUserFollowRequest), new TraktUserFollowRequestJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktUserFriend), new TraktUserFriendJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktUserHiddenItem), new TraktUserHiddenItemJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktUserIds), new TraktUserIdsJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktUserImages), new TraktUserImagesJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktUserLikeItem), new TraktUserLikeItemJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktUserSettings), new TraktUserSettingsJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktUserWatchingItem), new TraktUserWatchingItemJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktAccountSettings), new TraktAccountSettingsJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktSharingText), new TraktSharingTextJsonReaderFactory());

            // user list objects
            s_readerFactories.Add(typeof(ITraktList), new TraktListJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktListIds), new TraktListIdsJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktListItem), new TraktListItemJsonReaderFactory());

            // user response post objects
            s_readerFactories.Add(typeof(ITraktUserFollowUserPostResponse), new TraktUserFollowUserPostResponseJsonReaderFactory());

            // user statistic objects
            s_readerFactories.Add(typeof(ITraktUserStatistics), new TraktUserStatisticsJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktUserEpisodesStatistics), new TraktUserEpisodesStatisticsJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktUserMoviesStatistics), new TraktUserMoviesStatisticsJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktUserNetworkStatistics), new TraktUserNetworkStatisticsJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktUserRatingsStatistics), new TraktUserRatingsStatisticsJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktUserSeasonsStatistics), new TraktUserSeasonsStatisticsJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktUserShowsStatistics), new TraktUserShowsStatisticsJsonReaderFactory());

            // watched objects
            s_readerFactories.Add(typeof(ITraktWatchedShowEpisode), new TraktWatchedShowEpisodeJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktWatchedShowSeason), new TraktWatchedShowSeasonJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktWatchedShow), new TraktWatchedShowJsonReaderFactory());
            s_readerFactories.Add(typeof(ITraktWatchedMovie), new TraktWatchedMovieJsonReaderFactory());

            // watchlist objects
            s_readerFactories.Add(typeof(ITraktWatchlistItem), new TraktWatchlistItemJsonReaderFactory());
        }
    }
}