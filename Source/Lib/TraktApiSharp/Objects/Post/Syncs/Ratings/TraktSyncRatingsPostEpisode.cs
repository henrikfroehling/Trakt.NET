namespace TraktApiSharp.Objects.Post.Syncs.Ratings
{
    using Get.Shows.Episodes;
    using Newtonsoft.Json;
    using System;

    public class TraktSyncRatingsPostEpisode
    {
        [JsonProperty(PropertyName = "rated_at")]
        public DateTime? RatedAt { get; set; }

        [JsonProperty(PropertyName = "rating")]
        public int? Rating { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public TraktEpisodeIds Ids { get; set; }
    }
}
