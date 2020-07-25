namespace TraktNet.Objects.Get.Users.Lists.Json.Writer
{
    using Extensions;
    using Get.Users.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ListObjectJsonWriter : AObjectJsonWriter<ITraktList>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktList obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Name))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_NAME, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Name, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Description))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_DESCRIPTION, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Description, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Privacy != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_PRIVACY, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Privacy.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (obj.DisplayNumbers.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_DISPLAY_NUMBERS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.DisplayNumbers, cancellationToken).ConfigureAwait(false);
            }

            if (obj.AllowComments.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_ALLOW_COMMENTS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.AllowComments, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.SortBy))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SORT_BY, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.SortBy, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.SortHow))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SORT_HOW, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.SortHow, cancellationToken).ConfigureAwait(false);
            }

            if (obj.CreatedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_CREATED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CreatedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.UpdatedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_UPDATED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.UpdatedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.ItemCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_ITEM_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.ItemCount, cancellationToken).ConfigureAwait(false);
            }

            if (obj.CommentCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_COMMENT_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CommentCount, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Likes.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_LIKES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Likes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Ids != null)
            {
                var listIdsObjectJsonWriter = new ListIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await listIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ids, cancellationToken).ConfigureAwait(false);
            }

            if (obj.User != null)
            {
                var userObjectJsonWriter = new UserObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_USER, cancellationToken).ConfigureAwait(false);
                await userObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.User, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
