namespace TraktNet.Objects.Post.Syncs.Ratings.Responses
{
    using Get.Episodes;

    /// <summary>A rated Trakt episode, which was not found.</summary>
    public interface ITraktSyncRatingsPostResponseNotFoundEpisode
    {
        /// <summary>Gets or sets the rating of the not found episode.</summary>
        int? Rating { get; set; }

        /// <summary>Gets or sets the ids of the not found episode. See also <seealso cref="ITraktEpisodeIds" />.</summary>
        ITraktEpisodeIds Ids { get; set; }
    }
}
