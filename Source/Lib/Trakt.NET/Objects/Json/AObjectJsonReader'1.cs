namespace TraktNet.Objects.Json
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class AObjectJsonReader<TReturnType> : IObjectJsonReader<TReturnType>
    {
        public virtual Task<TReturnType> ReadObjectAsync(string json, CancellationToken cancellationToken = default)
        {
            CheckJson(json);

            if (json == string.Empty)
                return Task.FromResult(default(TReturnType));

            using var reader = new StringReader(json);
            using var jsonReader = new JsonTextReader(reader);
            return ReadObjectAsync(jsonReader, cancellationToken);
        }

        public virtual Task<TReturnType> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            CheckStream(stream);
            using var streamReader = new StreamReader(stream);
            using var jsonReader = new JsonTextReader(streamReader);
            return ReadObjectAsync(jsonReader, cancellationToken);
        }

        public abstract Task<TReturnType> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default);

        protected void CheckJson(string json)
        {
            if (json == null)
                throw new ArgumentNullException(nameof(json));
        }

        protected void CheckStream(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
        }

        protected void CheckJsonTextReader(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                throw new ArgumentNullException(nameof(jsonReader));
        }
    }
}
