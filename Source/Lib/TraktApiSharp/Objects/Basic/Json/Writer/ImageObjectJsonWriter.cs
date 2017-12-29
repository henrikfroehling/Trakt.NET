namespace TraktApiSharp.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ImageObjectJsonWriter : AObjectJsonWriter<ITraktImage>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktImage obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken);

            if (!string.IsNullOrEmpty(obj.Full))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.IMAGE_PROPERTY_NAME_FULL, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Full, cancellationToken);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken);
        }
    }
}
