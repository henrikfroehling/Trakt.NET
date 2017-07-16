namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses
{
    using Get.Seasons;

    public interface ITraktSyncRatingsPostResponseNotFoundSeason
    {
        int? Rating { get; set; }

        ITraktSeasonIds Ids { get; set; }
    }
}
