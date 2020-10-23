namespace TraktNet.Objects.Post.Users.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListsReorderPostResponseObjectJsonWriter : AObjectJsonWriter<ITraktUserCustomListsReorderPostResponse>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserCustomListsReorderPostResponse obj, CancellationToken cancellationToken = default)
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

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
