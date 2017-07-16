namespace TraktApiSharp.Objects.Post.Syncs.Collection.Responses.Implementations
{
    using Newtonsoft.Json;
    using Syncs.Responses;

    /// <summary>
    /// Represents the response for a collection post. See also <see cref="TraktSyncCollectionPost" />.
    /// <para>Contains the number of added, updated, existing and not found movies, shows, seasons and episodes.</para>
    /// </summary>
    public class TraktSyncCollectionPostResponse : ITraktSyncCollectionPostResponse
    {
        /// <summary>
        /// A collection containing the number of added movies, shows, seasons and episodes.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "added")]
        public ITraktSyncPostResponseGroup Added { get; set; }

        /// <summary>
        /// A collection containing the number of updated movies, shows, seasons and episodes.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public ITraktSyncPostResponseGroup Updated { get; set; }

        /// <summary>
        /// A collection containing the number of existing movies, shows, seasons and episodes.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "existing")]
        public ITraktSyncPostResponseGroup Existing { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows, seasons and episodes, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "not_found")]
        public ITraktSyncPostResponseNotFoundGroup NotFound { get; set; }
    }
}
