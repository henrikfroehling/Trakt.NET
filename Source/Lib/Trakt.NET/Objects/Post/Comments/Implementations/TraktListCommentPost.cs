namespace TraktNet.Objects.Post.Comments
{
    using Exceptions;
    using Get.Lists;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>A list comment post.</summary>
    public class TraktListCommentPost : TraktCommentPost, ITraktListCommentPost
    {
        /// <summary>
        /// Gets or sets the required Trakt list for the list comment post.
        /// See also <seealso cref="ITraktList" />.
        /// </summary>
        public ITraktList List { get; set; }

        public override Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktListCommentPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktListCommentPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public override void Validate()
        {
            base.Validate();

            if (List == null)
                throw new TraktPostValidationException(nameof(List), "list must not be null");

            if (List.Ids == null)
                throw new TraktPostValidationException(nameof(List.Ids), "list ids must not be null");

            if (!List.Ids.HasAnyId)
                throw new TraktPostValidationException("list ids have no valid id", nameof(List.Ids));
        }
    }
}
