namespace TraktNet.Objects.Post.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ListItemUpdatePostObjectJsonWriter : AObjectJsonWriter<ITraktListItemUpdatePost>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktListItemUpdatePost obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_NOTES, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.Notes, cancellationToken).ConfigureAwait(false);

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
