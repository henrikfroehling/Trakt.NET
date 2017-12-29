namespace TraktApiSharp.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class NetworkArrayJsonWriter : IArrayJsonWriter<ITraktNetwork>
    {
        public Task<string> WriteArrayAsync(IEnumerable<ITraktNetwork> objects, CancellationToken cancellationToken = default)
        {
            using (var writer = new StringWriter())
            {
                return WriteArrayAsync(writer, objects, cancellationToken);
            }
        }

        public async Task<string> WriteArrayAsync(StringWriter writer, IEnumerable<ITraktNetwork> objects, CancellationToken cancellationToken = default)
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

        public async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktNetwork> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var networkObjectJsonWriter = new NetworkObjectJsonWriter();
            await jsonWriter.WriteStartArrayAsync(cancellationToken);

            foreach (ITraktNetwork traktNetwork in objects)
                await networkObjectJsonWriter.WriteObjectAsync(jsonWriter, traktNetwork, cancellationToken);

            await jsonWriter.WriteEndArrayAsync(cancellationToken);
        }
    }
}
