namespace TraktApiSharp.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class NetworkArrayJsonReader : AArrayJsonReader<ITraktNetwork>
    {
        public override async Task<IEnumerable<ITraktNetwork>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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
