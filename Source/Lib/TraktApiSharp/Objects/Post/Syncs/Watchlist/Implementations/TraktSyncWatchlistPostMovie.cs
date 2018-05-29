namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using Get.Movies;

    /// <summary>A Trakt watchlist post movie, containing the required movie ids.</summary>
    public class TraktSyncWatchlistPostMovie : ITraktSyncWatchlistPostMovie
    {
        /// <summary>Gets or sets the optional title of the Trakt movie.<para>Nullable</para></summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt movie.</summary>
        public int? Year { get; set; }

        /// <summary>Gets or sets the required movie ids. See also <seealso cref="ITraktMovieIds" />.</summary>
        public ITraktMovieIds Ids { get; set; }
    }
}
