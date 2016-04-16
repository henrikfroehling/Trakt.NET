namespace TraktApiSharp.Objects.Shows
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// The air time of a Trakt show.
    /// </summary>
    public class TraktShowAirs
    {
        private static List<string> DAYS = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

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
