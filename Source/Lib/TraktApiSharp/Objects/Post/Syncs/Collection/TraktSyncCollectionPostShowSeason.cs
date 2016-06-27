namespace TraktApiSharp.Objects.Post.Syncs.Collection
{
    using Basic;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class TraktSyncCollectionPostShowSeason
    {
        [JsonProperty(PropertyName = "collected_at")]
        public DateTime? CollectedAt { get; set; }

        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncCollectionPostShowEpisode> Episodes { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public TraktMetadata Metadata { get; set; }
    }
}
