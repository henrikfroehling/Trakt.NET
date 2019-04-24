namespace TraktNet.Objects.Post.Comments
{
    using Get.Movies;

    /// <summary>A movie comment post.</summary>
    public interface ITraktMovieCommentPost : ITraktCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt movie for the movie comment post.
        /// See also <seealso cref="ITraktMovie" />.
        /// </summary>
        ITraktMovie Movie { get; set; }
    }
}
