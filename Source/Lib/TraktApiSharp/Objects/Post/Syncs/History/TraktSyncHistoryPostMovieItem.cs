namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Get.Movies;
    using Newtonsoft.Json;
    using System;

    public class TraktSyncHistoryPostMovieItem
    {
        [JsonProperty(PropertyName = "watched_at")]
        public DateTime? WatchedAt { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int? Year { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public TraktMovieIds Ids { get; set; }
    }
}
