namespace TraktApiSharp.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ErrorObjectJsonWriter : AObjectJsonWriter<ITraktError>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktError obj, CancellationToken cancellationToken = default)
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
