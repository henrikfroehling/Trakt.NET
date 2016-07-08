namespace TraktApiSharp.Objects.Get.Shows.Episodes
{
    using Newtonsoft.Json;

    public abstract class TraktEpisodeProgress
    {
        [JsonProperty(PropertyName = "number")]
        public int? Number { get; set; }

        [JsonProperty(PropertyName = "completed")]
        public bool? Completed { get; set; }
    }
}
