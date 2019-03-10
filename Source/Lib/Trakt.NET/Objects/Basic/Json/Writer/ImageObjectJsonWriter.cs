namespace TraktNet.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ImageObjectJsonWriter : AObjectJsonWriter<ITraktImage>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktImage obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Full))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.IMAGE_PROPERTY_NAME_FULL, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Full, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
