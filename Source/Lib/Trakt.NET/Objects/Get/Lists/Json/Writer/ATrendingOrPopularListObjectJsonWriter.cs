namespace TraktNet.Objects.Get.Lists.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ATrendingOrPopularListObjectJsonWriter<TListObjectType> : AObjectJsonWriter<TListObjectType> where TListObjectType : ITraktTrendingOrPopularList
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, TListObjectType obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);
            await WriteListObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }

        protected virtual async Task WriteListObjectAsync(JsonTextWriter jsonWriter, TListObjectType obj, CancellationToken cancellationToken = default)
        {
            if (obj.LikeCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_LIKE_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.LikeCount, cancellationToken).ConfigureAwait(false);
            }

            if (obj.CommentCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_COMMENT_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CommentCount, cancellationToken).ConfigureAwait(false);
            }

            if (obj.List != null)
            {
                var listObjectWriter = new ListObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_LIST, cancellationToken).ConfigureAwait(false);
                await listObjectWriter.WriteObjectAsync(obj.List, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
