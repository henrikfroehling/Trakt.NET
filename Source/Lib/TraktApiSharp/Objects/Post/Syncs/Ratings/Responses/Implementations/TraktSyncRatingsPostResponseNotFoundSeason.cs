namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses
{
    using Get.Seasons;

    public class TraktSyncRatingsPostResponseNotFoundSeason : ITraktSyncRatingsPostResponseNotFoundSeason
    {
        public int? Rating { get; set; }

        public ITraktSeasonIds Ids { get; set; }
    }
}
