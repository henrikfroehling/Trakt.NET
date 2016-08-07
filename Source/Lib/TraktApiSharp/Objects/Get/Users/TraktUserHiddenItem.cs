namespace TraktApiSharp.Objects.Get.Users
{
    using Attributes;
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
        [Nullable]
        public TraktHiddenItemType Type { get; set; }

        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }

        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }

        [JsonProperty(PropertyName = "season")]
        [Nullable]
        public TraktSeason Season { get; set; }
    }
}
