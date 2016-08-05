namespace TraktApiSharp.Objects.Post.Syncs.Collection
{
    using Attributes;
    using Basic;
    using Get.Movies;
    using Newtonsoft.Json;
    using System;

    public class TraktSyncCollectionPostMovie
    {
        [JsonProperty(PropertyName = "collected_at")]
        public DateTime? CollectedAt { get; set; }

        [JsonProperty(PropertyName = "title")]
        [Nullable]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int? Year { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public TraktMovieIds Ids { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        [Nullable]
        public TraktMetadata Metadata { get; set; }
    }
}
