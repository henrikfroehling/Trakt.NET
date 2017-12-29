namespace TraktApiSharp.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CertificationsObjectJsonWriter : IObjectJsonWriter<ITraktCertifications>
    {
        public Task<string> WriteObjectAsync(ITraktCertifications obj, CancellationToken cancellationToken = default)
        {
            using (var writer = new StringWriter())
            {
                return WriteObjectAsync(writer, obj, cancellationToken);
            }
        }

        public async Task<string> WriteObjectAsync(StringWriter writer, ITraktCertifications obj, CancellationToken cancellationToken = default)
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

        public async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktCertifications obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken);

            if (obj.US != null)
            {
                var certificationArrayJsonWriter = new CertificationArrayJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CERTIFICATIONS_PROPERTY_NAME_US, cancellationToken);
                await certificationArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.US, cancellationToken);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken);
        }
    }
}
