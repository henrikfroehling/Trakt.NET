namespace TraktApiSharp.Objects.Post.Comments.Implementations
{
    using Get.Users.Lists;
    using System.Net.Http;

    /// <summary>A list comment post.</summary>
    public class TraktListCommentPost : TraktCommentPost, ITraktListCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt list for the list comment post.
        /// See also <seealso cref="ITraktList" />.
        /// </summary>
        public ITraktList List { get; set; }

        public override string HttpContentAsString
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        public override HttpContent ToHttpContent() => throw new System.NotImplementedException();

        public override void Validate() => throw new System.NotImplementedException();
    }
}
