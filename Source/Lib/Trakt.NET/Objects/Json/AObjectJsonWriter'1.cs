namespace TraktNet.Objects.Json
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class AObjectJsonWriter<TObjectType> : IObjectJsonWriter<TObjectType>
    {
        public virtual Task<string> WriteObjectAsync(TObjectType obj, CancellationToken cancellationToken = default)
        {
            using var writer = new StringWriter();
            return WriteObjectAsync(writer, obj, cancellationToken);
        }

        public virtual async Task<string> WriteObjectAsync(StringWriter writer, TObjectType obj, CancellationToken cancellationToken = default)
        {
            CheckObject(obj);
            CheckStringWriter(writer);
            using (var jsonWriter = new JsonTextWriter(writer))
            await WriteObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
            return writer.ToString();
        }

        public abstract Task WriteObjectAsync(JsonTextWriter jsonWriter, TObjectType obj, CancellationToken cancellationToken = default);

        protected void CheckObject(TObjectType obj)
        {
            if (EqualityComparer<TObjectType>.Default.Equals(obj, default))
                throw new ArgumentNullException(nameof(obj));
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
