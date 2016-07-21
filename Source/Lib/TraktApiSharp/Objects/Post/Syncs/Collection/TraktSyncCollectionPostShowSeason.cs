namespace TraktApiSharp.Objects.Post.Syncs.Collection
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncCollectionPostShowSeason
    {
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncCollectionPostShowEpisode> Episodes { get; set; }
    }
}
