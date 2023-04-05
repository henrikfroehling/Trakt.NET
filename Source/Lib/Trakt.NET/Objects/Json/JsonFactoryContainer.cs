namespace TraktNet.Objects.Json
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
    using Get.Lists;
    using Get.Lists.Json.Factories;
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
    using Get.Users.Statistics;
    using Get.Users.Statistics.Json.Factories;
    using Get.Watched;
    using Get.Watched.Json.Factories;
    using Get.Watchlist;
    using Get.Watchlist.Json.Factories;
    using Post.Basic;
    using Post.Basic.Json.Factories;
    using Post.Basic.Responses;
    using Post.Basic.Responses.Json.Factories;
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
    using Post.Shows;
    using Post.Shows.Json.Factories;
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
    using Post.Syncs.Recommendations;
    using Post.Syncs.Recommendations.Json.Factories;
    using Post.Syncs.Recommendations.Responses;
    using Post.Syncs.Recommendations.Responses.Json.Factories;
    using Post.Syncs.Responses;
    using Post.Syncs.Responses.Json.Factories;
    using Post.Syncs.Watchlist;
    using Post.Syncs.Watchlist.Json.Factories;
    using Post.Syncs.Watchlist.Responses;
    using Post.Syncs.Watchlist.Responses.Json.Factories;
    using Post.Users;
    using Post.Users.HiddenItems;
    using Post.Users.HiddenItems.Json.Factories;
    using Post.Users.HiddenItems.Responses;
    using Post.Users.HiddenItems.Responses.Json.Factories;
    using Post.Users.Json.Factories;
    using Post.Users.PersonalListItems;
    using Post.Users.PersonalListItems.Json.Factories;
    using Post.Users.PersonalListItems.Responses;
    using Post.Users.PersonalListItems.Responses.Json.Factories;
    using Post.Users.Responses;
    using Post.Users.Responses.Json.Factories;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    internal static class JsonFactoryContainer
    {
        private static readonly Dictionary<Type, object> s_jsonIOFactories = new();

        public static IObjectJsonReader<TReturnType> CreateObjectReader<TReturnType>()
        {
            var factory = GetJsonIOFactory<TReturnType>();
            Debug.Assert(factory != null, $"factory for {nameof(TReturnType)} should not be null");
            return factory.CreateObjectReader();
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
            s_jsonIOFactories.Add(typeof(ITraktConnections), new ConnectionsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktCountry), new CountryJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktCrew), new CrewJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktCrewMember), new CrewMemberJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktError), new ErrorJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktGenre), new GenreJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktIds), new IdsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktImage), new ImageJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktLanguage), new LanguageJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktMetadata), new MetadataJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktNetwork), new NetworkJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktRateLimitInfo), new RateLimitInfoJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktRating), new RatingJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSearchResult), new SearchResultJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktStatistics), new StatisticsJsonIOFactory());

            // basic post objects
            s_jsonIOFactories.Add(typeof(ITraktListItemsReorderPost), new ListItemsReorderPostJsonIOFactory());

            // user response post objects
            s_jsonIOFactories.Add(typeof(ITraktListItemsReorderPostResponse), new ListItemsReorderPostResponseJsonIOFactory());

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
            s_jsonIOFactories.Add(typeof(ITraktPersonSocialIds), new PersonSocialIdsJsonIOFactory());

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
            s_jsonIOFactories.Add(typeof(ITraktPostResponseListData), new PostResponseListDataJsonIOFactory());
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
            s_jsonIOFactories.Add(typeof(ITraktSeasonTranslation), new SeasonTranslationJsonIOFactory());
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
            s_jsonIOFactories.Add(typeof(ITraktShowCastAndCrew), new ShowCastAndCrewJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktShowCastMember), new ShowCastMemberJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktShowCollectionProgress), new ShowCollectionProgressJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktShowCrew), new ShowCrewJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktShowCrewMember), new ShowCrewMemberJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktShowWatchedProgress), new ShowWatchedProgressJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktMostAnticipatedShow), new MostAnticipatedShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktMostPWCShow), new MostPWCShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktRecentlyUpdatedShow), new RecentlyUpdatedShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktTrendingShow), new TrendingShowJsonIOFactory());

            // sync activities objects
            s_jsonIOFactories.Add(typeof(ITraktSyncAccountLastActivities), new SyncAccountLastActivitiesJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncCommentsLastActivities), new SyncCommentsLastActivitiesJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncEpisodesLastActivities), new SyncEpisodesLastActivitiesJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncLastActivities), new SyncLastActivitiesJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncListsLastActivities), new SyncListsLastActivitiesJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncMoviesLastActivities), new SyncMoviesLastActivitiesJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRecommendationsLastActivities), new SyncRecommendationsLastActivitiesJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncSavedFiltersLastActivities), new SyncSavedFiltersLastActivitiesJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncSeasonsLastActivities), new SyncSeasonsLastActivitiesJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncShowsLastActivities), new SyncShowsLastActivitiesJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncWatchlistLastActivities), new SyncWatchlistLastActivitiesJsonIOFactory());

            // show post objects
            s_jsonIOFactories.Add(typeof(ITraktShowResetWatchedProgressPost), new ShowResetWatchedProgressPostJsonIOFactory());

            // sync collection post objects
            s_jsonIOFactories.Add(typeof(ITraktSyncCollectionPost), new SyncCollectionPostJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncCollectionPostEpisode), new SyncCollectionPostEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncCollectionPostMovie), new SyncCollectionPostMovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncCollectionPostSeason), new SyncCollectionPostSeasonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncCollectionPostShow), new SyncCollectionPostShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncCollectionPostShowEpisode), new SyncCollectionPostShowEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncCollectionPostShowSeason), new SyncCollectionPostShowSeasonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncCollectionRemovePost), new SyncCollectionRemovePostJsonIOFactory());

            // sync collection post response objects
            s_jsonIOFactories.Add(typeof(ITraktSyncCollectionPostResponse), new SyncCollectionPostResponseJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncCollectionRemovePostResponse), new SyncCollectionRemovePostResponseJsonIOFactory());

            // sync history post objects
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryPost), new SyncHistoryPostJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryPostEpisode), new SyncHistoryPostEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryPostMovie), new SyncHistoryPostMovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryPostSeason), new SyncHistoryPostSeasonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryPostShow), new SyncHistoryPostShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryPostShowEpisode), new SyncHistoryPostShowEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryPostShowSeason), new SyncHistoryPostShowSeasonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryRemovePost), new SyncHistoryRemovePostJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryRemovePostEpisode), new SyncHistoryRemovePostEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryRemovePostMovie), new SyncHistoryRemovePostMovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryRemovePostSeason), new SyncHistoryRemovePostSeasonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryRemovePostShow), new SyncHistoryRemovePostShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryRemovePostShowEpisode), new SyncHistoryRemovePostShowEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryRemovePostShowSeason), new SyncHistoryRemovePostShowSeasonJsonIOFactory());

            // sync history post response objects
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryPostResponse), new SyncHistoryPostResponseJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryRemovePostResponse), new SyncHistoryRemovePostResponseJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryRemovePostResponseGroup), new SyncHistoryRemovePostResponseGroupJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncHistoryRemovePostResponseNotFoundGroup), new SyncHistoryRemovePostResponseNotFoundGroupJsonIOFactory());

            // sync ratings post objects
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPost), new SyncRatingsPostJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostEpisode), new SyncRatingsPostEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostMovie), new SyncRatingsPostMovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostSeason), new SyncRatingsPostSeasonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostShow), new SyncRatingsPostShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostShowEpisode), new SyncRatingsPostShowEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostShowSeason), new SyncRatingsPostShowSeasonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsRemovePost), new SyncRatingsRemovePostJsonIOFactory());

            // sync rating post response objects
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostResponse), new SyncRatingsPostResponseJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostResponseNotFoundEpisode), new SyncRatingsPostResponseNotFoundEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostResponseNotFoundGroup), new SyncRatingsPostResponseNotFoundGroupJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostResponseNotFoundMovie), new SyncRatingsPostResponseNotFoundMovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostResponseNotFoundSeason), new SyncRatingsPostResponseNotFoundSeasonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsPostResponseNotFoundShow), new SyncRatingsPostResponseNotFoundShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRatingsRemovePostResponse), new SyncRatingsRemovePostResponseJsonIOFactory());

            // sync recommendations post objects
            s_jsonIOFactories.Add(typeof(ITraktSyncRecommendationsPost), new SyncRecommendationsPostJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRecommendationsPostMovie), new SyncRecommendationsPostMovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRecommendationsPostShow), new SyncRecommendationsPostShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRecommendationsRemovePost), new SyncRecommendationsRemovePostJsonIOFactory());

            // sync recommendations post response objects
            s_jsonIOFactories.Add(typeof(ITraktSyncRecommendationsPostResponse), new SyncRecommendationsPostResponseJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRecommendationsRemovePostResponse), new SyncRecommendationsRemovePostResponseJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRecommendationsPostResponseGroup), new SyncRecommendationsPostResponseGroupJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncRecommendationsPostResponseNotFoundGroup), new SyncRecommendationsPostResponseNotFoundGroupJsonIOFactory());

            // sync playback objects
            s_jsonIOFactories.Add(typeof(ITraktSyncPlaybackProgressItem), new SyncPlaybackProgressItemJsonIOFactory());

            // sync response objects
            s_jsonIOFactories.Add(typeof(ITraktSyncPostResponseGroup), new SyncPostResponseGroupJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncPostResponseNotFoundGroup), new SyncPostResponseNotFoundGroupJsonIOFactory());

            // sync watchlist post objects
            s_jsonIOFactories.Add(typeof(ITraktSyncWatchlistPost), new SyncWatchlistPostJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncWatchlistPostEpisode), new SyncWatchlistPostEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncWatchlistPostMovie), new SyncWatchlistPostMovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncWatchlistPostSeason), new SyncWatchlistPostSeasonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncWatchlistPostShow), new SyncWatchlistPostShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncWatchlistPostShowEpisode), new SyncWatchlistPostShowEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncWatchlistPostShowSeason), new SyncWatchlistPostShowSeasonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncWatchlistRemovePost), new SyncWatchlistRemovePostJsonIOFactory());

            // sync watchlist post response objects
            s_jsonIOFactories.Add(typeof(ITraktSyncWatchlistPostResponse), new SyncWatchlistPostResponseJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSyncWatchlistRemovePostResponse), new SyncWatchlistRemovePostResponseJsonIOFactory());

            // user personal list items post objects
            s_jsonIOFactories.Add(typeof(ITraktUserPersonalListItemsPost), new UserPersonalListItemsPostJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserPersonalListItemsPostEpisode), new UserPersonalListItemsPostEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserPersonalListItemsPostMovie), new UserPersonalListItemsPostMovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserPersonalListItemsPostPerson), new UserPersonalListItemsPostPersonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserPersonalListItemsPostSeason), new UserPersonalListItemsPostSeasonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserPersonalListItemsPostShow), new UserPersonalListItemsPostShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserPersonalListItemsPostShowEpisode), new UserPersonalListItemsPostShowEpisodeJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserPersonalListItemsPostShowSeason), new UserPersonalListItemsPostShowSeasonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserPersonalListItemsRemovePost), new UserPersonalListItemsRemovePostJsonIOFactory());

            // user personal list items post response objects
            s_jsonIOFactories.Add(typeof(ITraktUserPersonalListItemsPostResponse), new UserPersonalListItemsPostResponseJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserPersonalListItemsPostResponseGroup), new UserPersonalListItemsPostResponseGroupJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserPersonalListItemsPostResponseNotFoundGroup), new UserPersonalListItemsPostResponseNotFoundGroupJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserPersonalListItemsRemovePostResponse), new UserPersonalListItemsRemovePostResponseJsonIOFactory());

            // user hidden items post objects
            s_jsonIOFactories.Add(typeof(ITraktUserHiddenItemsPost), new UserHiddenItemsPostJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserHiddenItemsPostMovie), new UserHiddenItemsPostMovieJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserHiddenItemsPostSeason), new UserHiddenItemsPostSeasonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserHiddenItemsPostShow), new UserHiddenItemsPostShowJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserHiddenItemsPostShowSeason), new UserHiddenItemsPostShowSeasonJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserHiddenItemsRemovePost), new UserHiddenItemsRemovePostJsonIOFactory());

            // user hidden items post response objects
            s_jsonIOFactories.Add(typeof(ITraktUserHiddenItemsPostResponse), new UserHiddenItemsPostResponseJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserHiddenItemsPostResponseGroup), new UserHiddenItemsPostResponseGroupJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserHiddenItemsPostResponseNotFoundGroup), new UserHiddenItemsPostResponseNotFoundGroupJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserHiddenItemsRemovePostResponse), new UserHiddenItemsRemovePostResponseJsonIOFactory());

            // user objects
            s_jsonIOFactories.Add(typeof(ITraktAccountSettings), new AccountSettingsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktRecommendation), new RecommendationJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktSharingText), new SharingTextJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUser), new UserJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserComment), new UserCommentJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserFollower), new UserFollowerJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserFollowRequest), new UserFollowRequestJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserFriend), new UserFriendJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserHiddenItem), new UserHiddenItemJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserIds), new UserIdsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserImages), new UserImagesJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserLikeItem), new UserLikeItemJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserLimits), new UserLimitsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserListLimits), new UserListLimitsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserRecommendationsLimits), new UserRecommendationsLimitsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserSavedFilter), new UserSavedFilterJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserSettings), new UserSettingsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserWatchingItem), new UserWatchingItemJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktUserWatchlistLimits), new UserWatchlistLimitsJsonIOFactory());

            // user list objects
            s_jsonIOFactories.Add(typeof(ITraktList), new ListJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktListIds), new ListIdsJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktListItem), new ListItemJsonIOFactory());
            s_jsonIOFactories.Add(typeof(ITraktListLike), new ListLikeJsonIOFactory());

            // user post objects
            s_jsonIOFactories.Add(typeof(ITraktUserPersonalListPost), new UserPersonalListPostJsonIOFactory());

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
