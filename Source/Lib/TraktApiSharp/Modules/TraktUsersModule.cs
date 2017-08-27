namespace TraktApiSharp.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Basic;
    using Objects.Get.Collections;
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
    using Requests.Handler;
    using Requests.Parameters;
    using Requests.Users;
    using Requests.Users.OAuth;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to users.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/users">"Trakt API Doc - Users"</a> section.
    /// </para>
    /// </summary>
    public class TraktUsersModule : ITraktModule
    {
        internal TraktUsersModule(TraktClient client)
        {
            Client = client;
        }

        /// <summary>Gets a reference to the associated <see cref="TraktClient" /> instance.</summary>
        public TraktClient Client { get; }

        /// <summary>
        /// Gets the user's settings.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/settings/retrieve-settings">"Trakt API Doc - Users: Settings"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktUserSettings" /> instance containing the user's settings.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktResponse<ITraktUserSettings>> GetSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteSingleItemRequestAsync(new TraktUserSettingsRequest(), cancellationToken);
        }

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
        /// <param name="cancellationToken"></param>
        /// <returns>A list of <see cref="ITraktUserFollowRequest" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktListResponse<ITraktUserFollowRequest>> GetFollowRequestsAsync(TraktExtendedInfo extendedInfo = null,
                                                                                       CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteListRequestAsync(new TraktUserFollowRequestsRequest { ExtendedInfo = extendedInfo }, cancellationToken);
        }

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
        /// <param name="pagedParameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktUserHiddenItem}"/> instance containing the queried hidden items and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktUserHiddenItem" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given hidden items section is unspecified.</exception>
        public Task<TraktPagedResponse<ITraktUserHiddenItem>> GetHiddenItemsAsync(TraktHiddenItemsSection hiddenItemsSection,
                                                                                  TraktHiddenItemType hiddenItemType = null,
                                                                                  TraktExtendedInfo extendedInfo = null,
                                                                                  TraktPagedParameters pagedParameters = null,
                                                                                  CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new TraktUserHiddenItemsRequest
            {
                Section = hiddenItemsSection,
                Type = hiddenItemType,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            }, cancellationToken);
        }

        /// <summary>
        /// Gets the items (movies, shows, seasons, episodes, persons, comments, lists) the user likes.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/likes/get-likes">"Trakt API Doc - Users: Likes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="likeType">Determines, which type of objects liked should be queried. See also <seealso cref="TraktUserLikeType" />.</param>
        /// <param name="pagedParameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktUserLikeItem}"/> instance containing the queried like items and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktUserLikeItem" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktUserLikeItem>> GetLikesAsync(TraktUserLikeType likeType = null,
                                                                          TraktPagedParameters pagedParameters = null,
                                                                          CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new TraktUserLikesRequest
            {
                Type = likeType,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            }, cancellationToken);
        }

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
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktUser" /> instance containing the user's profile information.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        public Task<TraktResponse<ITraktUser>> GetUserProfileAsync(string usernameOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                   CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new TraktUserProfileRequest
            {
                Username = usernameOrSlug,
                ExtendedInfo = extendedInfo
            }, cancellationToken);
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
        /// <param name="cancellationToken"></param>
        /// <returns>A list of <see cref="ITraktCollectionMovie" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        public Task<TraktListResponse<ITraktCollectionMovie>> GetCollectionMoviesAsync(string usernameOrSlug,
                                                                                       TraktExtendedInfo extendedInfo = null,
                                                                                       CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new UserCollectionMoviesRequest
            {
                Username = usernameOrSlug,
                ExtendedInfo = extendedInfo
            }, cancellationToken);
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
        /// <param name="cancellationToken"></param>
        /// <returns>A list of <see cref="ITraktCollectionShow" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        public Task<TraktListResponse<ITraktCollectionShow>> GetCollectionShowsAsync(string usernameOrSlug,
                                                                                     TraktExtendedInfo extendedInfo = null,
                                                                                     CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new UserCollectionShowsRequest
            {
                Username = usernameOrSlug,
                ExtendedInfo = extendedInfo
            }, cancellationToken);
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
        /// <param name="pagedParameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktUserComment}"/> instance containing the queried comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktUserComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        public Task<TraktPagedResponse<ITraktUserComment>> GetCommentsAsync(string usernameOrSlug,
                                                                            TraktCommentType commentType = null,
                                                                            TraktObjectType objectType = null,
                                                                            TraktExtendedInfo extendedInfo = null,
                                                                            TraktPagedParameters pagedParameters = null,
                                                                            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new UserCommentsRequest
            {
                Username = usernameOrSlug,
                CommentType = commentType,
                ObjectType = objectType,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            }, cancellationToken);
        }

        /// <summary>
        /// Gets an user's custom lists.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/lists">"Trakt API Doc - Users: Lists"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the custom lists should be queried.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of <see cref="ITraktList" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        public Task<TraktListResponse<ITraktList>> GetCustomListsAsync(string usernameOrSlug, CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteListRequestAsync(new UserCustomListsRequest { Username = usernameOrSlug }, cancellationToken);
        }

        /// <summary>
        /// Gets an user's single custom list.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/list/get-custom-list">"Trakt API Doc - Users: List"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultipleCustomListsAsync(TraktMultipleUserListsQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the custom list should be queried.</param>
        /// <param name="listIdOrSlug">The id or slug of the custom list, which should be queried.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Anv <see cref="ITraktList" /> instance containing the custom list informations.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given username or slug is null, empty or contains spaces.
        /// Thrown, if the given list id is null, empty or contains spaces.
        /// </exception>
        public Task<TraktResponse<ITraktList>> GetCustomSingleListAsync(string usernameOrSlug, string listIdOrSlug,
                                                                        CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new UserCustomSingleListRequest
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug
            }, cancellationToken);
        }

        /// <summary>
        /// Gets multiple different custom lists for multiple different users at once.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/list/get-custom-list">"Trakt API Doc - Users: List"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetCustomSingleListAsync(string, string, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="userListsQueryParams">A list of usernames and list ids. See also <seealso cref="TraktMultipleUserListsQueryParams" />.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of <see cref="ITraktList" /> instances with the data of each queried custom list.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if one of the given usernames is null, empty or contains spaces.
        /// Thrown, if one of the given list ids is null, empty or contains spaces.
        /// </exception>
        public async Task<IEnumerable<TraktResponse<ITraktList>>> GetMultipleCustomListsAsync(TraktMultipleUserListsQueryParams userListsQueryParams,
                                                                                              CancellationToken cancellationToken = default(CancellationToken))
        {
            if (userListsQueryParams == null || userListsQueryParams.Count <= 0)
                return new List<TraktResponse<ITraktList>>();

            var tasks = new List<Task<TraktResponse<ITraktList>>>();

            foreach (var queryParam in userListsQueryParams)
            {
                Task<TraktResponse<ITraktList>> task = GetCustomSingleListAsync(queryParam.Username, queryParam.ListId, cancellationToken);
                tasks.Add(task);
            }

            var lists = await Task.WhenAll(tasks).ConfigureAwait(false);
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
        /// <param name="pagedParameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of <see cref="ITraktListItem" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given username or slug is null, empty or contains spaces.
        /// Thrown, if the given list id is null, empty or contains spaces.
        /// </exception>
        public Task<TraktPagedResponse<ITraktListItem>> GetCustomListItemsAsync(string usernameOrSlug, string listIdOrSlug,
                                                                                TraktListItemType listItemType = null, TraktExtendedInfo extendedInfo = null,
                                                                                TraktPagedParameters pagedParameters = null,
                                                                                CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new UserCustomListItemsRequest
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug,
                Type = listItemType,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            }, cancellationToken);
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
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktList" /> instance containing information about the successfully created custom list.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given username or slug is null, empty or contains spaces.
        /// Thrown, if the given list name is null or empty.
        /// </exception>
        public Task<TraktResponse<ITraktList>> CreateCustomListAsync(string usernameOrSlug, string listName,
                                                                     string listDescription = null, TraktAccessScope privacy = null,
                                                                     bool? displayNumbers = null, bool? allowComments = null,
                                                                     CancellationToken cancellationToken = default(CancellationToken))
        {
            if (listName == null)
                throw new ArgumentNullException(nameof(listName), "list name must not be null");

            if (listName.Length == 0)
                throw new ArgumentException("list name must not be empty", nameof(listName));

            var requestBody = new TraktUserCustomListPost
            {
                Name = listName,
                Description = listDescription,
                DisplayNumbers = displayNumbers,
                AllowComments = allowComments
            };

            if (privacy != null && privacy != TraktAccessScope.Unspecified)
                requestBody.Privacy = privacy;

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new UserCustomListAddRequest
            {
                Username = usernameOrSlug,
                RequestBody = requestBody
            }, cancellationToken);
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
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktList" /> instance containing information about the successfully updated custom list.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given username or slug is null, empty or contains spaces.
        /// Thrown, if the given list id is null, empty or contains spaces.
        /// Thrown, if the no new values are given (list name is null or empty and description is null and privacy is not set and
        /// display numbers is not set and comments allowed is not set).
        /// </exception>
        public Task<TraktResponse<ITraktList>> UpdateCustomListAsync(string usernameOrSlug, string listIdOrSlug,
                                                                     string listName = null, string listDescription = null,
                                                                     TraktAccessScope privacy = null,
                                                                     bool? displayNumbers = null, bool? allowComments = null,
                                                                     CancellationToken cancellationToken = default(CancellationToken))
        {
            bool isListNameNotValid = string.IsNullOrEmpty(listName);
            bool isDescriptionNotSet = listDescription == null;
            bool isPrivacyNotSetOrValid = privacy == null || privacy == TraktAccessScope.Unspecified;
            bool isDisplayNumbersNotSet = !displayNumbers.HasValue;
            bool isAllowCommentsNotSet = !allowComments.HasValue;

            if (isListNameNotValid && isDescriptionNotSet && isPrivacyNotSetOrValid && isDisplayNumbersNotSet && isAllowCommentsNotSet)
                throw new ArgumentException("no list specific values set");

            var requestBody = new TraktUserCustomListPost
            {
                Name = listName,
                Description = listDescription,
                DisplayNumbers = displayNumbers,
                AllowComments = allowComments
            };

            if (!isPrivacyNotSetOrValid)
                requestBody.Privacy = privacy;

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new UserCustomListUpdateRequest
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug,
                RequestBody = requestBody
            }, cancellationToken);
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
        /// <param name="cancellationToken"></param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given username or slug is null, empty or contains spaces.
        /// Thrown, if the given list id is null, empty or contains spaces.
        /// </exception>
        public Task<TraktNoContentResponse> DeleteCustomListAsync(string usernameOrSlug, string listIdOrSlug,
                                                                  CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new UserCustomListDeleteRequest
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug
            }, cancellationToken);
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
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktUserCustomListItemsPostResponse" /> instance, which contains information about which items were added, existing and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given list items post is null.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given username or slug is null, empty or contains spaces.
        /// Thrown, if the given list id is null, empty or contains spaces.
        /// Thrown, if the given list items post is empty.
        /// </exception>
        public Task<TraktResponse<ITraktUserCustomListItemsPostResponse>> AddCustomListItemsAsync(string usernameOrSlug, string listIdOrSlug,
                                                                                                  TraktUserCustomListItemsPost listItemsPost,
                                                                                                  TraktListItemType listItemType = null,
                                                                                                  CancellationToken cancellationToken = default(CancellationToken))
        {
            ValidateCustomListItemsPost(listItemsPost);

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new UserCustomListItemsAddRequest
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug,
                Type = listItemType,
                RequestBody = listItemsPost
            }, cancellationToken);
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
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktUserCustomListItemsPostResponse" /> instance, which contains information about which items were deleted and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the given list items remove post is null.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given username or slug is null, empty or contains spaces.
        /// Thrown, if the given list id is null, empty or contains spaces.
        /// Thrown, if the given list items remove post is empty.
        /// </exception>
        public Task<TraktResponse<ITraktUserCustomListItemsRemovePostResponse>> RemoveCustomListItemsAsync(string usernameOrSlug, string listIdOrSlug,
                                                                                                           TraktUserCustomListItemsPost listItemsRemovePost,
                                                                                                           CancellationToken cancellationToken = default(CancellationToken))
        {
            ValidateCustomListItemsPost(listItemsRemovePost);

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new UserCustomListItemsRemoveRequest
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug,
                RequestBody = listItemsRemovePost
            }, cancellationToken);
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
        /// <param name="pagedParameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktComment}"/> instance containing the queried custom list comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given username or slug is null, empty or contains spaces.
        /// Thrown, if the given list id is null, empty or contains spaces.
        /// </exception>
        public Task<TraktPagedResponse<ITraktComment>> GetListCommentsAsync(string usernameOrSlug, string listIdOrSlug,
                                                                            TraktCommentSortOrder commentSortOrder = null,
                                                                            TraktPagedParameters pagedParameters = null,
                                                                            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new UserListCommentsRequest
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug,
                SortOrder = commentSortOrder,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            }, cancellationToken);
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
        /// <param name="cancellationToken"></param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given username or slug is null, empty or contains spaces.
        /// Thrown, if the given list id is null, empty or contains spaces.
        /// </exception>
        public Task<TraktNoContentResponse> LikeListAsync(string usernameOrSlug, string listIdOrSlug,
                                                          CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new TraktUserListLikeRequest
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug
            }, cancellationToken);
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
        /// <param name="cancellationToken"></param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given username or slug is null, empty or contains spaces.
        /// Thrown, if the given list id is null, empty or contains spaces.
        /// </exception>
        public Task<TraktNoContentResponse> UnlikeListAsync(string usernameOrSlug, string listIdOrSlug,
                                                            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new TraktUserListUnlikeRequest
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug
            }, cancellationToken);
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
        /// <param name="cancellationToken"></param>
        /// <returns>A list of <see cref="ITraktUserFollower" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        public Task<TraktListResponse<ITraktUserFollower>> GetFollowersAsync(string usernameOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                             CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteListRequestAsync(new TraktUserFollowersRequest { Username = usernameOrSlug, ExtendedInfo = extendedInfo }, cancellationToken);
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
        /// <param name="cancellationToken"></param>
        /// <returns>A list of <see cref="ITraktUserFollower" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        public Task<TraktListResponse<ITraktUserFollower>> GetFollowingAsync(string usernameOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                             CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteListRequestAsync(new TraktUserFollowingRequest { Username = usernameOrSlug, ExtendedInfo = extendedInfo }, cancellationToken);
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
        /// <param name="cancellationToken"></param>
        /// <returns>A list of <see cref="ITraktUserFriend" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        public Task<TraktListResponse<ITraktUserFriend>> GetFriendsAsync(string usernameOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                         CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteListRequestAsync(new TraktUserFriendsRequest { Username = usernameOrSlug, ExtendedInfo = extendedInfo }, cancellationToken);
        }

        /// <summary>
        /// Sends a follow request for an user with the given username.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/follow/follow-this-user">"Trakt API Doc - Users: Follow"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, which should be followed.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// An <see cref="ITraktUserFollowUserPostResponse" /> instance containing information whether the request was successful.
        /// See <see cref="ITraktUserFollowUserPostResponse.ApprovedAt" />.
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        public Task<TraktResponse<ITraktUserFollowUserPostResponse>> FollowUserAsync(string usernameOrSlug,
                                                                                     CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteSingleItemRequestAsync(new TraktUserFollowUserRequest { Username = usernameOrSlug }, cancellationToken);
        }

        /// <summary>
        /// Sends an unfollow request for an user with the given username.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/follow/unfollow-this-user">"Trakt API Doc - Users: Follow"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, which should be unfollowed.</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        public Task<TraktNoContentResponse> UnfollowUserAsync(string usernameOrSlug, CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteNoContentRequestAsync(new TraktUserUnfollowUserRequest { Username = usernameOrSlug }, cancellationToken);
        }

        /// <summary>
        /// Approves a follower request with the given id.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/approve-or-deny-follower-requests/approve-follow-request">"Trakt API Doc - Users: Approve or Deny Follower Requests"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="followerRequestId">The id of the follower request, which should be approved.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktUserFollower" /> instance containing information about the approved user.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given follower request id is null, empty or contains spaces.</exception>
        public Task<TraktResponse<ITraktUserFollower>> ApproveFollowRequestAsync(uint followerRequestId, CancellationToken cancellationToken = default(CancellationToken))
        {
            ValidateFollowerRequestId(followerRequestId);
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteSingleItemRequestAsync(new UserApproveFollowerRequest { Id = followerRequestId.ToString() }, cancellationToken);
        }

        /// <summary>
        /// Denies a follower request with the given id.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/approve-or-deny-follower-requests/deny-follow-request">"Trakt API Doc - Users: Approve or Deny Follower Requests"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="followerRequestId">The id of the follower request, which should be denied.</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given follower request id is null, empty or contains spaces.</exception>
        public Task<TraktNoContentResponse> DenyFollowRequestAsync(uint followerRequestId, CancellationToken cancellationToken = default(CancellationToken))
        {
            ValidateFollowerRequestId(followerRequestId);
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteNoContentRequestAsync(new UserDenyFollowerRequest { Id = followerRequestId.ToString() }, cancellationToken);
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
        /// <param name="pagedParameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// A <see cref="TraktPagedResponse{ITraktHistoryItem}"/> instance containing the queried history items and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktHistoryItem" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        public Task<TraktPagedResponse<ITraktHistoryItem>> GetWatchedHistoryAsync(string usernameOrSlug, TraktSyncItemType historyItemType = null,
                                                                                  uint? itemId = null, DateTime? startAt = null,
                                                                                  DateTime? endAt = null, TraktExtendedInfo extendedInfo = null,
                                                                                  TraktPagedParameters pagedParameters = null,
                                                                                  CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new TraktUserWatchedHistoryRequest
            {
                Username = usernameOrSlug,
                Type = historyItemType,
                ItemId = itemId,
                StartAt = startAt,
                EndAt = endAt,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            }, cancellationToken);
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
        /// <param name="cancellationToken"></param>
        /// <returns>A list of <see cref="ITraktRatingsItem" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        public Task<TraktListResponse<ITraktRatingsItem>> GetRatingsAsync(string usernameOrSlug, TraktRatingsItemType ratingsItemType = null,
                                                                          int[] ratingsFilter = null, TraktExtendedInfo extendedInfo = null,
                                                                          CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new TraktUserRatingsRequest
            {
                Username = usernameOrSlug,
                Type = ratingsItemType,
                RatingFilter = ratingsFilter,
                ExtendedInfo = extendedInfo
            }, cancellationToken);
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
        /// <param name="pagedParameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktWatchlistItem}"/> instance containing the queried watchlist items and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktWatchlistItem" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        public Task<TraktPagedResponse<ITraktWatchlistItem>> GetWatchlistAsync(string usernameOrSlug, TraktSyncItemType watchlistItemType = null,
                                                                               TraktExtendedInfo extendedInfo = null,
                                                                               TraktPagedParameters pagedParameters = null,
                                                                               CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new TraktUserWatchlistRequest
            {
                Username = usernameOrSlug,
                Type = watchlistItemType,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            }, cancellationToken);
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
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktUserWatchingItem" /> instance containing the movie or episode an user is currently watching.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        public Task<TraktResponse<ITraktUserWatchingItem>> GetWatchingAsync(string usernameOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteSingleItemRequestAsync(new TraktUserWatchingRequest
            {
                Username = usernameOrSlug,
                ExtendedInfo = extendedInfo
            }, cancellationToken);
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
        /// <param name="cancellationToken"></param>
        /// <returns>A list of <see cref="ITraktWatchedMovie" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        public Task<TraktListResponse<ITraktWatchedMovie>> GetWatchedMoviesAsync(string usernameOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                                 CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteListRequestAsync(new TraktUserWatchedMoviesRequest
            {
                Username = usernameOrSlug,
                ExtendedInfo = extendedInfo
            }, cancellationToken);
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
        /// <param name="cancellationToken"></param>
        /// <returns>A list of <see cref="ITraktWatchedShow" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        public Task<TraktListResponse<ITraktWatchedShow>> GetWatchedShowsAsync(string usernameOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                               CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new TraktUserWatchedShowsRequest
            {
                Username = usernameOrSlug,
                ExtendedInfo = extendedInfo
            }, cancellationToken);
        }

        /// <summary>
        /// Gets statistics about the movies, shows and episodes an user has watched.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/stats/get-stats">"Trakt API Doc - Users: Stats"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the statistics should be queried.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktUserStatistics" /> instance coontaining statistics about movies, shows and episodes.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given username or slug is null, empty or contains spaces.</exception>
        public Task<TraktResponse<ITraktUserStatistics>> GetStatisticsAsync(string usernameOrSlug, CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteSingleItemRequestAsync(new TraktUserStatisticsRequest { Username = usernameOrSlug }, cancellationToken);
        }

        private void ValidateCustomListItemsPost(TraktUserCustomListItemsPost customListItemsPost)
        {
            if (customListItemsPost == null)
                throw new ArgumentNullException(nameof(customListItemsPost), "list items post must not be null");

            IEnumerable<TraktUserCustomListItemsPostMovie> movies = customListItemsPost.Movies;
            IEnumerable<TraktUserCustomListItemsPostShow> shows = customListItemsPost.Shows;
            IEnumerable<Objects.Get.People.Implementations.TraktPerson> people = customListItemsPost.People;

            bool bHasNoMovies = movies == null || !movies.Any();
            bool bHasNoShows = shows == null || !shows.Any();
            bool bHasNoPeople = people == null || !people.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoPeople)
                throw new ArgumentException("no items set");
        }

        private void ValidateFollowerRequestId(ulong followerRequestId)
        {
            if (followerRequestId == 0)
                throw new ArgumentOutOfRangeException(nameof(followerRequestId), "follower request id is not valid");
        }
    }
}
