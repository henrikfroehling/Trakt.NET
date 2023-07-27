namespace TraktNet.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Get.Lists;
    using Objects.Get.People;
    using Parameters;
    using Requests.Handler;
    using Requests.People;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktPeopleModule : ATraktModule
    {
        /// <summary>
        /// Gets all <see cref="ITraktList" />s containing a <see cref="ITraktPerson" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/people/lists/get-lists-containing-this-person">"Trakt API Doc - People: Lists"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="personIdOrSlug">The person's Trakt-Id or -Slug. See also <seealso cref="ITraktPersonIds" />.</param>
        /// <param name="listType">The type of lists, that should be queried. Defaults to personal lists.</param>
        /// <param name="listSortOrder">The list sort order. See also <seealso cref="TraktListSortOrder" />. Defaults to sorted by popularity.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the list items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktList}"/> instance containing the queried person lists and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktList" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktList>> GetPersonListsAsync(string personIdOrSlug, TraktListType listType = null,
                                                                        TraktListSortOrder listSortOrder = null,
                                                                        TraktExtendedInfo extendedInfo = null,
                                                                        TraktPagedParameters pagedParameters = null,
                                                                        CancellationToken cancellationToken = default)
        {
            var request = new PersonListsRequest
            {
                Id = personIdOrSlug,
                Type = listType,
                SortOrder = listSortOrder,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets all <see cref="ITraktList" />s containing a <see cref="ITraktPerson" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/people/lists/get-lists-containing-this-person">"Trakt API Doc - People: Lists"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktPersonId">The person's Trakt-Id. See also <seealso cref="ITraktPersonIds" />.</param>
        /// <param name="listType">The type of lists, that should be queried. Defaults to personal lists.</param>
        /// <param name="listSortOrder">The list sort order. See also <seealso cref="TraktListSortOrder" />. Defaults to sorted by popularity.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the list items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktList}"/> instance containing the queried person lists and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktList" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktPersonId"/> is 0.</exception>
        public Task<TraktPagedResponse<ITraktList>> GetPersonListsAsync(uint traktPersonId, TraktListType listType = null,
                                                                        TraktListSortOrder listSortOrder = null,
                                                                        TraktExtendedInfo extendedInfo = null,
                                                                        TraktPagedParameters pagedParameters = null,
                                                                        CancellationToken cancellationToken = default)
        {
            if (traktPersonId == 0)
                throw new ArgumentException("person id must not be 0", nameof(traktPersonId));

            return GetPersonListsAsync(traktPersonId.ToString(), listType, listSortOrder, extendedInfo, pagedParameters, cancellationToken);
        }

        /// <summary>
        /// Gets all <see cref="ITraktList" />s containing a <see cref="ITraktPerson" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/people/lists/get-lists-containing-this-person">"Trakt API Doc - People: Lists"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="personIds">The person's ids. See also <seealso cref="ITraktPersonIds" />.</param>
        /// <param name="listType">The type of lists, that should be queried. Defaults to personal lists.</param>
        /// <param name="listSortOrder">The list sort order. See also <seealso cref="TraktListSortOrder" />. Defaults to sorted by popularity.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the list items should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktList}"/> instance containing the queried person lists and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktList" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="personIds"/> is null.</exception>
        public Task<TraktPagedResponse<ITraktList>> GetPersonListsAsync(ITraktPersonIds personIds, TraktListType listType = null,
                                                                        TraktListSortOrder listSortOrder = null,
                                                                        TraktExtendedInfo extendedInfo = null,
                                                                        TraktPagedParameters pagedParameters = null,
                                                                        CancellationToken cancellationToken = default)
        {
            if (personIds == null)
                throw new ArgumentNullException(nameof(personIds));

            return GetPersonListsAsync(personIds.GetBestId(), listType, listSortOrder, extendedInfo, pagedParameters, cancellationToken);
        }
    }
}
