namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses
{
    using Get.Movies;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Get.Shows.Seasons;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncRatingsPostResponseNotFound
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktSyncRatingsPostResponseNotFoundItem<TraktMovieIds>> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktSyncRatingsPostResponseNotFoundItem<TraktShowIds>> Shows { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<TraktSyncRatingsPostResponseNotFoundItem<TraktSeasonIds>> Seasons { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncRatingsPostResponseNotFoundItem<TraktEpisodeIds>> Episodes { get; set; }
    }
}
