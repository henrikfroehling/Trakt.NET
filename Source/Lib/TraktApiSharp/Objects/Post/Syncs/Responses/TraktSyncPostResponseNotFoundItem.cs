namespace TraktApiSharp.Objects.Post.Syncs.Responses
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>Represents a Trakt object, which was not found.</summary>
    /// <typeparam name="T">The type of the Trakt object.</typeparam>
    public class TraktSyncPostResponseNotFoundItem<T>
    {
        /// <summary>Gets or sets the ids of the Trakt object, which was not found.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "ids")]
        [Nullable]
        public T Ids { get; set; }
    }
}
