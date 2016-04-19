namespace TraktApiSharp.Objects.Get.Movies.Common
{
    using Newtonsoft.Json;

    public class TraktMoviesMostAnticipatedItem
    {
        [JsonProperty(PropertyName = "list_count")]
        public int? ListCount { get; set; }

        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }
    }
}
