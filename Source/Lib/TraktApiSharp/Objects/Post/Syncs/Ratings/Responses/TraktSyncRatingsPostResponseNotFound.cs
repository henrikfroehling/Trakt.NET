namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses
{
    using Attributes;
    using Get.Movies;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Get.Shows.Seasons;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncRatingsPostResponseNotFound
    {
        [JsonProperty(PropertyName = "movies")]
        [Nullable]
        public IEnumerable<TraktSyncRatingsPostResponseNotFoundItem<TraktMovieIds>> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        [Nullable]
        public IEnumerable<TraktSyncRatingsPostResponseNotFoundItem<TraktShowIds>> Shows { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        [Nullable]
        public IEnumerable<TraktSyncRatingsPostResponseNotFoundItem<TraktSeasonIds>> Seasons { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public IEnumerable<TraktSyncRatingsPostResponseNotFoundItem<TraktEpisodeIds>> Episodes { get; set; }
    }
}
