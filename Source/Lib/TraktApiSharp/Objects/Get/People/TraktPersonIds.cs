namespace TraktApiSharp.Objects.Get.People
{
    using Newtonsoft.Json;
    using System.Globalization;

    /// <summary>
    /// A collection of ids for various web services for a Trakt person.
    /// </summary>
    public class TraktPersonIds
    {
        /// <summary>
        /// The Trakt numeric id for the person.
        /// </summary>
        [JsonProperty(PropertyName = "trakt")]
        public int Trakt { get; set; }

        /// <summary>
        /// The Trakt slug for the person.
        /// </summary>
        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        /// <summary>
        /// The id for the person from imdb.com
        /// </summary>
        [JsonProperty(PropertyName = "imdb")]
        public string Imdb { get; set; }

        /// <summary>
        /// The numeric id for the person from themoviedb.org
        /// </summary>
        [JsonProperty(PropertyName = "tmdb")]
        public int? Tmdb { get; set; }

        /// <summary>
        /// The numeric id for the person from tvrage.com
        /// </summary>
        [JsonProperty(PropertyName = "tvrage")]
        public int? TvRage { get; set; }

        /// <summary>
        /// Tests, if at least one id has been set.
        /// </summary>
        public bool HasAnyId() => Trakt > 0 || !string.IsNullOrEmpty(Slug) || !string.IsNullOrEmpty(Imdb) || Tmdb > 0 || TvRage > 0;

        /// <summary>
        /// Get the most reliable id from those that have been set for the person.
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
