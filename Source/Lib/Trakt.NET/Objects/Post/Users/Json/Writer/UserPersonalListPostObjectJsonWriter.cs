namespace TraktNet.Objects.Post.Users.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserPersonalListPostObjectJsonWriter : AObjectJsonWriter<ITraktUserPersonalListPost>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserPersonalListPost obj, CancellationToken cancellationToken = default)
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

            if (obj.SortBy != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SORT_BY, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.SortBy.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (obj.SortHow != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SORT_HOW, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.SortHow.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
