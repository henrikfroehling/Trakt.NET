namespace TraktApiSharp.Objects.Get.Collection
{
    using Basic;
    using Newtonsoft.Json;
    using System;

    public class TraktCollectionEpisode
    {
        [JsonProperty(PropertyName = "number")]
        public int? Number { get; set; }

        [JsonProperty(PropertyName = "collected_at")]
        public DateTime? CollectedAt { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public TraktMetadata Metadata { get; set; }
    }
}
