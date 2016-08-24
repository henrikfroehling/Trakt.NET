namespace TraktApiSharp.Objects.Post.Comments
{
    using Attributes;
    using Basic;
    using Newtonsoft.Json;

    public abstract class TraktCommentPost
    {
        /// <summary>Gets or sets the required comment's content.</summary>
        [JsonProperty(PropertyName = "comment")]
        public string Comment { get; set; }

        /// <summary>Gets or sets, whether the comment contains spoiler.</summary>
        [JsonProperty(PropertyName = "spoiler")]
        public bool? Spoiler { get; set; }

        /// <summary>
        /// Gets or sets the sharing options for the comment post.
        /// See also <seealso cref="TraktSharing" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "sharing")]
        [Nullable]
        public TraktSharing Sharing { get; set; }
    }
}
