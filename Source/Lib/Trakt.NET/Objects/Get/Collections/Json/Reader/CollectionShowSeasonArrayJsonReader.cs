namespace TraktNet.Objects.Get.Collections.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CollectionShowSeasonArrayJsonReader : ArrayJsonReader<ITraktCollectionShowSeason>
    {
        public override async Task<IEnumerable<ITraktCollectionShowSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCollectionShowSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var collectionShowSeasonObjectReader = new CollectionShowSeasonObjectJsonReader();
                var collectionShowSeasons = new List<ITraktCollectionShowSeason>();
                ITraktCollectionShowSeason collectionShowSeason = await collectionShowSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (collectionShowSeason != null)
                {
                    collectionShowSeasons.Add(collectionShowSeason);
                    collectionShowSeason = await collectionShowSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return collectionShowSeasons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCollectionShowSeason>));
        }
    }
}
