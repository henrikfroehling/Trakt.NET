namespace TraktNet.Objects.Get.Collections.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CollectionShowSeasonArrayJsonReader : AArrayJsonReader<ITraktCollectionShowSeason>
    {
        public override async Task<IEnumerable<ITraktCollectionShowSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCollectionShowSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var collectionShowSeasonObjectReader = new CollectionShowSeasonObjectJsonReader();
                //var collectionShowSeasonReadingTasks = new List<Task<ITraktCollectionShowSeason>>();
                var collectionShowSeasons = new List<ITraktCollectionShowSeason>();

                //collectionShowSeasonReadingTasks.Add(collectionShowSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktCollectionShowSeason collectionShowSeason = await collectionShowSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (collectionShowSeason != null)
                {
                    collectionShowSeasons.Add(collectionShowSeason);
                    //collectionShowSeasonReadingTasks.Add(collectionShowSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                    collectionShowSeason = await collectionShowSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readCollectionShowSeasons = await Task.WhenAll(collectionShowSeasonReadingTasks);
                //return (IEnumerable<ITraktCollectionShowSeason>)readCollectionShowSeasons.GetEnumerator();
                return collectionShowSeasons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCollectionShowSeason>));
        }
    }
}
