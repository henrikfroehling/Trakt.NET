namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Implementations
{
    using Get.Episodes;

    public class TraktSyncRatingsPostResponseNotFoundEpisode : ITraktSyncRatingsPostResponseNotFoundEpisode
    {
        public int? Rating { get; set; }

        public ITraktEpisodeIds Ids { get; set; }
    }
}
