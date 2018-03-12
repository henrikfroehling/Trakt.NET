namespace TraktApiSharp.Objects.Post.Comments.Implementations
{
    using Get.Shows;
    using System.Net.Http;

    /// <summary>A show comment post.</summary>
    public class TraktShowCommentPost : TraktCommentPost, ITraktShowCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt show for the show comment post.
        /// See also <seealso cref="ITraktShow" />.
        /// </summary>
        public ITraktShow Show { get; set; }

        public override string HttpContentAsString
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        public override HttpContent ToHttpContent() => throw new System.NotImplementedException();

        public override void Validate() => throw new System.NotImplementedException();
    }
}
