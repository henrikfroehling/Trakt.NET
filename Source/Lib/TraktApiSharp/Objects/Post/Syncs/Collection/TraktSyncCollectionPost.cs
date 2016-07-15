namespace TraktApiSharp.Objects.Post.Syncs.Collection
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncCollectionPost
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktSyncCollectionPostMovie> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktSyncCollectionPostShow> Shows { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncCollectionPostEpisode> Episodes { get; set; }
    }
}
