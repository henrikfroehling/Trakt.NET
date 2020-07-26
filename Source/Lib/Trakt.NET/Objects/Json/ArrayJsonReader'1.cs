namespace TraktNet.Objects.Json
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class ArrayJsonReader<TReturnType> : IArrayJsonReader<TReturnType>
    {
        public virtual Task<IEnumerable<TReturnType>> ReadArrayAsync(string json, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<TReturnType>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public virtual Task<IEnumerable<TReturnType>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<TReturnType>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public abstract Task<IEnumerable<TReturnType>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default);

        protected void CheckJsonTextReader(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                throw new ArgumentNullException(nameof(jsonReader));
        }
    }
}
