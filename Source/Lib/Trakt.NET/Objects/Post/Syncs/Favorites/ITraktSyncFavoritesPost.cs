namespace TraktNet.Objects.Post.Syncs.Favorites
{
    using Requests.Interfaces;
    using System.Collections.Generic;

    /// <summary>A Trakt favorites post, containing all movies and shows, which should be favorited by an user.</summary>
    public interface ITraktSyncFavoritesPost : IRequestBody
    {
        /// <summary>
        /// An optional list of <see cref="ITraktSyncFavoritesPostMovie" />s.
        /// <para>Each <see cref="ITraktSyncFavoritesPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IList<ITraktSyncFavoritesPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktSyncFavoritesPostShow" />s.
        /// <para>Each <see cref="ITraktSyncFavoritesPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IList<ITraktSyncFavoritesPostShow> Shows { get; set; }
    }
}
