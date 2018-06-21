namespace TraktNet.Objects.Post.Syncs.Ratings.Responses
{
    using Get.Movies;

    public class TraktSyncRatingsPostResponseNotFoundMovie : ITraktSyncRatingsPostResponseNotFoundMovie
    {
        public int? Rating { get; set; }

        public ITraktMovieIds Ids { get; set; }
    }
}
