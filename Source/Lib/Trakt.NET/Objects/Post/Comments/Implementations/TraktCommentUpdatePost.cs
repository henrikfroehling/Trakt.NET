namespace TraktNet.Objects.Post.Comments
{
    using Exceptions;
    using Extensions;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>A comment update post.</summary>
    public class TraktCommentUpdatePost : ITraktCommentUpdatePost
    {
        /// <summary>Gets or sets the required comment's content.</summary>
        public string Comment { get; set; }

        /// <summary>Gets or sets, whether the comment contains spoiler.</summary>
        public bool? Spoiler { get; set; }

        public virtual Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktCommentUpdatePost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktCommentUpdatePost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public virtual void Validate()
        {
            if (Comment == null)
                throw new TraktPostValidationException(nameof(Comment), "comment must not be null");

            if (Comment.WordCount() < 5)
                throw new TraktPostValidationException(nameof(Comment), "comment has too few words - at least five words are required");
        }
    }
}
