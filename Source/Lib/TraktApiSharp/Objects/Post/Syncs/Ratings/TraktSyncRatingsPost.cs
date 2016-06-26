namespace TraktApiSharp.Objects.Post.Syncs.Ratings
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncRatingsPost
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktSyncRatingsPostMovie> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktSyncRatingsPostShow> Shows { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncRatingsPostEpisode> Episodes { get; set; }
    }
}
