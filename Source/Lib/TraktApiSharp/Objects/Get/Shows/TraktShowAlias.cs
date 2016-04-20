namespace TraktApiSharp.Objects.Get.Shows
{
    using Newtonsoft.Json;

    public class TraktShowAlias
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string CountryCode { get; set; }
    }
}
