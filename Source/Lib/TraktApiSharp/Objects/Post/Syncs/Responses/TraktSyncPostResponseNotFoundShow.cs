namespace TraktApiSharp.Objects.Post.Syncs.Responses
{
    using Get.Shows;
    using Newtonsoft.Json;

    public class TraktSyncPostResponseNotFoundShow
    {
        [JsonProperty(PropertyName = "ids")]
        public TraktShowIds Ids { get; set; }
    }
}
