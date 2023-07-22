namespace TraktNet.Objects.Post.Syncs.Favorites.Responses
{
    using System.Collections.Generic;

    /// <summary>A collection containing the ids of favorited movies and shows, which were not found.</summary>
    public class TraktSyncFavoritesPostResponseNotFoundGroup : ITraktSyncFavoritesPostResponseNotFoundGroup
    {
        /// <summary>
        /// A list of <see cref="ITraktSyncFavoritesPostMovie" />, containing the ids of favorited movies, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        public IList<ITraktSyncFavoritesPostMovie> Movies { get; set; }

        /// <summary>
        /// A list of <see cref="ITraktSyncFavoritesPostShow" />, containing the ids of favorited shows, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        public IList<ITraktSyncFavoritesPostShow> Shows { get; set; }
    }
}
