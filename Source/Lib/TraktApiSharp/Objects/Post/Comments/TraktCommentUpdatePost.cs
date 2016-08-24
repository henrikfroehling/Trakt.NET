namespace TraktApiSharp.Objects.Post.Comments
{
    using Newtonsoft.Json;

    /// <summary>A comment update post.</summary>
    public class TraktCommentUpdatePost
    {
        /// <summary>Gets or sets the required comment's content.</summary>
        [JsonProperty(PropertyName = "comment")]
        public string Comment { get; set; }

        /// <summary>Gets or sets, whether the comment contains spoiler.</summary>
        [JsonProperty(PropertyName = "spoiler")]
        public bool? Spoiler { get; set; }
    }
}
