namespace TraktNet.Objects.Authentication.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class AuthorizationArrayJsonWriter : ArrayJsonWriter<ITraktAuthorization>
    {
        internal bool CompleteSerialization { get; set; }

        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktAuthorization> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var objectJsonWriter = new AuthorizationObjectJsonWriter
            {
                CompleteSerialization = CompleteSerialization
            };

            var writerTasks = new List<Task>();
            await jsonWriter.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);

            foreach (ITraktAuthorization obj in objects)
                writerTasks.Add(objectJsonWriter.WriteObjectAsync(jsonWriter, obj, cancellationToken));

            await Task.WhenAll(writerTasks).ConfigureAwait(false);
            await jsonWriter.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
