namespace TraktApiSharp.Objects.Get.Calendars
{
    using Attributes;
    using Newtonsoft.Json;
    using Shows;
    using Shows.Episodes;
    using System;

    public class TraktCalendarShow
    {
        [JsonProperty(PropertyName = "first_aired")]
        public DateTime? FirstAired { get; set; }

        [JsonProperty(PropertyName = "episode")]
        [Nullable]
        public TraktEpisode Episode { get; set; }

        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }
    }
}
