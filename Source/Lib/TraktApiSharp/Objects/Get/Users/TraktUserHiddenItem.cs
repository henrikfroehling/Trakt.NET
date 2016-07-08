namespace TraktApiSharp.Objects.Get.Users
{
    using Enums;
    using Movies;
    using Newtonsoft.Json;
    using Shows;
    using Shows.Seasons;
    using System;

    public class TraktUserHiddenItem
    {
        [JsonProperty(PropertyName = "hidden_at")]
        public DateTime? HiddenAt { get; set; }

        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(TraktHiddenItemTypeConverter))]
        public TraktHiddenItemType? Type { get; set; }

        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }

        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }

        [JsonProperty(PropertyName = "season")]
        public TraktSeason Season { get; set; }
    }
}
