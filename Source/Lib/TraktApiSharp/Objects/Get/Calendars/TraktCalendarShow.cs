namespace TraktApiSharp.Objects.Get.Calendars
{
    using Newtonsoft.Json;
    using Shows;
    using Shows.Episodes;
    using System;

    public class TraktCalendarShow
    {
        [JsonProperty(PropertyName = "first_aired")]
        public DateTime? FirstAired { get; set; }

        [JsonProperty(PropertyName = "episode")]
        public TraktEpisode Episode { get; set; }

        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }
    }
}
