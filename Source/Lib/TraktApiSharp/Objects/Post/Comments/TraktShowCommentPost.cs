namespace TraktApiSharp.Objects.Post.Comments
{
    using Get.Shows;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Get.Shows.Implementations;

    /// <summary>A show comment post.</summary>
    public class TraktShowCommentPost : TraktCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt show for the show comment post.
        /// See also <seealso cref="TraktShow" />.
        /// </summary>
        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }
    }
}
