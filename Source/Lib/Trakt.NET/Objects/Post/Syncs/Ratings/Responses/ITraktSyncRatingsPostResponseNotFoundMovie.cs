namespace TraktNet.Objects.Post.Syncs.Ratings.Responses
{
    using Get.Movies;

    /// <summary>A rated Trakt movie, which was not found.</summary>
    public interface ITraktSyncRatingsPostResponseNotFoundMovie
    {
        /// <summary>Gets or sets the rating of the not found movie.</summary>
        int? Rating { get; set; }

        /// <summary>Gets or sets the ids of the not found movie. See also <seealso cref="ITraktMovieIds" />.</summary>
        ITraktMovieIds Ids { get; set; }
    }
}
