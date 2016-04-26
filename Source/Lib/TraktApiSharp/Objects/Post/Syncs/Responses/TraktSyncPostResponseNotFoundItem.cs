namespace TraktApiSharp.Objects.Post.Syncs.Responses
{
    using Newtonsoft.Json;

    public class TraktSyncPostResponseNotFoundItem<T>
    {
        [JsonProperty(PropertyName = "ids")]
        public T Ids { get; set; }
    }
}
