namespace TraktApiSharp.Objects.Post.Syncs.Collection
{
    using Attributes;
    using Basic;
    using Get.Shows;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class TraktSyncCollectionPostShow
    {
        [JsonProperty(PropertyName = "collected_at")]
        public DateTime? CollectedAt { get; set; }

        [JsonProperty(PropertyName = "title")]
        [Nullable]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int? Year { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public TraktShowIds Ids { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        [Nullable]
        public IEnumerable<TraktSyncCollectionPostShowSeason> Seasons { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        [Nullable]
        public TraktMetadata Metadata { get; set; }
    }
}
