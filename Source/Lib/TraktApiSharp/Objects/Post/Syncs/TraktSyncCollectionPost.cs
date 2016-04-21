namespace TraktApiSharp.Objects.Post.Syncs
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncCollectionPost
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktSyncCollectionPostMovieItem> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktSyncCollectionPostShowItem> Shows { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncCollectionPostEpisodeItem> Episodes { get; set; }
    }
}
