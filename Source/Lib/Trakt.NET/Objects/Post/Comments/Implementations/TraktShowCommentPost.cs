namespace TraktNet.Objects.Post.Comments
{
    using Exceptions;
    using Get.Shows;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>A show comment post.</summary>
    public class TraktShowCommentPost : TraktCommentPost, ITraktShowCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt show for the show comment post.
        /// See also <seealso cref="ITraktShow" />.
        /// </summary>
        public ITraktShow Show { get; set; }

        public override Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktShowCommentPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktShowCommentPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public override void Validate()
        {
            base.Validate();

            if (Show == null)
                throw new TraktPostValidationException(nameof(Show), "show must not be null");

            if (Show.Ids == null)
                throw new TraktPostValidationException(nameof(Show.Ids), "show ids must not be null");

            if (!Show.Ids.HasAnyId)
                throw new TraktPostValidationException("show ids have no valid id", nameof(Show.Ids));
        }
    }
}
