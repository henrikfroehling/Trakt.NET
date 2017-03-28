namespace TraktApiSharp.Objects.Get.Shows.Seasons
{
    using Attributes;
    using Episodes;
    using Modules;
    using Newtonsoft.Json;
    using Requests.Params;
    using System;
    using System.Collections.Generic;

    /// <summary>A Trakt season of a Trakt show.</summary>
    public class TraktSeason
    {
        /// <summary>Gets or sets the season number.</summary>
        [JsonProperty(PropertyName = "number")]
        public int? Number { get; set; }

        /// <summary>
        /// Gets or sets the collection of ids for the season for various web services.
        /// See also <seealso cref="TraktSeasonIds" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "ids")]
        [Nullable]
        public TraktSeasonIds Ids { get; set; }

        /// <summary>
        /// Gets or sets the title of the season.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        [Nullable]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the collection of images for the season.
        /// See also <seealso cref="TraktSeasonImages" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "images")]
        [Nullable]
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

        /// <summary>Gets or sets the synopsis of the season.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "overview")]
        [Nullable]
        public string Overview { get; set; }

        /// <summary>Gets or sets the UTC datetime when the season was first aired.</summary>
        [JsonProperty(PropertyName = "first_aired")]
        public DateTime? FirstAired { get; set; }

        /// <summary>Gets or sets the collection of Trakt episodes in the season. See also <seealso cref="TraktEpisode" />.<para>Nullable</para></summary>
        /// <remarks>
        /// This property is set automatically if this season is in a collection
        /// of seasons and this collection was returned by
        /// <see cref="TraktSeasonsModule.GetAllSeasonsAsync(string, TraktExtendedInfo, string)" />
        /// and the optional <see cref="TraktExtendedInfo" /> has
        /// <see cref="TraktExtendedInfo.Episodes" /> set to true.
        /// </remarks>
        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public IEnumerable<TraktEpisode> Episodes { get; set; }
    }
}
