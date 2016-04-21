namespace TraktApiSharp.Objects.Get.Shows
{
    using Newtonsoft.Json;

    public class TraktShowTranslation
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }

        [JsonProperty(PropertyName = "language")]
        public string LanguageCode { get; set; }
    }
}
