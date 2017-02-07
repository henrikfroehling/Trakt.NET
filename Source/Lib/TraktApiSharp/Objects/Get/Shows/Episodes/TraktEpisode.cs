namespace TraktApiSharp.Objects.Get.Shows.Episodes
{
    using Modules;
    using Newtonsoft.Json;
    using Requests.Parameters;
    using Shows.Seasons;
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
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the collection of ids for the episode for various web services.
        /// See also <seealso cref="TraktEpisodeIds" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "ids")]
        public TraktEpisodeIds Ids { get; set; }

        /// <summary>
        /// Gets or sets the collection of images for the episode.
        /// See also <seealso cref="TraktEpisodeImages" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "images")]
        public TraktEpisodeImages Images { get; set; }

        /// <summary>Gets or sets the absolute episode number of all episodes in all seasons.</summary>
        [JsonProperty(PropertyName = "number_abs")]
        public int? NumberAbsolute { get; set; }

        /// <summary>Gets or sets the synopsis of the episode.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }

        /// <summary>Gets or sets the runtime of the episode.</summary>
        [JsonProperty(PropertyName = "runtime")]
        public int? Runtime { get; set; }

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
        public IEnumerable<string> AvailableTranslationLanguageCodes { get; set; }

        /// <summary>Gets or sets the list of <see cref="TraktEpisodeTranslation" />s for the episode.<para>Nullable</para></summary>
        /// <seealso cref="TraktSeason.Episodes" />
        /// <remarks>
        /// This property is set automatically if this episode is in a
        /// <see cref="TraktSeason.Episodes" /> collection and the episode's season
        /// is in a collection of seasons returned by
        /// <see cref="TraktSeasonsModule.GetAllSeasonsAsync(string, TraktExtendedInfo, string)" />
        /// and a translation language code was specified.
        /// This property is also set automatically if this episode is in
        /// a collection returned by <see cref="TraktSeasonsModule.GetSeasonAsync(string, uint, TraktExtendedInfo, string)" />
        /// and a translation language code was specified.
        /// </remarks>
        [JsonProperty(PropertyName = "translations")]
        public IEnumerable<TraktEpisodeTranslation> Translations { get; set; }
    }
}
