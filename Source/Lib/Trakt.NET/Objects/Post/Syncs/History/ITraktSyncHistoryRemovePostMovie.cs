namespace TraktNet.Objects.Post.Syncs.History
{
    using Get.Movies;

    /// <summary>A Trakt history remove post movie, containing the required movie ids.</summary>
    public interface ITraktSyncHistoryRemovePostMovie
    {
        /// <summary>Gets or sets the optional title of the Trakt movie.<para>Nullable</para></summary>
        string Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt movie.</summary>
        int? Year { get; set; }

        /// <summary>Gets or sets the required movie ids. See also <seealso cref="ITraktMovieIds" />.</summary>
        ITraktMovieIds Ids { get; set; }
    }
}
