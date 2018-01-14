namespace TraktApiSharp.Objects.Json
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal static class JsonWriterHelper
    {
        internal static async Task WriteStringArrayAsync(JsonTextWriter jsonWriter, IEnumerable<string> values, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartArrayAsync(cancellationToken);

            foreach (string value in values)
            {
                if (!string.IsNullOrEmpty(value))
                    await jsonWriter.WriteValueAsync(value, cancellationToken);
            }

            await jsonWriter.WriteEndArrayAsync(cancellationToken);
        }
    }
}
