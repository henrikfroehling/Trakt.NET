namespace TraktNet.Objects.Post.Comments
{
    using Extensions;
    using Objects.Basic;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class TraktCommentPost : ITraktCommentPost
    {
        /// <summary>Gets or sets the required comment's content.</summary>
        public string Comment { get; set; }

        /// <summary>Gets or sets, whether the comment contains spoiler.</summary>
        public bool? Spoiler { get; set; }

        /// <summary>
        /// Gets or sets the sharing options for the comment post.
        /// See also <seealso cref="ITraktConnections" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktConnections Sharing { get; set; }

        public abstract Task<string> ToJson(CancellationToken cancellationToken = default);

        public virtual void Validate()
        {
            if (Comment == null)
                throw new ArgumentNullException(nameof(Comment));

            if (Comment.WordCount() < 5)
                throw new ArgumentOutOfRangeException(nameof(Comment), "comment has too few words - at least five words are required");
        }
    }
}
