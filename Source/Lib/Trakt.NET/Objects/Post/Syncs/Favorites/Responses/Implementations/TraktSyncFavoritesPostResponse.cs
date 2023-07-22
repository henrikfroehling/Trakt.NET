namespace TraktNet.Objects.Post.Syncs.Favorites.Responses
{
    using Objects.Post.Responses;

    /// <summary>
    /// Represents the response for a favorites post. See also <see cref="ITraktSyncFavoritesPost" />.
    /// <para>Contains the number of added, existing and not found movies and shows.</para>
    /// </summary>
    public class TraktSyncFavoritesPostResponse : ITraktSyncFavoritesPostResponse
    {
        /// <summary>
        /// A collection containing the number of added movies and shows.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncFavoritesPostResponseGroup Added { get; set; }

        /// <summary>
        /// A collection containing the number of existing movies and shows.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncFavoritesPostResponseGroup Existing { get; set; }

        /// <summary>
        /// A collection containing the ids of movies and shows, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncFavoritesPostResponseNotFoundGroup NotFound { get; set; }

        /// <summary>
        /// Information about the updated list.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktPostResponseListData List { get; set; }
    }
}
