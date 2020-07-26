namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class NetworkArrayJsonReader : ArrayJsonReader<ITraktNetwork>
    {
        public override async Task<IEnumerable<ITraktNetwork>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktNetwork>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var networkReader = new NetworkObjectJsonReader();
                var networks = new List<ITraktNetwork>();
                ITraktNetwork network = await networkReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (network != null)
                {
                    networks.Add(network);
                    network = await networkReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return networks;
            }

            return await Task.FromResult(default(IEnumerable<ITraktNetwork>));
        }
    }
}
