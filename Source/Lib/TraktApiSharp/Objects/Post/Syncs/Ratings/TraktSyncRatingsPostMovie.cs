namespace TraktApiSharp.Objects.Post.Syncs.Ratings
{
    using Attributes;
    using Get.Movies;
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// A Trakt ratings post movie, containing the required movie ids,
    /// an optional rating and an optional datetime, when the movie was rated.
    /// </summary>
    public class TraktSyncRatingsPostMovie
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt movie was rated.</summary>
        [JsonProperty(PropertyName = "rated_at")]
        public DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets an optional rating for the movie.</summary>
        [JsonProperty(PropertyName = "rating")]
        public int? Rating { get; set; }

        /// <summary>Gets or sets the optional title of the Trakt movie.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "title")]
        [Nullable]
        public string Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt movie.</summary>
        [JsonProperty(PropertyName = "year")]
        public int? Year { get; set; }

        /// <summary>Gets or sets the required movie ids. See also <seealso cref="TraktMovieIds" />.</summary>
        [JsonProperty(PropertyName = "ids")]
        public TraktMovieIds Ids { get; set; }
    }
}
