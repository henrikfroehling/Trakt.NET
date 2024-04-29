namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Lists;
    using Requests.Handler;
    using Requests.Lists;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktListsModule : ATraktModule
    {
        /// <summary>
        /// Unlike a list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/list-like/like-a-list">"Trakt API Doc - Lists: List Like"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="listIdOrSlug">The id or slug of the list, which will be unliked. See also <seealso cref="ITraktListIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktNoContentResponse> UnlikeListAsync(string listIdOrSlug, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new ListUnlikeRequest
            {
                Id = listIdOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Unlike a list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/list-like/like-a-list">"Trakt API Doc - Lists: List Like"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktListId">The Trakt ID of the list, which will be unliked. See also <seealso cref="ITraktListIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktNoContentResponse> UnlikeListAsync(uint traktListId, CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return UnlikeListAsync(traktListId.ToString(), cancellationToken);
        }

        /// <summary>
        /// Unlike a list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/list-like/like-a-list">"Trakt API Doc - Lists: List Like"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="listIds">The ids of the list, which will be unliked. See also <seealso cref="ITraktListIds" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktNoContentResponse> UnlikeListAsync(ITraktListIds listIds, CancellationToken cancellationToken = default)
        {
            if (listIds == null)
                throw new ArgumentNullException(nameof(listIds));

            if (!listIds.HasAnyId)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return UnlikeListAsync(listIds.GetBestId(), cancellationToken);
        }

        /// <summary>
        /// Unlike a list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/list-like/like-a-list">"Trakt API Doc - Lists: List Like"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="list">The list, which will be unliked. See also <seealso cref="ITraktList" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        public Task<TraktNoContentResponse> UnlikeListAsync(ITraktList list, CancellationToken cancellationToken = default)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            return UnlikeListAsync(list.Ids, cancellationToken);
        }
    }
}
