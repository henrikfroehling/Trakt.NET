namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using Get.Episodes;

    public interface ITraktSyncWatchlistPostEpisode
    {
        ITraktEpisodeIds Ids { get; set; }
    }
}
