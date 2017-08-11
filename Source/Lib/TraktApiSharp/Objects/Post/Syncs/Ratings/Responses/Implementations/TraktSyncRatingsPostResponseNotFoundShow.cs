namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Implementations
{
    using Get.Shows;

    public class TraktSyncRatingsPostResponseNotFoundShow : ITraktSyncRatingsPostResponseNotFoundShow
    {
        public int? Rating { get; set; }

        public ITraktShowIds Ids { get; set; }
    }
}
