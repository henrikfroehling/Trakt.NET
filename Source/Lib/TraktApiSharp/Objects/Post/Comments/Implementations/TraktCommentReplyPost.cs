namespace TraktApiSharp.Objects.Post.Comments.Implementations
{
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>A comment reply post.</summary>
    public class TraktCommentReplyPost : TraktCommentUpdatePost, ITraktCommentReplyPost
    {
        public override Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktCommentReplyPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktCommentReplyPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }
    }
}
