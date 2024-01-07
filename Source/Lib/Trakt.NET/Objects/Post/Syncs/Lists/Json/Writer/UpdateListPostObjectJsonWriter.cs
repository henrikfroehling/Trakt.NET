namespace TraktNet.Objects.Post.Syncs.Lists.Json.Writer
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class UpdateListPostObjectJsonWriter : AObjectJsonWriter<ITraktUpdateListPost>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUpdateListPost obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Description)) {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_DESCRIPTION, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Description, cancellationToken).ConfigureAwait(false);
            }

            if (obj.SortBy != null && obj.SortBy != TraktSortBy.Unspecified) {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SORT_BY, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.SortBy.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (obj.SortHow != null && obj.SortHow != TraktSortHow.Unspecified) {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SORT_HOW, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.SortHow.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
