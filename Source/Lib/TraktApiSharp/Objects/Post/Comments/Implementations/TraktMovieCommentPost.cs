namespace TraktApiSharp.Objects.Post.Comments.Implementations
{
    using Get.Movies;

    /// <summary>A movie comment post.</summary>
    public class TraktMovieCommentPost : TraktCommentPost, ITraktMovieCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt movie for the movie comment post.
        /// See also <seealso cref="ITraktMovie" />.
        /// </summary>
        public ITraktMovie Movie { get; set; }

        public override string ToJson() => "";

        public override void Validate()
        {
            // TODO
        }
    }
}
