namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using Get.Movies;
    using Newtonsoft.Json;

    public class TraktSyncWatchlistPostMovie
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int? Year { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public TraktMovieIds Ids { get; set; }
    }
}
