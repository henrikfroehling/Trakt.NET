namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Lists;
    using Objects.Post.Users.PersonalListItems;
    using Objects.Post.Users.PersonalListItems.Responses;
    using Requests.Handler;
    using Requests.Users.OAuth;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktUsersModule : ATraktModule
    {
        /// <summary>
        /// Removes items from an user's personal list. Accepts shows, seasons, episodes, movies and people.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/remove-list-items/remove-items-from-personal-list">"Trakt API Doc - Users: Remove List Items"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktUserPersonalListItemsRemovePostBuilder" /> to create an instance
        /// of the required <see cref="ITraktUserPersonalListItemsRemovePost" />.
        /// See also <seealso cref="TraktPost.NewUserPersonalListItemsRemovePost()" />.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which items should be removed from a personal list.</param>
        /// <param name="listIdOrSlug">The id or slug of the personal list, from which items should be removed.</param>
        /// <param name="listItemsRemovePost">An <see cref="ITraktUserPersonalListItemsRemovePost" /> instance containing all shows, seasons, episodes, movies and people, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="TraktUserPersonalListItemsRemovePostResponse" /> instance, which contains information about which items were deleted and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktUserPersonalListItemsRemovePostResponse>> RemovePersonalListItemsAsync(string usernameOrSlug, string listIdOrSlug,
                                                                                                               ITraktUserPersonalListItemsRemovePost listItemsRemovePost,
                                                                                                               CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new UserPersonalListItemsRemoveRequest
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug,
                RequestBody = listItemsRemovePost
            },
            cancellationToken);
        }

        /// <summary>
        /// Removes items from an user's personal list. Accepts shows, seasons, episodes, movies and people.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/remove-list-items/remove-items-from-personal-list">"Trakt API Doc - Users: Remove List Items"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktUserPersonalListItemsRemovePostBuilder" /> to create an instance
        /// of the required <see cref="ITraktUserPersonalListItemsRemovePost" />.
        /// See also <seealso cref="TraktPost.NewUserPersonalListItemsRemovePost()" />.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which items should be removed from a personal list.</param>
        /// <param name="traktListId">The Trakt-ID of the personal list, from which items should be removed.</param>
        /// <param name="listItemsRemovePost">An <see cref="ITraktUserPersonalListItemsRemovePost" /> instance containing all shows, seasons, episodes, movies and people, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="TraktUserPersonalListItemsRemovePostResponse" /> instance, which contains information about which items were deleted and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse<ITraktUserPersonalListItemsRemovePostResponse>> RemovePersonalListItemsAsync(string usernameOrSlug, uint traktListId,
                                                                                                               ITraktUserPersonalListItemsRemovePost listItemsRemovePost,
                                                                                                               CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return RemovePersonalListItemsAsync(usernameOrSlug, traktListId.ToString(), listItemsRemovePost, cancellationToken);
        }

        /// <summary>
        /// Removes items from an user's personal list. Accepts shows, seasons, episodes, movies and people.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/remove-list-items/remove-items-from-personal-list">"Trakt API Doc - Users: Remove List Items"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktUserPersonalListItemsRemovePostBuilder" /> to create an instance
        /// of the required <see cref="ITraktUserPersonalListItemsRemovePost" />.
        /// See also <seealso cref="TraktPost.NewUserPersonalListItemsRemovePost()" />.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which items should be removed from a personal list.</param>
        /// <param name="listIds">The ids of the personal list, from which items should be removed.</param>
        /// <param name="listItemsRemovePost">An <see cref="ITraktUserPersonalListItemsRemovePost" /> instance containing all shows, seasons, episodes, movies and people, which should be removed.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="TraktUserPersonalListItemsRemovePostResponse" /> instance, which contains information about which items were deleted and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse<ITraktUserPersonalListItemsRemovePostResponse>> RemovePersonalListItemsAsync(string usernameOrSlug, ITraktListIds listIds,
                                                                                                               ITraktUserPersonalListItemsRemovePost listItemsRemovePost,
                                                                                                               CancellationToken cancellationToken = default)
        {
            if (listIds == null)
                throw new ArgumentNullException(nameof(listIds));

            if (!listIds.HasAnyId)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return RemovePersonalListItemsAsync(usernameOrSlug, listIds.GetBestId(), listItemsRemovePost, cancellationToken);
        }
    }
}
