namespace TraktApiSharp.Objects.Post.Comments.Responses.Implementations
{
    using Basic;
    using Basic.Implementations;
    using Newtonsoft.Json;

    /// <summary>Represents a comment post response.</summary>
    public class TraktCommentPostResponse : TraktComment, ITraktCommentPostResponse
    {
        /// <summary>
        /// Gets or sets the sharing options of the comment post response.
        /// See also <seealso cref="ITraktSharing" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "sharing")]
        public ITraktSharing Sharing { get; set; }
    }
}
