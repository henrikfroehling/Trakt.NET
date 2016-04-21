namespace TraktApiSharp.Objects.Post.Syncs
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncCollectionPostShowSeasonItem
    {
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncCollectionPostShowEpisodeItem> Episodes { get; set; }
    }
}
