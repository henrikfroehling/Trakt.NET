namespace TraktApiSharp.Objects.Post.Syncs.Ratings
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// A Trakt ratings post episode, containing the required episode number,
    /// an optional rating and an optional datetime, when the episode was rated.
    /// </summary>
    public class TraktSyncRatingsPostShowEpisode
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt episode was rated.</summary>
        [JsonProperty(PropertyName = "rated_at")]
        public DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets an optional rating for the episode.</summary>
        [JsonProperty(PropertyName = "rating")]
        public int? Rating { get; set; }

        /// <summary>Gets or sets the required season number of the Trakt episode.</summary>
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }
    }
}
