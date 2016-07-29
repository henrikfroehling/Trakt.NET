namespace TraktApiSharp.Objects.Get.Shows.Seasons
{
    using Newtonsoft.Json;

    /// <summary>A collection of ids for various web services, including the Trakt id, for a Trakt season.</summary>
    public class TraktSeasonIds
    {
        /// <summary>Gets or sets the Trakt numeric id.</summary>
        [JsonProperty(PropertyName = "trakt")]
        public int Trakt { get; set; }

        /// <summary>Gets or sets the numeric id from thetvdb.com</summary>
        [JsonProperty(PropertyName = "tvdb")]
        public int? Tvdb { get; set; }

        /// <summary>Gets or sets the numeric id from themoviedb.org</summary>
        [JsonProperty(PropertyName = "tmdb")]
        public int? Tmdb { get; set; }

        /// <summary>Gets or sets the numeric id from tvrage.com</summary>
        [JsonProperty(PropertyName = "tvrage")]
        public int? TvRage { get; set; }

        /// <summary>Returns, whether any id has been set.</summary>
        [JsonIgnore]
        public bool HasAnyId => Trakt > 0 || Tvdb > 0 || Tvdb > 0 || TvRage > 0;
    }
}
