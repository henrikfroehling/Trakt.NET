namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Lists;
    using Objects.Post.Users.PersonalListItems;
    using Objects.Post.Users.PersonalListItems.Responses;
    using PostBuilder;
    using Requests.Handler;
    using Requests.Users.OAuth;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktUsersModule : ATraktModule
    {
        /// <summary>
        /// Adds items to an user's personal list. Accepts shows, seasons, episodes, movies and people.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/add-list-items/add-items-to-personal-list">"Trakt API Doc - Users: List Items"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktUserPersonalListItemsPostBuilder" /> to create an instance
        /// of the required <see cref="ITraktUserPersonalListItemsPost" />.
        /// See also <seealso cref="TraktPost.NewUserPersonalListItemsPost()" />.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which items should be added to a personal list.</param>
        /// <param name="listIdOrSlug">The id or slug of the personal list, to which items should be added.</param>
        /// <param name="listItemsPost">An <see cref="ITraktUserPersonalListItemsPost" /> instance containing all shows, seasons, episodes, movies and people, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktUserPersonalListItemsPostResponse" /> instance, which contains information about which items were added, existing and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktUserPersonalListItemsPostResponse>> AddPersonalListItemsAsync(string usernameOrSlug, string listIdOrSlug,
                                                                                                      ITraktUserPersonalListItemsPost listItemsPost,
                                                                                                      CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new UserPersonalListItemsAddRequest
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug,
                RequestBody = listItemsPost
            },
            cancellationToken);
        }

        /// <summary>
        /// Adds items to an user's personal list. Accepts shows, seasons, episodes, movies and people.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/add-list-items/add-items-to-personal-list">"Trakt API Doc - Users: List Items"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktUserPersonalListItemsPostBuilder" /> to create an instance
        /// of the required <see cref="ITraktUserPersonalListItemsPost" />.
        /// See also <seealso cref="TraktPost.NewUserPersonalListItemsPost()" />.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which items should be added to a personal list.</param>
        /// <param name="traktListId">The Trakt-ID of the personal list, to which items should be added.</param>
        /// <param name="listItemsPost">An <see cref="ITraktUserPersonalListItemsPost" /> instance containing all shows, seasons, episodes, movies and people, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktUserPersonalListItemsPostResponse" /> instance, which contains information about which items were added, existing and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse<ITraktUserPersonalListItemsPostResponse>> AddPersonalListItemsAsync(string usernameOrSlug, uint traktListId,
                                                                                                      ITraktUserPersonalListItemsPost listItemsPost,
                                                                                                      CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return AddPersonalListItemsAsync(usernameOrSlug, traktListId.ToString(), listItemsPost, cancellationToken);
        }

        /// <summary>
        /// Adds items to an user's personal list. Accepts shows, seasons, episodes, movies and people.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/add-list-items/add-items-to-personal-list">"Trakt API Doc - Users: List Items"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktUserPersonalListItemsPostBuilder" /> to create an instance
        /// of the required <see cref="ITraktUserPersonalListItemsPost" />.
        /// See also <seealso cref="TraktPost.NewUserPersonalListItemsPost()" />.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which items should be added to a personal list.</param>
        /// <param name="listIds">The ids of the personal list, to which items should be added.</param>
        /// <param name="listItemsPost">An <see cref="ITraktUserPersonalListItemsPost" /> instance containing all shows, seasons, episodes, movies and people, which should be added.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktUserPersonalListItemsPostResponse" /> instance, which contains information about which items were added, existing and not found.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse<ITraktUserPersonalListItemsPostResponse>> AddPersonalListItemsAsync(string usernameOrSlug, ITraktListIds listIds,
                                                                                                      ITraktUserPersonalListItemsPost listItemsPost,
                                                                                                      CancellationToken cancellationToken = default)
        {
            if (listIds == null)
                throw new ArgumentNullException(nameof(listIds));

            if (!listIds.HasAnyId)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return AddPersonalListItemsAsync(usernameOrSlug, listIds.GetBestId(), listItemsPost, cancellationToken);
        }
    }
}
