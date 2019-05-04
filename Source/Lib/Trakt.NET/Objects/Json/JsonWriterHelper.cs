namespace TraktNet.Objects.Json
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

            if (values == null)
                throw new ArgumentNullException(nameof(values));

            var writerTasks = new List<Task>();
            await jsonWriter.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);

            foreach (string value in values)
            {
                if (!string.IsNullOrEmpty(value))
                    writerTasks.Add(jsonWriter.WriteValueAsync(value, cancellationToken));
            }

            await Task.WhenAll(writerTasks).ConfigureAwait(false);
            await jsonWriter.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
        }

        internal static async Task WriteUnsignedLongArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ulong> values, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            if (values == null)
                throw new ArgumentNullException(nameof(values));

            var writerTasks = new List<Task>();
            await jsonWriter.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);

            foreach (ulong value in values)
                writerTasks.Add(jsonWriter.WriteValueAsync(value, cancellationToken));

            await Task.WhenAll(writerTasks).ConfigureAwait(false);
            await jsonWriter.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
        }

        internal static async Task WriteUnsignedIntegerArrayAsync(JsonTextWriter jsonWriter, IEnumerable<uint> values, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            if (values == null)
                throw new ArgumentNullException(nameof(values));

            var writerTasks = new List<Task>();
            await jsonWriter.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);

            foreach (uint value in values)
                writerTasks.Add(jsonWriter.WriteValueAsync(value, cancellationToken));

            await Task.WhenAll(writerTasks).ConfigureAwait(false);
            await jsonWriter.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
        }

        internal static async Task WriteDistributionAsync(JsonTextWriter jsonWriter, IDictionary<string, int> distribution, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            if (distribution == null)
                throw new ArgumentNullException(nameof(distribution));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            for (int i = 1; i <= 10; i++)
            {
                string key = i.ToString();
                await jsonWriter.WritePropertyNameAsync(key, cancellationToken).ConfigureAwait(false);

                if (distribution.TryGetValue(key, out int value))
                {
                    if (value > 0)
                        await jsonWriter.WriteValueAsync(value, cancellationToken).ConfigureAwait(false);
                    else
                        await jsonWriter.WriteValueAsync(0, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    await jsonWriter.WriteValueAsync(0, cancellationToken).ConfigureAwait(false);
                }
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
