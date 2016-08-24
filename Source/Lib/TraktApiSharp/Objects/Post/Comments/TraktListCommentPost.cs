namespace TraktApiSharp.Objects.Post.Comments
{
    using Get.Users.Lists;
    using Newtonsoft.Json;

    /// <summary>A list comment post.</summary>
    public class TraktListCommentPost : TraktCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt list for the list comment post.
        /// See also <seealso cref="TraktList" />.
        /// </summary>
        [JsonProperty(PropertyName = "list")]
        public TraktList List { get; set; }
    }
}
