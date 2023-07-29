namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Lists;
    using Objects.Post.Basic;
    using Objects.Post.Basic.Responses;
    using Requests.Handler;
    using Requests.Users.OAuth;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktUsersModule : ATraktModule
    {
        /// <summary>
        /// Reorders an user's personal list items.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/reorder-list-items/reorder-items-on-a-list">"Trakt API Doc - Users: Reorder List Items"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list items should be reordered.</param>
        /// <param name="listIdOrSlug">The id or slug of the list, for which the items should be reordered.</param>
        /// <param name="reorderedListItemsRank">A collection of list item ids. Represents the new order of an user's personal list items.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktListItemsReorderPostResponse" /> instance containing information about the successfully updated personal list items order.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktListItemsReorderPostResponse>> ReorderPersonalListItemsAsync(string usernameOrSlug, string listIdOrSlug,
                                                                                                     IList<uint> reorderedListItemsRank,
                                                                                                     CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new UserPersonalListItemsReorderRequest
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug,
                RequestBody = new TraktListItemsReorderPost
                {
                    Rank = reorderedListItemsRank
                }
            },
            cancellationToken);
        }

        /// <summary>
        /// Reorders an user's personal list items.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/reorder-list-items/reorder-items-on-a-list">"Trakt API Doc - Users: Reorder List Items"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list items should be reordered.</param>
        /// <param name="traktListId">The Trakt-ID of the list, for which the items should be reordered.</param>
        /// <param name="reorderedListItemsRank">A collection of list item ids. Represents the new order of an user's personal list items.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktListItemsReorderPostResponse" /> instance containing information about the successfully updated personal list items order.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse<ITraktListItemsReorderPostResponse>> ReorderPersonalListItemsAsync(string usernameOrSlug, uint traktListId,
                                                                                                     IList<uint> reorderedListItemsRank,
                                                                                                     CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return ReorderPersonalListItemsAsync(usernameOrSlug, traktListId.ToString(), reorderedListItemsRank, cancellationToken);
        }

        /// <summary>
        /// Reorders an user's personal list items.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/reorder-list-items/reorder-items-on-a-list">"Trakt API Doc - Users: Reorder List Items"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list items should be reordered.</param>
        /// <param name="listIds">The ids of the list, for which the items should be reordered.</param>
        /// <param name="reorderedListItemsRank">A collection of list item ids. Represents the new order of an user's personal list items.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktListItemsReorderPostResponse" /> instance containing information about the successfully updated personal list items order.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse<ITraktListItemsReorderPostResponse>> ReorderPersonalListItemsAsync(string usernameOrSlug, ITraktListIds listIds,
                                                                                                     IList<uint> reorderedListItemsRank,
                                                                                                     CancellationToken cancellationToken = default)
        {
            if (listIds == null)
                throw new ArgumentNullException(nameof(listIds));

            if (!listIds.HasAnyId)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return ReorderPersonalListItemsAsync(usernameOrSlug, listIds.GetBestId(), reorderedListItemsRank, cancellationToken);
        }
    }
}
