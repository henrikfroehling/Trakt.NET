namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses
{
    using Attributes;
    using Newtonsoft.Json;

    public class TraktSyncRatingsPostResponseNotFoundItem<T>
    {
        [JsonProperty(PropertyName = "rating")]
        public int? Rating { get; set; }

        [JsonProperty(PropertyName = "ids")]
        [Nullable]
        public T Ids { get; set; }
    }
}
