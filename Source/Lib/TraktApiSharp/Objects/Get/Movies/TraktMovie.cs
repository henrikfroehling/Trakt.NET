namespace TraktApiSharp.Objects.Get.Movies
{
    using Attributes;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>A Trakt movie.</summary>
    public class TraktMovie
    {
        /// <summary>Gets or sets the movie title.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "title")]
        [Nullable]
        public string Title { get; set; }

        /// <summary>Gets or sets the movie release year.</summary>
        [JsonProperty(PropertyName = "year")]
        public int? Year { get; set; }

        /// <summary>
        /// Gets or sets the collection of ids for the movie for various web services.
        /// See also <seealso cref="TraktMovieIds" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "ids")]
        [Nullable]
        public TraktMovieIds Ids { get; set; }

        /// <summary>
        /// Gets or sets the collection of images and image sets for the movie.
        /// See also <seealso cref="TraktMovieImages" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "images")]
        [Nullable]
        public TraktMovieImages Images { get; set; }

        /// <summary>Gets or sets the movie tagline.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "tagline")]
        [Nullable]
        public string Tagline { get; set; }

        /// <summary>Gets or sets the synopsis of the movie.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "overview")]
        [Nullable]
        public string Overview { get; set; }

        /// <summary>Gets or sets the UTC datetime when the movie was released.</summary>
        [JsonProperty(PropertyName = "released")]
        public DateTime? Released { get; set; }

        /// <summary>Gets or sets the runtime for the movie.</summary>
        [JsonProperty(PropertyName = "runtime")]
        public int? Runtime { get; set; }

        /// <summary>Gets or sets the web address of a trailer for the movie.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "trailer")]
        [Nullable]
        public string Trailer { get; set; }

        /// <summary>Gets or sets the web address of the homepage of the movie.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "homepage")]
        [Nullable]
        public string Homepage { get; set; }

        /// <summary>Gets or sets the average user rating of the movie.</summary>
        [JsonProperty(PropertyName = "rating")]
        public float? Rating { get; set; }

        /// <summary>Gets or sets the number of votes for the movie.</summary>
        [JsonProperty(PropertyName = "votes")]
        public int? Votes { get; set; }

        /// <summary>Gets or sets the UTC datetime when the movie was last updated.</summary>
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the two letter language code of the movie.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "language")]
        [Nullable]
        public string LanguageCode { get; set; }

        /// <summary>Gets or sets the list of translation language codes (two letters) for the movie.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "available_translations")]
        [Nullable]
        public IEnumerable<string> AvailableTranslationLanguageCodes { get; set; }

        /// <summary>Gets or sets the collection of Trakt genre slugs for the movie.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "genres")]
        [Nullable]
        public IEnumerable<string> Genres { get; set; }

        /// <summary>Gets or sets the content certification of the movie.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "certification")]
        [Nullable]
        public string Certification { get; set; }
    }
}
