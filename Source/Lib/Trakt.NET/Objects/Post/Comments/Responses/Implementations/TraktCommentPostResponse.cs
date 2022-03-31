namespace TraktNet.Objects.Post.Comments.Responses
{
    using Objects.Basic;

    /// <summary>Represents a comment post response.</summary>
    public class TraktCommentPostResponse : TraktComment, ITraktCommentPostResponse
    {
        /// <summary>
        /// Gets or sets the sharing options of the comment post response.
        /// See also <seealso cref="ITraktSharing" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSharing Sharing { get; set; }
    }
}
