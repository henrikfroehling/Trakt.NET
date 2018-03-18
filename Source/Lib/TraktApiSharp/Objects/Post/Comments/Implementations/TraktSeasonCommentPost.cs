namespace TraktApiSharp.Objects.Post.Comments.Implementations
{
    using Get.Seasons;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>A season comment post.</summary>
    public class TraktSeasonCommentPost : TraktCommentPost, ITraktSeasonCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt season for the season comment post.
        /// See also <seealso cref="ITraktSeason" />.
        /// </summary>
        public ITraktSeason Season { get; set; }

        public override Task<string> ToJson(CancellationToken cancellationToken = default) => Task.FromResult("");

        public override void Validate()
        {
            // TODO
        }
    }
}
