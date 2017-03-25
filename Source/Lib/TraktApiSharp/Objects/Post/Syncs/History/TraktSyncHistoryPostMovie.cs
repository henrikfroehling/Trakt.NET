namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Get.Movies;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Objects.Get.Movies.Implementations;

    /// <summary>
    /// A Trakt history post movie, containing the required movie ids
    /// and an optional datetime, when the movie was watched.
    /// </summary>
    public class TraktSyncHistoryPostMovie
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt movie was watched.</summary>
        [JsonProperty(PropertyName = "watched_at")]
        public DateTime? WatchedAt { get; set; }

        /// <summary>Gets or sets the optional title of the Trakt movie.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt movie.</summary>
        [JsonProperty(PropertyName = "year")]
        public int? Year { get; set; }

        /// <summary>Gets or sets the required movie ids. See also <seealso cref="TraktMovieIds" />.</summary>
        [JsonProperty(PropertyName = "ids")]
        public TraktMovieIds Ids { get; set; }
    }
}
