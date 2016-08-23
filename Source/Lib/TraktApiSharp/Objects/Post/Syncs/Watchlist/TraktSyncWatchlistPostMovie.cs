namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using Attributes;
    using Get.Movies;
    using Newtonsoft.Json;

    /// <summary>A Trakt watchlist post movie, containing the required movie ids.</summary>
    public class TraktSyncWatchlistPostMovie
    {
        /// <summary>Gets or sets the optional title of the Trakt movie.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "title")]
        [Nullable]
        public string Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt movie.</summary>
        [JsonProperty(PropertyName = "year")]
        public int? Year { get; set; }

        /// <summary>Gets or sets the required movie ids. See also <seealso cref="TraktMovieIds" />.</summary>
        [JsonProperty(PropertyName = "ids")]
        public TraktMovieIds Ids { get; set; }
    }
}
