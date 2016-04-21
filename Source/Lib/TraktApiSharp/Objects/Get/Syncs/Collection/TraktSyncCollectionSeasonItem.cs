namespace TraktApiSharp.Objects.Get.Syncs.Collection
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncCollectionSeasonItem
    {
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncCollectionEpisodeItem> Episodes { get; set; }
    }
}
