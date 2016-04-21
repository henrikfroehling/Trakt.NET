namespace TraktApiSharp.Objects.Get.Shows
{
    using Newtonsoft.Json;

    /// <summary>
    /// The air time of a Trakt show.
    /// </summary>
    public class TraktShowAirs
    {
        /// <summary>
        /// The day of week on which the show airs.
        /// </summary>
        [JsonProperty(PropertyName = "day")]
        public string Day { get; set; }

        /// <summary>
        /// The time of day at which the show airs.
        /// </summary>
        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }

        /// <summary>
        /// The time zone id (Olson) for the location in which the show airs.
        /// </summary>
        [JsonProperty(PropertyName = "timezone")]
        public string TimeZoneId { get; set; }
    }
}
