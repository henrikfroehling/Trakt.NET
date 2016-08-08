namespace TraktApiSharp.Objects.Get.History
{
    using Attributes;
    using Enums;
    using Movies;
    using Newtonsoft.Json;
    using Shows;
    using Shows.Episodes;
    using Shows.Seasons;
    using System;

    public class TraktHistoryItem
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "watched_at")]
        public DateTime? WatchedAt { get; set; }

        [JsonProperty(PropertyName = "action")]
        [JsonConverter(typeof(TraktHistoryActionTypeConverter))]
        [Nullable]
        public TraktHistoryActionType Action { get; set; }

        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(TraktSyncItemTypeConverter))]
        [Nullable]
        public TraktSyncItemType Type { get; set; }

        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }

        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }

        [JsonProperty(PropertyName = "season")]
        [Nullable]
        public TraktSeason Season { get; set; }

        [JsonProperty(PropertyName = "episode")]
        [Nullable]
        public TraktEpisode Episode { get; set; }
    }
}
