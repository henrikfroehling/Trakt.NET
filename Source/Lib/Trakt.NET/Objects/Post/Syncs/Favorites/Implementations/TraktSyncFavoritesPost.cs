namespace TraktNet.Objects.Post.Syncs.Favorites
{
    using Exceptions;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>A Trakt favorites post, containing all movies and shows, which should be favorited by an user.</summary>
    public class TraktSyncFavoritesPost : ITraktSyncFavoritesPost
    {
        /// <summary>
        /// An optional list of <see cref="ITraktSyncFavoritesPostMovie" />s.
        /// <para>Each <see cref="ITraktSyncFavoritesPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IList<ITraktSyncFavoritesPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncFavoritesPostShow" />s.
        /// <para>Each <see cref="ITraktSyncFavoritesPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        public IList<ITraktSyncFavoritesPostShow> Shows { get; set; }

        public Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktSyncFavoritesPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktSyncFavoritesPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public void Validate()
        {
            bool bHasNoMovies = Movies == null || !Movies.Any();
            bool bHasNoShows = Shows == null || !Shows.Any();

            if (bHasNoMovies && bHasNoShows)
                throw new TraktPostValidationException("no favorite items set");

            if (Movies != null && Movies.Any())
            {
                foreach (ITraktSyncFavoritesPostMovie postMovie in Movies)
                {
                    if (postMovie.Notes?.Length > 255)
                        throw new TraktPostValidationException($"Movies[{Movies.ToList().IndexOf(postMovie)}].Notes", "notes cannot be longer than 255 characters");
                }
            }

            if (Shows != null && Shows.Any())
            {
                foreach (ITraktSyncFavoritesPostShow postShow in Shows)
                {
                    if (postShow.Notes?.Length > 255)
                        throw new TraktPostValidationException($"Shows[{Shows.ToList().IndexOf(postShow)}].Notes", "notes cannot be longer than 255 characters");
                }
            }
        }
    }
}
