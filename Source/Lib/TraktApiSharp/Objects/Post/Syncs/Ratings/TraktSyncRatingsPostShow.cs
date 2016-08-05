namespace TraktApiSharp.Objects.Post.Syncs.Ratings
{
    using Attributes;
    using Get.Shows;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class TraktSyncRatingsPostShow
    {
        [JsonProperty(PropertyName = "rated_at")]
        public DateTime? RatedAt { get; set; }

        [JsonProperty(PropertyName = "rating")]
        public int? Rating { get; set; }

        [JsonProperty(PropertyName = "title")]
        [Nullable]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int? Year { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public TraktShowIds Ids { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        [Nullable]
        public IEnumerable<TraktSyncRatingsPostShowSeason> Seasons { get; set; }
    }
}
