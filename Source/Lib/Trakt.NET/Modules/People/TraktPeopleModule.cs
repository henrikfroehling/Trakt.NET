namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.People;
    using Parameters;
    using Requests.Handler;
    using Requests.People;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to people.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/people">"Trakt API Doc - People"</a> section.
    /// </para>
    /// </summary>
    public partial class TraktPeopleModule : ATraktModule
    {
        internal TraktPeopleModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Gets recently updated people ids since the given <paramref name="startDate" />.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/people/updated-ids/get-recently-updated-people-trakt-ids">"Trakt API Doc - People: Updated Ids"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The start date, after which updated people ids should be queried. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ListItem}"/> instance containing the queried updated people ids and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<int>> GetRecentlyUpdatedPeopleIdsAsync(DateTime? startDate = null, TraktPagedParameters pagedParameters = null,
                                                                              CancellationToken cancellationToken = default)
        {
            var request = new PeopleRecentlyUpdatedIdsRequest
            {
                StartDate = startDate,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets updated people since the given <paramref name="startDate" />.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/people/updates/get-recently-updated-people">"Trakt API Doc - People: Updates"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="startDate">The start date, after which updated people should be queried. Will be converted to the Trakt UTC-datetime and -format.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the people should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktRecentlyUpdatedPerson}"/> instance containing the queried updated people and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktRecentlyUpdatedPerson" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktRecentlyUpdatedPerson>> GetRecentlyUpdatedPeopleAsync(DateTime? startDate = null,
                                                                                                   TraktExtendedInfo extendedInfo = null,
                                                                                                   TraktPagedParameters pagedParameters = null,
                                                                                                   CancellationToken cancellationToken = default)
        {
            var request = new PeopleRecentlyUpdatedRequest
            {
                StartDate = startDate,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        private Task<TraktResponse<ITraktPerson>> GetPersoInStreamAsync(string personIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                        CancellationToken cancellationToken = default)
            => GetPersoImplementationAsync(true, personIdOrSlug, extendedInfo, cancellationToken);

        private Task<TraktResponse<ITraktPerson>> GetPersoImplementationAsync(bool asyncStream, string personIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                              CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            var request = new PersonSummaryRequest
            {
                Id = personIdOrSlug,
                ExtendedInfo = extendedInfo
            };

            if (asyncStream)
                return requestHandler.ExecuteSingleItemStreamRequestAsync(request, cancellationToken);

            return requestHandler.ExecuteSingleItemRequestAsync(request, cancellationToken);
        }
    }
}
