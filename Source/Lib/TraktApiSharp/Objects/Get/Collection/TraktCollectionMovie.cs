namespace TraktApiSharp.Objects.Get.Collection
{
    using Basic;
    using Movies;
    using Newtonsoft.Json;
    using System;

    public class TraktCollectionMovie
    {
        [JsonProperty(PropertyName = "collected_at")]
        public DateTime CollectedAt { get; set; }

        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public TraktMetadata Metadata { get; set; }
    }
}
