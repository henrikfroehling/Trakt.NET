namespace TraktApiSharp.Objects.Get.Users
{
    using Attributes;
    using Newtonsoft.Json;

    public class TraktAccountSettings
    {
        [JsonProperty(PropertyName = "timezone")]
        [Nullable]
        public string TimeZoneId { get; set; }

        [JsonProperty(PropertyName = "time_24hr")]
        public bool? Time24Hr { get; set; }

        [JsonProperty(PropertyName = "cover_image")]
        [Nullable]
        public string CoverImage { get; set; }
    }
}
