namespace TraktNet.Objects.Post.Syncs.History
{
    using TraktNet.Objects.Get.Seasons;

    /// <summary>A Trakt history remove post season, containing the required season ids.</summary>
    public class TraktSyncHistoryRemovePostSeason : ITraktSyncHistoryRemovePostSeason
    {
        /// <summary>Gets or sets the required season ids. See also <seealso cref="ITraktSeasonIds" />.</summary>
        public ITraktSeasonIds Ids { get; set; }
    }
}
