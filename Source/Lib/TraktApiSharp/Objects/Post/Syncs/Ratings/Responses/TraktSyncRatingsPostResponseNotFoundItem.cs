namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>Represents a rated Trakt object, which was not found.</summary>
    /// <typeparam name="T">The type of the Trakt object.</typeparam>
    public class TraktSyncRatingsPostResponseNotFoundItem<T>
    {
        /// <summary>Gets or sets an optional rating for the Trakt object, which was not found.</summary>
        [JsonProperty(PropertyName = "rating")]
        public int? Rating { get; set; }

        /// <summary>Gets or sets the ids of the Trakt object, which was not found.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "ids")]
        [Nullable]
        public T Ids { get; set; }
    }
}
