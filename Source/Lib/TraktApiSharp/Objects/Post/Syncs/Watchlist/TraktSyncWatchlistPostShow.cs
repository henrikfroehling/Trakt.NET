namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using Get.Shows;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncWatchlistPostShow
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int? Year { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public TraktShowIds Ids { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<TraktSyncWatchlistPostShowSeason> Seasons { get; set; }
    }
}
