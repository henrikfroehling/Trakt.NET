namespace TraktApiSharp.Objects.Get.Shows.Episodes
{
    using Attributes;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>A Trakt episode of a Trakt season.</summary>
    public class TraktEpisode
    {
        /// <summary>Gets or sets the season number in which the episode was aired.</summary>
        [JsonProperty(PropertyName = "season")]
        public int? SeasonNumber { get; set; }

        /// <summary>Gets or sets the episode number within the season to which it belongs.</summary>
        [JsonProperty(PropertyName = "number")]
        public int? Number { get; set; }

        /// <summary>Gets or sets the episode title.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "title")]
        [Nullable]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the collection of ids for the episode for various web services.
        /// See also <seealso cref="TraktEpisodeIds" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "ids")]
        [Nullable]
        public TraktEpisodeIds Ids { get; set; }

        /// <summary>
        /// Gets or sets the collection of images for the episode.
        /// See also <seealso cref="TraktEpisodeImages" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "images")]
        [Nullable]
        public TraktEpisodeImages Images { get; set; }

        /// <summary>Gets or sets the absolute episode number of all episodes in all seasons.</summary>
        [JsonProperty(PropertyName = "number_abs")]
        public int? NumberAbsolute { get; set; }

        /// <summary>Gets or sets the synopsis of the episode.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "overview")]
        [Nullable]
        public string Overview { get; set; }

        /// <summary>Gets or sets the average user rating of the episode.</summary>
        [JsonProperty(PropertyName = "rating")]
        public float? Rating { get; set; }

        /// <summary>Gets or sets the number of votes for the episode.</summary>
        [JsonProperty(PropertyName = "votes")]
        public int? Votes { get; set; }

        /// <summary>Gets or sets the UTC datetime when the episode was first aired.</summary>
        [JsonProperty(PropertyName = "first_aired")]
        public DateTime? FirstAired { get; set; }

        /// <summary>Gets or sets the UTC datetime when the episode was last updated.</summary>
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the list of translation language codes (two letters) for the episode.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "available_translations")]
        [Nullable]
        public IEnumerable<string> AvailableTranslationLanguageCodes { get; set; }
    }
}
