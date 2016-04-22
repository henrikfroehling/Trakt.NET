namespace TraktApiSharp.Objects.Get.Calendars
{
    using Movies;
    using Newtonsoft.Json;

    public class TraktCalendarMovieItem
    {
        [JsonProperty(PropertyName = "released")]
        public string Released { get; set; }

        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }
    }
}
