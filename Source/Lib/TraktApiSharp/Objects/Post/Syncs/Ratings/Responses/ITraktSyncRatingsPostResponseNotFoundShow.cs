namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses
{
    using Get.Shows;

    public interface ITraktSyncRatingsPostResponseNotFoundShow
    {
        int? Rating { get; set; }

        ITraktShowIds Ids { get; set; }
    }
}
