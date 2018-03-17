namespace TraktApiSharp.Objects.Post.Comments.Implementations
{
    using Get.Shows;

    /// <summary>A show comment post.</summary>
    public class TraktShowCommentPost : TraktCommentPost, ITraktShowCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt show for the show comment post.
        /// See also <seealso cref="ITraktShow" />.
        /// </summary>
        public ITraktShow Show { get; set; }

        public override string ToJson() => "";

        public override void Validate()
        {
            // TODO
        }
    }
}
