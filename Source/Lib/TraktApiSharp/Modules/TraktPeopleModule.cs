namespace TraktApiSharp.Modules
{
    using Attributes;
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
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/people/summary/get-a-single-person">"Trakt API Doc - People: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMultiplePersonsAsync(TraktMultipleObjectsQueryParams)" />.</para>
        /// </summary>
        /// <param name="personIdOrSlug">The person's Trakt-Id or -Slug. See also <seealso cref="TraktPersonIds" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the person should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <returns>An <see cref="TraktPerson" /> instance with the queried person's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given personIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPerson> GetPersonAsync([NotNull] string personIdOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            Validate(personIdOrSlug);

            return await QueryAsync(new TraktPersonSummaryRequest(Client)
            {
                Id = personIdOrSlug,
                ExtendedInfo = extendedInfo
            });
        }

        /// <summary>
        /// Gets multiple different <see cref="TraktPerson" />s at once with the given Trakt-Ids or -Slugs.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/people/summary/get-a-single-person">"Trakt API Doc - People: Summary"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetPersonAsync(string, TraktExtendedInfo)" />.</para>
        /// </summary>
        /// <param name="personsQueryParams">A list of person ids and optional extended infos. See also <seealso cref="TraktMultipleObjectsQueryParams" />.</param>
        /// <returns>A list of <see cref="TraktPerson" /> instances with the data of each queried person.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if one of the given person ids is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktPerson>> GetMultiplePersonsAsync(TraktMultipleObjectsQueryParams personsQueryParams)
        {
            if (personsQueryParams == null || personsQueryParams.Count <= 0)
                return new List<TraktPerson>();

            var tasks = new List<Task<TraktPerson>>();

            foreach (var queryParam in personsQueryParams)
            {
                Task<TraktPerson> task = GetPersonAsync(queryParam.Id, queryParam.ExtendedInfo);
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
        /// <returns>An <see cref="TraktPersonMovieCredits" /> instance with the queried person's movie credits.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given personIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPersonMovieCredits> GetPersonMovieCreditsAsync([NotNull] string personIdOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            Validate(personIdOrSlug);

            return await QueryAsync(new TraktPersonMovieCreditsRequest(Client)
            {
                Id = personIdOrSlug,
                ExtendedInfo = extendedInfo
            });
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
        /// <returns>An <see cref="TraktPersonShowCredits" /> instance with the queried person's show credits.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given personIdOrSlug is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPersonShowCredits> GetPersonShowCreditsAsync([NotNull] string personIdOrSlug, TraktExtendedInfo extendedInfo = null)
        {
            Validate(personIdOrSlug);

            return await QueryAsync(new TraktPersonShowCreditsRequest(Client)
            {
                Id = personIdOrSlug,
                ExtendedInfo = extendedInfo
            });
        }

        private void Validate(string personIdOrSlug)
        {
            if (string.IsNullOrEmpty(personIdOrSlug) || personIdOrSlug.ContainsSpace())
                throw new ArgumentException("person id or slug not valid", nameof(personIdOrSlug));
        }
    }
}
