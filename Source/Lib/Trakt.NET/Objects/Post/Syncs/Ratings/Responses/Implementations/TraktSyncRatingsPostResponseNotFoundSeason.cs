namespace TraktNet.Objects.Post.Syncs.Ratings.Responses
{
    using Get.Seasons;

    /// <summary>A rated Trakt season, which was not found.</summary>
    public class TraktSyncRatingsPostResponseNotFoundSeason : ITraktSyncRatingsPostResponseNotFoundSeason
    {
        /// <summary>Gets or sets the rating of the not found season.</summary>
        public int? Rating { get; set; }

        /// <summary>Gets or sets the ids of the not found season. See also <seealso cref="ITraktSeasonIds" />.</summary>
        public ITraktSeasonIds Ids { get; set; }
    }
}
