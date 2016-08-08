namespace TraktApiSharp.Objects.Get.Syncs.Playback
{
    using Attributes;
    using Enums;
    using Movies;
    using Newtonsoft.Json;
    using Shows;
    using Shows.Episodes;
    using System;

    public class TraktSyncPlaybackProgressItem
    {
        [JsonProperty(PropertyName = "progress")]
        public float? Progress { get; set; }

        [JsonProperty(PropertyName = "paused_at")]
        public DateTime? PausedAt { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktSyncType>))]
        [Nullable]
        public TraktSyncType Type { get; set; }

        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }

        [JsonProperty(PropertyName = "episode")]
        [Nullable]
        public TraktEpisode Episode { get; set; }

        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }
    }
}
