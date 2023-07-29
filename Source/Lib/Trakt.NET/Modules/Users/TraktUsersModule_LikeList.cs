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
        /// Likes an user's list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/list-like/like-a-list">"Trakt API Doc - Users: List Like"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the list should be liked.</param>
        /// <param name="listIdOrSlug">The id or slug of the list, which should be liked.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktNoContentResponse> LikeListAsync(string usernameOrSlug, string listIdOrSlug,
                                                          CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new UserListLikeRequest
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Likes an user's list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/list-like/like-a-list">"Trakt API Doc - Users: List Like"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the list should be liked.</param>
        /// <param name="traktListId">The Trakt-ID of the list, which should be liked.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktNoContentResponse> LikeListAsync(string usernameOrSlug, uint traktListId,
                                                          CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return LikeListAsync(usernameOrSlug, traktListId.ToString(), cancellationToken);
        }

        /// <summary>
        /// Likes an user's list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/users/list-like/like-a-list">"Trakt API Doc - Users: List Like"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the list should be liked.</param>
        /// <param name="listIds">The ids of the list, which should be liked.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktNoContentResponse> LikeListAsync(string usernameOrSlug, ITraktListIds listIds,
                                                          CancellationToken cancellationToken = default)
        {
            if (listIds == null)
                throw new ArgumentNullException(nameof(listIds));

            if (!listIds.HasAnyId)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return LikeListAsync(usernameOrSlug, listIds.GetBestId(), cancellationToken);
        }
    }
}
