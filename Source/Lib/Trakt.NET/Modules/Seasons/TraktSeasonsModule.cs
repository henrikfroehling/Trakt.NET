namespace TraktNet.Modules
{
    using Objects.Get.Episodes;
    using Parameters;
    using Requests.Handler;
    using Requests.Seasons;
    using Responses;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to seasons.
    /// <para>
    /// This module contains all methods of the <a href ="http://trakt.docs.apiary.io/#reference/seasons">"Trakt API Doc - Seasons"</a> section.
    /// </para>
    /// </summary>
    public partial class TraktSeasonsModule : ATraktModule
    {
        internal TraktSeasonsModule(TraktClient client) : base(client)
        {
        }

        private Task<TraktListResponse<ITraktEpisode>> GetSeasonInStreamAsync(string showIdOrSlug, uint seasonNumber,
                                                                            TraktExtendedInfo extendedInfo = null,
                                                                            string translationLanguageCode = null,
                                                                            CancellationToken cancellationToken = default)
            => GetSeasonImplementationAsync(true, showIdOrSlug, seasonNumber, extendedInfo, translationLanguageCode, cancellationToken);

        private Task<TraktListResponse<ITraktEpisode>> GetSeasonImplementationAsync(bool asyncStream, string showIdOrSlug, uint seasonNumber,
                                                                                   TraktExtendedInfo extendedInfo = null,
                                                                                   string translationLanguageCode = null,
                                                                                   CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            var request = new SeasonSingleRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                ExtendedInfo = extendedInfo,
                TranslationLanguageCode = translationLanguageCode
            };

            if (asyncStream)
                return requestHandler.ExecuteListStreamRequestAsync(request, cancellationToken);

            return requestHandler.ExecuteListRequestAsync(request, cancellationToken);
        }
    }
}
