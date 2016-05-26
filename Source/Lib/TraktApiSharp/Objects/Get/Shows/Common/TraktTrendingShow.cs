namespace TraktApiSharp.Objects.Get.Shows.Common
{
    using Newtonsoft.Json;

    public class TraktTrendingShow
    {
        [JsonProperty(PropertyName = "watchers")]
        public int Watchers { get; set; }

        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }
    }
}
