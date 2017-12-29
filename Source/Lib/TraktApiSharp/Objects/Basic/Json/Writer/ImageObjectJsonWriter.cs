namespace TraktApiSharp.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ImageObjectJsonWriter : IObjectJsonWriter<ITraktImage>
    {
        public Task<string> WriteObjectAsync(ITraktImage obj, CancellationToken cancellationToken = default)
        {
            using (var writer = new StringWriter())
            {
                return WriteObjectAsync(writer, obj, cancellationToken);
            }
        }

        public async Task<string> WriteObjectAsync(StringWriter writer, ITraktImage obj, CancellationToken cancellationToken = default)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            using (var jsonWriter = new JsonTextWriter(writer))
            {
                await WriteObjectAsync(jsonWriter, obj, cancellationToken);
            }

            return writer.ToString();
        }

        public async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktImage obj, CancellationToken cancellationToken = default)
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
