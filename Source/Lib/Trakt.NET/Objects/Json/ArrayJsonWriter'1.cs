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
        public bool WithIndentation { get; set; }

        public virtual Task<string> WriteArrayAsync(IEnumerable<TObjectType> objects, CancellationToken cancellationToken = default)
        {
            using var writer = new StringWriter();
            return WriteArrayAsync(writer, objects, cancellationToken);
        }

        public virtual async Task<string> WriteArrayAsync(StringWriter writer, IEnumerable<TObjectType> objects, CancellationToken cancellationToken = default)
        {
            CheckObjects(objects);
            CheckStringWriter(writer);
            using (var jsonWriter = new JsonTextWriter(writer))
            await WriteArrayAsync(jsonWriter, objects, cancellationToken).ConfigureAwait(false);
            return writer.ToString();
        }

        public virtual async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<TObjectType> objects, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);

            if (WithIndentation)
            {
                jsonWriter.Formatting = Formatting.Indented;
                jsonWriter.IndentChar = ' ';
                jsonWriter.Indentation = 4;
            }

            var objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<TObjectType>();
            var writerTasks = new List<Task>();
            await jsonWriter.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);

            foreach (TObjectType obj in objects)
                writerTasks.Add(objectJsonWriter.WriteObjectAsync(jsonWriter, obj, cancellationToken));

            await Task.WhenAll(writerTasks).ConfigureAwait(false);
            await jsonWriter.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
        }

        protected void CheckObjects(IEnumerable<TObjectType> objects)
        {
            if (objects == null)
                throw new ArgumentNullException(nameof(objects));
        }

        protected void CheckStringWriter(StringWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));
        }

        protected void CheckJsonTextWriter(JsonTextWriter jsonWriter)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));
        }
    }
}
