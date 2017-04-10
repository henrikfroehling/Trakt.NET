namespace TraktApiSharp.Objects.Get.Movies.Implementations
{
    using Enums;
    using Newtonsoft.Json;
    using System;

    /// <summary>A release of a Trakt movie.</summary>
    public class TraktMovieRelease : ITraktMovieRelease
    {
        /// <summary>Gets or sets the two letter country code for the movie release.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "country")]
        public string CountryCode { get; set; }

        /// <summary>Gets or sets the content certification for the movie release.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "certification")]
        public string Certification { get; set; }

        /// <summary>Gets or sets the release date of the movie release.</summary>
        [JsonProperty(PropertyName = "release_date")]
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the release type for the movie release.
        /// See also <seealso cref="TraktReleaseType" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "release_type")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktReleaseType>))]
        public TraktReleaseType ReleaseType { get; set; }

        /// <summary>Gets or sets a note for the movie release.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }
    }
}
