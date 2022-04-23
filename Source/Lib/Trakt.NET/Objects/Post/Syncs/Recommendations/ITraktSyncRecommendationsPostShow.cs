namespace TraktNet.Objects.Post.Syncs.Recommendations
{
    using Get.Shows;

    /// <summary>A Trakt recommendation post show, containing the required show ids and optional show title, year and notes.</summary>
    public interface ITraktSyncRecommendationsPostShow
    {
        /// <summary>Gets or sets the optional title of the Trakt show.<para>Nullable</para></summary>
        string Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt show.</summary>
        int? Year { get; set; }

        /// <summary>Gets or sets the required show ids. See also <seealso cref="ITraktShowIds" />.</summary>
        ITraktShowIds Ids { get; set; }

        /// <summary>Gets or sets the optional notes for the Trakt show.</summary>
        string Notes { get; set; }
    }
}
