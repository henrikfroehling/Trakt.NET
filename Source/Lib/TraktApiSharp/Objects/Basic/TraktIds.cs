﻿namespace TraktApiSharp.Objects.Basic
{
    using Newtonsoft.Json;

    /// <summary>A collection of ids for various web services, including the Trakt id.</summary>
    public class TraktIds
    {
        /// <summary>Gets or sets the Trakt numeric id.</summary>
        [JsonProperty(PropertyName = "trakt")]
        public int Trakt { get; set; }

        /// <summary>Gets or sets the Trakt slug.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        /// <summary>Gets or sets the numeric id from thetvdb.com</summary>
        [JsonProperty(PropertyName = "tvdb")]
        public int? Tvdb { get; set; }

        /// <summary>Gets or sets the id from imdb.com<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "imdb")]
        public string Imdb { get; set; }

        /// <summary>Gets or sets the numeric id from themoviedb.org</summary>
        [JsonProperty(PropertyName = "tmdb")]
        public int? Tmdb { get; set; }

        /// <summary>Gets or sets the numeric id from tvrage.com</summary>
        [JsonProperty(PropertyName = "tvrage")]
        public int? TvRage { get; set; }

        /// <summary>Returns, whether any id has been set.</summary>
        [JsonIgnore]
        public bool HasAnyId => Trakt > 0 || !string.IsNullOrEmpty(Slug) || Tvdb > 0 || !string.IsNullOrEmpty(Imdb) || Tmdb > 0 || TvRage > 0;

        /// <summary>Gets the most reliable id from those that have been set.</summary>
        /// <returns>The id as a string or an empty string, if no id is set.</returns>
        public string GetBestId()
        {
            if (Trakt > 0)
                return Trakt.ToString();

            if (!string.IsNullOrEmpty(Slug))
                return Slug;

            if (Tvdb.HasValue && Tvdb.Value > 0)
                return Tvdb.Value.ToString();

            if (!string.IsNullOrEmpty(Imdb))
                return Imdb;

            if (Tmdb.HasValue && Tmdb.Value > 0)
                return Tmdb.Value.ToString();

            if (TvRage.HasValue && TvRage.Value > 0)
                return TvRage.Value.ToString();

            return string.Empty;
        }
    }
}
