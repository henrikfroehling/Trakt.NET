namespace TraktApiSharp.Objects.Get.Shows.Seasons
{
    using Newtonsoft.Json;

    public abstract class TraktSeasonProgress
    {
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "aired")]
        public int Aired { get; set; }

        [JsonProperty(PropertyName = "completed")]
        public int Completed { get; set; }
    }
}
