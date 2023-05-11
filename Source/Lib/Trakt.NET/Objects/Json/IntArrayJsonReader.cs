namespace TraktNet.Objects.Json
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class IntArrayJsonReader : IArrayJsonReader<int>
    {
        public Task<IList<int>> ReadArrayAsync(string json, CancellationToken cancellationToken = default)
        {
            CheckJson(json);

            if (json == string.Empty)
                return Task.FromResult(default(IList<int>));

            using var reader = new StringReader(json);
            using var jsonReader = new JsonTextReader(reader);
            return ReadArrayAsync(jsonReader, cancellationToken);
        }

        public Task<IList<int>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            CheckStream(stream);
            using var streamReader = new StreamReader(stream);
            using var jsonReader = new JsonTextReader(streamReader);
            return ReadArrayAsync(jsonReader, cancellationToken);
        }

        public async Task<IList<int>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var values = new List<int>();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.Integer)
                {
                    if (jsonReader.Value != null)
                        values.Add((int)(long)jsonReader.Value); // jsonReader.Value is of type Int64 (long), but we explicitly want the type int
                }

                return values;
            }

            return await Task.FromResult(default(IList<int>));
        }

        private void CheckJson(string json)
        {
            if (json == null)
                throw new ArgumentNullException(nameof(json));
        }

        private void CheckStream(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
        }

        private void CheckJsonTextReader(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                throw new ArgumentNullException(nameof(jsonReader));
        }
    }
}
