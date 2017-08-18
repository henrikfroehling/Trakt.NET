namespace TraktApiSharp.Modules
{
    using Exceptions;
    using Objects.Get.People;
    using Objects.Get.People.Credits;
    using Requests.Handler;
    using Requests.Parameters;
    using Requests.People;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to people.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/people">"Trakt API Doc - People"</a> section.
    /// </para>
    /// </summary>
    public class TraktPeopleModule : TraktBaseModule
    {
        internal TraktPeopleModule(TraktClient client) : base(client) { }

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
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktPerson" /> instance with the queried person's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given personIdOrSlug is null, empty or contains spaces.</exception>
        public async Task<TraktResponse<ITraktPerson>> GetPersonAsync(string personIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                      CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecuteSingleItemRequestAsync(new TraktPersonSummaryRequest
            {
                Id = personIdOrSlug,
                ExtendedInfo = extendedInfo
            }, cancellationToken);
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
        /// <param name="cancellationToken"></param>
        /// <returns>A list of <see cref="ITraktPerson" /> instances with the data of each queried person.</returns>
        /// <exception cref="TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if one of the given person ids is null, empty or contains spaces.</exception>
        public async Task<IEnumerable<TraktResponse<ITraktPerson>>> GetMultiplePersonsAsync(TraktMultipleObjectsQueryParams personsQueryParams,
                                                                                            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (personsQueryParams == null || personsQueryParams.Count <= 0)
                return new List<TraktResponse<ITraktPerson>>();

            var tasks = new List<Task<TraktResponse<ITraktPerson>>>();

            foreach (var queryParam in personsQueryParams)
            {
                Task<TraktResponse<ITraktPerson>> task = GetPersonAsync(queryParam.Id, queryParam.ExtendedInfo, cancellationToken);
                tasks.Add(task);
            }

            var people = await Task.WhenAll(tasks);
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
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktPersonMovieCredits" /> instance with the queried person's movie credits.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given personIdOrSlug is null, empty or contains spaces.</exception>
        public async Task<TraktResponse<ITraktPersonMovieCredits>> GetPersonMovieCreditsAsync(string personIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                                              CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecuteSingleItemRequestAsync(new TraktPersonMovieCreditsRequest
            {
                Id = personIdOrSlug,
                ExtendedInfo = extendedInfo
            }, cancellationToken);
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
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktPersonShowCredits" /> instance with the queried person's show credits.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given personIdOrSlug is null, empty or contains spaces.</exception>
        public async Task<TraktResponse<ITraktPersonShowCredits>> GetPersonShowCreditsAsync(string personIdOrSlug, TraktExtendedInfo extendedInfo = null,
                                                                                            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecuteSingleItemRequestAsync(new TraktPersonShowCreditsRequest
            {
                Id = personIdOrSlug,
                ExtendedInfo = extendedInfo
            }, cancellationToken);
        }
    }
}
