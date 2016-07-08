namespace TraktApiSharp.Objects.Get.Shows.Episodes
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt episode of a Trakt season.
    /// </summary>
    public class TraktEpisode
    {
        #region Minimal Info

        /// <summary>
        /// The season number in which the episode was aired.
        /// </summary>
        [JsonProperty(PropertyName = "season")]
        public int? SeasonNumber { get; set; }

        /// <summary>
        /// The episode number within the season to which it belongs.
        /// </summary>
        [JsonProperty(PropertyName = "number")]
        public int? Number { get; set; }

        /// <summary>
        /// The episode title.
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// A collection of ids for the episode for various web services.
        /// </summary>
        [JsonProperty(PropertyName = "ids")]
        public TraktEpisodeIds Ids { get; set; }

        #endregion

        #region Images

        /// <summary>
        /// A collection of images for the episode.
        /// </summary>
        [JsonProperty(PropertyName = "images")]
        public TraktEpisodeImages Images { get; set; }

        #endregion

        #region Full (additional info)

        /// <summary>
        /// The absolute episode number of all episodes in all seasons.
        /// </summary>
        [JsonProperty(PropertyName = "number_abs")]
        public int? NumberAbsolute { get; set; }

        /// <summary>
        /// A synopsis of the episode.
        /// </summary>
        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }

        /// <summary>
        /// The average user rating of the episode.
        /// </summary>
        [JsonProperty(PropertyName = "rating")]
        public float? Rating { get; set; }

        /// <summary>
        /// The number of votes for the episode.
        /// </summary>
        [JsonProperty(PropertyName = "votes")]
        public int? Votes { get; set; }

        /// <summary>
        /// The UTC date when the episode was first aired.
        /// </summary>
        [JsonProperty(PropertyName = "first_aired")]
        public DateTime? FirstAired { get; set; }

        /// <summary>
        /// The UTC date when the episode was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// A list of translation language codes (two letters) for the episode.
        /// </summary>
        [JsonProperty(PropertyName = "available_translations")]
        public IEnumerable<string> AvailableTranslationLanguageCodes { get; set; }

        #endregion
    }
}
