namespace TraktNet.Objects.Post.Syncs.Ratings.Responses
{
    using Get.Shows;

    /// <summary>A rated Trakt show, which was not found.</summary>
    public class TraktSyncRatingsPostResponseNotFoundShow : ITraktSyncRatingsPostResponseNotFoundShow
    {
        /// <summary>Gets or sets the rating of the not found show.</summary>
        public int? Rating { get; set; }

        /// <summary>Gets or sets the ids of the not found show. See also <seealso cref="ITraktShowIds" />.</summary>
        public ITraktShowIds Ids { get; set; }
    }
}
