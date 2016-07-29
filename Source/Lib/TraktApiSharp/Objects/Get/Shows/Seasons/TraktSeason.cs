namespace TraktApiSharp.Objects.Get.Shows.Seasons
{
    using Episodes;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>A Trakt season of a Trakt show.</summary>
    public class TraktSeason
    {
        /// <summary>Gets or sets the season number.</summary>
        [JsonProperty(PropertyName = "number")]
        public int? Number { get; set; }

        /// <summary>Gets or sets the collection of ids for the season for various web services.</summary>
        [JsonProperty(PropertyName = "ids")]
        public TraktSeasonIds Ids { get; set; }

        /// <summary>Gets or sets the collection of images for the season.</summary>
        [JsonProperty(PropertyName = "images")]
        public TraktSeasonImages Images { get; set; }

        /// <summary>Gets or sets the average user rating of the season.</summary>
        [JsonProperty(PropertyName = "rating")]
        public float? Rating { get; set; }

        /// <summary>Gets or sets the number of votes for the season.</summary>
        [JsonProperty(PropertyName = "votes")]
        public int? Votes { get; set; }

        /// <summary>Gets or sets the number of episodes in the season.</summary>
        [JsonProperty(PropertyName = "episode_count")]
        public int? TotalEpisodesCount { get; set; }

        /// <summary>Gets or sets the number of aired episodes in the season.</summary>
        [JsonProperty(PropertyName = "aired_episodes")]
        public int? AiredEpisodesCount { get; set; }

        /// <summary>Gets or sets the synopsis of the season.</summary>
        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }

        /// <summary>Gets or sets the UTC datetime when the season was first aired.</summary>
        [JsonProperty(PropertyName = "first_aired")]
        public DateTime? FirstAired { get; set; }

        /// <summary>Gets or sets the collection of Trakt episodes in the season.</summary>
        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktEpisode> Episodes { get; set; }
    }
}
