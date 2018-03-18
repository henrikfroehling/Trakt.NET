namespace TraktApiSharp.Objects.Post.Comments.Implementations
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>A comment update post.</summary>
    public class TraktCommentUpdatePost : ITraktCommentUpdatePost
    {
        /// <summary>Gets or sets the required comment's content.</summary>
        public string Comment { get; set; }

        /// <summary>Gets or sets, whether the comment contains spoiler.</summary>
        public bool? Spoiler { get; set; }

        public virtual Task<string> ToJson(CancellationToken cancellationToken = default) => Task.FromResult("");

        public virtual void Validate()
        {
            // TODO
        }
    }
}
