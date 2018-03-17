namespace TraktApiSharp.Objects.Post.Comments.Implementations
{
    using Get.Users.Lists;

    /// <summary>A list comment post.</summary>
    public class TraktListCommentPost : TraktCommentPost, ITraktListCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt list for the list comment post.
        /// See also <seealso cref="ITraktList" />.
        /// </summary>
        public ITraktList List { get; set; }

        public override string ToJson() => "";

        public override void Validate()
        {
            // TODO
        }
    }
}
