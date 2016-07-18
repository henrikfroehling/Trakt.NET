namespace TraktApiSharp.Modules
{
    using Enums;
    using Extensions;
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
    using Requests;
    using Requests.Params;
    using Requests.WithOAuth.Syncs;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TraktSyncModule : TraktBaseModule
    {
        internal TraktSyncModule(TraktClient client) : base(client) { }

        public async Task<TraktSyncLastActivities> GetLastActivitiesAsync()
        {
            return await QueryAsync(new TraktSyncLastActivitiesRequest(Client));
        }

        public async Task<IEnumerable<TraktSyncPlaybackProgressItem>> GetPlaybackProgressAsync(TraktSyncType? type = null, int? limit = null)
        {
            return await QueryAsync(new TraktSyncPlaybackProgressRequest(Client)
            {
                Type = type,
                PaginationOptions = new TraktPaginationOptions(null, limit)
            });
        }

        public async Task RemovePlaybackItemAsync(string playbackId)
        {
            if (string.IsNullOrEmpty(playbackId) || playbackId.ContainsSpace())
                throw new ArgumentException("playback id not valid", nameof(playbackId));

            await QueryAsync(new TraktSyncPlaybackDeleteRequest(Client) { Id = playbackId });
        }

        public async Task<IEnumerable<TraktCollectionMovie>> GetCollectionMoviesAsync(TraktExtendedOption extended = null)
        {
            return await QueryAsync(new TraktSyncCollectionMoviesRequest(Client) { ExtendedOption = extended });
        }

        public async Task<IEnumerable<TraktCollectionShow>> GetCollectionShowsAsync(TraktExtendedOption extended = null)
        {
            return await QueryAsync(new TraktSyncCollectionShowsRequest(Client) { ExtendedOption = extended });
        }

        public async Task<TraktSyncCollectionPostResponse> AddCollectionItemsAsync(TraktSyncCollectionPost collectionPost)
        {
            ValidateCollectionPost(collectionPost);

            return await QueryAsync(new TraktSyncCollectionAddRequest(Client) { RequestBody = collectionPost });
        }

        public async Task<TraktSyncCollectionRemovePostResponse> RemoveCollectionItemsAsync(TraktSyncCollectionPost collectionRemovePost)
        {
            ValidateCollectionPost(collectionRemovePost);

            return await QueryAsync(new TraktSyncCollectionRemoveRequest(Client) { RequestBody = collectionRemovePost });
        }

        public async Task<IEnumerable<TraktWatchedMovie>> GetWatchedMoviesAsync(TraktExtendedOption extended = null)
        {
            return await QueryAsync(new TraktSyncWatchedMoviesRequest(Client) { ExtendedOption = extended });
        }

        public async Task<IEnumerable<TraktWatchedShow>> GetWatchedShowsAsync(TraktExtendedOption extended = null)
        {
            return await QueryAsync(new TraktSyncWatchedShowsRequest(Client) { ExtendedOption = extended });
        }

        public async Task<TraktPaginationListResult<TraktHistoryItem>> GetWatchedHistoryAsync(TraktSyncItemType? type = null, string itemId = null,
                                                                                              DateTime? startAt = null, DateTime? endAt = null,
                                                                                              TraktExtendedOption extended = null,
                                                                                              int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktSyncWatchedHistoryRequest(Client)
            {
                Type = type,
                ItemId = itemId,
                StartAt = startAt,
                EndAt = endAt,
                ExtendedOption = extended,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktSyncHistoryPostResponse> AddWatchedHistoryItemsAsync(TraktSyncHistoryPost historyPost)
        {
            ValidateHistoryPost(historyPost);

            return await QueryAsync(new TraktSyncWatchedHistoryAddRequest(Client) { RequestBody = historyPost });
        }

        public async Task<TraktSyncHistoryRemovePostResponse> RemoveWatchedHistoryItemsAsync(TraktSyncHistoryRemovePost historyRemovePost)
        {
            ValidateHistoryPost(historyRemovePost);

            return await QueryAsync(new TraktSyncWatchedHistoryRemoveRequest(Client) { RequestBody = historyRemovePost });
        }

        public async Task<IEnumerable<TraktRatingsItem>> GetRatingsAsync(TraktSyncRatingsItemType? type = null,
                                                                         int[] rating = null,
                                                                         TraktExtendedOption extended = null)
        {
            return await QueryAsync(new TraktSyncRatingsRequest(Client)
            {
                Type = type,
                Rating = rating,
                ExtendedOption = extended
            });
        }

        public async Task<TraktSyncRatingsPostResponse> AddRatingsAsync(TraktSyncRatingsPost ratingsPost)
        {
            ValidateRatingsPost(ratingsPost);

            return await QueryAsync(new TraktSyncRatingsAddRequest(Client) { RequestBody = ratingsPost });
        }

        public async Task<TraktSyncRatingsRemovePostResponse> RemoveRatingsAsync(TraktSyncRatingsPost ratingsRemovePost)
        {
            ValidateRatingsPost(ratingsRemovePost);

            return await QueryAsync(new TraktSyncRatingsRemoveRequest(Client) { RequestBody = ratingsRemovePost });
        }

        public async Task<IEnumerable<TraktWatchlistItem>> GetWatchlistAsync(TraktSyncItemType? type = null,
                                                                             TraktExtendedOption extended = null)
        {
            return await QueryAsync(new TraktSyncWatchlistRequest(Client)
            {
                Type = type,
                ExtendedOption = extended
            });
        }

        public async Task<TraktSyncWatchlistPostResponse> AddWatchlistItemsAsync(TraktSyncWatchlistPost watchlistPost)
        {
            ValidateWatchlistPost(watchlistPost);

            return await QueryAsync(new TraktSyncWatchlistAddRequest(Client) { RequestBody = watchlistPost });
        }

        public async Task<TraktSyncWatchlistRemovePostResponse> RemoveWatchlistItemsAsync(TraktSyncWatchlistPost watchlistRemovePost)
        {
            ValidateWatchlistPost(watchlistRemovePost);

            return await QueryAsync(new TraktSyncWatchlistRemoveRequest(Client) { RequestBody = watchlistRemovePost });
        }

        private void ValidateCollectionPost(TraktSyncCollectionPost collectionPost)
        {
            if (collectionPost == null)
                throw new ArgumentNullException("collection post must not be null", nameof(collectionPost));

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
                throw new ArgumentNullException("history post must not be null", nameof(historyPost));

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
                throw new ArgumentNullException("ratings post must not be null", nameof(ratingsPost));

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
                throw new ArgumentNullException("watchlist post must not be null", nameof(watchlistPost));

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
