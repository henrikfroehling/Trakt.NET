namespace TraktApiSharp.Objects.Shows.Seasons
{
    using Newtonsoft.Json;

    /// <summary>
    /// A collection of ids for various web services for a Trakt season.
    /// </summary>
    public class TraktSeasonIds
    {
        /// <summary>
        /// The Trakt numeric id for the season.
        /// </summary>
        [JsonProperty(PropertyName = "trakt")]
        public int Trakt { get; set; }

        /// <summary>
        /// The numeric id for the season from thetvdb.com
        /// </summary>
        [JsonProperty(PropertyName = "tvdb")]
        public int? Tvdb { get; set; }

        /// <summary>
        /// The numeric id for the season from themoviedb.org
        /// </summary>
        [JsonProperty(PropertyName = "tmdb")]
        public int? Tmdb { get; set; }

        /// <summary>
        /// The numeric id for the season from tvrage.com
        /// </summary>
        [JsonProperty(PropertyName = "tvrage")]
        public int? TvRage { get; set; }

        /// <summary>
        /// Tests, if at least one id has been set.
        /// </summary>
        public bool HasAnyId => Trakt > 0 || Tvdb > 0 || Tvdb > 0 || TvRage > 0;
    }
}
