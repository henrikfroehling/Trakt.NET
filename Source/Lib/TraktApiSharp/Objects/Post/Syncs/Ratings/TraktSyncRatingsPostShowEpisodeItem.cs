namespace TraktApiSharp.Objects.Post.Syncs.Ratings
{
    using Newtonsoft.Json;
    using System;

    public class TraktSyncRatingsPostShowEpisodeItem
    {
        [JsonProperty(PropertyName = "rated_at")]
        public DateTime? RatedAt { get; set; }

        [JsonProperty(PropertyName = "rating")]
        public int Rating { get; set; }

        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }
    }
}
