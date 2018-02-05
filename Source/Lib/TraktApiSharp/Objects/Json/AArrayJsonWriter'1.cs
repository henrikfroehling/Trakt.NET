namespace TraktApiSharp.Objects.Json
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class AArrayJsonWriter<TObjectType> : IArrayJsonWriter<TObjectType>
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

        public abstract Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<TObjectType> objects, CancellationToken cancellationToken = default);
    }
}
