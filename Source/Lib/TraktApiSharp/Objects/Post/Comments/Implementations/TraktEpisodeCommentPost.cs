namespace TraktApiSharp.Objects.Post.Comments.Implementations
{
    using Get.Episodes;
    using System.Net.Http;

    /// <summary>An episode comment post.</summary>
    public class TraktEpisodeCommentPost : TraktCommentPost, ITraktEpisodeCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt episode for the episode comment post.
        /// See also <seealso cref="ITraktEpisode" />.
        /// </summary>
        public ITraktEpisode Episode { get; set; }

        public override string HttpContentAsString
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        public override HttpContent ToHttpContent() => throw new System.NotImplementedException();

        public override void Validate() => throw new System.NotImplementedException();
    }
}
