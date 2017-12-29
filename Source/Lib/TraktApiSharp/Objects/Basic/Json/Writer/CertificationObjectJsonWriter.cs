namespace TraktApiSharp.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CertificationObjectJsonWriter : AObjectJsonWriter<ITraktCertification>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktCertification obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken);

            if (!string.IsNullOrEmpty(obj.Name))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CERTIFICATION_PROPERTY_NAME_NAME, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Name, cancellationToken);
            }

            if (!string.IsNullOrEmpty(obj.Slug))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CERTIFICATION_PROPERTY_NAME_SLUG, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Slug, cancellationToken);
            }

            if (!string.IsNullOrEmpty(obj.Description))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CERTIFICATION_PROPERTY_NAME_DESCRIPTION, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Description, cancellationToken);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken);
        }
    }
}
