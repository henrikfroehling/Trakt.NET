namespace TraktNet.Objects.Post.Syncs.History
{
    using Get.Seasons;

    /// <summary>A Trakt history remove post season, containing the required season ids.</summary>
    public interface ITraktSyncHistoryRemovePostSeason
    {
        /// <summary>Gets or sets the required season ids. See also <seealso cref="ITraktSeasonIds" />.</summary>
        ITraktSeasonIds Ids { get; set; }
    }
}
