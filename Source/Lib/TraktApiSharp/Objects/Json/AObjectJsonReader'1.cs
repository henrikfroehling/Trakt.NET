namespace TraktApiSharp.Objects.Json
{
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class AObjectJsonReader<TReturnType> : IObjectJsonReader<TReturnType>
    {
        public virtual Task<TReturnType> ReadObjectAsync(string json, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(TReturnType));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public virtual Task<TReturnType> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            if (stream == null)
                return Task.FromResult(default(TReturnType));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public abstract Task<TReturnType> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default);
    }
}
