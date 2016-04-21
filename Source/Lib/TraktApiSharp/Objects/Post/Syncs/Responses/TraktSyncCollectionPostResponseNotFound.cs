namespace TraktApiSharp.Objects.Post.Syncs.Responses
{
    using Get.Movies;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Get.Shows.Seasons;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncCollectionPostResponseNotFound
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktMovieIds> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktShowIds> Shows { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<TraktSeasonIds> Seasons { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktEpisodeIds> Episodes { get; set; }
    }
}
