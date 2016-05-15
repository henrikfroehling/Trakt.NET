namespace TraktApiSharp.Objects.Get.Movies.Common
{
    using Newtonsoft.Json;

    public class TraktBoxOfficeMovie
    {
        [JsonProperty(PropertyName = "revenue")]
        public int Revenue { get; set; }

        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }
    }
}
