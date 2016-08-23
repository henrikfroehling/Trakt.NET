namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses
{
    using Attributes;
    using Newtonsoft.Json;
    using Syncs.Responses;

    /// <summary>
    /// Represents the response for a ratings remove post. See also <see cref="TraktSyncRatingsPost" />.
    /// <para>Contains the number of deleted and not found movies, shows, seasons and episodes.</para>
    /// </summary>
    public class TraktSyncRatingsRemovePostResponse
    {
        /// <summary>
        /// A collection containing the number of deleted movies, shows, seasons and episodes.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "deleted")]
        [Nullable]
        public TraktSyncPostResponseGroup Deleted { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows, seasons and episodes, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "not_found")]
        [Nullable]
        public TraktSyncPostResponseNotFound NotFound { get; set; }
    }
}
