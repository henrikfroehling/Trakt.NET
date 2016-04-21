namespace TraktApiSharp.Objects.Get.Syncs
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncWatchedShowSeasonItem
    {
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncWatchedShowEpisodeItem> Episodes { get; set; }
    }
}
