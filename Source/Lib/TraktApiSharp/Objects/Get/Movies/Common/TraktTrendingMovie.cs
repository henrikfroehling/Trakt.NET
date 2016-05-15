namespace TraktApiSharp.Objects.Get.Movies.Common
{
    using Newtonsoft.Json;

    public class TraktTrendingMovie
    {
        [JsonProperty(PropertyName = "watchers")]
        public int Watchers { get; set; }

        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }
    }
}
