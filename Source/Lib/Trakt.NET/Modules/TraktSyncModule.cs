namespace TraktNet.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Get.Collections;
    using Objects.Get.History;
    using Objects.Get.Ratings;
    using Objects.Get.Syncs.Activities;
    using Objects.Get.Syncs.Playback;
    using Objects.Get.Users;
    using Objects.Get.Watched;
    using Objects.Get.Watchlist;
    using Objects.Post;
    using Objects.Post.Syncs.Collection;
    using Objects.Post.Syncs.Collection.Responses;
    using Objects.Post.Syncs.History;
    using Objects.Post.Syncs.History.Responses;
    using Objects.Post.Syncs.Ratings;
    using Objects.Post.Syncs.Ratings.Responses;
    using Objects.Post.Syncs.Watchlist;
    using Objects.Post.Syncs.Watchlist.Responses;
    using Requests.Handler;
    using Requests.Parameters;
    using Requests.Syncs.OAuth;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to sync.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/sync">"Trakt API Doc - Sync"</a> section.
    /// </para>
    /// </summary>
    public class TraktSyncModule : ATraktModule
    {
        internal TraktSyncModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Gets the user's last activities.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/last-activities/get-last-activity">"Trakt API Doc - Sync: Last Activities"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktSyncLastActivities" /> instance with the queried last activities.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktResponse<ITraktSyncLastActivities>> GetLastActivitiesAsync(CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteSingleItemRequestAsync(new SyncLastActivitiesRequest(), cancellationToken);
        }

        /// <summary>
        /// Gets an user's personal recommendations for movies and / or shows.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/sync/get-personal-recommendations/get-personal-recommendations">"Trakt API Doc - Sync: Personal Recommendations"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="recommendationObjectType">Determines, which type of recommendation items should be queried. See also <seealso cref="TraktRecommendationObjectType" />.</param>
        /// <param name="sortOrder">
        /// The recommendations sort order. See also <seealso cref="TraktWatchlistSortOrder" />.
        /// Will be ignored, if the given array contains a number higher than 10 or below 1 or if it contains more than ten numbers.
        /// Will be ignored, if the given <paramref name="recommendationObjectType" /> is null or unspecified.
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the recommendation items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktRecommendation" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktRecommendation>> GetPersonalRecommendationsAsync(TraktRecommendationObjectType recommendationObjectType = null,
                                                                                              TraktWatchlistSortOrder sortOrder = null, TraktExtendedInfo extendedInfo = null,
                                                                                              TraktPagedParameters pagedParameters = null, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new SyncPersonalRecommendationsRequest
            {
                Type = recommendationObjectType,
                Sort = sortOrder,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the user's saved playback progress of scrobbles that are paused.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/last-activities/get-playback-progress">"Trakt API Doc - Sync: Playback"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="objectType">Determines, which type of items should be queried. By default, all types will be returned. See also <seealso cref="TraktSyncType" />.</param>
        /// <param name="startAt">Determines an optional start date and time for a range of the returned playback progress.</param>
        /// <param name="endAt">Determines an optional end date and time for a range of the returned playback progress.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktSyncPlaybackProgressItem" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktSyncPlaybackProgressItem>> GetPlaybackProgressAsync(TraktSyncType objectType = null,
                                                                                                 DateTime? startAt = null,
                                                                                                 DateTime? endAt = null,
                                                                                                 TraktPagedParameters pagedParameters = null,
                                                                                                 CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new SyncPlaybackProgressRequest
            {
                Type = objectType,
                StartAt = startAt,
                EndAt = endAt,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }

        /// <summary>
        /// Removes a playback progress item from the user's playback progress list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/remove-playback/remove-a-playback-item">"Trakt API Doc - Sync: Remove Playback"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="playbackId">The id of the playback progress item, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given playback progress id is null, empty or contains spaces.</exception>
        public Task<TraktNoContentResponse> RemovePlaybackItemAsync(uint playbackId, CancellationToken cancellationToken = default)
        {
            if (playbackId == 0)
                throw new ArgumentOutOfRangeException(nameof(playbackId), "playback id not valid");

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new SyncPlaybackDeleteRequest
            {
                Id = playbackId.ToString()
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all collected movies in the user's collection.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/get-collection/get-collection">"Trakt API Doc - Sync: Get Collection"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the collected movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktCollectionMovie" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktListResponse<ITraktCollectionMovie>> GetCollectionMoviesAsync(TraktExtendedInfo extendedInfo = null,
                                                                                       CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new SyncCollectionMoviesRequest
            {
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all collected shows in the user's collection.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/get-collection/get-collection">"Trakt API Doc - Sync: Get Collection"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the collected shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktCollectionShow" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktListResponse<ITraktCollectionShow>> GetCollectionShowsAsync(TraktExtendedInfo extendedInfo = null,
                                                                                     CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new SyncCollectionShowsRequest
            {
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        /// <summary>
        /// Adds items to the user's collection. Accepts shows, seasons, episodes and movies.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/get-collection/add-items-to-collection">"Trakt API Doc - Sync: Add to Collection"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktSyncCollectionPostBuilder" /> to create an instance
        /// of the required <see cref="ITraktSyncCollectionPost" />.
        /// See also <seealso cref="TraktPost.NewSyncCollectionPost()" />.
        /// </para>
        /// </summary>
        /// <param name="collectionPost">An <see cref="ITraktSyncCollectionPost" /> instance containing all shows, seasons, episodes and movies, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktSyncCollectionPostResponse" /> instance, which contains information about which items were added, updated, existing and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given collection post is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given collection post is empty.</exception>
        public Task<TraktResponse<ITraktSyncCollectionPostResponse>> AddCollectionItemsAsync(ITraktSyncCollectionPost collectionPost,
                                                                                             CancellationToken cancellationToken = default)
        {
            ValidateCollectionPost(collectionPost);
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new SyncCollectionAddRequest
            {
                RequestBody = collectionPost
            },
            cancellationToken);
        }

        /// <summary>
        /// Removes items from the user's collection. Accepts shows, seasons, episodes and movies.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/remove-from-collection/remove-items-from-collection">"Trakt API Doc - Sync: Remove from Collection"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktSyncCollectionPostBuilder" /> to create an instance
        /// of the required <see cref="ITraktSyncCollectionPost" />.
        /// See also <seealso cref="TraktPost.NewSyncCollectionPost()" />.
        /// </para>
        /// </summary>
        /// <param name="collectionRemovePost">An <see cref="ITraktSyncCollectionPost" /> instance containing all shows, seasons, episodes and movies, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktSyncCollectionRemovePostResponse" /> instance, which contains information about which items were deleted and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given collection remove post is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given collection remove post is empty.</exception>
        public Task<TraktResponse<ITraktSyncCollectionRemovePostResponse>> RemoveCollectionItemsAsync(ITraktSyncCollectionPost collectionRemovePost,
                                                                                                      CancellationToken cancellationToken = default)
        {
            ValidateCollectionPost(collectionRemovePost);
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new SyncCollectionRemoveRequest
            {
                RequestBody = collectionRemovePost
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all movies the user has watched, sorted by most plays.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/get-watched/get-watched">"Trakt API Doc - Sync: Get Watched"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktWatchedMovie" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktListResponse<ITraktWatchedMovie>> GetWatchedMoviesAsync(TraktExtendedInfo extendedInfo = null,
                                                                                 CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new SyncWatchedMoviesRequest
            {
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all shows the user has watched, sorted by most plays.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/get-watched/get-watched">"Trakt API Doc - Sync: Get Watched"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktWatchedShow" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktListResponse<ITraktWatchedShow>> GetWatchedShowsAsync(TraktExtendedInfo extendedInfo = null,
                                                                               CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new SyncWatchedShowsRequest
            {
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all movies, shows, seasons and / or episodes the user has watched, sorted by most recent.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/get-history/get-watched-history">"Trakt API Doc - Sync: Get History"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="historyItemType">Determines, which type of history items should be queried. See also <seealso cref="TraktSyncItemType" />.</param>
        /// <param name="itemId">The Trakt Id for the item, which should be specifically queried. Will be ignored, if <paramref name="historyItemType" /> is not set or unspecified.</param>
        /// <param name="startAt">The datetime, after which history items should be queried. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="endAt">The datetime, until which history items should be queried. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the history items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktHistoryItem}"/> instance containing the queried history items and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktHistoryItem" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktHistoryItem>> GetWatchedHistoryAsync(TraktSyncItemType historyItemType = null, uint? itemId = null,
                                                                                  DateTime? startAt = null, DateTime? endAt = null,
                                                                                  TraktExtendedInfo extendedInfo = null,
                                                                                  TraktPagedParameters pagedParameters = null,
                                                                                  CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new SyncWatchedHistoryRequest
            {
                Type = historyItemType,
                ItemId = itemId,
                StartAt = startAt,
                EndAt = endAt,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }

        /// <summary>
        /// Adds items to the user's watch history. Accepts shows, seasons, episodes and movies.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/add-to-history/add-items-to-watched-history">"Trakt API Doc - Sync: Add to History"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktSyncHistoryPostBuilder" /> to create an instance
        /// of the required <see cref="ITraktSyncHistoryPost" />.
        /// See also <seealso cref="TraktPost.NewSyncHistoryPost()" />.
        /// </para>
        /// </summary>
        /// <param name="historyPost">An <see cref="ITraktSyncHistoryPost" /> instance containing all shows, seasons, episodes and movies, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktSyncHistoryPostResponse" /> instance, which contains information about which items were added and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given history post is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given history post is empty.</exception>
        public Task<TraktResponse<ITraktSyncHistoryPostResponse>> AddWatchedHistoryItemsAsync(ITraktSyncHistoryPost historyPost,
                                                                                              CancellationToken cancellationToken = default)
        {
            ValidateHistoryPost(historyPost);
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new SyncWatchedHistoryAddRequest
            {
                RequestBody = historyPost
            },
            cancellationToken);
        }

        /// <summary>
        /// Removes items from the user's watch history. Accepts shows, seasons, episodes and movies.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/remove-from-history/remove-items-from-history">"Trakt API Doc - Sync: Remove from History"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktSyncHistoryRemovePostBuilder" /> to create an instance
        /// of the required <see cref="ITraktSyncHistoryRemovePost" />.
        /// See also <seealso cref="TraktPost.NewSyncHistoryRemovePost()" />.
        /// </para>
        /// </summary>
        /// <param name="historyRemovePost">An <see cref="ITraktSyncHistoryRemovePost" /> instance containing all shows, seasons, episodes and movies, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktSyncHistoryRemovePostResponse" /> instance, which contains information about which items were deleted and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given history remove post is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given history remove post is empty.</exception>
        public Task<TraktResponse<ITraktSyncHistoryRemovePostResponse>> RemoveWatchedHistoryItemsAsync(ITraktSyncHistoryRemovePost historyRemovePost,
                                                                                                       CancellationToken cancellationToken = default)
        {
            ValidateHistoryPost(historyRemovePost);
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new SyncWatchedHistoryRemoveRequest
            {
                RequestBody = historyRemovePost
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the user's ratings for movies, shows, seasons and / or episodes.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/get-ratings/get-ratings">"Trakt API Doc - Sync: Get Ratings"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="ratingsItemType">Determines, which type of rating items should be queried. See also <seealso cref="TraktRatingsItemType" />.</param>
        /// <param name="ratingsFilter">
        /// An array of numbers. Numbers should be between 1 and 10.
        /// Will be ignored, if the given array contains a number higher than 10 or below 1 or if it contains more than ten numbers.
        /// Will be ignored, if the given <paramref name="ratingsItemType" /> is null or unspecified.
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the rating items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktRatingsItem" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktRatingsItem>> GetRatingsAsync(TraktRatingsItemType ratingsItemType = null,
                                                                           int[] ratingsFilter = null,
                                                                           TraktExtendedInfo extendedInfo = null,
                                                                           TraktPagedParameters pagedParameters = null,
                                                                           CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new SyncRatingsRequest
            {
                Type = ratingsItemType,
                RatingFilter = ratingsFilter,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }

        /// <summary>
        /// Adds items to the user's ratings. Accepts shows, seasons, episodes and movies.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/add-ratings/add-new-ratings">"Trakt API Doc - Sync: Add Ratings"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktSyncRatingsPostBuilder" /> to create an instance
        /// of the required <see cref="ITraktSyncRatingsPost" />.
        /// See also <seealso cref="TraktPost.NewSyncRatingsPost()" />.
        /// </para>
        /// </summary>
        /// <param name="ratingsPost">An <see cref="ITraktSyncRatingsPost" /> instance containing all shows, seasons, episodes and movies, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktSyncRatingsPostResponse" /> instance, which contains information about which items were added and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given ratings post is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given ratings post is empty.</exception>
        public Task<TraktResponse<ITraktSyncRatingsPostResponse>> AddRatingsAsync(ITraktSyncRatingsPost ratingsPost,
                                                                                  CancellationToken cancellationToken = default)
        {
            ValidateRatingsPost(ratingsPost);
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new SyncRatingsAddRequest
            {
                RequestBody = ratingsPost
            },
            cancellationToken);
        }

        /// <summary>
        /// Removes items from the user's ratings. Accepts shows, seasons, episodes and movies.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/remove-ratings/remove-ratings">"Trakt API Doc - Sync: Remove Ratings"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktSyncRatingsPostBuilder" /> to create an instance
        /// of the required <see cref="ITraktSyncRatingsPost" />.
        /// See also <seealso cref="TraktPost.NewSyncRatingsPost()" />.
        /// </para>
        /// </summary>
        /// <param name="ratingsRemovePost">An <see cref="ITraktSyncRatingsPost" /> instance containing all shows, seasons, episodes and movies, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktSyncRatingsRemovePostResponse" /> instance, which contains information about which items were deleted and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given ratings remove post is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given ratings remove post is empty.</exception>
        public Task<TraktResponse<ITraktSyncRatingsRemovePostResponse>> RemoveRatingsAsync(ITraktSyncRatingsPost ratingsRemovePost,
                                                                                           CancellationToken cancellationToken = default)
        {
            ValidateRatingsPost(ratingsRemovePost);
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new SyncRatingsRemoveRequest
            {
                RequestBody = ratingsRemovePost
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the user's watchlist containing movies, shows, seasons and / or episodes.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/get-watchlist/get-watchlist">"Trakt API Doc - Sync: Get Watchlist"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="watchlistItemType">Determines, which type of watchlist items should be queried. See also <seealso cref="TraktSyncItemType" />.</param>
        /// <param name="sortOrder">Determines the sort order of the returned watchlist items. See also <seealso cref="TraktWatchlistSortOrder" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the watchlist items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktWatchlistItem}"/> instance containing the queried watchlist items and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktWatchlistItem" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktWatchlistItem>> GetWatchlistAsync(TraktSyncItemType watchlistItemType = null,
                                                                               TraktWatchlistSortOrder sortOrder = null,
                                                                               TraktExtendedInfo extendedInfo = null,
                                                                               TraktPagedParameters pagedParameters = null,
                                                                               CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new SyncWatchlistRequest
            {
                Type = watchlistItemType,
                Sort = sortOrder,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }

        /// <summary>
        /// Adds items to the user's watchlist. Accepts shows, seasons, episodes and movies.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/add-to-watchlist/add-items-to-watchlist">"Trakt API Doc - Sync: Add to Watchlist"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktSyncWatchlistPostBuilder" /> to create an instance
        /// of the required <see cref="ITraktSyncWatchlistPost" />.
        /// See also <seealso cref="TraktPost.NewSyncWatchlistPost()" />.
        /// </para>
        /// </summary>
        /// <param name="watchlistPost">An <see cref="ITraktSyncWatchlistPost" /> instance containing all shows, seasons, episodes and movies, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktSyncWatchlistPostResponse" /> instance, which contains information about which items were added, existing and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given watchlist post is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given watchlist post is empty.</exception>
        public Task<TraktResponse<ITraktSyncWatchlistPostResponse>> AddWatchlistItemsAsync(ITraktSyncWatchlistPost watchlistPost,
                                                                                           CancellationToken cancellationToken = default)
        {
            ValidateWatchlistPost(watchlistPost);
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new SyncWatchlistAddRequest
            {
                RequestBody = watchlistPost
            },
            cancellationToken);
        }

        /// <summary>
        /// Removes items from the user's watchlist. Accepts shows, seasons, episodes and movies.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/remove-from-watchlist/remove-items-from-watchlists">"Trakt API Doc - Sync: Remove from Watchlist"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktSyncWatchlistPostBuilder" /> to create an instance
        /// of the required <see cref="ITraktSyncWatchlistPost" />.
        /// See also <seealso cref="TraktPost.NewSyncWatchlistPost()" />.
        /// </para>
        /// </summary>
        /// <param name="watchlistRemovePost">An <see cref="ITraktSyncWatchlistPost" /> instance containing all shows, seasons, episodes and movies, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktSyncWatchlistRemovePostResponse" /> instance, which contains information about which items were deleted and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given watchlist remove post is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given watchlist remove post is empty.</exception>
        public Task<TraktResponse<ITraktSyncWatchlistRemovePostResponse>> RemoveWatchlistItemsAsync(ITraktSyncWatchlistPost watchlistRemovePost,
                                                                                                    CancellationToken cancellationToken = default)
        {
            ValidateWatchlistPost(watchlistRemovePost);
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new SyncWatchlistRemoveRequest
            {
                RequestBody = watchlistRemovePost
            },
            cancellationToken);
        }

        private void ValidateCollectionPost(ITraktSyncCollectionPost collectionPost)
        {
            if (collectionPost == null)
                throw new ArgumentNullException(nameof(collectionPost), "collection post must not be null");

            IEnumerable<ITraktSyncCollectionPostMovie> movies = collectionPost.Movies;
            IEnumerable<ITraktSyncCollectionPostShow> shows = collectionPost.Shows;
            IEnumerable<ITraktSyncCollectionPostEpisode> episodes = collectionPost.Episodes;

            bool bHasNoMovies = movies == null || !movies.Any();
            bool bHasNoShows = shows == null || !shows.Any();
            bool bHasNoEpisodes = episodes == null || !episodes.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoEpisodes)
                throw new ArgumentException("no collection items set");
        }

        private void ValidateHistoryPost(ITraktSyncHistoryPost historyPost)
        {
            if (historyPost == null)
                throw new ArgumentNullException(nameof(historyPost), "history post must not be null");

            IEnumerable<ITraktSyncHistoryPostMovie> movies = historyPost.Movies;
            IEnumerable<ITraktSyncHistoryPostShow> shows = historyPost.Shows;
            IEnumerable<ITraktSyncHistoryPostEpisode> episodes = historyPost.Episodes;

            bool bHasNoMovies = movies == null || !movies.Any();
            bool bHasNoShows = shows == null || !shows.Any();
            bool bHasNoEpisodes = episodes == null || !episodes.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoEpisodes)
                throw new ArgumentException("no watched history items set");
        }

        private void ValidateRatingsPost(ITraktSyncRatingsPost ratingsPost)
        {
            if (ratingsPost == null)
                throw new ArgumentNullException(nameof(ratingsPost), "ratings post must not be null");

            IEnumerable<ITraktSyncRatingsPostMovie> movies = ratingsPost.Movies;
            IEnumerable<ITraktSyncRatingsPostShow> shows = ratingsPost.Shows;
            IEnumerable<ITraktSyncRatingsPostEpisode> episodes = ratingsPost.Episodes;

            bool bHasNoMovies = movies == null || !movies.Any();
            bool bHasNoShows = shows == null || !shows.Any();
            bool bHasNoEpisodes = episodes == null || !episodes.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoEpisodes)
                throw new ArgumentException("no ratings items set");
        }

        private void ValidateWatchlistPost(ITraktSyncWatchlistPost watchlistPost)
        {
            if (watchlistPost == null)
                throw new ArgumentNullException(nameof(watchlistPost), "watchlist post must not be null");

            IEnumerable<ITraktSyncWatchlistPostMovie> movies = watchlistPost.Movies;
            IEnumerable<ITraktSyncWatchlistPostShow> shows = watchlistPost.Shows;
            IEnumerable<ITraktSyncWatchlistPostEpisode> episodes = watchlistPost.Episodes;

            bool bHasNoMovies = movies == null || !movies.Any();
            bool bHasNoShows = shows == null || !shows.Any();
            bool bHasNoEpisodes = episodes == null || !episodes.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoEpisodes)
                throw new ArgumentException("no watchlist items set");
        }
    }
}
