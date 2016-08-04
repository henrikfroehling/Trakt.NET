namespace TraktApiSharp.Objects.Get.Users
{
    using Attributes;
    using Newtonsoft.Json;

    public class TraktSharingText
    {
        [JsonProperty(PropertyName = "watching")]
        [Nullable]
        public string Watching { get; set; }

        [JsonProperty(PropertyName = "watched")]
        [Nullable]
        public string Watched { get; set; }
    }
}
