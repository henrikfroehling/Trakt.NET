namespace TraktNet.Objects.Post.Comments.Json.Writer
{
    using Basic.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class ACommentPostObjectJsonWriter<TCommentObjectType> : AObjectJsonWriter<TCommentObjectType> where TCommentObjectType : ITraktCommentPost
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, TCommentObjectType obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Comment))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_COMMENT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Comment).ConfigureAwait(false);
            }

            if (obj.Spoiler.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SPOILER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Spoiler, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Sharing != null)
            {
                var sharingObjectJsonWriter = new SharingObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHARING, cancellationToken).ConfigureAwait(false);
                await sharingObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Sharing, cancellationToken).ConfigureAwait(false);
            }

            await WriteCommentObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }

        protected abstract Task WriteCommentObjectAsync(JsonTextWriter jsonWriter, TCommentObjectType obj, CancellationToken cancellationToken = default);
    }
}
