namespace TraktNet.Objects.Post.Syncs.Collection.Responses
{
    using Syncs.Responses;

    /// <summary>
    /// Represents the response for a collection post. See also <see cref="ITraktSyncCollectionPost" />.
    /// <para>Contains the number of added, updated, existing and not found movies, shows, seasons and episodes.</para>
    /// </summary>
    public interface ITraktSyncCollectionPostResponse
    {
        /// <summary>
        /// A collection containing the number of added movies, shows, seasons and episodes.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSyncPostResponseGroup Added { get; set; }

        /// <summary>
        /// A collection containing the number of updated movies, shows, seasons and episodes.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSyncPostResponseGroup Updated { get; set; }

        /// <summary>
        /// A collection containing the number of existing movies, shows, seasons and episodes.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSyncPostResponseGroup Existing { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows, seasons and episodes, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSyncPostResponseNotFoundGroup NotFound { get; set; }
    }
}
