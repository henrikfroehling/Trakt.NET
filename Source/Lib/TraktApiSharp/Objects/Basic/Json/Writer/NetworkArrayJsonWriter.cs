namespace TraktApiSharp.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class NetworkArrayJsonWriter : AArrayJsonWriter<ITraktNetwork>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktNetwork> objects, CancellationToken cancellationToken = default)
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
