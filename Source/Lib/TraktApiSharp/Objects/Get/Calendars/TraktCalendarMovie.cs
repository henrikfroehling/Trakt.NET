namespace TraktApiSharp.Objects.Get.Calendars
{
    using Attributes;
    using Movies;
    using Newtonsoft.Json;
    using System;

    public class TraktCalendarMovie
    {
        [JsonProperty(PropertyName = "released")]
        public DateTime? Released { get; set; }

        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }
    }
}
