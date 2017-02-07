namespace TraktApiSharp.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Basic;
    using Objects.Get.Collection;
    using Objects.Get.History;
    using Objects.Get.Ratings;
    using Objects.Get.Syncs.Activities;
    using Objects.Get.Syncs.Playback;
    using Objects.Get.Watched;
    using Objects.Get.Watchlist;
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
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to sync.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/sync">"Trakt API Doc - Sync"</a> section.
    /// </para>
    /// </summary>
    public class TraktSyncModule : TraktBaseModule
    {
        internal TraktSyncModule(TraktClient client) : base(client) { }

        /// <summary>
        /// Gets the user's last activities.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/last-activities/get-last-activity">"Trakt API Doc - Sync: Last Activities"</a> for more information.
        /// </para>
        /// </summary>
        /// <returns>An <see cref="TraktSyncLastActivities" /> instance with the queried last activities.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktResponse<TraktSyncLastActivities>> GetLastActivitiesAsync()
        {
            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteSingleItemRequestAsync(new TraktSyncLastActivitiesRequest());
        }

        /// <summary>
        /// Gets the user's saved playback progress of scrobbles that are paused.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/last-activities/get-playback-progress">"Trakt API Doc - Sync: Playback"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="objectType">Determines, which type of items should be queried. By default, all types will be returned. See also <seealso cref="TraktSyncType" />.</param>
        /// <param name="limit">Determines, how many progress items should be queried. By default, all items will be returned</param>
        /// <returns>A list of <see cref="TraktSyncPlaybackProgressItem" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktListResponse<TraktSyncPlaybackProgressItem>> GetPlaybackProgressAsync(TraktSyncType objectType = null, int? limit = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecuteListRequestAsync(new TraktSyncPlaybackProgressRequest
            {
                Type = objectType,
                Limit = limit
            });
        }

        /// <summary>
        /// Removes a playback progress item from the user's playback progress list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/remove-playback/remove-a-playback-item">"Trakt API Doc - Sync: Remove Playback"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="playbackId">The id of the playback progress item, which should be removed.</param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given playback progress id is null, empty or contains spaces.</exception>
        public async Task<TraktNoContentResponse> RemovePlaybackItemAsync(uint playbackId)
        {
            if (playbackId == 0)
                throw new ArgumentOutOfRangeException(nameof(playbackId), "playback id not valid");

            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteNoContentRequestAsync(new TraktSyncPlaybackDeleteRequest { Id = playbackId.ToString() });
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
        /// <returns>A list of <see cref="TraktCollectionMovie" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktListResponse<TraktCollectionMovie>> GetCollectionMoviesAsync(TraktExtendedInfo extendedInfo = null)
        {
            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteListRequestAsync(new TraktSyncCollectionMoviesRequest { ExtendedInfo = extendedInfo });
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
        /// <returns>A list of <see cref="TraktCollectionShow" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktListResponse<TraktCollectionShow>> GetCollectionShowsAsync(TraktExtendedInfo extendedInfo = null)
        {
            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteListRequestAsync(new TraktSyncCollectionShowsRequest { ExtendedInfo = extendedInfo });
        }

        /// <summary>
        /// Adds items to the user's collection. Accepts shows, seasons, episodes and movies.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/get-collection/add-items-to-collection">"Trakt API Doc - Sync: Add to Collection"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="TraktSyncCollectionPostBuilder" /> to create an instance
        /// of the required <see cref="TraktSyncCollectionPost" />.
        /// See also <seealso cref="TraktSyncCollectionPost.Builder()" />.
        /// </para>
        /// </summary>
        /// <param name="collectionPost">An <see cref="TraktSyncCollectionPost" /> instance containing all shows, seasons, episodes and movies, which should be added.</param>
        /// <returns>An <see cref="TraktSyncCollectionPostResponse" /> instance, which contains information about which items were added, updated, existing and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given collection post is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given collection post is empty.</exception>
        public async Task<TraktResponse<TraktSyncCollectionPostResponse>> AddCollectionItemsAsync(TraktSyncCollectionPost collectionPost)
        {
            ValidateCollectionPost(collectionPost);
            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteSingleItemRequestAsync(new TraktSyncCollectionAddRequest { RequestBody = collectionPost });
        }

        /// <summary>
        /// Removes items from the user's collection. Accepts shows, seasons, episodes and movies.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/remove-from-collection/remove-items-from-collection">"Trakt API Doc - Sync: Remove from Collection"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="TraktSyncCollectionPostBuilder" /> to create an instance
        /// of the required <see cref="TraktSyncCollectionPost" />.
        /// See also <seealso cref="TraktSyncCollectionPost.Builder()" />.
        /// </para>
        /// </summary>
        /// <param name="collectionRemovePost">An <see cref="TraktSyncCollectionPost" /> instance containing all shows, seasons, episodes and movies, which should be removed.</param>
        /// <returns>An <see cref="TraktSyncCollectionRemovePostResponse" /> instance, which contains information about which items were deleted and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given collection remove post is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given collection remove post is empty.</exception>
        public async Task<TraktResponse<TraktSyncCollectionRemovePostResponse>> RemoveCollectionItemsAsync(TraktSyncCollectionPost collectionRemovePost)
        {
            ValidateCollectionPost(collectionRemovePost);
            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteSingleItemRequestAsync(new TraktSyncCollectionRemoveRequest { RequestBody = collectionRemovePost });
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
        /// <returns>A list of <see cref="TraktWatchedMovie" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktListResponse<TraktWatchedMovie>> GetWatchedMoviesAsync(TraktExtendedInfo extendedInfo = null)
        {
            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteListRequestAsync(new TraktSyncWatchedMoviesRequest { ExtendedInfo = extendedInfo });
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
        /// <returns>A list of <see cref="TraktWatchedShow" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktListResponse<TraktWatchedShow>> GetWatchedShowsAsync(TraktExtendedInfo extendedInfo = null)
        {
            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteListRequestAsync(new TraktSyncWatchedShowsRequest { ExtendedInfo = extendedInfo });
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
        /// <param name="page">The page of the history items list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of history items for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktHistoryItem}"/> instance containing the queried history items and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktHistoryItem" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktPagedResponse<TraktHistoryItem>> GetWatchedHistoryAsync(TraktSyncItemType historyItemType = null, uint? itemId = null,
                                                                                       DateTime? startAt = null, DateTime? endAt = null,
                                                                                       TraktExtendedInfo extendedInfo = null,
                                                                                       int? page = null, int? limitPerPage = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecutePagedRequestAsync(new TraktSyncWatchedHistoryRequest
            {
                Type = historyItemType,
                ItemId = itemId,
                StartAt = startAt,
                EndAt = endAt,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limitPerPage
            });
        }

        /// <summary>
        /// Adds items to the user's watch history. Accepts shows, seasons, episodes and movies.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/add-to-history/add-items-to-watched-history">"Trakt API Doc - Sync: Add to History"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="TraktSyncHistoryPostBuilder" /> to create an instance
        /// of the required <see cref="TraktSyncHistoryPost" />.
        /// See also <seealso cref="TraktSyncHistoryPost.Builder()" />.
        /// </para>
        /// </summary>
        /// <param name="historyPost">An <see cref="TraktSyncHistoryPost" /> instance containing all shows, seasons, episodes and movies, which should be added.</param>
        /// <returns>An <see cref="TraktSyncHistoryPostResponse" /> instance, which contains information about which items were added and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given history post is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given history post is empty.</exception>
        public async Task<TraktResponse<TraktSyncHistoryPostResponse>> AddWatchedHistoryItemsAsync(TraktSyncHistoryPost historyPost)
        {
            ValidateHistoryPost(historyPost);
            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteSingleItemRequestAsync(new TraktSyncWatchedHistoryAddRequest { RequestBody = historyPost });
        }

        /// <summary>
        /// Removes items from the user's watch history. Accepts shows, seasons, episodes and movies.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/remove-from-history/remove-items-from-history">"Trakt API Doc - Sync: Remove from History"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="TraktSyncHistoryRemovePostBuilder" /> to create an instance
        /// of the required <see cref="TraktSyncHistoryRemovePost" />.
        /// See also <seealso cref="TraktSyncHistoryRemovePost.Builder()" />.
        /// </para>
        /// </summary>
        /// <param name="historyRemovePost">An <see cref="TraktSyncHistoryRemovePost" /> instance containing all shows, seasons, episodes and movies, which should be removed.</param>
        /// <returns>An <see cref="TraktSyncHistoryRemovePostResponse" /> instance, which contains information about which items were deleted and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given history remove post is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given history remove post is empty.</exception>
        public async Task<TraktResponse<TraktSyncHistoryRemovePostResponse>> RemoveWatchedHistoryItemsAsync(TraktSyncHistoryRemovePost historyRemovePost)
        {
            ValidateHistoryPost(historyRemovePost);
            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteSingleItemRequestAsync(new TraktSyncWatchedHistoryRemoveRequest { RequestBody = historyRemovePost });
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
        /// <returns>A list of <see cref="TraktRatingsItem" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktListResponse<TraktRatingsItem>> GetRatingsAsync(TraktRatingsItemType ratingsItemType = null,
                                                                               int[] ratingsFilter = null,
                                                                               TraktExtendedInfo extendedInfo = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecuteListRequestAsync(new TraktSyncRatingsRequest
            {
                Type = ratingsItemType,
                RatingFilter = ratingsFilter,
                ExtendedInfo = extendedInfo
            });
        }

        /// <summary>
        /// Adds items to the user's ratings. Accepts shows, seasons, episodes and movies.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/add-ratings/add-new-ratings">"Trakt API Doc - Sync: Add Ratings"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="TraktSyncRatingsPostBuilder" /> to create an instance
        /// of the required <see cref="TraktSyncRatingsPost" />.
        /// See also <seealso cref="TraktSyncRatingsPost.Builder()" />.
        /// </para>
        /// </summary>
        /// <param name="ratingsPost">An <see cref="TraktSyncRatingsPost" /> instance containing all shows, seasons, episodes and movies, which should be added.</param>
        /// <returns>An <see cref="TraktSyncRatingsPostResponse" /> instance, which contains information about which items were added and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given ratings post is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given ratings post is empty.</exception>
        public async Task<TraktResponse<TraktSyncRatingsPostResponse>> AddRatingsAsync(TraktSyncRatingsPost ratingsPost)
        {
            ValidateRatingsPost(ratingsPost);
            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteSingleItemRequestAsync(new TraktSyncRatingsAddRequest { RequestBody = ratingsPost });
        }

        /// <summary>
        /// Removes items from the user's ratings. Accepts shows, seasons, episodes and movies.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/remove-ratings/remove-ratings">"Trakt API Doc - Sync: Remove Ratings"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="TraktSyncRatingsPostBuilder" /> to create an instance
        /// of the required <see cref="TraktSyncRatingsPost" />.
        /// See also <seealso cref="TraktSyncRatingsPost.Builder()" />.
        /// </para>
        /// </summary>
        /// <param name="ratingsRemovePost">An <see cref="TraktSyncRatingsPost" /> instance containing all shows, seasons, episodes and movies, which should be removed.</param>
        /// <returns>An <see cref="TraktSyncRatingsRemovePostResponse" /> instance, which contains information about which items were deleted and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given ratings remove post is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given ratings remove post is empty.</exception>
        public async Task<TraktResponse<TraktSyncRatingsRemovePostResponse>> RemoveRatingsAsync(TraktSyncRatingsPost ratingsRemovePost)
        {
            ValidateRatingsPost(ratingsRemovePost);
            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteSingleItemRequestAsync(new TraktSyncRatingsRemoveRequest { RequestBody = ratingsRemovePost });
        }

        /// <summary>
        /// Gets the user's watchlist containing movies, shows, seasons and / or episodes.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/get-watchlist/get-watchlist">"Trakt API Doc - Sync: Get Watchlist"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="watchlistItemType">Determines, which type of watchlist items should be queried. See also <seealso cref="TraktSyncItemType" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the watchlist items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="page">The page of the watchlist items list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of watchlist items for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktWatchlistItem}"/> instance containing the queried watchlist items and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktWatchlistItem" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public async Task<TraktPagedResponse<TraktWatchlistItem>> GetWatchlistAsync(TraktSyncItemType watchlistItemType = null,
                                                                                    TraktExtendedInfo extendedInfo = null,
                                                                                    int? page = null, int? limitPerPage = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecutePagedRequestAsync(new TraktSyncWatchlistRequest
            {
                Type = watchlistItemType,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limitPerPage
            });
        }

        /// <summary>
        /// Adds items to the user's watchlist. Accepts shows, seasons, episodes and movies.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/add-to-watchlist/add-items-to-watchlist">"Trakt API Doc - Sync: Add to Watchlist"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="TraktSyncWatchlistPostBuilder" /> to create an instance
        /// of the required <see cref="TraktSyncWatchlistPost" />.
        /// See also <seealso cref="TraktSyncWatchlistPost.Builder()" />.
        /// </para>
        /// </summary>
        /// <param name="watchlistPost">An <see cref="TraktSyncWatchlistPost" /> instance containing all shows, seasons, episodes and movies, which should be added.</param>
        /// <returns>An <see cref="TraktSyncWatchlistPostResponse" /> instance, which contains information about which items were added, existing and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given watchlist post is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given watchlist post is empty.</exception>
        public async Task<TraktResponse<TraktSyncWatchlistPostResponse>> AddWatchlistItemsAsync(TraktSyncWatchlistPost watchlistPost)
        {
            ValidateWatchlistPost(watchlistPost);
            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteSingleItemRequestAsync(new TraktSyncWatchlistAddRequest { RequestBody = watchlistPost });
        }

        /// <summary>
        /// Removes items from the user's watchlist. Accepts shows, seasons, episodes and movies.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/sync/remove-from-watchlist/remove-items-from-watchlists">"Trakt API Doc - Sync: Remove from Watchlist"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="TraktSyncWatchlistPostBuilder" /> to create an instance
        /// of the required <see cref="TraktSyncWatchlistPost" />.
        /// See also <seealso cref="TraktSyncWatchlistPost.Builder()" />.
        /// </para>
        /// </summary>
        /// <param name="watchlistRemovePost">An <see cref="TraktSyncWatchlistPost" /> instance containing all shows, seasons, episodes and movies, which should be removed.</param>
        /// <returns>An <see cref="TraktSyncWatchlistRemovePostResponse" /> instance, which contains information about which items were deleted and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given watchlist remove post is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given watchlist remove post is empty.</exception>
        public async Task<TraktResponse<TraktSyncWatchlistRemovePostResponse>> RemoveWatchlistItemsAsync(TraktSyncWatchlistPost watchlistRemovePost)
        {
            ValidateWatchlistPost(watchlistRemovePost);
            var requestHandler = new TraktRequestHandler(Client);
            return await requestHandler.ExecuteSingleItemRequestAsync(new TraktSyncWatchlistRemoveRequest { RequestBody = watchlistRemovePost });
        }

        private void ValidateCollectionPost(TraktSyncCollectionPost collectionPost)
        {
            if (collectionPost == null)
                throw new ArgumentNullException(nameof(collectionPost), "collection post must not be null");

            var movies = collectionPost.Movies;
            var shows = collectionPost.Shows;
            var episodes = collectionPost.Episodes;

            var bHasNoMovies = movies == null || !movies.Any();
            var bHasNoShows = shows == null || !shows.Any();
            var bHasNoEpisodes = episodes == null || !episodes.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoEpisodes)
                throw new ArgumentException("no collection items set");
        }

        private void ValidateHistoryPost(TraktSyncHistoryPost historyPost)
        {
            if (historyPost == null)
                throw new ArgumentNullException(nameof(historyPost), "history post must not be null");

            var movies = historyPost.Movies;
            var shows = historyPost.Shows;
            var episodes = historyPost.Episodes;

            var bHasNoMovies = movies == null || !movies.Any();
            var bHasNoShows = shows == null || !shows.Any();
            var bHasNoEpisodes = episodes == null || !episodes.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoEpisodes)
                throw new ArgumentException("no watched history items set");
        }

        private void ValidateRatingsPost(TraktSyncRatingsPost ratingsPost)
        {
            if (ratingsPost == null)
                throw new ArgumentNullException(nameof(ratingsPost), "ratings post must not be null");

            var movies = ratingsPost.Movies;
            var shows = ratingsPost.Shows;
            var episodes = ratingsPost.Episodes;

            var bHasNoMovies = movies == null || !movies.Any();
            var bHasNoShows = shows == null || !shows.Any();
            var bHasNoEpisodes = episodes == null || !episodes.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoEpisodes)
                throw new ArgumentException("no ratings items set");
        }

        private void ValidateWatchlistPost(TraktSyncWatchlistPost watchlistPost)
        {
            if (watchlistPost == null)
                throw new ArgumentNullException(nameof(watchlistPost), "watchlist post must not be null");

            var movies = watchlistPost.Movies;
            var shows = watchlistPost.Shows;
            var episodes = watchlistPost.Episodes;

            var bHasNoMovies = movies == null || !movies.Any();
            var bHasNoShows = shows == null || !shows.Any();
            var bHasNoEpisodes = episodes == null || !episodes.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoEpisodes)
                throw new ArgumentException("no watchlist items set");
        }
    }
}
