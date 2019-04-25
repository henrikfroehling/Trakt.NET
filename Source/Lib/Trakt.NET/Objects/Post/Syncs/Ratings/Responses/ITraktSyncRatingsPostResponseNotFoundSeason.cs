namespace TraktNet.Objects.Post.Syncs.Ratings.Responses
{
    using Get.Seasons;

    /// <summary>A rated Trakt season, which was not found.</summary>
    public interface ITraktSyncRatingsPostResponseNotFoundSeason
    {
        /// <summary>Gets or sets the rating of the not found season.</summary>
        int? Rating { get; set; }

        /// <summary>Gets or sets the ids of the not found season. See also <seealso cref="ITraktSeasonIds" />.</summary>
        ITraktSeasonIds Ids { get; set; }
    }
}
