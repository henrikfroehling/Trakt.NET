namespace TraktNet.Objects.Post.Responses
{
    using Get.Movies;

    /// <summary>A Trakt movie, which was not found.</summary>
    public interface ITraktPostResponseNotFoundMovie
    {
        /// <summary>Gets or sets the ids of the not found movie. See also <seealso cref="ITraktMovieIds" />.</summary>
        ITraktMovieIds Ids { get; set; }
    }
}
