namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SharingArrayJsonReader : ArrayJsonReader<ITraktSharing>
    {
        public override async Task<IEnumerable<ITraktSharing>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSharing>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var sharingReader = new SharingObjectJsonReader();
                var sharings = new List<ITraktSharing>();
                ITraktSharing sharing = await sharingReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (sharing != null)
                {
                    sharings.Add(sharing);
                    sharing = await sharingReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return sharings;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSharing>));
        }
    }
}
