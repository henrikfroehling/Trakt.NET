namespace TraktApiSharp.Objects.Post.Syncs.Ratings
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncRatingsPost
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktSyncRatingsPostMovieItem> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktSyncRatingsPostShowItem> Shows { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncRatingsPostEpisodeItem> Episodes { get; set; }
    }
}
