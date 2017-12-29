namespace TraktApiSharp.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CertificationArrayJsonWriter : AArrayJsonWriter<ITraktCertification>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktCertification> objects, CancellationToken cancellationToken = default)
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
