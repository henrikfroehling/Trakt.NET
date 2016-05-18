namespace TraktApiSharp.Objects.Basic
{
    using Newtonsoft.Json;
    using System.Globalization;

    /// <summary>
    /// A collection of ids for various web services, including the Trakt id.
    /// </summary>
    public class TraktIds
    {
        /// <summary>
        /// The Trakt numeric id for an item.
        /// </summary>
        [JsonProperty(PropertyName = "trakt")]
        public int Trakt { get; set; }

        /// <summary>
        /// The Trakt slug for an item.
        /// </summary>
        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        /// <summary>
        /// The numeric id for an item from thetvdb.com
        /// </summary>
        [JsonProperty(PropertyName = "tvdb")]
        public int? Tvdb { get; set; }

        /// <summary>
        /// The id for an item from imdb.com
        /// </summary>
        [JsonProperty(PropertyName = "imdb")]
        public string Imdb { get; set; }

        /// <summary>
        /// The numeric id for an item from themoviedb.org
        /// </summary>
        [JsonProperty(PropertyName = "tmdb")]
        public int? Tmdb { get; set; }

        /// <summary>
        /// The numeric id for an item from tvrage.com
        /// </summary>
        [JsonProperty(PropertyName = "tvrage")]
        public int? TvRage { get; set; }

        /// <summary>
        /// Tests, if at least one id has been set.
        /// </summary>
        [JsonIgnore]
        public bool HasAnyId => Trakt > 0 || !string.IsNullOrEmpty(Slug) || Tvdb > 0 || !string.IsNullOrEmpty(Imdb) || Tmdb > 0 || TvRage > 0;

        /// <summary>
        /// Get the most reliable id from those that have been set for an item.
        /// </summary>
        /// <returns>The id as a string.</returns>
        public string GetBestId()
        {
            if (Trakt > 0)
                return Trakt.ToString(CultureInfo.InvariantCulture);

            if (!string.IsNullOrEmpty(Slug))
                return Slug;

            if (!string.IsNullOrEmpty(Imdb))
                return Imdb;

            return string.Empty;
        }
    }
}
