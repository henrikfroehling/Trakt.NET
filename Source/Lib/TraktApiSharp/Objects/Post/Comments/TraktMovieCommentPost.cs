namespace TraktApiSharp.Objects.Post.Comments
{
    using Get.Movies;
    using Newtonsoft.Json;

    /// <summary>A movie comment post.</summary>
    public class TraktMovieCommentPost : TraktCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt movie for the movie comment post.
        /// See also <seealso cref="TraktMovie" />.
        /// </summary>
        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }
    }
}
