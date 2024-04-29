namespace TraktNet.Objects.Post.Syncs.Favorites.Responses
{
    using Objects.Post.Responses;

    /// <summary>
    /// Represents the response for a favorites remove post. See also <see cref="ITraktSyncFavoritesRemovePostResponse" />.
    /// <para>Contains the number of deleted movies and shows and not found movies and shows.</para>
    /// </summary>
    public class TraktSyncFavoritesRemovePostResponse : ITraktSyncFavoritesRemovePostResponse
    {
        /// <summary>
        /// A collection containing the number of deleted movies and shows.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncFavoritesPostResponseGroup Deleted { get; set; }

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
