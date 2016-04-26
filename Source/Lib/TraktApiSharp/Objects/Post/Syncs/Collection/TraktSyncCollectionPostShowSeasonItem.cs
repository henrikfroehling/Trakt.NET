namespace TraktApiSharp.Objects.Post.Syncs.Collection
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class TraktSyncCollectionPostShowSeasonItem
    {
        [JsonProperty(PropertyName = "collected_at")]
        public DateTime? CollectedAt { get; set; }

        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncCollectionPostShowEpisodeItem> Episodes { get; set; }
    }
}
