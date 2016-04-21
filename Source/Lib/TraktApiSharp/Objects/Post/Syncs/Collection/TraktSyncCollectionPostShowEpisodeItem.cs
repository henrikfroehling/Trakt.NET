namespace TraktApiSharp.Objects.Post.Syncs.Collection
{
    using Basic;
    using Newtonsoft.Json;
    using System;

    public class TraktSyncCollectionPostShowEpisodeItem
    {
        [JsonProperty(PropertyName = "collected_at")]
        public DateTime? CollectedAt { get; set; }

        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public TraktMetadata Metadata { get; set; }
    }
}
