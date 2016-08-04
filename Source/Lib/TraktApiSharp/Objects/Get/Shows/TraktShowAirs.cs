namespace TraktApiSharp.Objects.Get.Shows
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>The air time of a Trakt show.</summary>
    public class TraktShowAirs
    {
        /// <summary>Gets or sets the day of week on which the show airs.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "day")]
        [Nullable]
        public string Day { get; set; }

        /// <summary>Gets or sets the time of day at which the show airs.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "time")]
        [Nullable]
        public string Time { get; set; }

        /// <summary>Gets or sets the time zone id (Olson) for the location in which the show airs.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "timezone")]
        [Nullable]
        public string TimeZoneId { get; set; }
    }
}
