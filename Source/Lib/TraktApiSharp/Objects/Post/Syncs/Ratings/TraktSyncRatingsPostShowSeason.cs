namespace TraktApiSharp.Objects.Post.Syncs.Ratings
{
    using Attributes;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt ratings post season, containing the required season number and optional episodes,
    /// an optional rating and an optional datetime, when the season was rated.
    /// </summary>
    public class TraktSyncRatingsPostShowSeason
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt season was rated.</summary>
        [JsonProperty(PropertyName = "rated_at")]
        public DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets an optional rating for the season.</summary>
        [JsonProperty(PropertyName = "rating")]
        public int? Rating { get; set; }

        /// <summary>Gets or sets the required season number of the Trakt season.</summary>
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncRatingsPostShowEpisode" />s.
        /// <para>
        /// If no episodes are set, the whole Trakt season will be added to the ratings.
        /// Otherwise, only the specified episodes will be added to the ratings.
        /// </para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public IEnumerable<TraktSyncRatingsPostShowEpisode> Episodes { get; set; }
    }
}
