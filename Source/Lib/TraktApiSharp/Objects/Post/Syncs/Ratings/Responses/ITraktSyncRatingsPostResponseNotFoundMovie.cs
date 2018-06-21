namespace TraktNet.Objects.Post.Syncs.Ratings.Responses
{
    using Get.Movies;

    public interface ITraktSyncRatingsPostResponseNotFoundMovie
    {
        int? Rating { get; set; }

        ITraktMovieIds Ids { get; set; }
    }
}
