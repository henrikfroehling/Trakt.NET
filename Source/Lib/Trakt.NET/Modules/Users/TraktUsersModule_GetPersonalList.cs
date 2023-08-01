namespace TraktNet.Modules
{
    using Exceptions;
    using Extensions;
    using Objects.Get.Lists;
    using Parameters;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktUsersModule : ATraktModule
    {
        /// <summary>
        /// Gets an user's single personal list.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/list/get-personal-list">"Trakt API Doc - Users: List"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultiplePersonalListsAsync(TraktMultipleUserListsQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be queried.</param>
        /// <param name="listIdOrSlug">The id or slug of the personal list, which should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>Anv <see cref="ITraktList" /> instance containing the personal list informations.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktList>> GetPersonalListAsync(string usernameOrSlug, string listIdOrSlug,
                                                                    CancellationToken cancellationToken = default)
            => GetPersonalListImplementationAsync(false, usernameOrSlug, listIdOrSlug, cancellationToken);

        /// <summary>
        /// Gets an user's single personal list.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/list/get-personal-list">"Trakt API Doc - Users: List"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultiplePersonalListsAsync(TraktMultipleUserListsQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be queried.</param>
        /// <param name="traktListId">The Trakt-ID of the personal list, which should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>Anv <see cref="ITraktList" /> instance containing the personal list informations.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktResponse<ITraktList>> GetPersonalListAsync(string usernameOrSlug, uint traktListId,
                                                                    CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return GetPersonalListImplementationAsync(false, usernameOrSlug, traktListId.ToString(), cancellationToken);
        }

        /// <summary>
        /// Gets an user's single personal list.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/list/get-personal-list">"Trakt API Doc - Users: List"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultiplePersonalListsAsync(TraktMultipleUserListsQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="usernameOrSlug">The username or slug of the user, for which the personal list should be queried.</param>
        /// <param name="listIds">The ids of the personal list, which should be queried.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>Anv <see cref="ITraktList" /> instance containing the personal list informations.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/> has not any ids set.</exception>
        public Task<TraktResponse<ITraktList>> GetPersonalListAsync(string usernameOrSlug, ITraktListIds listIds,
                                                                    CancellationToken cancellationToken = default)
        {
            if (listIds == null)
                throw new ArgumentNullException(nameof(listIds));

            if (!listIds.HasAnyId)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return GetPersonalListImplementationAsync(false, usernameOrSlug, listIds.GetBestId(), cancellationToken);
        }

        /// <summary>
        /// Gets multiple different personal lists for multiple different users at once.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/list/get-personal-list">"Trakt API Doc - Users: List"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetPersonalListAsync(string, string, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="userListsQueryParams">A list of usernames and list ids. See also <seealso cref="TraktMultipleUserListsQueryParams" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktList" /> instances with the data of each queried personal list.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        [Obsolete("GetMultiplePersonalListsAsync is deprecated, please use GetPersonalListsStreamAsync instead.")]
        public async Task<IEnumerable<TraktResponse<ITraktList>>> GetMultiplePersonalListsAsync(TraktMultipleUserListsQueryParams userListsQueryParams,
                                                                                                CancellationToken cancellationToken = default)
        {
            if (userListsQueryParams == null || userListsQueryParams.Count == 0)
                return new List<TraktResponse<ITraktList>>();

            var tasks = new List<Task<TraktResponse<ITraktList>>>();

            foreach (TraktUserListsQueryParams queryParam in userListsQueryParams)
            {
                Task<TraktResponse<ITraktList>> task = GetPersonalListAsync(queryParam.Username, queryParam.ListId, cancellationToken);
                tasks.Add(task);
            }

            TraktResponse<ITraktList>[] lists = await Task.WhenAll(tasks).ConfigureAwait(false);
            return lists.ToList();
        }

        /// <summary>
        /// Gets multiple different personal lists for multiple different users at once.
        /// <para>OAuth authorization optional.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/users/list/get-personal-list">"Trakt API Doc - Users: List"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetPersonalListAsync(string, string, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="userListsQueryParams">A list of usernames and list ids. See also <seealso cref="TraktMultipleUserListsQueryParams" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <a href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1?view=net-7.0">async stream</a> of <see cref="ITraktList" /> instances with the data of each queried personal list.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public async IAsyncEnumerable<TraktResponse<ITraktList>> GetPersonalListsStreamAsync(TraktMultipleUserListsQueryParams userListsQueryParams,
                                                                                             [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (userListsQueryParams == null || userListsQueryParams.Count == 0)
                yield break;

            var tasks = new List<Task<TraktResponse<ITraktList>>>();

            foreach (TraktUserListsQueryParams queryParam in userListsQueryParams)
            {
                Task<TraktResponse<ITraktList>> task = GetPersonalListInStreamAsync(queryParam.Username, queryParam.ListId, cancellationToken);
                tasks.Add(task);
            }

            await foreach (TraktResponse<ITraktList> result in tasks.StreamFinishedTaskResultsAsync())
            {
                yield return result;
            }
        }
    }
}
