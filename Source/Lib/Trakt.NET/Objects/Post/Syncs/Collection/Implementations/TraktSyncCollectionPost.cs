namespace TraktNet.Objects.Post.Syncs.Collection
{
    using Exceptions;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A Trakt collection post, containing all movies, shows, seasons and / or episodes,
    /// which should be added to the user's collection.
    /// </summary>
    public class TraktSyncCollectionPost : ITraktSyncCollectionPost
    {
        /// <summary>
        /// An optional list of <see cref="ITraktSyncCollectionPostMovie" />s.
        /// <para>Each <see cref="ITraktSyncCollectionPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IList<ITraktSyncCollectionPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncCollectionPostShow" />s.
        /// <para>Each <see cref="ITraktSyncCollectionPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IList<ITraktSyncCollectionPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncCollectionPostSeason" />s.
        /// <para>Each <see cref="ITraktSyncCollectionPostSeason" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IList<ITraktSyncCollectionPostSeason> Seasons { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncCollectionPostEpisode" />s.
        /// <para>Each <see cref="ITraktSyncCollectionPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IList<ITraktSyncCollectionPostEpisode> Episodes { get; set; }

        public Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktSyncCollectionPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktSyncCollectionPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public void Validate()
        {
            bool bHasNoMovies = Movies == null || !Movies.Any();
            bool bHasNoShows = Shows == null || !Shows.Any();
            bool bHasNoSeasons = Seasons == null || !Seasons.Any();
            bool bHasNoEpisodes = Episodes == null || !Episodes.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoSeasons && bHasNoEpisodes)
                throw new TraktPostValidationException("no collection items set");
        }
    }
}
