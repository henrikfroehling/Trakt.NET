namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.Lists;
    using Objects.Post.Basic;
    using Requests.Handler;
    using Requests.Users.OAuth;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktUsersModule : ATraktModule
    {
        /// <summary>
        /// Update the notes on a single list item.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/update-list-item/update-a-list-item">"Trakt API Doc - Users: Update List Item"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list item should be updated.</param>
        /// <param name="listIdOrSlug">The id or slug of the list, for which the item should be updated.</param>
        /// <param name="listItemId">The id of the list item which should be updated.</param>
        /// <param name="notes">The new list item's notes value. Can be null to delete the content of the notes.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns></returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktNoContentResponse> UpdatePersonalListItemAsync(string usernameOrSlug, string listIdOrSlug,
                                                                        uint listItemId, string notes = null,
                                                                        CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new UserPersonalListItemUpdateRequest
            {
                Username = usernameOrSlug,
                Id = listIdOrSlug,
                ListItemId = listItemId,
                RequestBody = new TraktListItemUpdatePost
                {
                    Notes = notes
                }
            }, cancellationToken);
        }

        /// <summary>
        /// Update the notes on a single list item.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/update-list-item/update-a-list-item">"Trakt API Doc - Users: Update List Item"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list item should be updated.</param>
        /// <param name="traktListId">The Trakt-ID of the list, for which the item should be updated.</param>
        /// <param name="listItemId">The id of the list item which should be updated.</param>
        /// <param name="notes">The new list item's notes value. Can be null to delete the content of the notes.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns></returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktNoContentResponse> UpdatePersonalListItemAsync(string usernameOrSlug, uint traktListId,
                                                                        uint listItemId, string notes = null,
                                                                        CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return UpdatePersonalListItemAsync(usernameOrSlug, traktListId.ToString(), listItemId, notes, cancellationToken);
        }

        /// <summary>
        /// Update the notes on a single list item.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/update-list-item/update-a-list-item">"Trakt API Doc - Users: Update List Item"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list item should be updated.</param>
        /// <param name="listIds">The ids of the list, for which the item should be updated.</param>
        /// <param name="listItemId">The id of the list item which should be updated.</param>
        /// <param name="notes">The new list item's notes value. Can be null to delete the content of the notes.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns></returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktNoContentResponse> UpdatePersonalListItemAsync(string usernameOrSlug, ITraktListIds listIds,
                                                                        uint listItemId, string notes = null,
                                                                        CancellationToken cancellationToken = default)
        {
            if (listIds == null)
                throw new ArgumentNullException(nameof(listIds));

            if (!listIds.HasAnyId)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return UpdatePersonalListItemAsync(usernameOrSlug, listIds.GetBestId(), listItemId, notes, cancellationToken);
        }
    }
}
