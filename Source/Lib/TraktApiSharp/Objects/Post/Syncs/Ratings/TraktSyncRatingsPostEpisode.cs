namespace TraktApiSharp.Objects.Post.Syncs.Ratings
{
    using Get.Shows.Episodes;
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// A Trakt ratings post episode, containing the required episode ids,
    /// an optional rating and an optional datetime, when the episode was rated.
    /// </summary>
    public class TraktSyncRatingsPostEpisode
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt episode was rated.</summary>
        [JsonProperty(PropertyName = "rated_at")]
        public DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets an optional rating for the episode.</summary>
        [JsonProperty(PropertyName = "rating")]
        public int? Rating { get; set; }

        /// <summary>Gets or sets the required episode ids. See also <seealso cref="TraktEpisodeIds" />.</summary>
        [JsonProperty(PropertyName = "ids")]
        public TraktEpisodeIds Ids { get; set; }
    }
}
