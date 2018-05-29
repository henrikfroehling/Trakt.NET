namespace TraktApiSharp.Objects.Post.Syncs.History
{
    using Get.Movies;
    using System;

    /// <summary>
    /// A Trakt history post movie, containing the required movie ids
    /// and an optional datetime, when the movie was watched.
    /// </summary>
    public class TraktSyncHistoryPostMovie : ITraktSyncHistoryPostMovie
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt movie was watched.</summary>
        public DateTime? WatchedAt { get; set; }

        /// <summary>Gets or sets the optional title of the Trakt movie.<para>Nullable</para></summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt movie.</summary>
        public int? Year { get; set; }

        /// <summary>Gets or sets the required movie ids. See also <seealso cref="ITraktMovieIds" />.</summary>
        public ITraktMovieIds Ids { get; set; }
    }
}
