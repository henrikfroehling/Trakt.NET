namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.Implementations
{
    /// <summary>
    /// Represents the response for a history remove post. See also <see cref="TraktSyncHistoryRemovePost" />.
    /// <para>Contains the number of deleted and not found movies, shows, seasons, episodes and history item ids.</para>
    /// </summary>
    public class TraktSyncHistoryRemovePostResponse : ITraktSyncHistoryRemovePostResponse
    {
        /// <summary>
        /// A collection containing the number of deleted movies, shows, seasons, episodes and history item ids.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncHistoryRemovePostResponseGroup Deleted { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows, seasons, episodes and history item ids, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncHistoryRemovePostResponseNotFoundGroup NotFound { get; set; }
    }
}
