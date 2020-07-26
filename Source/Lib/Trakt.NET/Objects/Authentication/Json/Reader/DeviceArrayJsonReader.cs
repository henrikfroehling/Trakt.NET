namespace TraktNet.Objects.Authentication.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class DeviceArrayJsonReader : ArrayJsonReader<ITraktDevice>
    {
        public override async Task<IEnumerable<ITraktDevice>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktDevice>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var deviceReader = new DeviceObjectJsonReader();
                var devices = new List<ITraktDevice>();
                ITraktDevice device = await deviceReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (device != null)
                {
                    devices.Add(device);
                    device = await deviceReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return devices;
            }

            return await Task.FromResult(default(IEnumerable<ITraktDevice>));
        }
    }
}
