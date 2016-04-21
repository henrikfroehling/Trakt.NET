namespace TraktApiSharp.Objects.Get.Syncs.History
{
    using Enums;
    using Movies;
    using Newtonsoft.Json;
    using Shows;
    using Shows.Episodes;
    using Shows.Seasons;
    using System;

    public class TraktSyncHistoryItem
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "watched_at")]
        public DateTime WatchedAt { get; set; }

        [JsonProperty(PropertyName = "action")]
        [JsonConverter(typeof(TraktSyncHistoryActionTypeConverter))]
        public TraktSyncHistoryActionType Action { get; set; }

        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(TraktSyncHistoryItemTypeConverter))]
        public TraktSyncHistoryItemType Type { get; set; }

        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }

        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }

        [JsonProperty(PropertyName = "season")]
        public TraktSeason Season { get; set; }

        [JsonProperty(PropertyName = "episode")]
        public TraktEpisode Episode { get; set; }
    }
}
