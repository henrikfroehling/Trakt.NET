namespace TraktApiSharp.Objects.Post.Syncs.Responses
{
    using Get.Shows.Seasons;
    using Newtonsoft.Json;

    public class TraktSyncPostResponseNotFoundSeason
    {
        [JsonProperty(PropertyName = "ids")]
        public TraktSeasonIds Ids { get; set; }
    }
}
