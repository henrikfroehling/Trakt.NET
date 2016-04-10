namespace TraktApiSharp.Objects.Movies
{
    using Newtonsoft.Json;

    public class TraktMovieImages
    {
        [JsonProperty(PropertyName = "fanart")]
        public TraktImageSet FanArt { get; set; }

        [JsonProperty(PropertyName = "poster")]
        public TraktImageSet Poster { get; set; }

        [JsonProperty(PropertyName = "logo")]
        public TraktImage Logo { get; set; }

        [JsonProperty(PropertyName = "clearart")]
        public TraktImage ClearArt { get; set; }

        [JsonProperty(PropertyName = "banner")]
        public TraktImage Banner { get; set; }

        [JsonProperty(PropertyName = "thumb")]
        public TraktImage Thumb { get; set; }
    }
}
