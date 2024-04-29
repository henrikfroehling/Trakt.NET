namespace TraktNet.Objects.Post.Syncs.Favorites
{
    using Get.Movies;

    /// <summary>A Trakt favorites post movie, containing the required movie ids and optional movie title, year and notes.</summary>
    public class TraktSyncFavoritesPostMovie : ITraktSyncFavoritesPostMovie
    {
        /// <summary>Gets or sets the optional title of the Trakt movie.<para>Nullable</para></summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt movie.</summary>
        public int? Year { get; set; }

        /// <summary>Gets or sets the required movie ids. See also <seealso cref="ITraktMovieIds" />.</summary>
        public ITraktMovieIds Ids { get; set; }

        /// <summary>Gets or sets the optional notes for the Trakt movie.</summary>
        public string Notes { get; set; }
    }
}
