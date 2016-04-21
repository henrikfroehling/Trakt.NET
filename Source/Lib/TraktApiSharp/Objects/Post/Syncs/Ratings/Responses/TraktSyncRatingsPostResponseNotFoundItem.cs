namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses
{
    using Newtonsoft.Json;

    public class TraktSyncRatingsPostResponseNotFoundItem<T>
    {
        [JsonProperty(PropertyName = "rating")]
        public int Rating { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public T Ids { get; set; }
    }
}
