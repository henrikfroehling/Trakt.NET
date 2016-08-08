namespace TraktApiSharp.Objects.Get.Users
{
    using Attributes;
    using Enums;
    using Movies;
    using Newtonsoft.Json;
    using Shows;
    using Shows.Episodes;
    using System;

    public class TraktUserWatchingItem
    {
        [JsonProperty(PropertyName = "expires_at")]
        public DateTime? ExpiresAt { get; set; }

        [JsonProperty(PropertyName = "started_at")]
        public DateTime? StartedAt { get; set; }

        [JsonProperty(PropertyName = "action")]
        [JsonConverter(typeof(TraktHistoryActionTypeConverter))]
        [Nullable]
        public TraktHistoryActionType Action { get; set; }

        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(TraktSyncTypeConverter))]
        [Nullable]
        public TraktSyncType Type { get; set; }

        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }

        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }

        [JsonProperty(PropertyName = "episode")]
        [Nullable]
        public TraktEpisode Episode { get; set; }
    }
}
