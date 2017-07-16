namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses
{
    using Get.Episodes;

    public interface ITraktSyncRatingsPostResponseNotFoundEpisode
    {
        int? Rating { get; set; }

        ITraktEpisodeIds Ids { get; set; }
    }
}
