namespace TraktNet.Objects.Post.Syncs.Collection.Responses
{
    using Syncs.Responses;

    /// <summary>
    /// Represents the response for a collection remove post. See also <see cref="ITraktSyncCollectionPost" />.
    /// <para>Contains the number of deleted and not found movies, shows, seasons and episodes.</para>
    /// </summary>
    public interface ITraktSyncCollectionRemovePostResponse
    {
        /// <summary>
        /// A collection containing the number of deleted movies, shows, seasons and episodes.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSyncPostResponseGroup Deleted { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows, seasons and episodes, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSyncPostResponseNotFoundGroup NotFound { get; set; }
    }
}
