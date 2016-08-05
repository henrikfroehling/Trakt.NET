namespace TraktApiSharp.Objects.Post.Syncs.Responses
{
    using Attributes;
    using Newtonsoft.Json;

    public class TraktSyncPostResponseNotFoundItem<T>
    {
        [JsonProperty(PropertyName = "ids")]
        [Nullable]
        public T Ids { get; set; }
    }
}
