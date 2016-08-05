namespace TraktApiSharp.Objects.Post.Syncs.Responses
{
    using Attributes;
    using Get.Movies;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Get.Shows.Seasons;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncPostResponseNotFound
    {
        [JsonProperty(PropertyName = "movies")]
        [Nullable]
        public IEnumerable<TraktSyncPostResponseNotFoundItem<TraktMovieIds>> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        [Nullable]
        public IEnumerable<TraktSyncPostResponseNotFoundItem<TraktShowIds>> Shows { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        [Nullable]
        public IEnumerable<TraktSyncPostResponseNotFoundItem<TraktSeasonIds>> Seasons { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public IEnumerable<TraktSyncPostResponseNotFoundItem<TraktEpisodeIds>> Episodes { get; set; }
    }
}
