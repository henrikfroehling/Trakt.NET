namespace TraktApiSharp.Modules
{
    using Extensions;
    using Objects.Get.People;
    using Objects.Get.People.Credits;
    using Requests.Params;
    using Requests.WithoutOAuth.People;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        /// Gets a <see cref="TraktPerson" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/people/summary/get-a-single-person">"Trakt API Doc - People: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultiplePersonsAsync(TraktMultipleObjectsQueryParams)" />.</para>
        /// </summary>
        /// <param name="personId">The person's Trakt-Id or -Slug. See also <seealso cref="TraktPersonIds" />.</param>
        /// <param name="extendedOption">
        /// The extended option, which determines how much data about the person should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <returns>A <see cref="TraktPerson" /> instance with the queried person's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given personId is null, empty or contains spaces.</exception>
        public async Task<TraktPerson> GetPersonAsync(string personId, TraktExtendedOption extendedOption = null)
        {
            Validate(personId);

            return await QueryAsync(new TraktPersonSummaryRequest(Client)
            {
                Id = personId,
                ExtendedOption = extendedOption
            });
        }

        /// <summary>
        /// Gets multiple different <see cref="TraktPerson" />s at once with the given Trakt-Ids or -Slugs.
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/people/summary/get-a-single-person">"Trakt API Doc - People: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetPersonAsync(string, TraktExtendedOption)" />.</para>
        /// </summary>
        /// <param name="personsQueryParams">A list of person ids and optional extended options. See also <seealso cref="TraktMultipleObjectsQueryParams" />.</param>
        /// <returns>A list of <see cref="TraktPerson" /> instances with the data of each queried person.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if one of the given person ids is null, empty or contains spaces.</exception>
        public async Task<IEnumerable<TraktPerson>> GetMultiplePersonsAsync(TraktMultipleObjectsQueryParams personsQueryParams)
        {
            if (personsQueryParams == null || personsQueryParams.Count <= 0)
                return new List<TraktPerson>();

            var tasks = new List<Task<TraktPerson>>();

            foreach (var queryParam in personsQueryParams)
            {
                Task<TraktPerson> task = GetPersonAsync(queryParam.Id, queryParam.ExtendedOption);
                tasks.Add(task);
            }

            var people = await Task.WhenAll(tasks);
            return people.ToList();
        }

        /// <summary>
        /// Gets all movies where a person with the given Trakt-Id or -Slug is in the cast or crew.
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/people/summary/get-movie-credits">"Trakt API Doc - People: Movies"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="personId">The Trakt-Id or -Slug of the person, for which the movies should be queried.</param>
        /// <param name="extendedOption">
        /// The extended option, which determines how much data about the movies should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <returns>A <see cref="TraktPersonMovieCredits" /> instance with the queried person's movie credits.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given personId is null, empty or contains spaces.</exception>
        public async Task<TraktPersonMovieCredits> GetPersonMovieCreditsAsync(string personId, TraktExtendedOption extendedOption = null)
        {
            Validate(personId);

            return await QueryAsync(new TraktPersonMovieCreditsRequest(Client)
            {
                Id = personId,
                ExtendedOption = extendedOption
            });
        }

        /// <summary>
        /// Gets all shows where a person with the given Trakt-Id or -Slug is in the cast or crew.
        /// <para>OAuth authorization NOT required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/people/shows/get-show-credits">"Trakt API Doc - People: Shows"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="personId">The Trakt-Id or -Slug of the person, for which the shows should be queried.</param>
        /// <param name="extendedOption">
        /// The extended option, which determines how much data about the shows should be queried.
        /// See also <seealso cref="TraktExtendedOption" />.
        /// </param>
        /// <returns>A <see cref="TraktPersonShowCredits" /> instance with the queried person's show credits.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given personId is null, empty or contains spaces.</exception>
        public async Task<TraktPersonShowCredits> GetPersonShowCreditsAsync(string personId, TraktExtendedOption extendedOption = null)
        {
            Validate(personId);

            return await QueryAsync(new TraktPersonShowCreditsRequest(Client)
            {
                Id = personId,
                ExtendedOption = extendedOption
            });
        }

        private void Validate(string personId)
        {
            if (string.IsNullOrEmpty(personId) || personId.ContainsSpace())
                throw new ArgumentException("person id not valid", nameof(personId));
        }
    }
}
