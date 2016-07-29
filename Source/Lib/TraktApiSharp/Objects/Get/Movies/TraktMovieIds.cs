namespace TraktApiSharp.Objects.Get.Movies
{
    using Newtonsoft.Json;
    using System.Globalization;

    /// <summary>A collection of ids for various web services, including the Trakt id, for a Trakt movie.</summary>
    public class TraktMovieIds
    {
        /// <summary>Gets or sets the Trakt numeric id.</summary>
        [JsonProperty(PropertyName = "trakt")]
        public int Trakt { get; set; }

        /// <summary>Gets or sets the Trakt slug.</summary>
        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        /// <summary>Gets or sets the id from imdb.com</summary>
        [JsonProperty(PropertyName = "imdb")]
        public string Imdb { get; set; }

        /// <summary>Gets or sets the numeric id from themoviedb.org</summary>
        [JsonProperty(PropertyName = "tmdb")]
        public int? Tmdb { get; set; }

        /// <summary>Returns, whether any id has been set.</summary>
        [JsonIgnore]
        public bool HasAnyId => Trakt > 0 || !string.IsNullOrEmpty(Slug) || !string.IsNullOrEmpty(Imdb) || Tmdb > 0;

        /// <summary>Gets the most reliable id from those that have been set.</summary>
        /// <returns>The id as a string or an empty string, if no id is set.</returns>
        public string GetBestId()
        {
            if (Trakt > 0)
                return Trakt.ToString(CultureInfo.InvariantCulture);

            if (!string.IsNullOrEmpty(Slug))
                return Slug;

            if (!string.IsNullOrEmpty(Imdb))
                return Imdb;

            if (Tmdb.HasValue && Tmdb.Value > 0)
                return Tmdb.Value.ToString();

            return string.Empty;
        }
    }
}
