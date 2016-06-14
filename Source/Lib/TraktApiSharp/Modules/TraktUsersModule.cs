namespace TraktApiSharp.Modules
{
    using Enums;
    using Extensions;
    using Objects.Basic;
    using Objects.Get.Users;
    using Objects.Get.Users.Collections;
    using Objects.Get.Users.Lists;
    using Objects.Get.Users.Statistics;
    using Objects.Get.Users.Watched;
    using Objects.Post.Users;
    using Objects.Post.Users.CustomListItems;
    using Objects.Post.Users.CustomListItems.Responses;
    using Objects.Post.Users.Responses;
    using Requests;
    using Requests.WithOAuth.Users;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class TraktUsersModule : TraktBaseModule
    {
        public TraktUsersModule(TraktClient client) : base(client) { }

        public async Task<TraktUserSettings> GetUserSettingsAsync()
        {
            return await QueryAsync(new TraktUserSettingsRequest(Client));
        }

        public async Task<TraktListResult<TraktUserFollowRequest>> GetUserFollowRequestsAsync()
        {
            return await QueryAsync(new TraktUserFollowRequestsRequest(Client));
        }

        public async Task<TraktPaginationListResult<TraktUserHiddenItem>> GetUserHiddenItemsAsync(TraktHiddenItemsSection section,
                                                                                                  TraktHiddenItemType? type = null,
                                                                                                  TraktExtendedOption extended = null,
                                                                                                  int? page = null, int? limit = null)
        {
            if (section == TraktHiddenItemsSection.Unspecified)
                throw new ArgumentException("section not valid", "section");

            return await QueryAsync(new TraktUserHiddenItemsRequest(Client)
            {
                Section = section,
                Type = type,
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktUserLikeItem>> GetUserLikesAsync(TraktUserLikeType? type = null,
                                                                                          int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktUserLikesRequest(Client)
            {
                Type = type,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktUser> GetUserProfileAsync(string username)
        {
            ValidateUsername(username);

            return await QueryAsync(new TraktUserProfileRequest(Client)
            {
                Username = username
            });
        }

        public async Task<TraktListResult<TraktUserCollectionMovieItem>> GetUserCollectionMoviesAsync(string username,
                                                                                                      TraktExtendedOption extended = null)
        {
            ValidateUsername(username);

            return await QueryAsync(new TraktUserCollectionMoviesRequest(Client)
            {
                Username = username,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktListResult<TraktUserCollectionShowItem>> GetUserCollectionShowsAsync(string username,
                                                                                                    TraktExtendedOption extended = null)
        {
            ValidateUsername(username);

            return await QueryAsync(new TraktUserCollectionShowsRequest(Client)
            {
                Username = username,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktPaginationListResult<TraktUserComment>> GetUserCommentsAsync(string username,
                                                                                            TraktCommentType? commentType = null,
                                                                                            TraktObjectType? type = null,
                                                                                            TraktExtendedOption extended = null,
                                                                                            int? page = null, int? limit = null)
        {
            ValidateUsername(username);

            return await QueryAsync(new TraktUserCommentsRequest(Client)
            {
                Username = username,
                CommentType = commentType,
                Type = type,
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktListResult<TraktList>> GetUserCustomListsAsync(string username)
        {
            ValidateUsername(username);

            return await QueryAsync(new TraktUserCustomListsRequest(Client)
            {
                Username = username
            });
        }

        public async Task<TraktList> GetUserCustomSingleListAsync(string username, string listId)
        {
            ValidateUsername(username);
            ValidateListId(listId);

            return await QueryAsync(new TraktUserCustomSingleListRequest(Client)
            {
                Username = username,
                Id = listId
            });
        }

        public async Task<TraktListResult<TraktListItem>> GetUserCustomListItemsAsync(string username, string listId,
                                                                                      TraktListItemType? type = null,
                                                                                      TraktExtendedOption extended = null)
        {
            ValidateUsername(username);
            ValidateListId(listId);

            return await QueryAsync(new TraktUserCustomListItemsRequest(Client)
            {
                Username = username,
                Id = listId,
                Type = type,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktList> CreateCustomListAsync(string username, string listName, string description = null,
                                                           TraktAccessScope? privacy = null,
                                                           bool? displayNumbers = null, bool? allowComments = null)
        {
            ValidateUsername(username);

            if (string.IsNullOrEmpty(listName))
                throw new ArgumentException("list name not valid", "listName");

            var requestBody = new TraktUserCustomListPost
            {
                Name = listName,
                Description = description,
                DisplayNumbers = displayNumbers,
                AllowComments = allowComments
            };

            if (privacy.HasValue && privacy.Value != TraktAccessScope.Unspecified)
                requestBody.Privacy = privacy.Value;

            return await QueryAsync(new TraktUserCustomListAddRequest(Client)
            {
                Username = username,
                RequestBody = requestBody
            });
        }

        public async Task<TraktList> UpdateCustomListAsync(string username, string listId,
                                                           string listName = null, string description = null,
                                                           TraktAccessScope? privacy = null,
                                                           bool? displayNumbers = null, bool? allowComments = null)
        {
            ValidateUsername(username);
            ValidateListId(listId);

            var isListNameNotValid = string.IsNullOrEmpty(listName);
            var isDescriptionNotSet = description == null;
            var isPrivacyNotSetOrValid = !privacy.HasValue || privacy.Value == TraktAccessScope.Unspecified;
            var isDisplayNumbersNotSet = !displayNumbers.HasValue;
            var isAllowCommentsNotSet = !allowComments.HasValue;

            if (isListNameNotValid && isDescriptionNotSet && isPrivacyNotSetOrValid && isDisplayNumbersNotSet && isAllowCommentsNotSet)
            {
                throw new ArgumentException("no list specific values set");
            }

            var requestBody = new TraktUserCustomListUpdatePost
            {
                Name = listName,
                Description = description,
                DisplayNumbers = displayNumbers,
                AllowComments = allowComments
            };

            if (privacy.HasValue && privacy.Value != TraktAccessScope.Unspecified)
                requestBody.Privacy = privacy.Value;

            return await QueryAsync(new TraktUserCustomListUpdateRequest(Client)
            {
                Username = username,
                Id = listId,
                RequestBody = requestBody
            });
        }

        public async Task DeleteCustomListAsync(string username, string listId)
        {
            ValidateUsername(username);
            ValidateListId(listId);

            await QueryAsync(new TraktUserCustomListDeleteRequest(Client)
            {
                Username = username,
                Id = listId
            });
        }

        public async Task<TraktUserCustomListItemsPostResponse> AddCustomListItemsAsync(string username, string listId,
                                                                                        TraktUserCustomListItemsPost listItemsPost,
                                                                                        TraktListItemType? type = null)
        {
            ValidateUsername(username);
            ValidateListId(listId);
            ValidateCustomListItemsPost(listItemsPost);

            return await QueryAsync(new TraktUserCustomListItemsAddRequest(Client)
            {
                Username = username,
                Id = listId,
                Type = type,
                RequestBody = listItemsPost
            });
        }

        public async Task<TraktUserCustomListItemsRemovePostResponse> RemoveCustomListItemsAsync(string username, string listId,
                                                                                                 TraktUserCustomListItemsRemovePost listItemsRemovePost)
        {
            ValidateUsername(username);
            ValidateListId(listId);
            ValidateCustomListItemsPost(listItemsRemovePost);

            return await QueryAsync(new TraktUserCustomListItemsRemoveRequest(Client)
            {
                Username = username,
                Id = listId,
                RequestBody = listItemsRemovePost
            });
        }

        public async Task LikeListAsync(string username, string listId)
        {
            await QueryAsync(new TraktUserListLikeRequest(Client)
            {
                Username = username,
                Id = listId
            });
        }

        public async Task UnlikeListAsync(string username, string listId)
        {
            await QueryAsync(new TraktUserListUnlikeRequest(Client)
            {
                Username = username,
                Id = listId
            });
        }

        public async Task<TraktListResult<TraktUserFollower>> GetUserFollowersAsync(string username)
        {
            return await QueryAsync(new TraktUserFollowersRequest(Client) { Username = username });
        }

        public async Task<TraktListResult<TraktUserFollower>> GetUserFollowingAsync(string username)
        {
            return await QueryAsync(new TraktUserFollowingRequest(Client) { Username = username });
        }

        public async Task<TraktListResult<TraktUserFriend>> GetUserFriendsAsync(string username)
        {
            return await QueryAsync(new TraktUserFriendsRequest(Client) { Username = username });
        }

        public async Task<TraktUserFollowUserPostResponse> FollowUserAsync(string username)
        {
            return await QueryAsync(new TraktUserFollowUserRequest(Client) { Username = username });
        }

        public async Task UnfollowUserAsync(string username)
        {
            await QueryAsync(new TraktUserUnfollowUserRequest(Client) { Username = username });
        }

        public async Task<TraktUserFollower> ApproveFollowerAsync(string followerRequestId)
        {
            return await QueryAsync(new TraktUserApproveFollowerRequest(Client) { Id = followerRequestId });
        }

        public async Task DenyFollowerAsync(string followerRequestId)
        {
            await QueryAsync(new TraktUserDenyFollowerRequest(Client) { Id = followerRequestId });
        }

        public async Task<TraktPaginationListResult<TraktUserHistoryItem>> GetUserWatchedHistoryAsync(string username, TraktSyncHistoryItemType? type = null,
                                                                                                      string id = null, TraktExtendedOption extended = null,
                                                                                                      int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktUserWatchedHistoryRequest(Client)
            {
                Username = username,
                Type = type,
                ItemId = id,
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktListResult<TraktUserRatingsItem>> GetUserRatingsAsync(string username, TraktSyncRatingsItemType? type = null,
                                                                                     int[] rating = null, TraktExtendedOption extended = null)
        {
            return await QueryAsync(new TraktUserRatingsRequest(Client)
            {
                Username = username,
                Type = type,
                Rating = rating,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktListResult<TraktUserWatchlistItem>> GetUserWatchlistAsync(string username, TraktSyncWatchlistItemType? type = null,
                                                                                         TraktExtendedOption extended = null)
        {
            return await QueryAsync(new TraktUserWatchlistRequest(Client)
            {
                Username = username,
                Type = type,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktUserWatchingItem> GetUserWatchingAsync(string username, TraktExtendedOption extended = null)
        {
            return await QueryAsync(new TraktUserWatchingRequest(Client)
            {
                Username = username,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktListResult<TraktUserWatchedMovieItem>> GetUserWatchedMoviesAsync(string username, TraktExtendedOption extended = null)
        {
            return await QueryAsync(new TraktUserWatchedMoviesRequest(Client)
            {
                Username = username,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktListResult<TraktUserWatchedShowItem>> GetUserWatchedShowAsync(string username, TraktExtendedOption extended = null)
        {
            return await QueryAsync(new TraktUserWatchedShowsRequest(Client)
            {
                Username = username,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktUserStatistics> GetUserStatisticsAsync(string username)
        {
            return await QueryAsync(new TraktUserStatisticsRequest(Client) { Username = username });
        }

        private void ValidateUsername(string username)
        {
            if (string.IsNullOrEmpty(username) || username.ContainsSpace())
                throw new ArgumentException("username not valid", "username");
        }

        private void ValidateListId(string listId)
        {
            if (string.IsNullOrEmpty(listId) || listId.ContainsSpace())
                throw new ArgumentException("list id not valid", "listId");
        }

        private void ValidateCustomListItemsPost(TraktUserCustomListItemsPost customListItemsPost)
        {
            if (customListItemsPost == null)
                throw new ArgumentNullException("list items post must not be null", "customListItemsPost");

            var movies = customListItemsPost.Movies;
            var shows = customListItemsPost.Shows;
            var people = customListItemsPost.People;

            var bHasNoMovies = movies == null || !movies.Any();
            var bHasNoShows = shows == null || !shows.Any();
            var bHasNoPeople = people == null || !people.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoPeople)
                throw new ArgumentException("no items set");
        }
    }
}
