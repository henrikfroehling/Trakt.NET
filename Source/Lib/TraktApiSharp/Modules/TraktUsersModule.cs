namespace TraktApiSharp.Modules
{
    using Enums;
    using Extensions;
    using Objects.Basic;
    using Objects.Get.Collection;
    using Objects.Get.History;
    using Objects.Get.Ratings;
    using Objects.Get.Users;
    using Objects.Get.Users.Lists;
    using Objects.Get.Users.Statistics;
    using Objects.Get.Watched;
    using Objects.Get.Watchlist;
    using Objects.Post.Users;
    using Objects.Post.Users.CustomListItems;
    using Objects.Post.Users.CustomListItems.Responses;
    using Objects.Post.Users.Responses;
    using Requests;
    using Requests.WithOAuth.Users;
    using Requests.WithoutOAuth.Users;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class TraktUsersModule : TraktBaseModule
    {
        internal TraktUsersModule(TraktClient client) : base(client) { }

        public async Task<TraktUserSettings> GetSettingsAsync()
        {
            return await QueryAsync(new TraktUserSettingsRequest(Client));
        }

        public async Task<TraktListResult<TraktUserFollowRequest>> GetFollowRequestsAsync()
        {
            return await QueryAsync(new TraktUserFollowRequestsRequest(Client));
        }

        public async Task<TraktPaginationListResult<TraktUserHiddenItem>> GetHiddenItemsAsync(TraktHiddenItemsSection section,
                                                                                              TraktHiddenItemType? type = null,
                                                                                              TraktExtendedOption extended = null,
                                                                                              int? page = null, int? limit = null)
        {
            if (section == TraktHiddenItemsSection.Unspecified)
                throw new ArgumentException("section not valid", nameof(section));

            return await QueryAsync(new TraktUserHiddenItemsRequest(Client)
            {
                Section = section,
                Type = type,
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktUserLikeItem>> GetLikesAsync(TraktUserLikeType? type = null,
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

        public async Task<TraktListResult<TraktCollectionMovie>> GetCollectionMoviesAsync(string username,
                                                                                          TraktExtendedOption extended = null)
        {
            ValidateUsername(username);

            return await QueryAsync(new TraktUserCollectionMoviesRequest(Client)
            {
                Username = username,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktListResult<TraktCollectionShow>> GetCollectionShowsAsync(string username,
                                                                                        TraktExtendedOption extended = null)
        {
            ValidateUsername(username);

            return await QueryAsync(new TraktUserCollectionShowsRequest(Client)
            {
                Username = username,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktPaginationListResult<TraktUserComment>> GetCommentsAsync(string username,
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

        public async Task<TraktListResult<TraktList>> GetCustomListsAsync(string username)
        {
            ValidateUsername(username);

            return await QueryAsync(new TraktUserCustomListsRequest(Client)
            {
                Username = username
            });
        }

        public async Task<TraktList> GetCustomSingleListAsync(string username, string listId)
        {
            ValidateUsername(username);
            ValidateListId(listId);

            return await QueryAsync(new TraktUserCustomSingleListRequest(Client)
            {
                Username = username,
                Id = listId
            });
        }

        public async Task<TraktListResult<TraktList>> GetMultipleCustomListsAsync(TraktUsersListId ids[])
        {
            if (ids == null && ids.Length <= 0)
                return null;

            var tasks = new List<Task<TraktList>>();

            for (int i = 0; i < ids.Length; i++)
            {
                 var listRequest = ids[i];

                 if (listRequest != null)
                 {
                     Task<TraktList> task = GetCustomSingleListAsync(listRequest.Username, listRequest.ListId);
                     tasks.Add(task);
                 }
            }

            var lists = await Task.WhenAll(tasks);
            return new TraktListResult<TraktList> { Items = lists.ToList() };
        }

        public async Task<TraktListResult<TraktListItem>> GetCustomListItemsAsync(string username, string listId,
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
                throw new ArgumentException("list name not valid", nameof(listName));

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

            var requestBody = new TraktUserCustomListPost
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
                                                                                                 TraktUserCustomListItemsPost listItemsRemovePost)
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

        public async Task<TraktPaginationListResult<TraktComment>> GetListCommentsAsync(string username, string listId,
                                                                                        TraktCommentSortOrder? sorting = null,
                                                                                        int? page = null, int? limit = null)
        {
            ValidateUsername(username);
            ValidateListId(listId);

            return await QueryAsync(new TraktUserListCommentsRequest(Client)
            {
                Username = username,
                Id = listId,
                Sorting = sorting,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task LikeListAsync(string username, string listId)
        {
            ValidateUsername(username);
            ValidateListId(listId);

            await QueryAsync(new TraktUserListLikeRequest(Client)
            {
                Username = username,
                Id = listId
            });
        }

        public async Task UnlikeListAsync(string username, string listId)
        {
            ValidateUsername(username);
            ValidateListId(listId);

            await QueryAsync(new TraktUserListUnlikeRequest(Client)
            {
                Username = username,
                Id = listId
            });
        }

        public async Task<TraktListResult<TraktUserFollower>> GetFollowersAsync(string username)
        {
            ValidateUsername(username);

            return await QueryAsync(new TraktUserFollowersRequest(Client) { Username = username });
        }

        public async Task<TraktListResult<TraktUserFollower>> GetFollowingAsync(string username)
        {
            ValidateUsername(username);

            return await QueryAsync(new TraktUserFollowingRequest(Client) { Username = username });
        }

        public async Task<TraktListResult<TraktUserFriend>> GetFriendsAsync(string username)
        {
            ValidateUsername(username);

            return await QueryAsync(new TraktUserFriendsRequest(Client) { Username = username });
        }

        public async Task<TraktUserFollowUserPostResponse> FollowUserAsync(string username)
        {
            ValidateUsername(username);

            return await QueryAsync(new TraktUserFollowUserRequest(Client) { Username = username });
        }

        public async Task UnfollowUserAsync(string username)
        {
            ValidateUsername(username);

            await QueryAsync(new TraktUserUnfollowUserRequest(Client) { Username = username });
        }

        public async Task<TraktUserFollower> ApproveFollowRequestAsync(string followerRequestId)
        {
            ValidateFollowerRequestId(followerRequestId);

            return await QueryAsync(new TraktUserApproveFollowerRequest(Client) { Id = followerRequestId });
        }

        public async Task DenyFollowRequestAsync(string followerRequestId)
        {
            ValidateFollowerRequestId(followerRequestId);

            await QueryAsync(new TraktUserDenyFollowerRequest(Client) { Id = followerRequestId });
        }

        public async Task<TraktPaginationListResult<TraktHistoryItem>> GetWatchedHistoryAsync(string username, TraktSyncItemType? type = null,
                                                                                              string itemId = null, DateTime? startAt = null,
                                                                                              DateTime? endAt = null, int? page = null, int? limit = null)
        {
            ValidateUsername(username);

            return await QueryAsync(new TraktUserWatchedHistoryRequest(Client)
            {
                Username = username,
                Type = type,
                ItemId = itemId,
                StartAt = startAt,
                EndAt = endAt,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktListResult<TraktRatingsItem>> GetRatingsAsync(string username, TraktSyncRatingsItemType? type = null,
                                                                             int[] rating = null, TraktExtendedOption extended = null)
        {
            ValidateUsername(username);

            return await QueryAsync(new TraktUserRatingsRequest(Client)
            {
                Username = username,
                Type = type,
                Rating = rating,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktListResult<TraktWatchlistItem>> GetWatchlistAsync(string username, TraktSyncItemType? type = null,
                                                                                 TraktExtendedOption extended = null)
        {
            ValidateUsername(username);

            return await QueryAsync(new TraktUserWatchlistRequest(Client)
            {
                Username = username,
                Type = type,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktUserWatchingItem> GetWatchingAsync(string username, TraktExtendedOption extended = null)
        {
            ValidateUsername(username);

            return await QueryAsync(new TraktUserWatchingRequest(Client)
            {
                Username = username,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktListResult<TraktWatchedMovie>> GetWatchedMoviesAsync(string username, TraktExtendedOption extended = null)
        {
            ValidateUsername(username);

            return await QueryAsync(new TraktUserWatchedMoviesRequest(Client)
            {
                Username = username,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktListResult<TraktWatchedShow>> GetWatchedShowsAsync(string username, TraktExtendedOption extended = null)
        {
            ValidateUsername(username);

            return await QueryAsync(new TraktUserWatchedShowsRequest(Client)
            {
                Username = username,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktUserStatistics> GetStatisticsAsync(string username)
        {
            ValidateUsername(username);

            return await QueryAsync(new TraktUserStatisticsRequest(Client) { Username = username });
        }

        private void ValidateUsername(string username)
        {
            if (string.IsNullOrEmpty(username) || username.ContainsSpace())
                throw new ArgumentException("username not valid", nameof(username));
        }

        private void ValidateListId(string listId)
        {
            if (string.IsNullOrEmpty(listId) || listId.ContainsSpace())
                throw new ArgumentException("list id not valid", nameof(listId));
        }

        private void ValidateCustomListItemsPost(TraktUserCustomListItemsPost customListItemsPost)
        {
            if (customListItemsPost == null)
                throw new ArgumentNullException("list items post must not be null", nameof(customListItemsPost));

            var movies = customListItemsPost.Movies;
            var shows = customListItemsPost.Shows;
            var people = customListItemsPost.People;

            var bHasNoMovies = movies == null || !movies.Any();
            var bHasNoShows = shows == null || !shows.Any();
            var bHasNoPeople = people == null || !people.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoPeople)
                throw new ArgumentException("no items set");
        }

        private void ValidateFollowerRequestId(string followerRequestId)
        {
            if (string.IsNullOrEmpty(followerRequestId) || followerRequestId.ContainsSpace())
                throw new ArgumentException("follower request id is not valid", nameof(followerRequestId));
        }
    }
}
