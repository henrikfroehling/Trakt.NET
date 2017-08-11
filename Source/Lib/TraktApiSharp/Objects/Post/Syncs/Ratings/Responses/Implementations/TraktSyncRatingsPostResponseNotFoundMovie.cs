namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Implementations
{
    using Get.Movies;

    public class TraktSyncRatingsPostResponseNotFoundMovie : ITraktSyncRatingsPostResponseNotFoundMovie
    {
        public int? Rating { get; set; }

        public ITraktMovieIds Ids { get; set; }
    }
}
