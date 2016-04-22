namespace TraktApiSharp.Objects.Get.Syncs.Watched
{
    using Newtonsoft.Json;
    using Shows;
    using System;
    using System.Collections.Generic;

    public class TraktSyncWatchedShowItem
    {
        [JsonProperty(PropertyName = "plays")]
        public int Plays { get; set; }

        [JsonProperty(PropertyName = "last_watched_at")]
        public DateTime LastWatchedAt { get; set; }

        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<TraktSyncWatchedShowSeasonItem> Seasons { get; set; }
    }
}
