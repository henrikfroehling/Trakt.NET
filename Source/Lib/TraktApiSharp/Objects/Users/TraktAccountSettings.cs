namespace TraktApiSharp.Objects.Users
{
    using Core;
    using Newtonsoft.Json;
    using NodaTime;

    public class TraktAccountSettings
    {
        [JsonProperty(PropertyName = "timezone")]
        public string TimeZoneId { get; set; }

        [JsonIgnore]
        public DateTimeZone TimeZone
        {
            get
            {
                return !string.IsNullOrEmpty(TimeZoneId) ? TraktTimeZone.FromOlsonTimeZoneId(TimeZoneId) : default(DateTimeZone);
            }
        }

        [JsonProperty(PropertyName = "time_24hr")]
        public bool? Time24Hr { get; set; }

        [JsonProperty(PropertyName = "cover_image")]
        public string CoverImage { get; set; }
    }
}
