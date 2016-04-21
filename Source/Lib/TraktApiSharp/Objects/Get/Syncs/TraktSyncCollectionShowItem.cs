namespace TraktApiSharp.Objects.Get.Syncs
{
    using Newtonsoft.Json;
    using Shows;
    using System;
    using System.Collections.Generic;

    public class TraktSyncCollectionShowItem
    {
        [JsonProperty(PropertyName = "last_collected_at")]
        public DateTime LastCollectedAt { get; set; }

        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<TraktSyncCollectionSeasonItem> Seasons { get; set; }
    }
}
