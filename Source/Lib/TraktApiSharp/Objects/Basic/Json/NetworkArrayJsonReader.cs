namespace TraktApiSharp.Objects.Basic.Json
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class NetworkArrayJsonReader : IArrayJsonReader<ITraktNetwork>
    {
        public Task<IEnumerable<ITraktNetwork>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktNetwork>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktNetwork>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktNetwork>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktNetwork>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktNetwork>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var networkReader = new NetworkObjectJsonReader();
                //var networkReadingTasks = new List<Task<ITraktNetwork>>();
                var networks = new List<ITraktNetwork>();

                //networkReadingTasks.Add(networkReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktNetwork network = await networkReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (network != null)
                {
                    networks.Add(network);
                    //networkReadingTasks.Add(networkReader.ReadObjectAsync(jsonReader, cancellationToken));
                    network = await networkReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readNetworks = await Task.WhenAll(networkReadingTasks);
                //return (IEnumerable<ITraktNetwork>)readNetworks.GetEnumerator();
                return networks;
            }

            return await Task.FromResult(default(IEnumerable<ITraktNetwork>));
        }
    }
}
