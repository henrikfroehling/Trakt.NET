namespace TraktNet.Objects.Post.Syncs.Favorites
{
    using Get.Shows;

    /// <summary>A Trakt favorites post show, containing the required show ids and optional show title, year and notes.</summary>
    public class TraktSyncFavoritesPostShow : ITraktSyncFavoritesPostShow
    {
        /// <summary>Gets or sets the optional title of the Trakt show.<para>Nullable</para></summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt show.</summary>
        public int? Year { get; set; }

        /// <summary>Gets or sets the required show ids. See also <seealso cref="ITraktShowIds" />.</summary>
        public ITraktShowIds Ids { get; set; }

        /// <summary>Gets or sets the optional notes for the Trakt show.</summary>
        public string Notes { get; set; }
    }
}
