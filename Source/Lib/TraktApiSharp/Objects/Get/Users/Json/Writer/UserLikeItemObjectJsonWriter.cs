namespace TraktApiSharp.Objects.Get.Users.Json.Writer
{
    using Basic.Json.Writer;
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Users.Lists.Json.Writer;

    internal class UserLikeItemObjectJsonWriter : AObjectJsonWriter<ITraktUserLikeItem>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserLikeItem obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.LikedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_LIKE_ITEM_PROPERTY_NAME_LIKED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.LikedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Type != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_LIKE_ITEM_PROPERTY_NAME_TYPE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Type.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Comment != null)
            {
                var commentObjectJsonWriter = new CommentObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_LIKE_ITEM_PROPERTY_NAME_COMMENT, cancellationToken).ConfigureAwait(false);
                await commentObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Comment, cancellationToken).ConfigureAwait(false);
            }

            if (obj.List != null)
            {
                var listObjectJsonWriter = new ListObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_LIKE_ITEM_PROPERTY_NAME_LIST, cancellationToken).ConfigureAwait(false);
                await listObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.List, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
