namespace TraktApiSharp.Objects.Get.People
{
    using Basic;
    using Newtonsoft.Json;

    public class TraktPersonImages
    {
        [JsonProperty(PropertyName = "headshot")]
        public TraktImageSet Headshot { get; set; }

        [JsonProperty(PropertyName = "fanart")]
        public TraktImageSet FanArt { get; set; }
    }
}
