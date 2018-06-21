namespace TraktNet.Objects.Json
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ArrayJsonWriter<TObjectType> : IArrayJsonWriter<TObjectType>
    {
        public virtual Task<string> WriteArrayAsync(IEnumerable<TObjectType> objects, CancellationToken cancellationToken = default)
        {
            using (var writer = new StringWriter())
            {
                return WriteArrayAsync(writer, objects, cancellationToken);
            }
        }

        public virtual async Task<string> WriteArrayAsync(StringWriter writer, IEnumerable<TObjectType> objects, CancellationToken cancellationToken = default)
        {
            if (objects == null)
                throw new ArgumentNullException(nameof(objects));

            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            using (var jsonWriter = new JsonTextWriter(writer))
            {
                await WriteArrayAsync(jsonWriter, objects, cancellationToken).ConfigureAwait(false);
            }

            return writer.ToString();
        }

        public virtual async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<TObjectType> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<TObjectType>();
            var writerTasks = new List<Task>();
            await jsonWriter.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);

            foreach (TObjectType obj in objects)
                writerTasks.Add(objectJsonWriter.WriteObjectAsync(jsonWriter, obj, cancellationToken));

            await Task.WhenAll(writerTasks).ConfigureAwait(false);
            await jsonWriter.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
