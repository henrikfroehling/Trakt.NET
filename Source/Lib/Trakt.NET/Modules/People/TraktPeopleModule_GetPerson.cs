namespace TraktNet.Modules
{
    using Exceptions;
    using Extensions;
    using Objects.Get.People;
    using Parameters;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktPeopleModule : ATraktModule
    {
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
            => GetPersoImplementationAsync(false, personIdOrSlug, extendedInfo, cancellationToken);

        /// <summary>
        /// Gets a <see cref="ITraktPerson" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/people/summary/get-a-single-person">"Trakt API Doc - People: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultiplePersonsAsync(TraktMultipleObjectsQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="traktPersonId">The person's Trakt-Id. See also <seealso cref="ITraktPersonIds" />.</param>
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
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktPersonId"/> is 0.</exception>
        public Task<TraktResponse<ITraktPerson>> GetPersonAsync(uint traktPersonId, TraktExtendedInfo extendedInfo = null,
                                                                CancellationToken cancellationToken = default)
        {
            if (traktPersonId == 0)
                throw new ArgumentException("person id must not be 0", nameof(traktPersonId));

            return GetPersoImplementationAsync(false, traktPersonId.ToString(), extendedInfo, cancellationToken);
        }

        /// <summary>
        /// Gets a <see cref="ITraktPerson" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/people/summary/get-a-single-person">"Trakt API Doc - People: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultiplePersonsAsync(TraktMultipleObjectsQueryParams, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="personIds">The person's ids. See also <seealso cref="ITraktPersonIds" />.</param>
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
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="personIds"/> is null.</exception>
        public Task<TraktResponse<ITraktPerson>> GetPersonAsync(ITraktPersonIds personIds, TraktExtendedInfo extendedInfo = null,
                                                                CancellationToken cancellationToken = default)
        {
            if (personIds == null)
                throw new ArgumentNullException(nameof(personIds));

            if (!personIds.HasAnyId)
                throw new ArgumentException($"{nameof(personIds)} has not any ids set", nameof(personIds));

            return GetPersoImplementationAsync(false, personIds.GetBestId(), extendedInfo, cancellationToken);
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
        [Obsolete("GetMultiplePersonsAsync is deprecated, please use GetPersonsStreamAsync instead.")]
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
        /// <returns>An <a href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1?view=net-7.0">async stream</a> of <see cref="ITraktPerson" /> instances with the data of each queried person.</returns>
        /// <exception cref="TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public async IAsyncEnumerable<TraktResponse<ITraktPerson>> GetPersonsStreamAsync(TraktMultipleObjectsQueryParams personsQueryParams,
                                                                                         [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (personsQueryParams == null || personsQueryParams.Count == 0)
                yield break;

            var tasks = new List<Task<TraktResponse<ITraktPerson>>>();

            foreach (TraktObjectsQueryParams queryParam in personsQueryParams)
            {
                Task<TraktResponse<ITraktPerson>> task = GetPersoInStreamAsync(queryParam.Id, queryParam.ExtendedInfo, cancellationToken);
                tasks.Add(task);
            }

            await foreach (TraktResponse<ITraktPerson> result in tasks.StreamFinishedTaskResultsAsync())
            {
                yield return result;
            }
        }
    }
}
