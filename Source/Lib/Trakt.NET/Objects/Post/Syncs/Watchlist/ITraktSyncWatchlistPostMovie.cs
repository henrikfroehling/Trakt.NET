namespace TraktNet.Objects.Post.Syncs.Watchlist
{
    using Get.Movies;

    public interface ITraktSyncWatchlistPostMovie
    {
        string Title { get; set; }

        int? Year { get; set; }

        ITraktMovieIds Ids { get; set; }
    }
}
