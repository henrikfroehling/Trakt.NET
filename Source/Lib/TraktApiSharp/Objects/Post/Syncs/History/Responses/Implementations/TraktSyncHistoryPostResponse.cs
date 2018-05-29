namespace TraktApiSharp.Objects.Post.Syncs.History.Responses
{
    using Syncs.Responses;

    /// <summary>
    /// Represents the response for a history post. See also <see cref="ITraktSyncHistoryPost" />.
    /// <para>Contains the number of added and not found movies, shows, seasons and episodes.</para>
    /// </summary>
    public class TraktSyncHistoryPostResponse : ITraktSyncHistoryPostResponse
    {
        /// <summary>
        /// A collection containing the number of added movies, shows, seasons and episodes.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncPostResponseGroup Added { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows, seasons and episodes, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSyncPostResponseNotFoundGroup NotFound { get; set; }
    }
}
