namespace TraktApiSharp.Objects.Post.Syncs
{
    using Basic;
    using Get.Shows.Episodes;
    using Newtonsoft.Json;
    using System;

    public class TraktSyncCollectionPostEpisodeItem
    {
        [JsonProperty(PropertyName = "collected_at")]
        public DateTime? CollectedAt { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public TraktEpisodeIds Ids { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public TraktMetadata Metadata { get; set; }
    }
}
