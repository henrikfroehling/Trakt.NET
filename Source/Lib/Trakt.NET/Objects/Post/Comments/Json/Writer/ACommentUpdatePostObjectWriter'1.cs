namespace TraktNet.Objects.Post.Comments.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ACommentUpdatePostObjectWriter<TCommentObjectType> : AObjectJsonWriter<TCommentObjectType> where TCommentObjectType : ITraktCommentUpdatePost
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, TCommentObjectType obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);
            await WriteCommentObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }

        protected virtual async Task WriteCommentObjectAsync(JsonTextWriter jsonWriter, TCommentObjectType obj, CancellationToken cancellationToken = default)
        {
            if (!string.IsNullOrEmpty(obj.Comment))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.COMMENT_UPDATE_POST_PROPERTY_NAME_COMMENT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Comment, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Spoiler.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.COMMENT_UPDATE_POST_PROPERTY_NAME_SPOILER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Spoiler, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
