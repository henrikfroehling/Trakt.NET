namespace TraktApiSharp.Objects.Post.Comments.Implementations
{
    using Get.Seasons;
    using System.Net.Http;

    /// <summary>A season comment post.</summary>
    public class TraktSeasonCommentPost : TraktCommentPost, ITraktSeasonCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt season for the season comment post.
        /// See also <seealso cref="ITraktSeason" />.
        /// </summary>
        public ITraktSeason Season { get; set; }

        public override string HttpContentAsString
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        public override HttpContent ToHttpContent() => throw new System.NotImplementedException();

        public override void Validate() => throw new System.NotImplementedException();
    }
}
