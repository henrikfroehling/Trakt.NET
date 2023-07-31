namespace TraktNet.Modules
{
    using Objects.Get.Episodes;
    using Parameters;
    using Requests.Episodes;
    using Requests.Handler;
    using Responses;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to episodes.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/episodes">"Trakt API Doc - Episodes"</a> section.
    /// </para>
    /// </summary>
    public partial class TraktEpisodesModule : ATraktModule
    {
        internal TraktEpisodesModule(TraktClient client) : base(client)
        {
        }

        private Task<TraktResponse<ITraktEpisode>> GetEpisodeInStreamAsync(string showIdOrSlug, uint seasonNumber, uint episodeNumber,
                                                                           TraktExtendedInfo extendedInfo = null,
                                                                           CancellationToken cancellationToken = default)
            => GetEpisodeImplementationAsync(true, showIdOrSlug, seasonNumber, episodeNumber, extendedInfo, cancellationToken);

        private Task<TraktResponse<ITraktEpisode>> GetEpisodeImplementationAsync(bool asyncStream, string showIdOrSlug, uint seasonNumber, uint episodeNumber,
                                                                                 TraktExtendedInfo extendedInfo = null,
                                                                                 CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            var request = new EpisodeSummaryRequest
            {
                Id = showIdOrSlug,
                SeasonNumber = seasonNumber,
                EpisodeNumber = episodeNumber,
                ExtendedInfo = extendedInfo
            };

            if (asyncStream)
                return requestHandler.ExecuteSingleItemStreamRequestAsync(request, cancellationToken);

            return requestHandler.ExecuteSingleItemRequestAsync(request, cancellationToken);
        }
    }
}
