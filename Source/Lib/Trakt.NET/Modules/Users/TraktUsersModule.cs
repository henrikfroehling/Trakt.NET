namespace TraktNet.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Get.Collections;
    using Objects.Get.History;
    using Objects.Get.Lists;
    using Objects.Get.Ratings;
    using Objects.Get.Users;
    using Objects.Get.Users.Notes;
    using Objects.Get.Users.Statistics;
    using Objects.Get.Watched;
    using Objects.Get.Watchlist;
    using Objects.Post.Basic;
    using Objects.Post.Basic.Responses;
    using Objects.Post.Users;
    using Objects.Post.Users.HiddenItems;
    using Objects.Post.Users.HiddenItems.Responses;
    using Objects.Post.Users.Responses;
    using Parameters;
    using PostBuilder;
    using Requests.Handler;
    using Requests.Users.OAuth;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to users.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/users">"Trakt API Doc - Users"</a> section.
    /// </para>
    /// </summary>
    public partial class TraktUsersModule : ATraktModule
    {
        internal TraktUsersModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Gets the user's settings.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/settings/retrieve-settings">"Trakt API Doc - Users: Settings"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktUserSettings" /> instance containing the user's settings.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktResponse<ITraktUserSettings>> GetSettingsAsync(CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);
            return requestHandler.ExecuteSingleItemRequestAsync(new UserSettingsRequest(), cancellationToken);
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktUserFollowRequest" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktListResponse<ITraktUserFollowRequest>> GetFollowRequestsAsync(TraktExtendedInfo extendedInfo = null,
                                                                                       CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new UserFollowRequestsRequest
            {
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the user's pending following requests.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/following-requests/get-pending-following-requests">"Trakt API Doc - Users: Following Requests"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the following request users should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktUserFollowRequest" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktListResponse<ITraktUserFollowRequest>> GetPendingFollowingRequestsAsync(TraktExtendedInfo extendedInfo = null,
                                                                                                 CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new UserPendingFollowingRequestsRequest
            {
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
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
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktUserHiddenItem}"/> instance containing the queried hidden items and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktUserHiddenItem" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktUserHiddenItem>> GetHiddenItemsAsync(TraktHiddenItemsSection hiddenItemsSection,
                                                                                  TraktHiddenItemType hiddenItemType = null,
                                                                                  TraktExtendedInfo extendedInfo = null,
                                                                                  TraktPagedParameters pagedParameters = null,
                                                                                  CancellationToken cancellationToken = default)
        {
            var request = new UserHiddenItemsRequest
            {
                Section = hiddenItemsSection,
                Type = hiddenItemType,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets the saved filters a user has created.
        /// <para>OAuth authorization required.</para>
        /// <para>VIP Only.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/saved-filters/get-saved-filters">"Trakt API Doc - Users: Saved Filters"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="section">Determines, from which section the saved filters should be queried. See also <seealso cref="TraktFilterSection" />.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktUserSavedFilter}"/> instance containing the queried saved filters and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktUserSavedFilter" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktUserSavedFilter>> GetSavedFiltersAsync(TraktFilterSection section = null,
                                                                                    TraktPagedParameters pagedParameters = null,
                                                                                    CancellationToken cancellationToken = default)
        {
            var request = new UserSavedFiltersRequest
            {
                Section = section,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Adds items to an user's hidden list. Accepts shows, seasons and movies.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/add-hidden-items/add-hidden-items">"Trakt API Doc - Users: Add Hidden Items"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktUserHiddenItemsPostBuilder" /> to create an instance
        /// of the required <see cref="ITraktUserHiddenItemsPost" />.
        /// See also <seealso cref="TraktPost.NewUserHiddenItemsPost()" />.
        /// </para>
        /// </summary>
        /// <param name="hiddenItemsPost">An <see cref="ITraktUserHiddenItemsPost" /> instance containing all shows, seasons and movies, which should be added.</param>
        /// <param name="hiddenItemsSection">Determines, which type of hidden items section should be queried. <see cref="TraktHiddenItemsSection "/></param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktUserHiddenItemsPostResponse" /> instance, which contains information about which items were added and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktUserHiddenItemsPostResponse>> AddHiddenItemsAsync(ITraktUserHiddenItemsPost hiddenItemsPost,
                                                                                          TraktHiddenItemsSection hiddenItemsSection,
                                                                                          CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new UserHiddenItemsAddRequest
            {
                RequestBody = hiddenItemsPost,
                Section = hiddenItemsSection
            },
            cancellationToken);
        }

        /// <summary>
        /// Removes items from an user's hidden list. Accepts shows, seasons and movies.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/remove-hidden-items/remove-hidden-items">"Trakt API Doc - Users: Remove Hidden Items"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktUserHiddenItemsRemovePostBuilder" /> to create an instance
        /// of the required <see cref="ITraktUserHiddenItemsRemovePost" />.
        /// See also <seealso cref="TraktPost.NewUserHiddenItemsRemovePost()" />.
        /// </para>
        /// </summary>
        /// <param name="hiddenItemsRemovePost">An <see cref="ITraktUserHiddenItemsRemovePost" /> instance containing all shows, seasons and movies, which should be removed.</param>
        /// <param name="hiddenItemsSection">Determines, which type of hidden items section should be queried. <see cref="TraktHiddenItemsSection "/></param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktUserHiddenItemsRemovePostResponse" /> instance, which contains information about which items were deleted and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktUserHiddenItemsRemovePostResponse>> RemoveHiddenItemsAsync(ITraktUserHiddenItemsRemovePost hiddenItemsRemovePost,
                                                                                                   TraktHiddenItemsSection hiddenItemsSection,
                                                                                                   CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new UserHiddenItemsRemoveRequest
            {
                RequestBody = hiddenItemsRemovePost,
                Section = hiddenItemsSection
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the items (movies, shows, seasons, episodes, persons, comments, lists) the user likes.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/likes/get-likes">"Trakt API Doc - Users: Likes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the likes should be queried.</param>
        /// <param name="likeType">Determines, which type of objects liked should be queried. See also <seealso cref="TraktUserLikeType" />.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktUserLikeItem}"/> instance containing the queried like items and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktUserLikeItem" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktUserLikeItem>> GetLikesAsync(string usernameOrSlug, TraktUserLikeType likeType = null,
                                                                          TraktPagedParameters pagedParameters = null,
                                                                          CancellationToken cancellationToken = default)
        {
            var request = new UserLikesRequest
            {
                Username = usernameOrSlug,
                Type = likeType,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktUser" /> instance containing the user's profile information.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktUser>> GetUserProfileAsync(string usernameOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                   CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new UserProfileRequest
            {
                Username = usernameOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktCollectionMovie" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktCollectionMovie>> GetCollectionMoviesAsync(string usernameOrSlug,
                                                                                       TraktExtendedInfo extendedInfo = null,
                                                                                       CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new UserCollectionMoviesRequest
            {
                Username = usernameOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktCollectionShow" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktCollectionShow>> GetCollectionShowsAsync(string usernameOrSlug,
                                                                                     TraktExtendedInfo extendedInfo = null,
                                                                                     CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new UserCollectionShowsRequest
            {
                Username = usernameOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
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
        /// <param name="includeReplies">Determines, whether replies should be retrieved alongside with comments.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the commented objects should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktUserComment}"/> instance containing the queried comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktUserComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktUserComment>> GetCommentsAsync(string usernameOrSlug,
                                                                            TraktCommentType commentType = null,
                                                                            TraktObjectType objectType = null,
                                                                            TraktIncludeReplies? includeReplies = null,
                                                                            TraktExtendedInfo extendedInfo = null,
                                                                            TraktPagedParameters pagedParameters = null,
                                                                            CancellationToken cancellationToken = default)
        {
            var request = new UserCommentsRequest
            {
                Username = usernameOrSlug,
                CommentType = commentType,
                ObjectType = objectType,
                IncludeReplies = includeReplies,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets an user's personal lists.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/lists/get-a-user's-personal-lists">"Trakt API Doc - Users: Lists"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal lists should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktList" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktList>> GetPersonalListsAsync(string usernameOrSlug, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new UserPersonalListsRequest
            {
                Username = usernameOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Creates a new personal list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/lists/create-personal-list">"Trakt API Doc - Users: Lists"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be created.</param>
        /// <param name="personalListPost">An <see cref="ITraktUserPersonalListPost" /> instance containing the data about the to be created list.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktList" /> instance containing information about the successfully created personal list.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktList>> CreatePersonalListAsync(string usernameOrSlug, ITraktUserPersonalListPost personalListPost,
                                                                       CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new UserPersonalListAddRequest
            {
                Username = usernameOrSlug,
                RequestBody = personalListPost
            },
            cancellationToken);
        }

        /// <summary>
        /// Reorders an user's personal lists.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/reorder-lists/reorder-a-user's-lists">"Trakt API Doc - Users: Reorder Lists"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal lists should be reordered.</param>
        /// <param name="reorderedListsRank">A collection of list ids. Represents the new order of an user's personal lists.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktListItemsReorderPostResponse" /> instance containing information about the successfully updated personal lists order.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktListItemsReorderPostResponse>> ReorderPersonalListsAsync(string usernameOrSlug, IList<uint> reorderedListsRank,
                                                                                                 CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new UserPersonalListsReorderRequest
            {
                Username = usernameOrSlug,
                RequestBody = new TraktListItemsReorderPost
                {
                    Rank = reorderedListsRank
                }
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all lists a user can collaborate on.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/collaborations/get-all-lists-a-user-can-collaborate-on">"Trakt API Doc - Users: Collaborations"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which lists on which the user can collaborate on should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktList" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktList>> GetListCollaborationsAsync(string usernameOrSlug, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new UserListCollaborationsRequest
            {
                Username = usernameOrSlug
            },
            cancellationToken);
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktUserFollower" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktUserFollower>> GetFollowersAsync(string usernameOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                             CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new UserFollowersRequest
            {
                Username = usernameOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktUserFollower" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktUserFollower>> GetFollowingAsync(string usernameOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                             CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new UserFollowingRequest
            {
                Username = usernameOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktUserFriend" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktUserFriend>> GetFriendsAsync(string usernameOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                         CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new UserFriendsRequest
            {
                Username = usernameOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        /// <summary>
        /// Sends a follow request for an user with the given username.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/follow/follow-this-user">"Trakt API Doc - Users: Follow"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, which should be followed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="ITraktUserFollowUserPostResponse" /> instance containing information whether the request was successful.
        /// See <see cref="ITraktUserFollowUserPostResponse.ApprovedAt" />.
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktUserFollowUserPostResponse>> FollowUserAsync(string usernameOrSlug,
                                                                                     CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new UserFollowUserRequest
            {
                Username = usernameOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Sends an unfollow request for an user with the given username.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/follow/unfollow-this-user">"Trakt API Doc - Users: Follow"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, which should be unfollowed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktNoContentResponse> UnfollowUserAsync(string usernameOrSlug, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new UserUnfollowUserRequest
            {
                Username = usernameOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Approves a follower request with the given id.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/approve-or-deny-follower-requests/approve-follow-request">"Trakt API Doc - Users: Approve or Deny Follower Requests"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="followerRequestId">The id of the follower request, which should be approved.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktUserFollower" /> instance containing information about the approved user.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktUserFollower>> ApproveFollowRequestAsync(uint followerRequestId, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new UserApproveFollowerRequest
            {
                Id = followerRequestId.ToString()
            },
            cancellationToken);
        }

        /// <summary>
        /// Denies a follower request with the given id.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/approve-or-deny-follower-requests/deny-follow-request">"Trakt API Doc - Users: Approve or Deny Follower Requests"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="followerRequestId">The id of the follower request, which should be denied.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktNoContentResponse> DenyFollowRequestAsync(uint followerRequestId, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new UserDenyFollowerRequest
            {
                Id = followerRequestId.ToString()
            },
            cancellationToken);
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
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// A <see cref="TraktPagedResponse{ITraktHistoryItem}"/> instance containing the queried history items and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktHistoryItem" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktHistoryItem>> GetWatchedHistoryAsync(string usernameOrSlug, TraktSyncItemType historyItemType = null,
                                                                                  uint? itemId = null, DateTime? startAt = null,
                                                                                  DateTime? endAt = null, TraktExtendedInfo extendedInfo = null,
                                                                                  TraktPagedParameters pagedParameters = null,
                                                                                  CancellationToken cancellationToken = default)
        {
            var request = new UserWatchedHistoryRequest
            {
                Username = usernameOrSlug,
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
        /// Gets an user's favorite movies and / or shows.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/favorites/get-favorites">"Trakt API Doc - Users: Favorites"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the favorites should be queried.</param>
        /// <param name="favoriteObjectType">Determines, which type of favorites items should be queried. See also <seealso cref="TraktFavoriteObjectType" />.</param>
        /// <param name="sortOrder">
        /// The favorites sort order. See also <seealso cref="TraktWatchlistSortOrder" />.
        /// Will be ignored, if the given array contains a number higher than 10 or below 1 or if it contains more than ten numbers.
        /// Will be ignored, if the given <paramref name="favoriteObjectType" /> is null or unspecified.
        /// </param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the favorited items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktFavorite" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktFavorite>> GetFavoritesAsync(string usernameOrSlug, TraktFavoriteObjectType favoriteObjectType = null,
                                                                          TraktWatchlistSortOrder sortOrder = null, TraktExtendedInfo extendedInfo = null,
                                                                          TraktPagedParameters pagedParameters = null, CancellationToken cancellationToken = default)
        {
            var request = new UserFavoritesRequest
            {
                Username = usernameOrSlug,
                Type = favoriteObjectType,
                Sort = sortOrder,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
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
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktRatingsItem" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktRatingsItem>> GetRatingsAsync(string usernameOrSlug, TraktRatingsItemType ratingsItemType = null,
                                                                           int[] ratingsFilter = null, TraktExtendedInfo extendedInfo = null,
                                                                           TraktPagedParameters pagedParameters = null,
                                                                           CancellationToken cancellationToken = default)
        {
            var request = new UserRatingsRequest
            {
                Username = usernameOrSlug,
                Type = ratingsItemType,
                RatingFilter = ratingsFilter,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
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
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktWatchlistItem>> GetWatchlistAsync(string usernameOrSlug, TraktSyncItemType watchlistItemType = null,
                                                                               TraktWatchlistSortOrder sortOrder = null,
                                                                               TraktExtendedInfo extendedInfo = null,
                                                                               TraktPagedParameters pagedParameters = null,
                                                                               CancellationToken cancellationToken = default)
        {
            var request = new UserWatchlistRequest
            {
                Username = usernameOrSlug,
                Type = watchlistItemType,
                Sort = sortOrder,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktUserWatchingItem" /> instance containing the movie or episode an user is currently watching.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktUserWatchingItem>> GetWatchingAsync(string usernameOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                            CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new UserWatchingRequest
            {
                Username = usernameOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktWatchedMovie" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktWatchedMovie>> GetWatchedMoviesAsync(string usernameOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                                 CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new UserWatchedMoviesRequest
            {
                Username = usernameOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktWatchedShow" /> instances.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktListResponse<ITraktWatchedShow>> GetWatchedShowsAsync(string usernameOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                               CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteListRequestAsync(new UserWatchedShowsRequest
            {
                Username = usernameOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets statistics about the movies, shows and episodes an user has watched.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/stats/get-stats">"Trakt API Doc - Users: Stats"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the statistics should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktUserStatistics" /> instance coontaining statistics about movies, shows and episodes.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktUserStatistics>> GetStatisticsAsync(string usernameOrSlug, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new UserStatisticsRequest
            {
                Username = usernameOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the most recently notes for a user.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/notes/get-notes">"Trakt API Doc - Users: Notes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the notes should be queried.</param>
        /// <param name="notesObjectType">Determines, which type of notes should be queried. See also <seealso cref="TraktNotesObjectType" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the notes media items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktUserNoteItem}"/> instance containing the notes items and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktUserNoteItem" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktUserNoteItem>> GetUserNotesAsync(string usernameOrSlug, TraktNotesObjectType notesObjectType = null,
                                                                              TraktExtendedInfo extendedInfo = null, TraktPagedParameters pagedParameters = null,
                                                                              CancellationToken cancellationToken = default)
        {
            var request = new UserNotesRequest
            {
                Username = usernameOrSlug,
                Type = notesObjectType,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        private Task<TraktResponse<ITraktList>> GetPersonalListInStreamAsync(string usernameOrSlug, string listIdOrSlug,
                                                                             CancellationToken cancellationToken = default)
            => GetPersonalListImplementationAsync(true, usernameOrSlug, listIdOrSlug, cancellationToken);

        private Task<TraktResponse<ITraktList>> GetPersonalListImplementationAsync(bool asyncStream, string usernameOrSlug, string listIdOrSlug,
                                                                                   CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            var request = new UserPersonalSingleListRequest
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug
            };

            if (asyncStream)
                return requestHandler.ExecuteSingleItemStreamRequestAsync(request, cancellationToken);

            return requestHandler.ExecuteSingleItemRequestAsync(request, cancellationToken);
        }
    }
}
