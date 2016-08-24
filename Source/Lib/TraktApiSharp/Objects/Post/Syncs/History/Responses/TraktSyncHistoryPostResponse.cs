namespace TraktApiSharp.Objects.Post.Syncs.History.Responses
{
    using Attributes;
    using Newtonsoft.Json;
    using Syncs.Responses;

    /// <summary>
    /// Represents the response for a history post. See also <see cref="TraktSyncHistoryPost" />.
    /// <para>Contains the number of added and not found movies, shows, seasons and episodes.</para>
    /// </summary>
    public class TraktSyncHistoryPostResponse
    {
        /// <summary>
        /// A collection containing the number of added movies, shows, seasons and episodes.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "added")]
        [Nullable]
        public TraktSyncPostResponseGroup Added { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows, seasons and episodes, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "not_found")]
        [Nullable]
        public TraktSyncPostResponseNotFound NotFound { get; set; }
    }
}
