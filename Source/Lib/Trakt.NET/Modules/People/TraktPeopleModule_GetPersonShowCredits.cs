namespace TraktNet.Modules
{
    using Exceptions;
    using Objects.Get.People;
    using Objects.Get.People.Credits;
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
        /// Gets all shows where a person with the given Trakt-Id or -Slug is in the cast or crew.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/people/shows/get-show-credits">"Trakt API Doc - People: Shows"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktPersonId">The person's Trakt-Id. See also <seealso cref="ITraktPersonIds" />.</param>
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
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktPersonId"/> is 0.</exception>
        public Task<TraktResponse<ITraktPersonShowCredits>> GetPersonShowCreditsAsync(uint traktPersonId, TraktExtendedInfo extendedInfo = null,
                                                                                      CancellationToken cancellationToken = default)
        {
            if (traktPersonId == 0)
                throw new ArgumentException("person id must not be 0", nameof(traktPersonId));

            return GetPersonShowCreditsAsync(traktPersonId.ToString(), extendedInfo, cancellationToken);
        }

        /// <summary>
        /// Gets all shows where a person with the given Trakt-Id or -Slug is in the cast or crew.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/people/shows/get-show-credits">"Trakt API Doc - People: Shows"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="personIds">The person's ids. See also <seealso cref="ITraktPersonIds" />.</param>
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
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="personIds"/> is null.</exception>
        public Task<TraktResponse<ITraktPersonShowCredits>> GetPersonShowCreditsAsync(ITraktPersonIds personIds, TraktExtendedInfo extendedInfo = null,
                                                                                      CancellationToken cancellationToken = default)
        {
            if (personIds == null)
                throw new ArgumentNullException(nameof(personIds));

            if (!personIds.HasAnyId)
                throw new ArgumentException($"{nameof(personIds)} has not any ids set", nameof(personIds));

            return GetPersonShowCreditsAsync(personIds.GetBestId(), extendedInfo, cancellationToken);
        }
    }
}
