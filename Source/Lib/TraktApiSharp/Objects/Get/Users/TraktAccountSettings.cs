namespace TraktApiSharp.Objects.Get.Users
{
    using Newtonsoft.Json;

    public class TraktAccountSettings
    {
        [JsonProperty(PropertyName = "timezone")]
        public string TimeZoneId { get; set; }

        [JsonProperty(PropertyName = "time_24hr")]
        public bool Time24Hr { get; set; }

        [JsonProperty(PropertyName = "cover_image")]
        public string CoverImage { get; set; }
    }
}
