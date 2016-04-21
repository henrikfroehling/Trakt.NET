namespace TraktApiSharp.Objects.Post.Syncs.Collection
{
    using Get.Shows;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncCollectionPostShowItem
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public TraktShowIds Ids { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<TraktSyncCollectionPostShowSeasonItem> Seasons { get; set; }
    }
}
