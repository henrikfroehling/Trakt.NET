namespace TraktNet.Objects.Post.Basic.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Objects.Post.Responses.Json.Writer;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ListItemsReorderPostResponseObjectJsonWriter : AObjectJsonWriter<ITraktListItemsReorderPostResponse>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktListItemsReorderPostResponse obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Updated.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_UPDATED, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Updated.Value, cancellationToken).ConfigureAwait(false);
            }

            if (obj.SkippedIds != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SKIPPED_IDS, cancellationToken).ConfigureAwait(false);
                await JsonWriterHelper.WriteUnsignedIntegerArrayAsync(jsonWriter, obj.SkippedIds, cancellationToken).ConfigureAwait(false);
            }

            if (obj.List != null)
            {
                var postResponseListDataObjectJsonWriter = new PostResponseListDataObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_LIST, cancellationToken);
                await postResponseListDataObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.List, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
