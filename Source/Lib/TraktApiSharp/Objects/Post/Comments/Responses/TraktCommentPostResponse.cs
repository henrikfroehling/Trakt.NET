namespace TraktApiSharp.Objects.Post.Comments.Responses
{
    using Basic;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Basic.Implementations;

    /// <summary>Represents a comment post response.</summary>
    public class TraktCommentPostResponse : TraktComment
    {
        /// <summary>
        /// Gets or sets the sharing options of the comment post response.
        /// See also <seealso cref="TraktSharing" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "sharing")]
        public TraktSharing Sharing { get; set; }
    }
}
