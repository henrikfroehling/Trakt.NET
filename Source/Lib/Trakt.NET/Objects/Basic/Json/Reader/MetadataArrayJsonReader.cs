namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MetadataArrayJsonReader : AArrayJsonReader<ITraktMetadata>
    {
        public override async Task<IEnumerable<ITraktMetadata>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMetadata>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var metadataReader = new MetadataObjectJsonReader();
                var metadatas = new List<ITraktMetadata>();
                ITraktMetadata metadata = await metadataReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (metadata != null)
                {
                    metadatas.Add(metadata);
                    metadata = await metadataReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return metadatas;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMetadata>));
        }
    }
}
