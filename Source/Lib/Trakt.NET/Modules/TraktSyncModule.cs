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
    using Objects.Post.Basic;
    using Objects.Post.Basic.Responses;
    using Objects.Post.Syncs.Collection;
    using Objects.Post.Syncs.Collection.Responses;
    using Objects.Post.Syncs.History;
    using Objects.Post.Syncs.History.Responses;
    using Objects.Post.Syncs.Ratings;
    using Objects.Post.Syncs.Ratings.Responses;
    using Objects.Post.Syncs.Recommendations;
    using Objects.Post.Syncs.Recommendations.Responses;
    using Objects.Post.Syncs.Watchlist;
    using Objects.Post.Syncs.Watchlist.Responses;
    using PostBuilder;
    using Requests.Handler;
    using Requests.Syncs.OAuth;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Parameters;

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
        /// <param name="recommendationObjectType">Determines, which type of recommendation items should be queried. See also <seealso cref="TraktFavoriteObjectType" />.</param>
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
        /// <returns>A list of <see cref="ITraktFavorite" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktFavorite>> GetPersonalRecommendationsAsync(TraktFavoriteObjectType recommendationObjectType = null,
                                                                                        TraktWatchlistSortOrder sortOrder = null, TraktExtendedInfo extendedInfo = null,
                                                                                        TraktPagedParameters pagedParameters = null, CancellationToken cancellationToken = default)
        {
            var request = new SyncPersonalRecommendationsRequest
            {
                Type = recommendationObjectType,
                Sort = sortOrder,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Reorder all items on a user's personal recommendations.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/sync/reorder-personal-recommendations/reorder-personally-recommended-items">"Trakt API Doc - Sync: Reorder Personal Recommendations"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="reorderedRecommendedItemRanks">A collection of list ids. Represents the new order of an user's personal recommendations.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktListItemsReorderPostResponse" /> instance containing information about the successfully updated personal recommendations order.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktListItemsReorderPostResponse>> ReorderRecommendedItemsAsync(IList<uint> reorderedRecommendedItemRanks,
                                                                                                    CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new SyncRecommendedItemsReorderRequest
            {
                RequestBody = new TraktListItemsReorderPost
                {
                    Rank = reorderedRecommendedItemRanks
                }
            },
            cancellationToken);
        }

        /// <summary>
        /// Update the notes on a single favorite item.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/sync/update-favorite-item/update-a-favorite-item">"Trakt API Doc - Sync: Update Favorite Item"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="listItemId">The id of the favorite item which should be updated.</param>
        /// <param name="notes">The new favorite item's notes value. Can be null to delete the content of the notes.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns></returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktNoContentResponse> UpdateFavoriteItemAsync(uint listItemId, string notes = null,
                                                                    CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new SyncFavoriteItemUpdateRequest
            {
                ListItemId = listItemId,
                RequestBody = new TraktListItemUpdatePost
                {
                    Notes = notes
                }
            }, cancellationToken);
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
            var request = new SyncPlaybackProgressRequest
            {
                Type = objectType,
                StartAt = startAt,
                EndAt = endAt,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
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
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
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
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktSyncCollectionPostResponse>> AddCollectionItemsAsync(ITraktSyncCollectionPost collectionPost,
                                                                                             CancellationToken cancellationToken = default)
        {
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
        /// It is recommended to use the <see cref="ITraktSyncCollectionRemovePostBuilder" /> to create an instance
        /// of the required <see cref="ITraktSyncCollectionRemovePost" />.
        /// See also <seealso cref="TraktPost.NewSyncCollectionRemovePost()" />.
        /// </para>
        /// </summary>
        /// <param name="collectionRemovePost">An <see cref="ITraktSyncCollectionRemovePost" /> instance containing all shows, seasons, episodes and movies, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktSyncCollectionRemovePostResponse" /> instance, which contains information about which items were deleted and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktSyncCollectionRemovePostResponse>> RemoveCollectionItemsAsync(ITraktSyncCollectionRemovePost collectionRemovePost,
                                                                                                      CancellationToken cancellationToken = default)
        {
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
            var request = new SyncWatchedHistoryRequest
            {
                Type = historyItemType,
                ItemId = itemId,
                StartAt = startAt,
                EndAt = endAt,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
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
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktSyncHistoryPostResponse>> AddWatchedHistoryItemsAsync(ITraktSyncHistoryPost historyPost,
                                                                                              CancellationToken cancellationToken = default)
        {
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
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktSyncHistoryRemovePostResponse>> RemoveWatchedHistoryItemsAsync(ITraktSyncHistoryRemovePost historyRemovePost,
                                                                                                       CancellationToken cancellationToken = default)
        {
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
            var request = new SyncRatingsRequest
            {
                Type = ratingsItemType,
                RatingFilter = ratingsFilter,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
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
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktSyncRatingsPostResponse>> AddRatingsAsync(ITraktSyncRatingsPost ratingsPost,
                                                                                  CancellationToken cancellationToken = default)
        {
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
        /// It is recommended to use the <see cref="ITraktSyncRatingsRemovePostBuilder" /> to create an instance
        /// of the required <see cref="ITraktSyncRatingsRemovePost" />.
        /// See also <seealso cref="TraktPost.NewSyncRatingsRemovePost()" />.
        /// </para>
        /// </summary>
        /// <param name="ratingsRemovePost">An <see cref="ITraktSyncRatingsRemovePost" /> instance containing all shows, seasons, episodes and movies, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktSyncRatingsRemovePostResponse" /> instance, which contains information about which items were deleted and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktSyncRatingsRemovePostResponse>> RemoveRatingsAsync(ITraktSyncRatingsRemovePost ratingsRemovePost,
                                                                                           CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new SyncRatingsRemoveRequest
            {
                RequestBody = ratingsRemovePost
            },
            cancellationToken);
        }

        /// <summary>
        /// Adds items to the user's personal recommendations. Accepts movies and shows.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/sync/get-personal-recommendations/add-items-to-personal-recommendations">"Trakt API Doc - Sync: Add to Personal Recommendations"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktSyncRecommendationsPostBuilder" /> to create an instance
        /// of the required <see cref="ITraktSyncRecommendationsPost" />.
        /// See also <seealso cref="TraktPost.NewSyncRecommendationsPost()" />.
        /// </para>
        /// </summary>
        /// <param name="recommendationsPost">An <see cref="ITraktSyncRecommendationsPost" /> instance containing all movies and shows, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktSyncRecommendationsPostResponse" /> instance, which contains information about which items were added and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktSyncRecommendationsPostResponse>> AddPersonalRecommendationsAsync(ITraktSyncRecommendationsPost recommendationsPost,
                                                                                                          CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new SyncRecommendationsAddRequest
            {
                RequestBody = recommendationsPost
            },
            cancellationToken);
        }

        /// <summary>
        /// Remove items from the user's personal recommendations. Accepts movies and shows.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/sync/remove-from-personal-recommendations/remove-items-from-personal-recommendations">"Trakt API Doc - Sync: Remove from Personal Recommendations"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktSyncRecommendationsRemovePostBuilder" /> to create an instance
        /// of the required <see cref="ITraktSyncRecommendationsRemovePost" />.
        /// See also <seealso cref="TraktPost.NewSyncRecommendationsRemovePost()" />.
        /// </para>
        /// </summary>
        /// <param name="recommendationsRemovePost">An <see cref="ITraktSyncRecommendationsRemovePost" /> instance containing all movies and shows, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktSyncRecommendationsRemovePostResponse" /> instance, which contains information about which items were removed and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktSyncRecommendationsRemovePostResponse>> RemovePersonalRecommendationsAsync(ITraktSyncRecommendationsRemovePost recommendationsRemovePost,
                                                                                                                   CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new SyncRecommendationsRemoveRequest
            {
                RequestBody = recommendationsRemovePost
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
            var request = new SyncWatchlistRequest
            {
                Type = watchlistItemType,
                Sort = sortOrder,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Reorders an user's watchlist.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/sync/reorder-watchlist/reorder-watchlist-items">"Trakt API Doc - Sync: Reorder Watchlist"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="reorderedWatchlistItemRanks">A collection of list ids. Represents the new order of an user's watchlist.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktListItemsReorderPostResponse" /> instance containing information about the successfully updated watchlist order.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktListItemsReorderPostResponse>> ReorderWatchlistItemsAsync(IList<uint> reorderedWatchlistItemRanks,
                                                                                                  CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new SyncWatchlistItemsReorderRequest
            {
                RequestBody = new TraktListItemsReorderPost
                {
                    Rank = reorderedWatchlistItemRanks
                }
            },
            cancellationToken);
        }

        /// <summary>
        /// Update the notes on a watchlist item.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/sync/update-watchlist-item/update-a-watchlist-item">"Trakt API Doc - Sync: Update Watchlist Item"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="listItemId">The id of the watchlist item which should be updated.</param>
        /// <param name="notes">The new watchlist item's notes value. Can be null to delete the content of the notes.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns></returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktNoContentResponse> UpdateWatchlistItemAsync(uint listItemId, string notes = null,
                                                                     CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new SyncWatchlistItemUpdateRequest
            {
                ListItemId = listItemId,
                RequestBody = new TraktListItemUpdatePost
                {
                    Notes = notes
                }
            }, cancellationToken);
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
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktSyncWatchlistPostResponse>> AddWatchlistItemsAsync(ITraktSyncWatchlistPost watchlistPost,
                                                                                           CancellationToken cancellationToken = default)
        {
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
        /// It is recommended to use the <see cref="ITraktSyncWatchlistRemovePostBuilder" /> to create an instance
        /// of the required <see cref="ITraktSyncWatchlistRemovePost" />.
        /// See also <seealso cref="TraktPost.NewSyncWatchlistRemovePost()" />.
        /// </para>
        /// </summary>
        /// <param name="watchlistRemovePost">An <see cref="ITraktSyncWatchlistRemovePost" /> instance containing all shows, seasons, episodes and movies, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktSyncWatchlistRemovePostResponse" /> instance, which contains information about which items were deleted and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktSyncWatchlistRemovePostResponse>> RemoveWatchlistItemsAsync(ITraktSyncWatchlistRemovePost watchlistRemovePost,
                                                                                                    CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new SyncWatchlistRemoveRequest
            {
                RequestBody = watchlistRemovePost
            },
            cancellationToken);
        }
    }
}
