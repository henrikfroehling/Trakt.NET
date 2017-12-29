namespace TraktApiSharp.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ErrorObjectJsonWriter : IObjectJsonWriter<ITraktError>
    {
        public Task<string> WriteObjectAsync(ITraktError obj, CancellationToken cancellationToken = default)
        {
            using (var writer = new StringWriter())
            {
                return WriteObjectAsync(writer, obj, cancellationToken);
            }
        }

        public async Task<string> WriteObjectAsync(StringWriter writer, ITraktError obj, CancellationToken cancellationToken = default)
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

        public async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktError obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken);

            if (!string.IsNullOrEmpty(obj.Error))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.ERROR_PROPERTY_NAME_ERROR, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Error, cancellationToken);
            }

            if (!string.IsNullOrEmpty(obj.Description))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.ERROR_PROPERTY_NAME_ERROR_DESCRIPTION, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Description, cancellationToken);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken);
        }
    }
}
