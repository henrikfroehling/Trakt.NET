namespace TraktNet.Objects.Post.Comments
{
    using Exceptions;
    using Get.Episodes;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>An episode comment post.</summary>
    public class TraktEpisodeCommentPost : TraktCommentPost, ITraktEpisodeCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt episode for the episode comment post.
        /// See also <seealso cref="ITraktEpisode" />.
        /// </summary>
        public ITraktEpisode Episode { get; set; }

        public override Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktEpisodeCommentPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktEpisodeCommentPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public override void Validate()
        {
            base.Validate();

            if (Episode == null)
                throw new TraktPostValidationException(nameof(Episode), "Episode must not be null");

            if (Episode.Ids == null)
                throw new TraktPostValidationException(nameof(Episode.Ids), "episode ids must not be null");

            if (!Episode.Ids.HasAnyId)
                throw new TraktPostValidationException("episode ids have no valid id", nameof(Episode.Ids));
        }
    }
}
