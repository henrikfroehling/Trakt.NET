namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Lists;
    using Requests.Handler;
    using Requests.Users.OAuth;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktUsersModule : ATraktModule
    {
        /// <summary>
        /// Deletes an user's personal list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/list/delete-a-user's-personal-list">"Trakt API Doc - Users: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be deleted.</param>
        /// <param name="listIdOrSlug">The id or slug of the list, which should be deleted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktNoContentResponse> DeletePersonalListAsync(string usernameOrSlug, string listIdOrSlug,
                                                                    CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new UserPersonalListDeleteRequest
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Deletes an user's personal list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/list/delete-a-user's-personal-list">"Trakt API Doc - Users: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be deleted.</param>
        /// <param name="traktListId">The Trakt-ID of the list, which should be deleted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktNoContentResponse> DeletePersonalListAsync(string usernameOrSlug, uint traktListId,
                                                                    CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return DeletePersonalListAsync(usernameOrSlug, traktListId.ToString(), cancellationToken);
        }

        /// <summary>
        /// Deletes an user's personal list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/list/delete-a-user's-personal-list">"Trakt API Doc - Users: List"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be deleted.</param>
        /// <param name="listIds">The ids of the list, which should be deleted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktNoContentResponse> DeletePersonalListAsync(string usernameOrSlug, ITraktListIds listIds,
                                                                    CancellationToken cancellationToken = default)
        {
            if (listIds == null)
                throw new ArgumentNullException(nameof(listIds));

            if (!listIds.HasAnyId)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return DeletePersonalListAsync(usernameOrSlug, listIds.GetBestId(), cancellationToken);
        }
    }
}
