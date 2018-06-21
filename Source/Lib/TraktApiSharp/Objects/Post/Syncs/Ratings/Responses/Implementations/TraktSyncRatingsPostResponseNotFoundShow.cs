namespace TraktNet.Objects.Post.Syncs.Ratings.Responses
{
    using Get.Shows;

    public class TraktSyncRatingsPostResponseNotFoundShow : ITraktSyncRatingsPostResponseNotFoundShow
    {
        public int? Rating { get; set; }

        public ITraktShowIds Ids { get; set; }
    }
}
