namespace TraktApiSharp.Objects.Get.Calendars
{
    using Attributes;
    using Movies;
    using Newtonsoft.Json;

    public class TraktCalendarMovie
    {
        [JsonProperty(PropertyName = "released")]
        [Nullable]
        public string Released { get; set; }

        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }
    }
}
