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
        /// Like a list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/list-like/like-a-list">"Trakt API Doc - Lists: List Like"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="listIdOrSlug">The id or slug of the list, which will be liked.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktNoContentResponse> LikeListAsync(string listIdOrSlug, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new ListLikeRequest
            {
                Id = listIdOrSlug
            },
            cancellationToken);
        }

        /// <summary>
        /// Like a list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/list-like/like-a-list">"Trakt API Doc - Lists: List Like"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktListId">The Trakt ID of the list, which will be liked.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktNoContentResponse> LikeListAsync(uint traktListId, CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return LikeListAsync(traktListId.ToString(), cancellationToken);
        }

        /// <summary>
        /// Like a list.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/list-like/like-a-list">"Trakt API Doc - Lists: List Like"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="listIds">The ids of the list, which will be liked.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        public Task<TraktNoContentResponse> LikeListAsync(ITraktListIds listIds, CancellationToken cancellationToken = default)
        {
            if (listIds == null)
                throw new ArgumentNullException(nameof(listIds));

            return LikeListAsync(listIds.GetBestId(), cancellationToken);
        }
    }
}
