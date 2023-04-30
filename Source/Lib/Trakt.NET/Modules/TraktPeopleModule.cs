namespace TraktNet.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Get.Lists;
    using Objects.Get.People;
    using Objects.Get.People.Credits;
    using Requests.Handler;
    using Requests.People;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Parameters;

    /// <summary>
    /// Provides access to data retrieving methods specific to people.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/people">"Trakt API Doc - People"</a> section.
    /// </para>
    /// </summary>
    public class TraktPeopleModule : ATraktModule
    {
        internal TraktPeopleModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Gets a <see cref="ITraktPerson" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/people/summary/get-a-single-person">"Trakt API Doc - People: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultiplePersonsAsync(TraktMultipleObjectsQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="personIdOrSlug">The person's Trakt-Id or -Slug. See also <seealso cref="ITraktPersonIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the person should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktPerson" /> instance with the queried person's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktPerson>> GetPersonAsync(string personIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new PersonSummaryRequest
            {
                Id = personIdOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets multiple different <see cref="ITraktPerson" />s at once with the given Trakt-Ids or -Slugs.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/people/summary/get-a-single-person">"Trakt API Doc - People: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetPersonAsync(string, TraktExtendedInfo, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="personsQueryParams">A list of person ids and optional extended infos. See also <seealso cref="TraktMultipleObjectsQueryParams" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktPerson" /> instances with the data of each queried person.</returns>
        /// <exception cref="TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public async Task<IEnumerable<TraktResponse<ITraktPerson>>> GetMultiplePersonsAsync(TraktMultipleObjectsQueryParams personsQueryParams,
                                                                                            CancellationToken cancellationToken = default)
        {
            if (personsQueryParams == null || personsQueryParams.Count == 0)
                return new List<TraktResponse<ITraktPerson>>();

            var tasks = new List<Task<TraktResponse<ITraktPerson>>>();

            foreach (TraktObjectsQueryParams queryParam in personsQueryParams)
            {
                Task<TraktResponse<ITraktPerson>> task = GetPersonAsync(queryParam.Id, queryParam.ExtendedInfo, cancellationToken);
                tasks.Add(task);
            }

            TraktResponse<ITraktPerson>[] people = await Task.WhenAll(tasks).ConfigureAwait(false);
            return people.ToList();
        }

        /// <summary>
        /// Gets all movies where a person with the given Trakt-Id or -Slug is in the cast or crew.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/people/summary/get-movie-credits">"Trakt API Doc - People: Movies"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="personIdOrSlug">The Trakt-Id or -Slug of the person, for which the movies should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktPersonMovieCredits" /> instance with the queried person's movie credits.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktPersonMovieCredits>> GetPersonMovieCreditsAsync(string personIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                                        CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new PersonMovieCreditsRequest
            {
                Id = personIdOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets all shows where a person with the given Trakt-Id or -Slug is in the cast or crew.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/people/shows/get-show-credits">"Trakt API Doc - People: Shows"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="personIdOrSlug">The Trakt-Id or -Slug of the person, for which the shows should be queried.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktPersonShowCredits" /> instance with the queried person's show credits.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktPersonShowCredits>> GetPersonShowCreditsAsync(string personIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                                      CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new PersonShowCreditsRequest
            {
                Id = personIdOrSlug,
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

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
                                                                        TraktPagedParameters pagedParameters = null,
                                                                        CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new PersonListsRequest
            {
                Id = personIdOrSlug,
                Type = listType,
                SortOrder = listSortOrder,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
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
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new PeopleRecentlyUpdatedIdsRequest
            {
                StartDate = startDate,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
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
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new PeopleRecentlyUpdatedRequest
            {
                StartDate = startDate,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }
    }
}
