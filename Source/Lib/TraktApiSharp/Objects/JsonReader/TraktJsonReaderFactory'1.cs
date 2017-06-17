namespace TraktApiSharp.Objects.JsonReader
{
    using Basic;
    using Basic.JsonReader;
    using Get.Calendars;
    using Get.Calendars.JsonReader;
    using Get.Collections;
    using Get.Collections.JsonReader;
    using Get.Episodes;
    using Get.Episodes.JsonReader;
    using Get.History;
    using Get.History.JsonReader;
    using Get.Movies;
    using Get.Movies.JsonReader;
    using Get.People;
    using Get.People.Credits;
    using Get.People.Credits.JsonReader;
    using Get.People.JsonReader;
    using Get.Ratings;
    using Get.Ratings.JsonReader;
    using Get.Seasons;
    using Get.Seasons.JsonReader;
    using Get.Shows;
    using Get.Shows.JsonReader;
    using Get.Syncs.Activities;
    using Get.Syncs.Activities.JsonReader;
    using Get.Syncs.Playback;
    using Get.Syncs.Playback.JsonReader;
    using Get.Users;
    using Get.Users.JsonReader;
    using Get.Users.Lists;
    using Get.Users.Lists.JsonReader;
    using Get.Users.Statistics;
    using Get.Users.Statistics.JsonReader;
    using Get.Watched;
    using Get.Watched.JsonReader;
    using Get.Watchlist;
    using Get.Watchlist.JsonReader;
    using System;
    using System.Collections.Generic;

    internal static class TraktJsonReaderFactory
    {
        private static readonly Dictionary<Type, Type> s_objectReaders = new Dictionary<Type, Type>();
        private static readonly Dictionary<Type, Type> s_arrayReaders = new Dictionary<Type, Type>();

        public static ITraktObjectJsonReader<TReturnType> CreateObjectReader<TReturnType>()
        {
            var type = typeof(TReturnType);

            if (!s_objectReaders.ContainsKey(type))
                throw new NotSupportedException($"A json reader for {nameof(TReturnType)} is not supported.");

            var typeOfReader = s_objectReaders[type];
            return (ITraktObjectJsonReader<TReturnType>)Activator.CreateInstance(typeOfReader);
        }

        public static ITraktObjectJsonReader<TReturnType> CreateArrayReader<TReturnType>()
        {
            var type = typeof(TReturnType);

            if (!s_arrayReaders.ContainsKey(type))
                throw new NotSupportedException($"A json reader for {nameof(TReturnType)} is not supported.");

            var typeOfReader = s_arrayReaders[type];
            return (ITraktObjectJsonReader<TReturnType>)Activator.CreateInstance(typeOfReader);
        }

        static TraktJsonReaderFactory()
        {
            // basic objects
            s_objectReaders.Add(typeof(ITraktCastAndCrew), typeof(TraktCastAndCrewObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktCastMember), typeof(TraktCastMemberObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktComment), typeof(TraktCommentObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktCrew), typeof(TraktCrewObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktCrewMember), typeof(TraktCrewMemberObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktError), typeof(TraktErrorObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktGenre), typeof(TraktGenreObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktIds), typeof(TraktIdsObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktImage), typeof(TraktImageObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktMetadata), typeof(TraktMetadataObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktRating), typeof(TraktRatingObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktSearchResult), typeof(TraktSearchResultObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktSharing), typeof(TraktSharingObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktStatistics), typeof(TraktStatisticsObjectJsonReader));

            // calendar objects
            s_objectReaders.Add(typeof(ITraktCalendarMovie), typeof(TraktCalendarMovieObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktCalendarShow), typeof(TraktCalendarShowObjectJsonReader));

            // collection objects
            s_objectReaders.Add(typeof(ITraktCollectionShowEpisode), typeof(TraktCollectionShowEpisodeObjectJsonReader));
            s_arrayReaders.Add(typeof(ITraktCollectionShowEpisode), typeof(TraktCollectionShowEpisodeArrayJsonReader));
            s_objectReaders.Add(typeof(ITraktCollectionShowSeason), typeof(TraktCollectionShowSeasonObjectJsonReader));
            s_arrayReaders.Add(typeof(ITraktCollectionShowSeason), typeof(TraktCollectionShowSeasonArrayJsonReader));
            s_objectReaders.Add(typeof(ITraktCollectionShow), typeof(TraktCollectionShowObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktCollectionMovie), typeof(TraktCollectionMovieObjectJsonReader));

            // episode objects
            s_objectReaders.Add(typeof(ITraktEpisode), typeof(TraktEpisodeObjectJsonReader));
            s_arrayReaders.Add(typeof(ITraktEpisode), typeof(TraktEpisodeArrayJsonReader));
            s_objectReaders.Add(typeof(ITraktEpisodeIds), typeof(TraktEpisodeIdsObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktEpisodeTranslation), typeof(TraktEpisodeTranslationObjectJsonReader));
            s_arrayReaders.Add(typeof(ITraktEpisodeTranslation), typeof(TraktEpisodeTranslationArrayJsonReader));
            s_objectReaders.Add(typeof(ITraktEpisodeCollectionProgress), typeof(TraktEpisodeCollectionProgressObjectJsonReader));
            s_arrayReaders.Add(typeof(ITraktEpisodeCollectionProgress), typeof(TraktEpisodeCollectionProgressArrayJsonReader));
            s_objectReaders.Add(typeof(ITraktEpisodeWatchedProgress), typeof(TraktEpisodeWatchedProgressObjectJsonReader));
            s_arrayReaders.Add(typeof(ITraktEpisodeWatchedProgress), typeof(TraktEpisodeWatchedProgressArrayJsonReader));

            // history objects
            s_objectReaders.Add(typeof(ITraktHistoryItem), typeof(TraktHistoryItemObjectJsonReader));

            // movie objects
            s_objectReaders.Add(typeof(ITraktMovie), typeof(TraktMovieObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktMovieAlias), typeof(TraktMovieAliasObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktMovieIds), typeof(TraktMovieIdsObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktMovieRelease), typeof(TraktMovieReleaseObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktMovieTranslation), typeof(TraktMovieTranslationObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktBoxOfficeMovie), typeof(TraktBoxOfficeMovieObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktMostAnticipatedMovie), typeof(TraktMostAnticipatedMovieObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktMostPWCMovie), typeof(TraktMostPWCMovieObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktRecentlyUpdatedMovie), typeof(TraktRecentlyUpdatedMovieObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktTrendingMovie), typeof(TraktTrendingMovieObjectJsonReader));

            // people objects
            s_objectReaders.Add(typeof(ITraktPerson), typeof(TraktPersonObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktPersonIds), typeof(TraktPersonIdsObjectJsonReader));

            // people credit objects
            s_objectReaders.Add(typeof(ITraktPersonMovieCredits), typeof(TraktPersonMovieCreditsObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktPersonMovieCreditsCastItem), typeof(TraktPersonMovieCreditsCastItemObjectJsonReader));
            s_arrayReaders.Add(typeof(ITraktPersonMovieCreditsCastItem), typeof(TraktPersonMovieCreditsCastItemArrayJsonReader));
            s_objectReaders.Add(typeof(ITraktPersonMovieCreditsCrew), typeof(TraktPersonMovieCreditsCrewObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktPersonMovieCreditsCrewItem), typeof(TraktPersonMovieCreditsCrewItemObjectJsonReader));
            s_arrayReaders.Add(typeof(ITraktPersonMovieCreditsCrewItem), typeof(TraktPersonMovieCreditsCrewItemArrayJsonReader));
            s_objectReaders.Add(typeof(ITraktPersonShowCredits), typeof(TraktPersonShowCreditsObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktPersonShowCreditsCastItem), typeof(TraktPersonShowCreditsCastItemObjectJsonReader));
            s_arrayReaders.Add(typeof(ITraktPersonShowCreditsCastItem), typeof(TraktPersonShowCreditsCastItemArrayJsonReader));
            s_objectReaders.Add(typeof(ITraktPersonShowCreditsCrew), typeof(TraktPersonShowCreditsCrewObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktPersonShowCreditsCrewItem), typeof(TraktPersonShowCreditsCrewItemObjectJsonReader));
            s_arrayReaders.Add(typeof(ITraktPersonShowCreditsCrewItem), typeof(TraktPersonShowCreditsCrewItemArrayJsonReader));

            // rating objects
            s_objectReaders.Add(typeof(ITraktRatingsItem), typeof(TraktRatingsItemObjectJsonReader));

            // season objects
            s_objectReaders.Add(typeof(ITraktSeason), typeof(TraktSeasonObjectJsonReader));
            s_arrayReaders.Add(typeof(ITraktSeason), typeof(TraktSeasonArrayJsonReader));
            s_objectReaders.Add(typeof(ITraktSeasonIds), typeof(TraktSeasonIdsObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktSeasonCollectionProgress), typeof(TraktSeasonCollectionProgressObjectJsonReader));
            s_arrayReaders.Add(typeof(ITraktSeasonCollectionProgress), typeof(TraktSeasonCollectionProgressArrayJsonReader));
            s_objectReaders.Add(typeof(ITraktSeasonWatchedProgress), typeof(TraktSeasonWatchedProgressObjectJsonReader));
            s_arrayReaders.Add(typeof(ITraktSeasonWatchedProgress), typeof(TraktSeasonWatchedProgressArrayJsonReader));

            // show objects
            s_objectReaders.Add(typeof(ITraktShow), typeof(TraktShowObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktShowAirs), typeof(TraktShowAirsObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktShowAlias), typeof(TraktShowAliasObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktShowIds), typeof(TraktShowIdsObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktShowTranslation), typeof(TraktShowTranslationObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktShowCollectionProgress), typeof(TraktShowCollectionProgressObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktShowWatchedProgress), typeof(TraktShowWatchedProgressObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktMostAnticipatedShow), typeof(TraktMostAnticipatedShowObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktMostPWCShow), typeof(TraktMostPWCShowObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktRecentlyUpdatedShow), typeof(TraktRecentlyUpdatedShowObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktTrendingShow), typeof(TraktTrendingShowObjectJsonReader));

            // sync activities objects
            s_objectReaders.Add(typeof(ITraktSyncLastActivities), typeof(TraktSyncLastActivitiesObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktSyncCommentsLastActivities), typeof(TraktSyncCommentsLastActivitiesObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktSyncEpisodesLastActivities), typeof(TraktSyncEpisodesLastActivitiesObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktSyncListsLastActivities), typeof(TraktSyncListsLastActivitiesObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktSyncMoviesLastActivities), typeof(TraktSyncMoviesLastActivitiesObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktSyncSeasonsLastActivities), typeof(TraktSyncSeasonsLastActivitiesObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktSyncShowsLastActivities), typeof(TraktSyncShowsLastActivitiesObjectJsonReader));

            // sync playback objects
            s_objectReaders.Add(typeof(ITraktSyncPlaybackProgressItem), typeof(TraktSyncPlaybackProgressItemObjectJsonReader));

            // user objects
            s_objectReaders.Add(typeof(ITraktUser), typeof(TraktUserObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktUserComment), typeof(TraktUserCommentObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktUserFollower), typeof(TraktUserFollowerObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktUserFollowRequest), typeof(TraktUserFollowRequestObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktUserFriend), typeof(TraktUserFriendObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktUserHiddenItem), typeof(TraktUserHiddenItemObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktUserIds), typeof(TraktUserIdsObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktUserImages), typeof(TraktUserImagesObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktUserLikeItem), typeof(TraktUserLikeItemObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktUserSettings), typeof(TraktUserSettingsObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktUserWatchingItem), typeof(TraktUserWatchingItemObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktAccountSettings), typeof(TraktAccountSettingsObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktSharingText), typeof(TraktSharingTextObjectJsonReader));

            // user list objects
            s_objectReaders.Add(typeof(ITraktList), typeof(TraktListObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktListIds), typeof(TraktListIdsObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktListItem), typeof(TraktListItemObjectJsonReader));

            // user statistic objects
            s_objectReaders.Add(typeof(ITraktUserStatistics), typeof(TraktUserStatisticsObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktUserEpisodesStatistics), typeof(TraktUserEpisodesStatisticsObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktUserMoviesStatistics), typeof(TraktUserMoviesStatisticsObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktUserNetworkStatistics), typeof(TraktUserNetworkStatisticsObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktUserRatingsStatistics), typeof(TraktUserRatingsStatisticsObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktUserSeasonsStatistics), typeof(TraktUserSeasonsStatisticsObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktUserShowsStatistics), typeof(TraktUserShowsStatisticsObjectJsonReader));

            // watched objects
            s_objectReaders.Add(typeof(ITraktWatchedShowEpisode), typeof(TraktWatchedShowEpisodeObjectJsonReader));
            s_arrayReaders.Add(typeof(ITraktWatchedShowEpisode), typeof(TraktWatchedShowEpisodeArrayJsonReader));
            s_objectReaders.Add(typeof(ITraktWatchedShowSeason), typeof(TraktWatchedShowSeasonObjectJsonReader));
            s_arrayReaders.Add(typeof(ITraktWatchedShowSeason), typeof(TraktWatchedShowSeasonArrayJsonReader));
            s_objectReaders.Add(typeof(ITraktWatchedShow), typeof(TraktWatchedShowObjectJsonReader));
            s_objectReaders.Add(typeof(ITraktWatchedMovie), typeof(TraktWatchedMovieObjectJsonReader));

            // watchlist objects
            s_objectReaders.Add(typeof(ITraktWatchlistItem), typeof(TraktWatchlistItemObjectJsonReader));
        }
    }
}
