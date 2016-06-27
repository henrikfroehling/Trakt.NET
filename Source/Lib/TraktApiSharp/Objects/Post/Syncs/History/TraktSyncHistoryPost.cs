namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncHistoryPost
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktSyncHistoryPostMovieItem> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktSyncHistoryPostShowItem> Shows { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncHistoryPostEpisodeItem> Episodes { get; set; }
    }
}
