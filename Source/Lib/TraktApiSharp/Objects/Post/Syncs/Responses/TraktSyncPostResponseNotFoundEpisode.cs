namespace TraktApiSharp.Objects.Post.Syncs.Responses
{
    using Get.Shows.Episodes;
    using Newtonsoft.Json;

    public class TraktSyncPostResponseNotFoundEpisode
    {
        [JsonProperty(PropertyName = "ids")]
        public TraktEpisodeIds Ids { get; set; }
    }
}
