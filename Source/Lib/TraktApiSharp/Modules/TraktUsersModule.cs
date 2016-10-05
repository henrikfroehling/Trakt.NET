namespace TraktApiSharp.Modules
{
    using Attributes;
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
    using Requests.Params;
    using Requests.WithOAuth.Users;
    using Requests.WithoutOAuth.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to users.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/users">"Trakt API Doc - Users"</a> section.
    /// </para>
    /// </summary>
    public class TraktUsersModule : TraktBaseModule
    {
        internal TraktUsersModule(TraktClient client) : base(client) { }

        /// <summary>
        /// Gets the user's settings.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/settings/retrieve-settings">"Trakt API Doc - Users: Settings"</a> for more information.
        /// </para>
        /// </summary>
        /// <returns>An <see cref="TraktUserSettings" /> instance containing the user's settings.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktUserSettings> GetSettingsAsync()
            => await QueryAsync(new TraktUserSettingsRequest(Client));

        /// <summary>
        /// Gets the user's pending follow requests.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/follower-requests/get-follow-requests">"Trakt API Doc - Users: Follower Requests"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the follow request users should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>A list of <see cref="TraktUserFollowRequest" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired]
        public async Task<IEnumerable<TraktUserFollowRequest>> GetFollowRequestsAsync(TraktExtendedInfo extendedInfo = null)
            => await QueryAsync(new TraktUserFollowRequestsRequest(Client) { ExtendedInfo = extendedInfo });

        /// <summary>
        /// Gets the user's hidden items, like movies, shows and / or seasons.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/hidden-items/get-hidden-items">"Trakt API Doc - Users: Hidden Items"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="hiddenItemsSection">Determines, from which section the hidden items should be queried. See also <seealso cref="TraktHiddenItemsSection" />.</param>
        /// <param name="hiddenItemType">Determines, which type of hidden items should be queried. See also <seealso cref="TraktHiddenItemType" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the hidden items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="page">The page of the hidden items list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of hidden items for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktUserHiddenItem}"/> instance containing the queried hidden items and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktUserHiddenItem" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given hidden items section is unspecified.</exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktPaginationListResult<TraktUserHiddenItem>> GetHiddenItemsAsync(TraktHiddenItemsSection hiddenItemsSection,
                                                                                              TraktHiddenItemType hiddenItemType = null,
                                                                                              TraktExtendedInfo extendedInfo = null,
                                                                                              int? page = null, int? limitPerPage = null)
        {
            if (hiddenItemsSection == null || hiddenItemsSection == TraktHiddenItemsSection.Unspecified)
                throw new ArgumentException("section not valid", nameof(hiddenItemsSection));

            return await QueryAsync(new TraktUserHiddenItemsRequest(Client)
            {
                Section = hiddenItemsSection,
                Type = hiddenItemType,
                ExtendedInfo = extendedInfo,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });
        }

        /// <summary>
        /// Gets the items (movies, shows, seasons, episodes, persons, comments, lists) the user likes.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/likes/get-likes">"Trakt API Doc - Users: Likes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="likeType">Determines, which type of objects liked should be queried. See also <seealso cref="TraktUserLikeType" />.</param>
        /// <param name="page">The page of the like items list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of like items for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktUserLikeItem}"/> instance containing the queried like items and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktUserLikeItem" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktPaginationListResult<TraktUserLikeItem>> GetLikesAsync(TraktUserLikeType likeType = null,
                                                                          int? page = null, int? limitPerPage = null)
            => await QueryAsync(new TraktUserLikesRequest(Client)
            {
                Type = likeType,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });

        /// <summary>
        /// Gets an user's profile information.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/profile/get-user-profile">"Trakt API Doc - Users: Profile"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the profile should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the user's profile should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>An <see cref="TraktUser" /> instance containing the user's profile information.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationOptional]
        public async Task<TraktUser> GetUserProfileAsync([NotNull] string usernameOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            ValidateUsername(usernameOrSlug);

            return await QueryAsync(new TraktUserProfileRequest(Client)
            {
                Username = usernameOrSlug,
                ExtendedInfo = extendedInfo
            });
        }

        /// <summary>
        /// Gets all collected movies in an user's collection.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/collection/get-collection">"Trakt API Doc - Users: Collection"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the collected movies should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the collected movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>A list of <see cref="TraktCollectionMovie" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationOptional]
        public async Task<IEnumerable<TraktCollectionMovie>> GetCollectionMoviesAsync([NotNull] string usernameOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            ValidateUsername(usernameOrSlug);

            return await QueryAsync(new TraktUserCollectionMoviesRequest(Client)
            {
                Username = usernameOrSlug,
                ExtendedInfo = extendedInfo
            });
        }

        /// <summary>
        /// Gets all collected shows in an user's collection.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/collection/get-collection">"Trakt API Doc - Users: Collection"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the collected shows should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the collected shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>A list of <see cref="TraktCollectionShow" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationOptional]
        public async Task<IEnumerable<TraktCollectionShow>> GetCollectionShowsAsync([NotNull] string usernameOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            ValidateUsername(usernameOrSlug);

            return await QueryAsync(new TraktUserCollectionShowsRequest(Client)
            {
                Username = usernameOrSlug,
                ExtendedInfo = extendedInfo
            });
        }

        /// <summary>
        /// Gets all comments an user has posted, sorted by most recent.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/comments/get-comments">"Trakt API Doc - Users: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the comments should be queried.</param>
        /// <param name="commentType">Determines, which type of comments should be queried. See also <seealso cref="TraktCommentType" />.</param>
        /// <param name="objectType">Determines, for which object types comments should be queried. See also <seealso cref="TraktObjectType" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the commented objects should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="page">The page of the comments list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of comments for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktUserComment}"/> instance containing the queried comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktUserComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationOptional]
        public async Task<TraktPaginationListResult<TraktUserComment>> GetCommentsAsync([NotNull] string usernameOrSlug,
                                                                                        TraktCommentType commentType = null,
                                                                                        TraktObjectType objectType = null,
                                                                                        TraktExtendedInfo extendedInfo = null,
                                                                                        int? page = null, int? limitPerPage = null)
        {
            ValidateUsername(usernameOrSlug);

            return await QueryAsync(new TraktUserCommentsRequest(Client)
            {
                Username = usernameOrSlug,
                CommentType = commentType,
                Type = objectType,
                ExtendedInfo = extendedInfo,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });
        }

        /// <summary>
        /// Gets an user's custom lists.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/lists">"Trakt API Doc - Users: Lists"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the custom lists should be queried.</param>
        /// <returns>A list of <see cref="TraktList" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationOptional]
        public async Task<IEnumerable<TraktList>> GetCustomListsAsync([NotNull] string usernameOrSlug)
        {
            ValidateUsername(usernameOrSlug);

            return await QueryAsync(new TraktUserCustomListsRequest(Client) { Username = usernameOrSlug });
        }

        /// <summary>
        /// Gets an user's single custom list.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/list/get-custom-list">"Trakt API Doc - Users: List"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleCustomListsAsync(TraktMultipleUserListsQueryParams)" />.</para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the custom list should be queried.</param>
        /// <param name="listIdOrSlug">The id or slug of the custom list, which should be queried.</param>
        /// <returns>Anv <see cref="TraktList" /> instance containing the custom list informations.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given username or slug is null, empty or contains spaces.
        /// Thrown, if the given list id is null, empty or contains spaces.
        /// </exception>
        [OAuthAuthorizationOptional]
        public async Task<TraktList> GetCustomSingleListAsync([NotNull] string usernameOrSlug, [NotNull] string listIdOrSlug)
        {
            ValidateUsername(usernameOrSlug);
            ValidateListId(listIdOrSlug);

            return await QueryAsync(new TraktUserCustomSingleListRequest(Client)
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug
            });
        }

        /// <summary>
        /// Gets multiple different custom lists for multiple different users at once.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/list/get-custom-list">"Trakt API Doc - Users: List"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetCustomSingleListAsync(string, string)" />.</para>
        /// </summary>
        /// <param name="userListsQueryParams">A list of usernames and list ids. See also <seealso cref="TraktMultipleUserListsQueryParams" />.</param>
        /// <returns>A list of <see cref="TraktList" /> instances with the data of each queried custom list.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if one of the given usernames is null, empty or contains spaces.
        /// Thrown, if one of the given list ids is null, empty or contains spaces.
        /// </exception>
        [OAuthAuthorizationOptional]
        public async Task<IEnumerable<TraktList>> GetMultipleCustomListsAsync(TraktMultipleUserListsQueryParams userListsQueryParams)
        {
            if (userListsQueryParams == null || userListsQueryParams.Count <= 0)
                return new List<TraktList>();

            var tasks = new List<Task<TraktList>>();

            foreach (var queryParam in userListsQueryParams)
            {
                Task<TraktList> task = GetCustomSingleListAsync(queryParam.Username, queryParam.ListId);
                tasks.Add(task);
            }

            var lists = await Task.WhenAll(tasks);
            return lists.ToList();
        }

        /// <summary>
        /// Gets the items on an user's single custom list.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/list-items/get-items-on-a-custom-list">"Trakt API Doc - Users: List Items"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the custom list items should be queried.</param>
        /// <param name="listIdOrSlug">The id or slug of the custom list, for which the items should be queried.</param>
        /// <param name="listItemType">Determines, which type of list items should be queried. See also <seealso cref="TraktListItemType" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the list items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>A list of <see cref="TraktListItem" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given username or slug is null, empty or contains spaces.
        /// Thrown, if the given list id is null, empty or contains spaces.
        /// </exception>
        [OAuthAuthorizationOptional]
        public async Task<IEnumerable<TraktListItem>> GetCustomListItemsAsync([NotNull] string usernameOrSlug, [NotNull] string listIdOrSlug,
                                                                              TraktListItemType listItemType = null,
                                                                              TraktExtendedInfo extendedInfo = null)
        {
            ValidateUsername(usernameOrSlug);
            ValidateListId(listIdOrSlug);

            return await QueryAsync(new TraktUserCustomListItemsRequest(Client)
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug,
                Type = listItemType,
                ExtendedInfo = extendedInfo
            });
        }

        /// <summary>
        /// Creates a new custom list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/lists/create-custom-list">"Trakt API Doc - Users: Lists"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the custom list should be created.</param>
        /// <param name="listName">The name of the newly created custom list.</param>
        /// <param name="listDescription">The description of the newly created custom list.</param>  
        /// <param name="privacy">Determines the visibility of the newly created custom list. See also <seealso cref="TraktAccessScope" />.</param>
        /// <param name="displayNumbers">Determines, if ranking numbers should be visible on the newly created custom list.</param>
        /// <param name="allowComments">Determines, if comments are allowed on the newly created custom list.</param>
        /// <returns>An <see cref="TraktList" /> instance containing information about the successfully created custom list.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given username or slug is null, empty or contains spaces.
        /// Thrown, if the given list name is null or empty.
        /// </exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktList> CreateCustomListAsync([NotNull] string usernameOrSlug, [NotNull] string listName, string listDescription = null,
                                                           TraktAccessScope privacy = null,
                                                           bool? displayNumbers = null, bool? allowComments = null)
        {
            ValidateUsername(usernameOrSlug);

            if (string.IsNullOrEmpty(listName))
                throw new ArgumentException("list name not valid", nameof(listName));

            var requestBody = new TraktUserCustomListPost
            {
                Name = listName,
                Description = listDescription,
                DisplayNumbers = displayNumbers,
                AllowComments = allowComments
            };

            if (privacy != null && privacy != TraktAccessScope.Unspecified)
                requestBody.Privacy = privacy;

            return await QueryAsync(new TraktUserCustomListAddRequest(Client)
            {
                Username = usernameOrSlug,
                RequestBody = requestBody
            });
        }

        /// <summary>
        /// Updates an user's custom list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/list/update-custom-list">"Trakt API Doc - Users: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the custom list should be updated.</param>
        /// <param name="listIdOrSlug">The id or slug of the custom list, which should be updated.</param>
        /// <param name="listName">A new name for the custom list with the given id.</param>
        /// <param name="listDescription">A new description for the custom list with the given id.</param>
        /// <param name="privacy">A new visibility setting for the custom list with the given id.</param>
        /// <param name="displayNumbers">A new ranking numbers visibility setting for the custom list with the given id.</param>
        /// <param name="allowComments">A new comments allowed setting for the custom list with the given id.</param>
        /// <returns>An <see cref="TraktList" /> instance containing information about the successfully updated custom list.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given username or slug is null, empty or contains spaces.
        /// Thrown, if the given list id is null, empty or contains spaces.
        /// Thrown, if the no new values are given (list name is null or empty and description is null and privacy is not set and
        /// display numbers is not set and comments allowed is not set).
        /// </exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktList> UpdateCustomListAsync([NotNull] string usernameOrSlug, [NotNull] string listIdOrSlug,
                                                           string listName = null, string listDescription = null,
                                                           TraktAccessScope privacy = null,
                                                           bool? displayNumbers = null, bool? allowComments = null)
        {
            ValidateUsername(usernameOrSlug);
            ValidateListId(listIdOrSlug);

            var isListNameNotValid = string.IsNullOrEmpty(listName);
            var isDescriptionNotSet = listDescription == null;
            var isPrivacyNotSetOrValid = privacy == null || privacy == TraktAccessScope.Unspecified;
            var isDisplayNumbersNotSet = !displayNumbers.HasValue;
            var isAllowCommentsNotSet = !allowComments.HasValue;

            if (isListNameNotValid && isDescriptionNotSet && isPrivacyNotSetOrValid && isDisplayNumbersNotSet && isAllowCommentsNotSet)
            {
                throw new ArgumentException("no list specific values set");
            }

            var requestBody = new TraktUserCustomListPost
            {
                Name = listName,
                Description = listDescription,
                DisplayNumbers = displayNumbers,
                AllowComments = allowComments
            };

            if (!isPrivacyNotSetOrValid)
                requestBody.Privacy = privacy;

            return await QueryAsync(new TraktUserCustomListUpdateRequest(Client)
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug,
                RequestBody = requestBody
            });
        }

        /// <summary>
        /// Deletes an user's custom list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/list">"Trakt API Doc - Users: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the custom list should be deleted.</param>
        /// <param name="listIdOrSlug">The id or slug of the list, which should be deleted.</param>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given username or slug is null, empty or contains spaces.
        /// Thrown, if the given list id is null, empty or contains spaces.
        /// </exception>
        [OAuthAuthorizationRequired]
        public async Task DeleteCustomListAsync([NotNull] string usernameOrSlug, [NotNull] string listIdOrSlug)
        {
            ValidateUsername(usernameOrSlug);
            ValidateListId(listIdOrSlug);

            await QueryAsync(new TraktUserCustomListDeleteRequest(Client)
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug
            });
        }

        /// <summary>
        /// Adds items to an user's custom list. Accepts shows, seasons, episodes, movies and people.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/list-items/add-items-to-custom-list">"Trakt API Doc - Users: List Items"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="TraktUserCustomListItemsPostBuilder" /> to create an instance
        /// of the required <see cref="TraktUserCustomListItemsPost" />.
        /// See also <seealso cref="TraktUserCustomListItemsPost.Builder()" />.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which items should be added to a custom list.</param>
        /// <param name="listIdOrSlug">The id or slug of the custom list, to which items should be added.</param>
        /// <param name="listItemsPost">An <see cref="TraktUserCustomListItemsPost" /> instance containing all shows, seasons, episodes, movies and people, which should be added.</param>
        /// <param name="listItemType">Determines, which type of items should be added. See also <seealso cref="TraktListItemType" />.</param>
        /// <returns>An <see cref="TraktUserCustomListItemsPostResponse" /> instance, which contains information about which items were added, existing and not found.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given list items post is null.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given username or slug is null, empty or contains spaces.
        /// Thrown, if the given list id is null, empty or contains spaces.
        /// Thrown, if the given list items post is empty.
        /// </exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktUserCustomListItemsPostResponse> AddCustomListItemsAsync([NotNull] string usernameOrSlug, [NotNull] string listIdOrSlug,
                                                                                        [NotNull] TraktUserCustomListItemsPost listItemsPost,
                                                                                        TraktListItemType listItemType = null)
        {
            ValidateUsername(usernameOrSlug);
            ValidateListId(listIdOrSlug);
            ValidateCustomListItemsPost(listItemsPost);

            return await QueryAsync(new TraktUserCustomListItemsAddRequest(Client)
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug,
                Type = listItemType,
                RequestBody = listItemsPost
            });
        }

        /// <summary>
        /// Removes items from an user's custom list. Accepts shows, seasons, episodes, movies and people.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/remove-list-items/remove-items-from-custom-list">"Trakt API Doc - Users: Remove List Items"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="TraktUserCustomListItemsPostBuilder" /> to create an instance
        /// of the required <see cref="TraktUserCustomListItemsPost" />.
        /// See also <seealso cref="TraktUserCustomListItemsPost.Builder()" />.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which items should be removed from a custom list.</param>
        /// <param name="listIdOrSlug">The id or slug of the custom list, from which items should be removed.</param>
        /// <param name="listItemsRemovePost">An <see cref="TraktUserCustomListItemsPost" /> instance containing all shows, seasons, episodes, movies and people, which should be removed.</param>
        /// <returns>An <see cref="TraktUserCustomListItemsPostResponse" /> instance, which contains information about which items were deleted and not found.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given list items remove post is null.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given username or slug is null, empty or contains spaces.
        /// Thrown, if the given list id is null, empty or contains spaces.
        /// Thrown, if the given list items remove post is empty.
        /// </exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktUserCustomListItemsRemovePostResponse> RemoveCustomListItemsAsync([NotNull] string usernameOrSlug, [NotNull] string listIdOrSlug,
                                                                                                 [NotNull] TraktUserCustomListItemsPost listItemsRemovePost)
        {
            ValidateUsername(usernameOrSlug);
            ValidateListId(listIdOrSlug);
            ValidateCustomListItemsPost(listItemsRemovePost);

            return await QueryAsync(new TraktUserCustomListItemsRemoveRequest(Client)
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug,
                RequestBody = listItemsRemovePost
            });
        }

        /// <summary>
        /// Gets top level comments for an user's custom list.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/list-comments/get-all-list-comments">"Trakt API Doc - Users: List Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the custom list comments should be queried.</param>
        /// <param name="listIdOrSlug">The id or slug of the custom list, for which the comments should be queried.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
        /// <param name="page">The page of the comments list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of comments for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktComment}"/> instance containing the queried custom list comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given username or slug is null, empty or contains spaces.
        /// Thrown, if the given list id is null, empty or contains spaces.
        /// </exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktComment>> GetListCommentsAsync([NotNull] string usernameOrSlug, [NotNull] string listIdOrSlug,
                                                                                        TraktCommentSortOrder commentSortOrder = null,
                                                                                        int? page = null, int? limitPerPage = null)
        {
            ValidateUsername(usernameOrSlug);
            ValidateListId(listIdOrSlug);

            return await QueryAsync(new TraktUserListCommentsRequest(Client)
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug,
                Sorting = commentSortOrder,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });
        }

        /// <summary>
        /// Likes an user's custom list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/list-like/like-a-list">"Trakt API Doc - Users: List Like"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the custom list should be liked.</param>
        /// <param name="listIdOrSlug">The id or slug of the list, which should be liked.</param>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given username or slug is null, empty or contains spaces.
        /// Thrown, if the given list id is null, empty or contains spaces.
        /// </exception>
        [OAuthAuthorizationRequired]
        public async Task LikeListAsync([NotNull] string usernameOrSlug, [NotNull] string listIdOrSlug)
        {
            ValidateUsername(usernameOrSlug);
            ValidateListId(listIdOrSlug);

            await QueryAsync(new TraktUserListLikeRequest(Client)
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug
            });
        }

        /// <summary>
        /// Removes like on an user's custom list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/list-like/remove-like-on-a-list">"Trakt API Doc - Users: List Like"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which a like on a custom list should be removed.</param>
        /// <param name="listIdOrSlug">The id or slug of the list, for which a like should be removed.</param>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given username or slug is null, empty or contains spaces.
        /// Thrown, if the given list id is null, empty or contains spaces.
        /// </exception>
        [OAuthAuthorizationRequired]
        public async Task UnlikeListAsync([NotNull] string usernameOrSlug, [NotNull] string listIdOrSlug)
        {
            ValidateUsername(usernameOrSlug);
            ValidateListId(listIdOrSlug);

            await QueryAsync(new TraktUserListUnlikeRequest(Client)
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug
            });
        }

        /// <summary>
        /// Gets an user's followers.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/followers/get-followers">"Trakt API Doc - Users: Followers"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the followers should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the follower users should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>A list of <see cref="TraktUserFollower" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationOptional]
        public async Task<IEnumerable<TraktUserFollower>> GetFollowersAsync([NotNull] string usernameOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            ValidateUsername(usernameOrSlug);

            return await QueryAsync(new TraktUserFollowersRequest(Client) { Username = usernameOrSlug, ExtendedInfo = extendedInfo });
        }

        /// <summary>
        /// Gets users an user is following.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/following/get-following">"Trakt API Doc - Users: Following"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the following users should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the following users should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>A list of <see cref="TraktUserFollower" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationOptional]
        public async Task<IEnumerable<TraktUserFollower>> GetFollowingAsync([NotNull] string usernameOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            ValidateUsername(usernameOrSlug);

            return await QueryAsync(new TraktUserFollowingRequest(Client) { Username = usernameOrSlug, ExtendedInfo = extendedInfo });
        }

        /// <summary>
        /// Gets an user's friends.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/friends/get-friends">"Trakt API Doc - Users: Friends"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the friends should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the friend users should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>A list of <see cref="TraktUserFriend" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationOptional]
        public async Task<IEnumerable<TraktUserFriend>> GetFriendsAsync([NotNull] string usernameOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            ValidateUsername(usernameOrSlug);

            return await QueryAsync(new TraktUserFriendsRequest(Client) { Username = usernameOrSlug, ExtendedInfo = extendedInfo });
        }

        /// <summary>
        /// Sends a follow request for an user with the given username.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/follow/follow-this-user">"Trakt API Doc - Users: Follow"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, which should be followed.</param>
        /// <returns>
        /// An <see cref="TraktUserFollowUserPostResponse" /> instance containing information whether the request was successful.
        /// See <see cref="TraktUserFollowUserPostResponse.ApprovedAt" />.
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktUserFollowUserPostResponse> FollowUserAsync([NotNull] string usernameOrSlug)
        {
            ValidateUsername(usernameOrSlug);

            return await QueryAsync(new TraktUserFollowUserRequest(Client) { Username = usernameOrSlug });
        }

        /// <summary>
        /// Sends an unfollow request for an user with the given username.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/follow/unfollow-this-user">"Trakt API Doc - Users: Follow"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, which should be unfollowed.</param>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired]
        public async Task UnfollowUserAsync([NotNull] string usernameOrSlug)
        {
            ValidateUsername(usernameOrSlug);

            await QueryAsync(new TraktUserUnfollowUserRequest(Client) { Username = usernameOrSlug });
        }

        /// <summary>
        /// Approves a follower request with the given id.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/approve-or-deny-follower-requests/approve-follow-request">"Trakt API Doc - Users: Approve or Deny Follower Requests"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="followerRequestId">The id of the follower request, which should be approved.</param>
        /// <returns>An <see cref="TraktUserFollower" /> instance containing information about the approved user.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given follower request id is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktUserFollower> ApproveFollowRequestAsync([NotNull] uint followerRequestId)
        {
            ValidateFollowerRequestId(followerRequestId);

            return await QueryAsync(new TraktUserApproveFollowerRequest(Client) { Id = followerRequestId.ToString() });
        }

        /// <summary>
        /// Denies a follower request with the given id.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/approve-or-deny-follower-requests/deny-follow-request">"Trakt API Doc - Users: Approve or Deny Follower Requests"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="followerRequestId">The id of the follower request, which should be denied.</param>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given follower request id is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired]
        public async Task DenyFollowRequestAsync([NotNull] uint followerRequestId)
        {
            ValidateFollowerRequestId(followerRequestId);

            await QueryAsync(new TraktUserDenyFollowerRequest(Client) { Id = followerRequestId.ToString() });
        }

        /// <summary>
        /// Gets all movies, shows, seasons and / or episodes an user has watched, sorted by most recent.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/history/get-watched-history">"Trakt API Doc - Users: History"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the watched history should be queried.</param>
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
        /// A <see cref="TraktPaginationListResult{TraktHistoryItem}"/> instance containing the queried history items and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktHistoryItem" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationOptional]
        public async Task<TraktPaginationListResult<TraktHistoryItem>> GetWatchedHistoryAsync([NotNull] string usernameOrSlug, TraktSyncItemType historyItemType = null,
                                                                                              uint? itemId = null, DateTime? startAt = null,
                                                                                              DateTime? endAt = null, TraktExtendedInfo extendedInfo = null,
                                                                                              int? page = null, int? limitPerPage = null)
        {
            ValidateUsername(usernameOrSlug);

            return await QueryAsync(new TraktUserWatchedHistoryRequest(Client)
            {
                Username = usernameOrSlug,
                Type = historyItemType,
                ItemId = itemId,
                StartAt = startAt,
                EndAt = endAt,
                ExtendedInfo = extendedInfo,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });
        }

        /// <summary>
        /// Gets an user's ratings for movies, shows, seasons and / or episodes.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/ratings/get-ratings">"Trakt API Doc - Users: Ratings"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the ratings should be queried.</param>
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
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationOptional]
        public async Task<IEnumerable<TraktRatingsItem>> GetRatingsAsync([NotNull] string usernameOrSlug, TraktRatingsItemType ratingsItemType = null,
                                                                         int[] ratingsFilter = null, TraktExtendedInfo extendedInfo = null)
        {
            ValidateUsername(usernameOrSlug);

            return await QueryAsync(new TraktUserRatingsRequest(Client)
            {
                Username = usernameOrSlug,
                Type = ratingsItemType,
                Rating = ratingsFilter,
                ExtendedInfo = extendedInfo
            });
        }

        /// <summary>
        /// Gets all items in an user's watchlist.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/watchlist/get-watchlist">"Trakt API Doc - Users: Watchlist"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the watchlist items should be queried.</param>
        /// <param name="watchlistItemType">Determines, which type of items in the watchlist should be queried. See also <seealso cref="TraktSyncItemType" />.</param>
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
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationOptional]
        public async Task<TraktPaginationListResult<TraktWatchlistItem>> GetWatchlistAsync([NotNull] string usernameOrSlug, TraktSyncItemType watchlistItemType = null,
                                                                                           TraktExtendedInfo extendedInfo = null,
                                                                                           int? page = null, int? limitPerPage = null)
        {
            ValidateUsername(usernameOrSlug);

            return await QueryAsync(new TraktUserWatchlistRequest(Client)
            {
                Username = usernameOrSlug,
                Type = watchlistItemType,
                ExtendedInfo = extendedInfo,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });
        }

        /// <summary>
        /// Gets the movie or episode an user is currently watching.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/watching/get-watching">"Trakt API Doc - Users: Watching"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the currently watching item should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the currently watching item should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>An <see cref="TraktUserWatchingItem" /> instance containing the movie or episode an user is currently watching.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationOptional]
        public async Task<TraktUserWatchingItem> GetWatchingAsync([NotNull] string usernameOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            ValidateUsername(usernameOrSlug);

            return await QueryAsync(new TraktUserWatchingRequest(Client)
            {
                Username = usernameOrSlug,
                ExtendedInfo = extendedInfo
            });
        }

        /// <summary>
        /// Gets all movies an user has watched, sorted by most plays.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/watched/get-watched">"Trakt API Doc - Users: Watched"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the watched movies should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the watched movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>A list of <see cref="TraktWatchedMovie" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationOptional]
        public async Task<IEnumerable<TraktWatchedMovie>> GetWatchedMoviesAsync([NotNull] string usernameOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            ValidateUsername(usernameOrSlug);

            return await QueryAsync(new TraktUserWatchedMoviesRequest(Client)
            {
                Username = usernameOrSlug,
                ExtendedInfo = extendedInfo
            });
        }

        /// <summary>
        /// Gets all shows an user has watched, sorted by most plays.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/watched/get-watched">"Trakt API Doc - Users: Watched"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the watched shows should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the watched shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>A list of <see cref="TraktWatchedShow" /> instances.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationOptional]
        public async Task<IEnumerable<TraktWatchedShow>> GetWatchedShowsAsync([NotNull] string usernameOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            ValidateUsername(usernameOrSlug);

            return await QueryAsync(new TraktUserWatchedShowsRequest(Client)
            {
                Username = usernameOrSlug,
                ExtendedInfo = extendedInfo
            });
        }

        /// <summary>
        /// Gets statistics about the movies, shows and episodes an user has watched.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/stats/get-stats">"Trakt API Doc - Users: Stats"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the statistics should be queried.</param>
        /// <returns>An <see cref="TraktUserStatistics" /> instance coontaining statistics about movies, shows and episodes.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationOptional]
        public async Task<TraktUserStatistics> GetStatisticsAsync([NotNull] string usernameOrSlug)
        {
            ValidateUsername(usernameOrSlug);

            return await QueryAsync(new TraktUserStatisticsRequest(Client) { Username = usernameOrSlug });
        }

        private void ValidateUsername(string usernameOrSlug)
        {
            if (string.IsNullOrEmpty(usernameOrSlug) || usernameOrSlug.ContainsSpace())
                throw new ArgumentException("username or slug not valid", nameof(usernameOrSlug));
        }

        private void ValidateListId(string listId)
        {
            if (string.IsNullOrEmpty(listId) || listId.ContainsSpace())
                throw new ArgumentException("list id not valid", nameof(listId));
        }

        private void ValidateCustomListItemsPost(TraktUserCustomListItemsPost customListItemsPost)
        {
            if (customListItemsPost == null)
                throw new ArgumentNullException(nameof(customListItemsPost), "list items post must not be null");

            var movies = customListItemsPost.Movies;
            var shows = customListItemsPost.Shows;
            var people = customListItemsPost.People;

            var bHasNoMovies = movies == null || !movies.Any();
            var bHasNoShows = shows == null || !shows.Any();
            var bHasNoPeople = people == null || !people.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoPeople)
                throw new ArgumentException("no items set");
        }

        private void ValidateFollowerRequestId(ulong followerRequestId)
        {
            if (followerRequestId == 0)
                throw new ArgumentException("follower request id is not valid", nameof(followerRequestId));
        }
    }
}
