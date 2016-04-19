namespace TraktApiSharp.Objects.Get.Shows.Seasons
{
    using Episodes;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt season of a Trakt show.
    /// </summary>
    public class TraktSeason
    {
        #region Minimal Info

        /// <summary>
        /// The season number.
        /// </summary>
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        /// <summary>
        /// A collection of ids for the season for various web services.
        /// </summary>
        [JsonProperty(PropertyName = "ids")]
        public TraktSeasonIds Ids { get; set; }

        #endregion

        #region Images

        /// <summary>
        /// A collection of images for the season.
        /// </summary>
        [JsonProperty(PropertyName = "images")]
        public TraktSeasonImages Images { get; set; }

        #endregion

        #region Full (additional info)

        /// <summary>
        /// The average user rating of the season.
        /// </summary>
        [JsonProperty(PropertyName = "rating")]
        public decimal? Rating { get; set; }

        /// <summary>
        /// The number of votes for the season.
        /// </summary>
        [JsonProperty(PropertyName = "votes")]
        public int? Votes { get; set; }

        /// <summary>
        /// The number of episodes in the season.
        /// </summary>
        [JsonProperty(PropertyName = "episode_count")]
        public int? TotalEpisodesCount { get; set; }

        /// <summary>
        /// The number of aired episodes in the season.
        /// </summary>
        [JsonProperty(PropertyName = "aired_episodes")]
        public int? AiredEpisodesCount { get; set; }

        /// <summary>
        /// A synopsis of the season.
        /// </summary>
        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }

        /// <summary>
        /// The UTC date when the season was first aired.
        /// </summary>
        [JsonProperty(PropertyName = "first_aired")]
        public DateTime? FirstAired { get; set; }

        #endregion

        #region Episodes

        /// <summary>
        /// A collection of Trakt episodes in the season.
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktEpisode> Episodes { get; set; }

        #endregion
    }
}
