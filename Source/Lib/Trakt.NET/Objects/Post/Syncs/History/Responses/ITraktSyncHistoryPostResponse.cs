namespace TraktNet.Objects.Post.Syncs.History.Responses
{
    using Syncs.Responses;

    /// <summary>
    /// Represents the response for a history post. See also <see cref="ITraktSyncHistoryPost" />.
    /// <para>Contains the number of added and not found movies, shows, seasons and episodes.</para>
    /// </summary>
    public interface ITraktSyncHistoryPostResponse
    {
        /// <summary>
        /// A collection containing the number of added movies, shows, seasons and episodes.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSyncPostResponseGroup Added { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows, seasons and episodes, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSyncPostResponseNotFoundGroup NotFound { get; set; }
    }
}
