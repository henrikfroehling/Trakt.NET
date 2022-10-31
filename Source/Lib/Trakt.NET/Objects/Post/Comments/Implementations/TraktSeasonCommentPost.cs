namespace TraktNet.Objects.Post.Comments
{
    using Exceptions;
    using Get.Seasons;
    using Objects.Json;
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

        public override Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktSeasonCommentPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktSeasonCommentPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public override void Validate()
        {
            base.Validate();

            if (Season == null)
                throw new TraktPostValidationException(nameof(Season), "season must not be null");

            if (Season.Ids == null)
                throw new TraktPostValidationException(nameof(Season.Ids), "season ids must not be null");

            if (!Season.Ids.HasAnyId)
                throw new TraktPostValidationException("season ids have no valid id", nameof(Season.Ids));
        }
    }
}
