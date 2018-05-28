namespace TraktApiSharp.Objects.Post.Comments.Implementations
{
    using Get.Seasons;
    using Objects.Json;
    using System.Net.Http;
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

        public override HttpContent ToHttpContent()
        {
            throw new System.NotImplementedException();
        }

        public override Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktSeasonCommentPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktSeasonCommentPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public override void Validate()
        {
            // TODO
        }
    }
}
