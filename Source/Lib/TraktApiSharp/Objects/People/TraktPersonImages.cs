namespace TraktApiSharp.Objects.People
{
    using Newtonsoft.Json;

    public class TraktPersonImages
    {
        [JsonProperty(PropertyName = "headshot")]
        public TraktImageSet Headshot { get; set; }

        [JsonProperty(PropertyName = "fanart")]
        public TraktImageSet FanArt { get; set; }
    }
}
