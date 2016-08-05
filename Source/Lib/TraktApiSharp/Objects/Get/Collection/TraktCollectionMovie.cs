namespace TraktApiSharp.Objects.Get.Collection
{
    using Attributes;
    using Basic;
    using Movies;
    using Newtonsoft.Json;
    using System;

    public class TraktCollectionMovie
    {
        [JsonProperty(PropertyName = "collected_at")]
        public DateTime? CollectedAt { get; set; }

        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        [Nullable]
        public TraktMetadata Metadata { get; set; }
    }
}
