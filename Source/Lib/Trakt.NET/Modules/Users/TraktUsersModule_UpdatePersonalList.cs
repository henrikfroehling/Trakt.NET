namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Lists;
    using Objects.Post.Users;
    using Requests.Handler;
    using Requests.Users.OAuth;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktUsersModule : ATraktModule
    {
        /// <summary>
        /// Updates an user's personal list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/list/update-personal-list">"Trakt API Doc - Users: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be updated.</param>
        /// <param name="listIdOrSlug">The id or slug of the personal list, which should be updated.</param>
        /// <param name="personalListPost">An <see cref="ITraktUserPersonalListPost" /> instance containing the data about the to be updated list.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktList" /> instance containing information about the successfully updated personal list.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktList>> UpdatePersonalListAsync(string usernameOrSlug, string listIdOrSlug,
                                                                       ITraktUserPersonalListPost personalListPost,
                                                                       CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new UserPersonalListUpdateRequest
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug,
                RequestBody = personalListPost
            },
            cancellationToken);
        }

        /// <summary>
        /// Updates an user's personal list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/list/update-personal-list">"Trakt API Doc - Users: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be updated.</param>
        /// <param name="traktListId">The Trakt-ID of the personal list, which should be updated.</param>
        /// <param name="personalListPost">An <see cref="ITraktUserPersonalListPost" /> instance containing the data about the to be updated list.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktList" /> instance containing information about the successfully updated personal list.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse<ITraktList>> UpdatePersonalListAsync(string usernameOrSlug, uint traktListId,
                                                                       ITraktUserPersonalListPost personalListPost,
                                                                       CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return UpdatePersonalListAsync(usernameOrSlug, traktListId.ToString(), personalListPost, cancellationToken);
        }

        /// <summary>
        /// Updates an user's personal list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/list/update-personal-list">"Trakt API Doc - Users: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be updated.</param>
        /// <param name="listIds">The ids of the personal list, which should be updated.</param>
        /// <param name="personalListPost">An <see cref="ITraktUserPersonalListPost" /> instance containing the data about the to be updated list.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktList" /> instance containing information about the successfully updated personal list.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse<ITraktList>> UpdatePersonalListAsync(string usernameOrSlug, ITraktListIds listIds,
                                                                       ITraktUserPersonalListPost personalListPost,
                                                                       CancellationToken cancellationToken = default)
        {
            if (listIds == null)
                throw new ArgumentNullException(nameof(listIds));

            if (!listIds.HasAnyId)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return UpdatePersonalListAsync(usernameOrSlug, listIds.GetBestId(), personalListPost, cancellationToken);
        }

        /// <summary>
        /// Updates an user's personal list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/list/update-personal-list">"Trakt API Doc - Users: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be updated.</param>
        /// <param name="list">The personal list, which should be updated.</param>
        /// <param name="personalListPost">An <see cref="ITraktUserPersonalListPost" /> instance containing the data about the to be updated list.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktList" /> instance containing information about the successfully updated personal list.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktResponse<ITraktList>> UpdatePersonalListAsync(string usernameOrSlug, ITraktList list,
                                                                       ITraktUserPersonalListPost personalListPost,
                                                                       CancellationToken cancellationToken = default)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            return UpdatePersonalListAsync(usernameOrSlug, list.Ids, personalListPost, cancellationToken);
        }
    }
}
