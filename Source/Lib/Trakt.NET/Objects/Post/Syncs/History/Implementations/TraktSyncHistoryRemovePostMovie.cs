namespace TraktNet.Objects.Post.Syncs.History
{
    using TraktNet.Objects.Get.Movies;

    /// <summary>A Trakt history remove post movie, containing the required movie ids.</summary>
    public class TraktSyncHistoryRemovePostMovie : ITraktSyncHistoryRemovePostMovie
    {
        /// <summary>Gets or sets the optional title of the Trakt movie.<para>Nullable</para></summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt movie.</summary>
        public int? Year { get; set; }

        /// <summary>Gets or sets the required movie ids. See also <seealso cref="ITraktMovieIds" />.</summary>
        public ITraktMovieIds Ids { get; set; }
    }
}
