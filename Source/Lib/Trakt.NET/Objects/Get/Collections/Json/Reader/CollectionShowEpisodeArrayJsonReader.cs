namespace TraktNet.Objects.Get.Collections.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CollectionShowEpisodeArrayJsonReader : AArrayJsonReader<ITraktCollectionShowEpisode>
    {
        public override async Task<IEnumerable<ITraktCollectionShowEpisode>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCollectionShowEpisode>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var collectionShowEpisodeObjectReader = new CollectionShowEpisodeObjectJsonReader();
                var collectionShowEpisodes = new List<ITraktCollectionShowEpisode>();
                ITraktCollectionShowEpisode collectionShowEpisode = await collectionShowEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (collectionShowEpisode != null)
                {
                    collectionShowEpisodes.Add(collectionShowEpisode);
                    collectionShowEpisode = await collectionShowEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return collectionShowEpisodes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCollectionShowEpisode>));
        }
    }
}
