namespace TraktApiSharp.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CertificationArrayJsonWriter : IArrayJsonWriter<ITraktCertification>
    {
        public Task<string> WriteArrayAsync(IEnumerable<ITraktCertification> objects, CancellationToken cancellationToken = default)
        {
            using (var writer = new StringWriter())
            {
                return WriteArrayAsync(writer, objects, cancellationToken);
            }
        }

        public async Task<string> WriteArrayAsync(StringWriter writer, IEnumerable<ITraktCertification> objects, CancellationToken cancellationToken = default)
        {
            if (objects == null)
                throw new ArgumentNullException(nameof(objects));

            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            using (var jsonWriter = new JsonTextWriter(writer))
            {
                await WriteArrayAsync(jsonWriter, objects, cancellationToken);
            }

            return writer.ToString();
        }

        public async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktCertification> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var certificationObjectJsonWriter = new CertificationObjectJsonWriter();
            await jsonWriter.WriteStartArrayAsync(cancellationToken);

            foreach (ITraktCertification traktCertification in objects)
                await certificationObjectJsonWriter.WriteObjectAsync(jsonWriter, traktCertification, cancellationToken);

            await jsonWriter.WriteEndArrayAsync(cancellationToken);
        }
    }
}
