namespace TraktNet.Objects.Post.Syncs.Ratings.Responses
{
    using Get.Shows;

    /// <summary>A rated Trakt show, which was not found.</summary>
    public interface ITraktSyncRatingsPostResponseNotFoundShow
    {
        /// <summary>Gets or sets the rating of the not found show.</summary>
        int? Rating { get; set; }

        /// <summary>Gets or sets the ids of the not found show. See also <seealso cref="ITraktShowIds" />.</summary>
        ITraktShowIds Ids { get; set; }
    }
}
